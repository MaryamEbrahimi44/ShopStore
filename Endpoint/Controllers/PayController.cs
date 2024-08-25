using Application.Interfaces;
using Dto.Payment;
using Dto.Response.Payment;
using Endpoint.Utilitis;
using Microsoft.AspNetCore.Mvc;
using ZarinPal.Class;
using static MongoDB.Driver.WriteConcern;

namespace Endpoint.Controllers
{
    public class PayController : Controller
    {
        
        private readonly IConfiguration configuration;
        private readonly IPaymentService paymentService;

        private readonly string merchentId;


        //کلاس های زرین پال
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;

        public PayController(IConfiguration configuration,IPaymentService paymentService) 
        {
            this.configuration = configuration;
            this.paymentService = paymentService;

            merchentId = configuration["ZarinpalMerchentId"];

            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index(Guid PaymentId)
        {
            var payment=paymentService.GetPayment(PaymentId);
            if (payment == null)
            {
                return NotFound();
            }
            string userId=ClaimUtility.GetUserId(User);
            if (userId != payment.UserId)
            {
                return BadRequest();
            }
            string callbackUrl=Url.Action(nameof(Verify),"Pay",new { payment.Id },protocol:Request.Scheme);

            var resultZarinpalRequest = await _payment.Request(new DtoRequest(){
                Amount = payment.Amount,
                    CallbackUrl=callbackUrl,
                    Description=payment.Description,
                    Email=payment.Email,
                    MerchantId=merchentId,
                    Mobile=payment.PhoneNumber
            },Payment.Mode.zarinpal
            );
             

            return Redirect($"---");
        }
        public IActionResult Verify(Guid Id,string Authority)
        { 
            string status=HttpContext.Request.Query["status"];
            if (status != "" && status.ToString().ToLower()=="ok" && Authority != "")
            {
                var payment=paymentService.GetPayment(Id);
                if (payment == null)
                {
                    return NotFound();
                }
                var verification=_payment.Verification(new DtoVerification
                {
                    Amount = payment.Amount,
                    Authority=Authority,
                    MerchantId=merchentId
                },Payment.Mode.zarinpal).Result;
                if (verification.Status == 100)
                { 
                    bool verifyResult=paymentService.VerifyPayment(Id, Authority,verification.RefId);
                    if (verifyResult)
                    { 
                        return Redirect("/customers/orders");
                    }
                    else
                    {
                        TempData["message"] = "پرداخت انجام شد اما ثبت نشد.";
                        return RedirectToAction("checkout", "basket");
                    }
                }
                else
                {
                    TempData["message"] = "پرداخت انجام نشد.لطفا دوباره تلاش کنید و درصورت بروز مشکل با پشتیبانی تماس حاصل فرمایید";
                    return RedirectToAction("checkout", "basket");
                }
                
            }
            TempData["message"] = "پرداخت شما ناموفق بوده است.";
            return RedirectToAction("checkout", "basket");
        }
    }
}
