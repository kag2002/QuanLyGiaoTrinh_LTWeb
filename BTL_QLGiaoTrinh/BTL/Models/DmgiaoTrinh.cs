using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class DmgiaoTrinh
{
    public string MaGt { get; set; } = null!;

    public string? TenGt { get; set; }

    public string? MaTacGia { get; set; }

    public int? NamXb { get; set; }

    public int? LanTb { get; set; }

    public string? MaChuyenNganh { get; set; }

    public int? SoTrang { get; set; }

    public string? TomTatNd { get; set; }

    public int? SoLuongGt { get; set; }

    public string? Anh { get; set; }

    public virtual ICollection<ChiTietHsmuon> ChiTietHsmuons { get; } = new List<ChiTietHsmuon>();

    public virtual ChuyenNganh? MaChuyenNganhNavigation { get; set; }

    public virtual TacGium? MaTacGiaNavigation { get; set; }
}
