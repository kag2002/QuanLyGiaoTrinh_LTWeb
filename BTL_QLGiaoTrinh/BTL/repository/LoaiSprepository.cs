using BTL.Models;

namespace BTL.repository
{
    public class LoaiSprepository : ILoaiSprepository
    {
        private readonly QuanLyGiaoTrinhContext context;
        public LoaiSprepository(QuanLyGiaoTrinhContext context)
        {
            this.context = context;
        }
        public ChuyenNganh Add(ChuyenNganh sp)
        {
            throw new NotImplementedException();
        }

        public ChuyenNganh Delete(string maloai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChuyenNganh> GetAllLoaiSp()
        {
            return context.ChuyenNganhs;
        }

        public ChuyenNganh GetLoai(string maloai)
        {
            throw new NotImplementedException();
        }

        public ChuyenNganh Update(ChuyenNganh sp)
        {
            throw new NotImplementedException();
        }
    }
}
