using Application.Dto;
using Application.Interfaces;
using Application.Visitor;
using Domain.Visitors;
using Microsoft.AspNetCore.Mvc.Filters;
using UAParser;

namespace Website.Endpoint2.Utilitis.Filters
{
    public class SaveVisitorFilter : IActionFilter
    {
        private readonly ISaveVisitorInfoService _saveVisitorInfoService;
        public SaveVisitorFilter(ISaveVisitorInfoService saveVisitorInfoService)
        {
            _saveVisitorInfoService = saveVisitorInfoService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string ip=context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var actionName=((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName=((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgent);  
            var refer = context.HttpContext.Request.Headers["Reffer"].ToString();
            var currentUrl = context.HttpContext.Request.Path;
            var Request=context.HttpContext.Request;
            string visitorId = context.HttpContext.Request.Cookies["VisitorId"];

            _saveVisitorInfoService.Execute(new RequestSaveVisitorInfoDto
            {
                CurrentLink = currentUrl,
                Ip = ip,
                Method=Request.Method,
                Protocol=Request.Protocol,
                PhysicalPath=$"{controllerName}/{actionName}",
                RefferLink=refer,
                VisitorId=visitorId,
                OperationSystem =new VisitorVersionDto()
                {
                    Family=clientInfo.OS.Family,
                    Version=$"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.PatchMinor}"

                },
                Browser =new VisitorVersionDto
                {
                    Family=clientInfo.UA.Family,
                    Version=$"{clientInfo.UA.Major }.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}"
                },
                
                Device=new DeviceDto
                {
                    Brand=clientInfo.Device.Brand,  
                    Family=clientInfo.Device.Family,    
                    IsSpider=clientInfo.Device.IsSpider,    
                    Model=clientInfo.Device.Model

                }

            });
        }

    }
    
}
