using System;
using System.Collections.Generic;

namespace CrudeOprationTest.Models;

public partial class Employee1
{
    public int EmpNo { get; set; }

    public string Name { get; set; } = null!;

    public decimal? BasicSalary { get; set; }

    public int? DeptNo { get; set; }
}
