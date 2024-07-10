using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class Baocao3
{
    public string MaHsm { get; set; } = null!;

    public string? MaThe { get; set; }

    public string? MaThuThu { get; set; }

    public DateTime? NgayMuon { get; set; }

    public DateTime? NgayTra { get; set; }

    public string? TinhTrangMuon { get; set; }

    public string MaGt { get; set; } = null!;

    public string? ChuaTra { get; set; }
}
