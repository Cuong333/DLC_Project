using System;
using System.Collections.Generic;

namespace DLC_Project.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
