using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class TheMuon
{
    public string MaThe { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? GioiTinh { get; set; }

    public string? MaLop { get; set; }

    public string? MaKhoa { get; set; }

    public string? KhoaThe { get; set; }

    public int? Slmuon { get; set; }

    public virtual ICollection<Hsmuon> Hsmuons { get; } = new List<Hsmuon>();

    public virtual Lop? MaLopNavigation { get; set; }
}
