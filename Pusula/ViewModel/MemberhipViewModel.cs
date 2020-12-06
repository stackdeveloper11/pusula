using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pusula.ViewModel
{
    public class MemberhipViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Gerekli!")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre Gerekli!")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
    }
}