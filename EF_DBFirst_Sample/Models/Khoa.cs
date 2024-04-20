﻿using System;
using System.Collections.Generic;

namespace EF_DBFirst_Sample.Models;

public partial class Khoa
{
    public int Id { get; set; }

    public string TenKhoa { get; set; } = null!;

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();
}
