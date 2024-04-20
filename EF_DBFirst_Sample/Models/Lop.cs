using System;
using System.Collections.Generic;

namespace EF_DBFirst_Sample.Models;

public partial class Lop
{
    public int Id { get; set; }

    public string TenLop { get; set; } = null!;

    public int? KhoaId { get; set; }

    public virtual Khoa? Khoa { get; set; }

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
