using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class ChiTietHstra
{
    public string MaHstra { get; set; } = null!;

    public string MaGt { get; set; } = null!;

    public string? MaViPham { get; set; }

    public string? MaPhat { get; set; }

    public virtual HoSoTra MaHstraNavigation { get; set; } = null!;

    public virtual Phat? MaPhatNavigation { get; set; }

    public virtual ViPham? MaViPhamNavigation { get; set; }
}
