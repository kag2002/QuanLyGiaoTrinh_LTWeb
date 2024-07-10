using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class Phat
{
    public string MaPhat { get; set; } = null!;

    public decimal? TienPhat { get; set; }

    public virtual ICollection<ChiTietHstra> ChiTietHstras { get; } = new List<ChiTietHstra>();
}
