using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcDemo.Controllers
{
    public class LoginController : Controller
    {
        private 客戶聯絡人Repository db = RepositoryHelper.Get客戶聯絡人Repository();
        // GET: LoginModel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Login LoginData)
        {
            var MyResult = db.Where(m => m.客戶資料.客戶名稱 == LoginData.UserName);
            if (MyResult != null && MyResult.Count()  > 0)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    LoginData.UserName + "Cookie",
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    true,
                    LoginData.UserName,
                    FormsAuthentication.FormsCookiePath);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                FormsAuthentication.RedirectFromLoginPage(LoginData.UserName, false);
                return RedirectToAction("Index", "Home");
                //return Content("OK");
            }
            return Content("NO");
        }
    }
}