using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class ChiTietHsmuon
{
    public string MaHsm { get; set; } = null!;

    public string MaGt { get; set; } = null!;

    public string? ChuaTra { get; set; }

    public virtual DmgiaoTrinh MaGtNavigation { get; set; } = null!;

    public virtual Hsmuon MaHsmNavigation { get; set; } = null!;
}
