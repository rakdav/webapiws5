using System;
using System.Collections.Generic;

namespace webapiws5.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdMedication { get; set; }

    public int Count { get; set; }

    public virtual Medication IdMedicationNavigation { get; set; } = null!;
}
