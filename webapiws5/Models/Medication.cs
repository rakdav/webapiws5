using System;
using System.Collections.Generic;

namespace webapiws5.Models;

public partial class Medication
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BestВeforeВate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
