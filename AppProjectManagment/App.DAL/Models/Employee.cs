using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }
}
