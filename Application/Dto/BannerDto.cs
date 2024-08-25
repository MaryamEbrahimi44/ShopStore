using Domain.Banners;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class BannerDto
    {
        [Display(Name = "نام بنر")]
        public string Name { get; set; }
        [Display(Name = "تصویر بنر")]
        public string Image { get; set; }
        [Display(Name = "لینک")]
        public string Link { get; set; }
        [Display(Name = "فعال")]
        public bool IsActive { get; set; }
        [Display(Name = "موقعیت نمایش")]
        public Position Position { get; set; }
        [Display(Name = "ترتیب نمایش")]
        public int Priority { get; set; }
    }
}
