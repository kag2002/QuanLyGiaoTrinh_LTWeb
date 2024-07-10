using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class TacGium
{
    public string MaTacGia { get; set; } = null!;

    public string? TenTacGia { get; set; }

    public string? MaKhoa { get; set; }

    public int? NamSinh { get; set; }

    public string? MaTrinhDo { get; set; }

    public virtual ICollection<DmgiaoTrinh> DmgiaoTrinhs { get; } = new List<DmgiaoTrinh>();

    public virtual Khoa? MaKhoaNavigation { get; set; }

    public virtual TrinhDo? MaTrinhDoNavigation { get; set; }
}
