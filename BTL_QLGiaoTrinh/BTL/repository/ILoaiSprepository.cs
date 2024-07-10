using BTL.Models;
namespace BTL.repository
{
    public interface ILoaiSprepository
    {
        ChuyenNganh Add(ChuyenNganh sp);
        ChuyenNganh Update(ChuyenNganh sp);
        ChuyenNganh Delete(string maloai);
        ChuyenNganh GetLoai(string maloai);
        IEnumerable<ChuyenNganh> GetAllLoaiSp();
    }
}
