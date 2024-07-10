using Azure;
using BTL.Models;
using BTL.Models.APIModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        QuanLyGiaoTrinhContext db = new QuanLyGiaoTrinhContext();
        public IEnumerable<Product> GetAllSP()
        {
            var sanPham = (from p in db.DmgiaoTrinhs
                           select new Product
                           {
                               MaGt = p.MaGt,
                               TenGt = p.TenGt,
                               MaTacGia = p.MaTacGia,
                               NamXb = p.NamXb,
                               Anh = p.Anh
                           }).ToList();
            return sanPham;

        }
        [HttpGet("{maloai}")]

        public IEnumerable<Product> showProductByCategor(string maloai)
        {

            var sanPham = (from p in db.ChiTietHsmuons
                           join c in db.DmgiaoTrinhs on p.MaGt equals c.MaGt
                           where p.MaHsm == maloai && p.ChuaTra == "false"
                           select new Product
                           {
                               MaGt = c.MaGt,
                               TenGt = c.TenGt,
                               MaTacGia = c.MaTacGia,
                               NamXb = c.NamXb,
                               Anh = c.Anh,
                           }).ToList();
            return sanPham;
        }


}
    
}
