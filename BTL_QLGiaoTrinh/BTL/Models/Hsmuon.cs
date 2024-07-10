using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class Hsmuon
{
    public string MaHsm { get; set; } = null!;

    public string? MaThe { get; set; }

    public string? MaThuThu { get; set; }

    public DateTime? NgayMuon { get; set; }

    public DateTime? NgayTra { get; set; }

    public string? TinhTrangMuon { get; set; }

    public virtual ICollection<ChiTietHsmuon> ChiTietHsmuons { get; } = new List<ChiTietHsmuon>();

    public virtual TheMuon? MaTheNavigation { get; set; }

    public virtual ThuThu? MaThuThuNavigation { get; set; }
}
