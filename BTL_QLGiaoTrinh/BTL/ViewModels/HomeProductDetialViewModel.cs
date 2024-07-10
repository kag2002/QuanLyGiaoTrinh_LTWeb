using BTL.Models;

namespace BTL.ViewModels
{
    public class HomeProductDetialViewModel 
    {
        private ChiTietHsmuon cthsm;
        private List<DmgiaoTrinh> giaotrinh;

        public HomeProductDetialViewModel(ChiTietHsmuon cthsm, List<DmgiaoTrinh> giaotrinh)
        {
            this.cthsm = cthsm;
            this.giaotrinh = giaotrinh;
        }

        public ChiTietHsmuon Hstra { get => cthsm; set => cthsm = value; }
        public List<DmgiaoTrinh> Giaotrinh { get => giaotrinh; set => giaotrinh = value; }
    }
}
