namespace LandRegistrationSystem.Models;

/// <summary>
/// Model: represents one land parcel record.
/// Contains properties only — no SQL, no UI controls.
/// </summary>
public class LandParcel
{
    public int     ParcelID         { get; set; }
    public string  ParcelNumber     { get; set; } = "";
    public string  OwnerName        { get; set; } = "";
    public string  Location         { get; set; } = "";
    public decimal AreaSqMeters     { get; set; }
    public string  LandUse          { get; set; } = "";
    public DateTime RegistrationDate { get; set; } = DateTime.Today;
}
