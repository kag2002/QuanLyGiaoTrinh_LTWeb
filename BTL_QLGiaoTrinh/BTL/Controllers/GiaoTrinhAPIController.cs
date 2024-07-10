using BTL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL.Models.APIModels;

namespace BTLwebcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoTrinhAPIController : ControllerBase
    {
        QuanLyGiaoTrinhContext db = new QuanLyGiaoTrinhContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            IList<Product> products = new List<Product>();
            var sanPhams = db.DmgiaoTrinhs.ToList();
            foreach (var s in sanPhams)
            {
                products.Add(new Product
                {
                    MaGt = s.MaGt,
                    TenGt = s.TenGt,
                    MaChuyenNganh = s.MaChuyenNganh,
                    Anh = s.Anh,
                    NamXb = s.NamXb

                });
            }
            return products;
        }
        [HttpGet("{machuyennganh}")]
        public IEnumerable<Product> GetAllProductByLoai(string machuyennganh)
        {
            IList<Product> products = new List<Product>();
            var sanPham = db.DmgiaoTrinhs.Where(x => x.MaChuyenNganh == machuyennganh).ToList();
            foreach (var s in sanPham)
            {
                products.Add(new Product
                {
                    MaGt = s.MaGt,
                    TenGt = s.TenGt,
                    MaChuyenNganh = s.MaChuyenNganh,
                    Anh = s.Anh,
                    NamXb = s.NamXb

                });
            }
            return products;
        }
    }
}
