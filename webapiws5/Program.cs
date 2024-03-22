using webapiws5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

PharmacyContext db = new();

app.MapGet("/medications", () =>
{
    var users = from s in db.Shipments
                join m in db.Medications on s.MedicationId equals m.Id
                join w in db.Warehouses on s.WarehouseId equals w.Id
                select new
                {
                    Name = m.Name,
                    Warehause = w.Name
                    
                };
});

//app.MapPost("api/medications", (Medication medication) =>
//{
//    if (medication == null)
//        return Results.BadRequest("Данные неверны");
//    db.Medications.Add(medication);
//    db.SaveChanges();
//    return Results.Json(medication);
//});

//app.MapPut("/api/medications", (Medication medication) =>
//{
//    var medicationOnChange = db.Medications.Where(m=>m.Id == medication.Id).FirstOrDefault();

//    if (medicationOnChange == null)
//        return Results.NotFound("Препарат не найден");
//    medicationOnChange.Name = medication.Name;
//    medicationOnChange.ExpireDate = medication.ExpireDate;
//    medicationOnChange.WarehouceId = medication.WarehouceId;
//    medicationOnChange.ShipmentId = medication.ShipmentId;
//    medicationOnChange.WriteoffReason = medication.WriteoffReason;
//    medicationOnChange.IsOnWarehouse = medicationOnChange.IsOnWarehouse;
//    db.Medications.Update(medicationOnChange);
//    db.SaveChanges();
//    return Results.Json(medicationOnChange);
//});

//app.MapDelete("/api/medications", (Medication medication) =>
//{
//    if (medication == null)
//        return Results.BadRequest("Данные неверны");
//    var medicationOnDelete = db.Medications.Where(m => m.Id == medication.Id).FirstOrDefault();
//    db.Medications.Remove(medicationOnDelete);
//    db.SaveChanges();
//    return Results.Json(db.Medications.ToList());
//});


//app.MapGet("/api/shipments", () => db.Shipments.ToList());

//app.MapPost("api/shipments", (Shipment shipment) =>
//{
//    if (shipment == null)
//        return Results.BadRequest("Данные неверны");
//    db.Shipments.Add(shipment);
//    db.SaveChanges();
//    return Results.Json(shipment);
//});

//app.MapPut("/api/shipments", (Shipment shipment) =>
//{
//    var shipmentOnChange = db.Shipments.Where(s => s.Id == shipment.Id).FirstOrDefault();

//    if (shipmentOnChange == null)
//        return Results.NotFound("Препарат не найден");
//    shipmentOnChange.PartyName = shipment.PartyName;
//    shipmentOnChange.ShipmentDate = shipment.ShipmentDate;
//    shipmentOnChange.ShipmentCount = shipment.ShipmentCount;
//    shipmentOnChange.WarehouseId = shipment.WarehouseId;
//    db.Shipments.Update(shipmentOnChange);
//    db.SaveChanges();
//    return Results.Json(shipmentOnChange);
//});

//app.MapDelete("/api/shipments", (Shipment shipment) =>
//{
//    if (shipment == null)
//        return Results.BadRequest("Данные неверны");
//    var shipmentOnDelete = db.Shipments.Where(s => s.Id == shipment.Id).FirstOrDefault();
//    db.Shipments.Remove(shipmentOnDelete);
//    db.SaveChanges();
//    return Results.Json(db.Shipments.ToList());
//});


//app.MapGet("/api/warehouses", () => db.Warehouses.ToList());

//app.MapPost("/api/warehouses", (Warehouse warehouse) =>
//{
//    if (warehouse == null)
//        return Results.BadRequest("Данные неверны");
//    db.Warehouses.Add(warehouse);
//    db.SaveChanges();
//    return Results.Json(warehouse);
//});

//app.MapPut("/api/warehouses", (Warehouse warehouse) =>
//{
//    if (warehouse == null)
//        return Results.BadRequest("Данные неверны");
//    var warehouseOnChange = db.Warehouses.Where(w=>w.Id == warehouse.Id).FirstOrDefault();
//    warehouseOnChange.Address = warehouse.Address;
//    warehouseOnChange.Name = warehouse.Name;
//    db.Warehouses.Update(warehouseOnChange);
//    db.SaveChanges();
//    return Results.Json(warehouseOnChange);
//});

//app.MapDelete("/api/warehouses", (Warehouse warehouse) =>
//{
//    if (warehouse == null)
//        return Results.BadRequest("Данные неверны");
//    var warehouseOnDelete = db.Warehouses.Where(w => w.Id == warehouse.Id).FirstOrDefault();
//    db.Warehouses.Remove(warehouseOnDelete);
//    db.SaveChanges();
//    return Results.Json(db.Warehouses.ToList());
//});

app.Run();
