﻿namespace PP.Domain.Models;

public class EmployeeOrder : EntityBase
{
    public int EmployeeId { get; set; }
    
    public int OrderId { get; set; }
}
