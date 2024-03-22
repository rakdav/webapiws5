using System;
using System.Collections.Generic;

namespace webapiws5.Models;

public partial class WriteOff
{
    public int Id { get; set; }

    public int IdShipment { get; set; }

    public string Cause { get; set; } = null!;

    public virtual Shipment IdShipmentNavigation { get; set; } = null!;
}
