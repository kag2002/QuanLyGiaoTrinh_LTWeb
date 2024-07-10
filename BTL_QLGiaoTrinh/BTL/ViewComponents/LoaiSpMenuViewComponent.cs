using Microsoft.AspNetCore.Mvc;
using BTL.repository;

namespace BTLwebcore.ViewComponents
{
    public class LoaiSpMenuViewComponent:ViewComponent
    {
        private ILoaiSprepository loaiSprepository;
        public LoaiSpMenuViewComponent(ILoaiSprepository loaiSprepository)
        {
            this.loaiSprepository = loaiSprepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisps = loaiSprepository.GetAllLoaiSp().OrderBy(x => x.MaChuyenNganh);
            return View(loaisps);
        }
    }
}
