using System;
using System.Collections.Generic;

namespace EF_DBFirst_Sample.Models;

public partial class SinhVien
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public int? LopId { get; set; }

    public virtual Lop? Lop { get; set; }
}
