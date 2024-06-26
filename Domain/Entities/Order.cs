﻿using Data.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseEntity
{
    public DateOnly OrderDate { get; set; }
    public Status Status { get; set; } = Status.todo;
    public int UserId { get; set; }
    public User? User { get; set; }
    public Double TodtalAmount { get; set; }
    public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
}