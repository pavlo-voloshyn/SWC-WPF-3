﻿using PP.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace PP.Domain.Models;

public class Order : EntityBase
{
    public ServiceType ServiceType { get; set; }

    public bool IsUrgent { get; set; }

    public Status Status { get; set; }

    public int PassportId { get; set; }

    public DateTime DateCreated { get; set; }
}
