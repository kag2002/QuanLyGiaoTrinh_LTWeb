using BTL.Models;
using BTL.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using X.PagedList;

namespace BTH1.Areas.Admin.Controllers
{

    [Area("admin")]


    [Route("admin/homeadmin")]
    public class HomeAdmin : Controller
    {
        QuanLyGiaoTrinhContext db = new QuanLyGiaoTrinhContext();

        [Route("")]
        [Route("index")]
        [Authenication]
        [AuthenicationQuyen]

        public IActionResult Index()
        {
            var soluonggt = db.DmgiaoTrinhs.Count().ToString();
            var banmuon = db.Hsmuons.Count().ToString();
            var bantra = db.HoSoTras.Count().ToString();
            ViewBag.soluonggiaotrinh = soluonggt;
            ViewBag.banmuon = banmuon;
            ViewBag.bantra = bantra;
            return View();
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("danhsachsanpham")]
        public IActionResult DanhSachSanPham(int page = 1)
        {
            int pageNumber = page;
            int pageSize = 12;
            var lstsanpham = db.TacGia.AsNoTracking().OrderBy(x => x.MaTacGia);
            PagedList<TacGium> lst = new PagedList<TacGium>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaKhoa = new SelectList(db.Khoas.ToList(), "MaKhoa", "TenKhoa");
            ViewBag.MaTrinhDo = new SelectList(db.TrinhDos.ToList(), "MaTrinhDo", "TenTrinhDo");

            return View();
        }


        [Route("ThemSanPhamMoi")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ThemSanPhamMoi(TacGium sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TacGia.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham");
            }
            return View(sanPham);
        }

        [Authenication]
        [AuthenicationQuyen]
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            var sanPham = db.TacGia.Find(maSanPham);
            ViewBag.MaKhoa = new SelectList(db.Khoas.ToList(), "MaKhoa", "TenKhoa");
            ViewBag.MaTrinhDo = new SelectList(db.TrinhDos.ToList(), "MaTrinhDo", "TenTrinhDo");
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SuaSanPham(TacGium sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSp)
        {
            TempData["Message"] = "";
            var listChiTiet = db.DmgiaoTrinhs.Where(x => x.MaTacGia == maSp);
            foreach (var item in listChiTiet)
            {
                if (db.DmgiaoTrinhs.Where(x => x.MaTacGia == item.MaTacGia) != null)
                {
                    TempData["Message"] = "Không xóa được sản phẩm này";
                    return RedirectToAction("DanhSachSanPham");
                }
            }
            //var listAnh = db.TAnhSps.Where(x => x.MaSp == maSp);


            // if (listAnh != null) db.RemoveRange(listAnh);
            if (listChiTiet != null) db.RemoveRange(listChiTiet);
            db.Remove(db.TacGia.Find(maSp));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("DanhSachSanPham");
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("sanphamtheoloai")]
        public IActionResult sanphamtheoloai()
        {

            var lstsanpham = db.DmgiaoTrinhs.AsNoTracking().OrderBy(x => x.MaGt).ToList();

            return View(lstsanpham);

        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("themsanpham")]

        public IActionResult ThemSanPham()
        {
            /*  ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
              ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
              ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
              ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
              ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");*/
            ViewBag.MaTacGia = new SelectList(db.TacGia.ToList(), "MaTacGia", "MaTacGia");
            ViewBag.MaChuyenNganh = new SelectList(db.ChuyenNganhs.ToList(), "MaChuyenNganh", "MaChuyenNganh");

            return View();
        }
        [Authenication]
        [AuthenicationQuyen]
        [ValidateAntiForgeryToken]
        [Route("themsanpham")]
        [HttpPost]
        public IActionResult ThemSanPham(DmgiaoTrinh sanPham)
        {
            if (ModelState.IsValid)
            {
                db.DmgiaoTrinhs.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("sanphamtheoloai");
            }
            return View(sanPham);
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("sualsanpham")]

        public IActionResult sualsanpham(string themuon)
        {
            var spedit = db.DmgiaoTrinhs.SingleOrDefault(x => x.MaGt == themuon);
            ViewBag.MaTacGia = new SelectList(db.TacGia.ToList(), "MaTacGia", "MaTacGia");
            ViewBag.MaChuyenNganh = new SelectList(db.ChuyenNganhs.ToList(), "MaChuyenNganh", "MaChuyenNganh");

            return View(spedit);
        }
        [ValidateAntiForgeryToken]
        [Route("sualsanpham")]
        [HttpPost]
        public IActionResult sualsanpham(DmgiaoTrinh dmgiaoTrinh)
        {

            if (ModelState.IsValid)
            {
                db.Entry(dmgiaoTrinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("sanphamtheoloai");
            }
            return View(dmgiaoTrinh);
        }

        [Route("XoaGiaoTrinh")]
        public IActionResult XoaGiaoTrinh(string masp)
        {
            var spedit = db.DmgiaoTrinhs.Where(x => x.MaGt == masp);
            var listAnh = db.ChiTietHsmuons.Where(x => x.MaGt == masp);
            if (listAnh != null) db.RemoveRange(listAnh);
            db.RemoveRange(spedit);
            db.SaveChanges();
            return RedirectToAction("sanphamtheoloai");
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("themuom")]
        public IActionResult themuom()
        {

            var lstsanpham = db.TheMuons.AsNoTracking().OrderBy(x => x.MaThe).ToList();

            return View(lstsanpham);

        }
        public enum Gender
        {
            Nam,
            Nữ,
            Khác
        }
        public enum truefalse
        {
            True,
            False

        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("themthemuon")]
        public IActionResult themthemuon()
        {

            ViewBag.MaLop = new SelectList(db.Lops.ToList(), "MaLop", "MaLop");
            ViewBag.MaKhoa = new SelectList(db.Khoas.ToList(), "MaKhoa", "MaKhoa");
            ViewBag.Nam = new SelectList(Enum.GetValues(typeof(Gender)), "Nam");
            ViewBag.True = new SelectList(Enum.GetValues(typeof(truefalse)), "True");
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("themthemuon")]
        [HttpPost]
        public IActionResult themthemuon(TheMuon theMuon)
        {
            if (ModelState.IsValid)
            {
                db.TheMuons.Add(theMuon);
                db.SaveChanges();
                return RedirectToAction("themuom");
            }
            return View(theMuon);
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("Suathemuon")]

        public IActionResult Suathemuon(string themuon)
        {
            var spedit = db.TheMuons.SingleOrDefault(x => x.MaThe == themuon);
            ViewBag.MaLop = new SelectList(db.Lops.ToList(), "MaLop", "MaLop");
            ViewBag.MaKhoa = new SelectList(db.Khoas.ToList(), "MaKhoa", "MaKhoa");
            ViewBag.Nam = new SelectList(Enum.GetValues(typeof(Gender)), "Nam");
            ViewBag.True = new SelectList(Enum.GetValues(typeof(truefalse)), "True");
            return View(spedit);
        }
        [ValidateAntiForgeryToken]
        [Route("Suathemuon")]
        [HttpPost]
        public IActionResult Suathemuon(TheMuon theMuon)
        {

            if (ModelState.IsValid)
            {
                db.Entry(theMuon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("themuom");
            }
            return View(theMuon);
        }
        [Route("Xoathemuon")]
        public IActionResult Xoathemuon(string masp)
        {
            var spedit = db.TheMuons.Where(x => x.MaThe == masp);

            db.RemoveRange(spedit);
            db.SaveChanges();
            return RedirectToAction("themuom");
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("DanhSachThuThu")]
        public IActionResult DanhSachThuThu(int page = 1)
        {
            int pageNumber = page;
            int pageSize = 12;
            var lstthuthu = db.ThuThus.AsNoTracking().OrderBy(x => x.TenThuThu);
            PagedList<ThuThu> lst = new PagedList<ThuThu>(lstthuthu, pageNumber, pageSize);
            return View(lst);
        }
        [Authenication]
        [AuthenicationQuyen]
        [Route("ThemThuThu")]
        [HttpGet]
        public IActionResult ThemThuThu()
        {
            ViewBag.MaQue = new SelectList(db.Ques.ToList(), "MaQue", "TenQue");
            return View();
        }
        [Route("ThemThuThu")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ThemThuThu(ThuThu thuThu)
        {
            if (ModelState.IsValid)
            {
                db.ThuThus.Add(thuThu);
                db.SaveChanges();
                return RedirectToAction("DanhSachThuThu");
            }
            return View(thuThu);
        }
        [Route("SuaThuThu")]
        [HttpGet]
        public IActionResult SuaThuThu(string maThuThu)
        {
            var thuThu = db.ThuThus.Find(maThuThu);
            ViewBag.MaQue = new SelectList(db.Ques.ToList(), "MaQue", "TenQue");
            return View(thuThu);
        }
        [Route("SuaThuThu")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SuaThuThu(ThuThu thuThu)
        {
            if (ModelState.IsValid)
            {
                db.Update(thuThu);
                db.SaveChanges();
                return RedirectToAction("DanhSachThuThu");
            }
            return View(thuThu);
        }
        [Route("XoaThuThu")]
        [HttpGet]
        public IActionResult XoaThuThu(string matt)
        {
            TempData["Message"] = "";
            var lstChiTiet = db.ThuThus.Where(x => x.MaThuThu == matt);
            foreach (var item in lstChiTiet)
            {
                if (db.ThuThus.Where(x => x.MaThuThu == item.MaThuThu) != null)
                {
                    TempData["Message"] = "Lỗi Xóa!!";
                    return RedirectToAction("DanhSachThuThu");
                }
            }
            if (lstChiTiet != null) db.RemoveRange(lstChiTiet);
            db.Remove(db.ThuThus.Find(matt));
            db.SaveChanges();
            TempData["Message"] = "Xóa thành công";
            return RedirectToAction("DanhSachThuThu");
        }
    

}
}
