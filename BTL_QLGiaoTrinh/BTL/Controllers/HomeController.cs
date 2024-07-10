using BTL.Models;
using BTL.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using X.PagedList;

namespace BTL.Controllers
{
    public class HomeController : Controller
    {
        QuanLyGiaoTrinhContext db  = new QuanLyGiaoTrinhContext();
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification _toastNotification;
        public HomeController(ILogger<HomeController> logger, IToastNotification toastNotification)
        {
            _logger = logger;
            _toastNotification = toastNotification;
        }
        [Authenication]
        public IActionResult Index(int? page)
        {
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            int pageSize = 6;
            var lstgt = db.DmgiaoTrinhs.AsNoTracking().OrderBy(x => x.TenGt);
            PagedList<DmgiaoTrinh> lst = new PagedList<DmgiaoTrinh>(lstgt, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ErrorLayout()
        {
            return View();
        }
        [Authenication]
        public IActionResult TraGiaoTrinh()
        {
            var lstGt = db.HoSoTras.AsNoTracking().OrderBy(x => x.MaHstra).ToList();
            return View(lstGt);
        }
        [Route("GiaoTrinhChuaTra/{ma}")]
        public IActionResult GiaoTrinhChuaTra(string ma, string matra)
        {
            var sp = db.ChiTietHsmuons.Where(x => x.MaHsm == ma && x.ChuaTra == "true").ToList();
            var anh = new List<DmgiaoTrinh>();
            foreach (var t in sp)
            {
                var b = new DmgiaoTrinh();
                b = db.DmgiaoTrinhs.SingleOrDefault((x) => x.MaGt == t.MaGt );
                anh.Add(b);
        
            }
            ViewBag.mahsm = ma;
            ViewBag.matra = matra;
            return View(anh);
        }
        [Authenication]
        public IActionResult ChiTietTraGiaoTrinh()
        {
            var lstGt = db.ChiTietHstras.AsNoTracking().OrderBy(x => x.MaHstra).ToList();
            return View(lstGt);
        }
        [Route("NutTraGiaoTrinh")]
        public IActionResult NutTraGiaoTrinh(string mahstra,string magt)
        {
            var sp = db.ChiTietHstras.SingleOrDefault(x => x.MaHstra == mahstra && x.MaGt == magt);
            return View(sp);
        }
        [Route("NutTraGiaoTrinh")]
        [HttpPost]
        public IActionResult NutTraGiaoTrinh(ChiTietHstra hoso)
        {
            db.ChiTietHstras.Add(hoso);
            var giaotrinh = db.DmgiaoTrinhs.Find(hoso.MaGt);
            if(giaotrinh.SoLuongGt > 0)
            {
                giaotrinh.SoLuongGt = giaotrinh.SoLuongGt - 1;
            }
            var mahstra = db.HoSoTras.Find(hoso.MaHstra);
            var check = db.ChiTietHsmuons.SingleOrDefault(x => x.MaHsm == mahstra.MaHsm && x.MaGt == hoso.MaGt);
            check.ChuaTra = "false";
            var themuon = db.Hsmuons.SingleOrDefault(x => x.MaHsm == mahstra.MaHsm);
            var slthemuon = db.TheMuons.SingleOrDefault(x => x.MaThe == themuon.MaThe);
            if (slthemuon.Slmuon > 0)
            {
                slthemuon.Slmuon = slthemuon.Slmuon - 1;
            }
            db.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Đã trả giáo trình.");
            return RedirectToAction("TraGiaoTrinh");
        }
        [Authenication]
        [Route("ThemChiTietHoSoTra")]
        public IActionResult ThemChiTietHoSoTra(string mahstra, string mahsm)
        {
           var spedit = db.ChiTietHstras.SingleOrDefault(x => x.MaHstra == mahstra);
           List<ChiTietHsmuon> lstsp = db.ChiTietHsmuons.Where(x => x.ChuaTra == "true" && x.MaHsm == mahsm).AsNoTracking().ToList();
           ViewBag.MaGt = new SelectList(lstsp, "MaGt", "MaGt");
            ViewBag.MaViPham = new SelectList(db.ViPhams.ToList(), "MaViPham", "MaViPham");
            ViewBag.MaPhat = new SelectList(db.Phats.ToList(), "MaPhat", "MaPhat");
            return View(spedit);
        }
        [ValidateAntiForgeryToken]
        [Route("ThemChiTietHoSoTra")]
        [HttpPost]
        public IActionResult ThemChiTietHoSoTra(ChiTietHstra hoso)
        {
          
            db.ChiTietHstras.Add(hoso);
            var giaotrinh = db.DmgiaoTrinhs.Find(hoso.MaGt);
            giaotrinh.SoLuongGt = giaotrinh.SoLuongGt - 1;
            db.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Đã thêm thành công hồ sơ.");
            return RedirectToAction("TraGiaoTrinh");
           
        }
        [Authenication]
        [Route("ThemHoSoTra")]
        public IActionResult ThemHoSoTra()
        {
      
            ViewBag.MaHsm = new SelectList(db.Hsmuons.ToList(), "MaHsm", "MaHsm");
            List<ChiTietHsmuon> fundList = db.ChiTietHsmuons.ToList();
            ViewBag.Funds = fundList;
            //List<ChiTietHsmuon> lstsp = db.ChiTietHsmuons.Where(x => x.ChuaTra == "true" && x.MaHsm == ViewBag.MaHsm).AsNoTracking().ToList();
            ViewBag.MaThuThu = new SelectList(db.ThuThus.ToList(), "MaThuThu", "MaThuThu");
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("ThemHoSoTra")]
        [HttpPost]
        public IActionResult ThemHoSoTra(HoSoTra hoso)
        {
            if (ModelState.IsValid)
            {
                db.HoSoTras.Add(hoso);
                db.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Đã thêm hồ sơ trả.");
                return RedirectToAction("TraGiaoTrinh");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Đã xảy ra lỗi.");

            }
            return View(hoso);
        }
        [Authenication]
        [Route("SuaHoSoTra")]
        public IActionResult SuaHoSoTra(string ma)
        {
            var spedit = db.HoSoTras.SingleOrDefault(x => x.MaHstra == ma);
            ViewBag.MaThuThu = new SelectList(db.ThuThus.ToList(), "MaThuThu", "MaThuThu");

            return View(spedit);
        }

        [Route("SuaHoSoTra")]
        [HttpPost]
        public IActionResult SuaHoSoTra(HoSoTra hoso)
        {

            if (ModelState.IsValid)
            {
                db.Entry(hoso).State = EntityState.Modified;
                db.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Đã cập nhật hồ sơ trả.");
                return RedirectToAction("TraGiaoTrinh");

            }
            else
            {
                _toastNotification.AddErrorToastMessage("Xảy ra lỗi.");
            }
            
            return View(hoso);
        }
        [Authenication]
        [Route("SuaChiTietHoSoTra")]
        public IActionResult SuaChiTietHoSoTra(string ma)
        {
            var spedit = db.ChiTietHstras.SingleOrDefault(x => x.MaHstra == ma);
            ViewBag.MaViPham = new SelectList(db.ViPhams.ToList(), "MaViPham", "MaViPham");
            ViewBag.MaPhat = new SelectList(db.Phats.ToList(), "MaPhat", "MaPhat");
            return View(spedit);
        }

        [Route("SuaChiTietHoSoTra")]
        [HttpPost]
        public IActionResult SuaChiTietHoSoTra(ChiTietHstra hoso)
        {

            if (ModelState.IsValid)
            {
                db.Entry(hoso).State = EntityState.Modified;
                db.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Đã cập nhật hồ sơ trả.");
                return RedirectToAction("TraGiaoTrinh");
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Xảy ra lỗi.");
            }
            return View(hoso);
        }
        [Authenication]
        [Route("XoaChiTietHoSoTra")]
        public IActionResult XoaChiTietHoSoTra(string ma, string magt)
        {
            
            db.Remove(db.ChiTietHstras.Find(ma,magt));
            db.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Đã xóa hồ sơ.");
            return RedirectToAction("ChiTietTraGiaoTrinh");
        }

        [Route("XoaHoSoTra")]
        public IActionResult XoaHoSoTra(string ma)
        {
            var listChiTiet = db.ChiTietHstras.Where(x => x.MaHstra == ma);
            
            if (listChiTiet != null) db.RemoveRange(listChiTiet);
            db.Remove(db.HoSoTras.Find(ma));
            db.SaveChanges();
            _toastNotification.AddSuccessToastMessage("Đã xóa hồ sơ.");
            return RedirectToAction("TraGiaoTrinh");
        }
        public IActionResult GTDetail(String magt, int? page)
        {
            int pageNumber = page == null || page <= 0 ? 1 : page.Value;
            int pageSize = 3;
            var sanpham = db.ChiTietHsmuons.AsNoTracking().Where(x => x.MaHsm == magt).ToList();
            IList<DmgiaoTrinh> products = new List<DmgiaoTrinh>();
            foreach (var s in sanpham)
            {
                DmgiaoTrinh sp = db.DmgiaoTrinhs.SingleOrDefault(x => x.MaGt == s.MaGt);
                products.Add(sp);
            }
            PagedList<DmgiaoTrinh> lst = new PagedList<DmgiaoTrinh>(products, pageNumber, pageSize);
            ViewBag.Mahsm = magt;
            return View(lst);
        }

        [Authenication]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Hosomuon(int page = 1)
        {
            int pageNumber = page;
            int pageSize = 6;
            var lstgt = db.Hsmuons.AsNoTracking().OrderBy(x => x.MaHsm);
            PagedList<Hsmuon> lst = new PagedList<Hsmuon>(lstgt, pageNumber, pageSize);
            return View(lst);

        }
        [Authenication]
        [Route("themhosomuon")]
        public IActionResult themhosomuon()
        {
            ViewBag.MaThe = new SelectList(db.TheMuons.ToList(), "MaThe", "MaThe");
            ViewBag.MaThuThu = new SelectList(db.ThuThus.ToList(), "MaThuThu", "MaThuThu");
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("themhosomuon")]
        [HttpPost]
        public IActionResult themhosomuon(Hsmuon sanPham)
        {
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
                db.Hsmuons.Add(sanPham);
                db.SaveChanges();
                TempData["Message"] = "Thêm hồ sơ thành công";
                return RedirectToAction("Hosomuon");
            }
            return View(sanPham);
        }
        [Authenication]
        [Route("themgtmuon")]
        public IActionResult themgtmuon(String magt)
        {
            ViewBag.MaHsm = new SelectList(db.Hsmuons.Where(x => x.MaHsm == magt).ToList(), "MaHsm", "MaHsm");
            var sanpham = db.ChiTietHsmuons.AsNoTracking().Where(x => x.MaHsm == magt).ToList();
            var list = db.DmgiaoTrinhs.ToList();
            List<DmgiaoTrinh> products = new List<DmgiaoTrinh>();
            foreach (var s in sanpham)
            {
                DmgiaoTrinh sp = db.DmgiaoTrinhs.SingleOrDefault(x => x.MaGt == s.MaGt);
                list.Remove(sp);
            }
            ViewBag.MaGt = new SelectList(list, "MaGt", "MaGt");
            ViewBag.Mahsm1 = magt;
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("themgtmuon")]
        [HttpPost]
        public IActionResult themgtmuon(ChiTietHsmuon sanPham)
        {
            TempData["Message"] = "";
            var sp = db.DmgiaoTrinhs.Where(x => x.MaGt == sanPham.MaGt).SingleOrDefault();
            sp.SoLuongGt--;
            var the = db.TheMuons.Where(x => x.MaThe == db.Hsmuons.Where(x => x.MaHsm == sanPham.MaHsm).SingleOrDefault().MaThe).SingleOrDefault();
            the.Slmuon++;
            db.Entry(sp).State = EntityState.Modified;
            db.Entry(the).State = EntityState.Modified;
            db.ChiTietHsmuons.Add(sanPham);
            db.SaveChanges();
            TempData["Message"] = "Thêm giáo trình thành công";
            return RedirectToAction("GTDetail", new { magt = sanPham.MaHsm });
        }
        [Route("suahs")]

        public IActionResult suahs(string mahsm)
        {
            var spedit = db.Hsmuons.SingleOrDefault(x => x.MaHsm == mahsm);
            ViewBag.MaThe = new SelectList(db.TheMuons.Where(x => x.MaThe == spedit.MaThe).ToList(), "MaThe", "MaThe");
            ViewBag.MaThuThu = new SelectList(db.ThuThus.ToList(), "MaThuThu", "MaThuThu");
            return View(spedit);
        }

        [Route("suahs")]
        [HttpPost]
        public IActionResult suahs(Hsmuon sanPham)
        {

            TempData["Message"] = "";
            if (ModelState.IsValid)
            {


                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Sửa hồ sơ thành công";
                return RedirectToAction("Hosomuon");
            }
            return View(sanPham);
        }
        [Route("XoaGT")]
        [HttpGet]
        public IActionResult XoaGT(string mahsm, string magiaotrinh)
        {
            TempData["Message"] = "";
            ChiTietHsmuon hsm = db.ChiTietHsmuons.Where(x => x.MaHsm == mahsm && x.MaGt == magiaotrinh).SingleOrDefault();
            var sp = db.DmgiaoTrinhs.Where(x => x.MaGt == magiaotrinh).SingleOrDefault();
            sp.SoLuongGt++;
            var the = db.TheMuons.Where(x => x.MaThe == db.Hsmuons.Where(x => x.MaHsm == mahsm).SingleOrDefault().MaThe).SingleOrDefault();
            the.Slmuon--;
            db.Entry(sp).State = EntityState.Modified;
            db.Entry(the).State = EntityState.Modified;
            db.ChiTietHsmuons.Remove(hsm);
            db.SaveChanges();
            TempData["Message"] = "Xóa giáo trình thành công";
            return RedirectToAction("GTDetail", new { magt = mahsm });
        }
        [Route("XoaHS")]
        [HttpGet]
        public IActionResult XoaHS(string mahsm)
        {
            TempData["Message"] = "";
            var lstchitiet = db.ChiTietHsmuons.Where(x => x.MaHsm == mahsm);
            var lst = db.ChiTietHsmuons.Where(x => x.MaHsm == mahsm).ToList();
            if (lstchitiet != null)
            {
                db.RemoveRange(lstchitiet);
                foreach (ChiTietHsmuon s in lst)
                {
                    var sp = db.DmgiaoTrinhs.Where(x => x.MaGt == s.MaGt).SingleOrDefault();
                    sp.SoLuongGt++;
                    var the = db.TheMuons.Where(x => x.MaThe == db.Hsmuons.Where(x => x.MaHsm == s.MaHsm).SingleOrDefault().MaThe).SingleOrDefault();
                    the.Slmuon--;
                    db.Entry(sp).State = EntityState.Modified;
                    db.Entry(the).State = EntityState.Modified;
                }
            }
            db.Remove(db.Hsmuons.Find(mahsm));
            db.SaveChanges();
            TempData["Message"] = "Xóa hồ sơ thành công";
            return RedirectToAction("Hosomuon");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}