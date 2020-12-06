using System.Web.Mvc;
using System.Linq;
using Pusula.ViewModel;
using JWT.Builder;
using JWT.Algorithms;
using System;

namespace Pusula.Controllers
{
    public class HomeController : Controller
    {
        Data.PusulaDB db = new Data.PusulaDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BenimUlkem()
        {
            return View();
        }
        public ActionResult UlkelerListesi(int id = 0)
        {
            return View();
        }
        public ActionResult Uyelik()
        {
            return View();
        }
        public ActionResult Signout()
        {
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Uyelik");
        }
        [HttpPost]

        public ActionResult Uyelik([Bind(Include = "UserName,Password")] MemberhipViewModel membershipViewModel, string durum)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(a => a.UserName == membershipViewModel.UserName && a.Password == membershipViewModel.Password).FirstOrDefault();
                string token = Helper.General.GenerateToken();
                if (durum == "girisyap")
                {
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Geçersiz Kullanıcı Adı veya Şifre Yazdınız");
                    }
                    else
                    {
                        user.Token = token;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        Response.Cookies["token"].Value = token;
                        Response.Cookies["token"].Expires = DateTime.Now.AddMinutes(120);
                        ViewBag.token = token;
                    }
                }
                if (durum == "kayitol")
                {
                    if (user == null)
                    {
                        Data.User regUser = new Data.User();
                        regUser.UserName = membershipViewModel.UserName;
                        regUser.Password = membershipViewModel.Password;
                        regUser.Gold = 20;
                        regUser.Token = token;
                        db.Users.Add(regUser);
                        db.SaveChanges();
                        Response.Cookies["token"].Value = token;
                        Response.Cookies["token"].Expires = DateTime.Now.AddMinutes(120);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Belirlediğiniz Kullanıcı Adı Daha Önce Kullanılmıştır!");
                    }
                }
            }
            return View();
        }
    }
}