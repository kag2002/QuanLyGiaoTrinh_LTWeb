using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL.Models;

public partial class HoSoTra
{
    public string MaHstra { get; set; } = null!;

    public string? MaHsm { get; set; }

    public DateTime? NgayTra { get; set; }


    public decimal? TongTienPhat { get; set; }

    public DateTime? NgayNopPhat { get; set; }

    public string? MaThuThu { get; set; }

    public virtual ICollection<ChiTietHstra> ChiTietHstras { get; } = new List<ChiTietHstra>();

    public virtual ThuThu? MaThuThuNavigation { get; set; }
}
