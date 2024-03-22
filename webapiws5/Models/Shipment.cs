using System;
using System.Collections.Generic;

namespace webapiws5.Models;

public partial class Shipment
{
    public int Id { get; set; }

    public string PartyName { get; set; } = null!;

    public DateOnly ShipmentDate { get; set; }

    public int ShipmentCount { get; set; }

    public int WarehouseId { get; set; }

    public int MedicationId { get; set; }

    public int IdProvider { get; set; }

    public string ExpirationDate { get; set; } = null!;

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual Medication Medication { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;

    public virtual ICollection<WriteOff> WriteOffs { get; set; } = new List<WriteOff>();
}
