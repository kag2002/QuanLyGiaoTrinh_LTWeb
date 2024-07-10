using System;
using System.Collections.Generic;

namespace BTL.Models;

public partial class Khoa
{
    public string MaKhoa { get; set; } = null!;

    public string? TenKhoa { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<TacGium> TacGia { get; } = new List<TacGium>();
}
