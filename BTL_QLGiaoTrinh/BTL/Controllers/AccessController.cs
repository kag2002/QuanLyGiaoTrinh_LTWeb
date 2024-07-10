using BTL.Controllers;
using BTL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NToastNotify;

namespace BTH1.Controllers
{
    
    public class AccessController : Controller
    {
        public static string check;
        QuanLyGiaoTrinhContext db = new QuanLyGiaoTrinhContext();

        private readonly IToastNotification _toastNotification;
        public AccessController( IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserName" ) == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public IActionResult Login(ThuThu user)
        { 
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var obj = db.ThuThus.Where(x => x.Username == user.Username && x.MatKhau == user.MatKhau).FirstOrDefault();
                if(obj != null)
                {
                    if(obj.Quyen.ToString() == "0")
                    {
                        HttpContext.Session.SetString("UserName", obj.Username.ToString());
                        HttpContext.Session.SetString("Quyen", obj.Quyen.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                    else if(obj.Quyen.ToString() == "1")
                    {
                        HttpContext.Session.SetString("UserName", obj.Username.ToString());
                        HttpContext.Session.SetString("Quyen", obj.Quyen.ToString());
                        return RedirectToAction("HomeAdmin", "Admin");
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("Đăng nhập thất bại.");
                        return RedirectToAction("HomeAdmin", "Admin");
                    }

                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Đăng nhập thất bại.");
                    return RedirectToAction("Login", "Access");
                }
        
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }
    }
}
