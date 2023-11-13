using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class Project
{
    public int Id { get; set; }

    public string? NameOfProject { get; set; }

    public string OrderingCompany { get; set; } = null!;

    public string? ExecutingCompany { get; set; }

    public int? ProjectManager { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int? Priority { get; set; }
}
