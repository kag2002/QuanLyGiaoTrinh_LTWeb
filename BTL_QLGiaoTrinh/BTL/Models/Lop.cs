using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class Lop
{
    public string MaLop { get; set; } = null!;

    public string? TenLop { get; set; }

    public string? MaKhoa { get; set; }

    public virtual ICollection<TheMuon> TheMuons { get; } = new List<TheMuon>();
}
