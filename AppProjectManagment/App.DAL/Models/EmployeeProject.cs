using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class EmployeeProject
{
    public int Id { get; set; }

    public int? Project { get; set; }

    public int? Employee { get; set; }

    public virtual Project? Employee1 { get; set; }

    public virtual Employee? EmployeeNavigation { get; set; }

    public virtual Project? ProjectNavigation { get; set; }
}
