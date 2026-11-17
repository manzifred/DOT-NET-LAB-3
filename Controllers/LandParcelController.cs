using System.Data;
using LandRegistrationSystem.Models;

namespace LandRegistrationSystem.Controllers;

/// <summary>
/// Controller: receives actions from the View, validates input,
/// calls the repository, and returns results.
/// Does NOT reference TextBox, Button, or DataGridView controls.
/// </summary>
public class LandParcelController
{
    private readonly LandParcelRepository _repository;

    public LandParcelController(LandParcelRepository repository)
    {
        _repository = repository;
    }

    public DataTable GetParcels() => _repository.GetAll();

    public DataTable SearchParcels(string keyword) =>
        _repository.Search(keyword.Trim());

    public void AddParcel(LandParcel parcel)
    {
        Validate(parcel);
        _repository.Insert(parcel);
    }

    public void EditParcel(LandParcel parcel)
    {
        if (parcel.ParcelID <= 0)
            throw new ArgumentException("Select a land parcel before updating.");
        Validate(parcel);
        _repository.Update(parcel);
    }

    public void RemoveParcel(int parcelID)
    {
        if (parcelID <= 0)
            throw new ArgumentException("Select a land parcel before deleting.");
        _repository.Delete(parcelID);
    }

    // Validation lives in the controller, not in the View or Repository
    private static void Validate(LandParcel parcel)
    {
        if (string.IsNullOrWhiteSpace(parcel.ParcelNumber))
            throw new ArgumentException("Parcel Number is required.");

        if (string.IsNullOrWhiteSpace(parcel.OwnerName))
            throw new ArgumentException("Owner Name is required.");

        if (string.IsNullOrWhiteSpace(parcel.Location))
            throw new ArgumentException("Location is required.");

        if (string.IsNullOrWhiteSpace(parcel.LandUse))
            throw new ArgumentException("Land Use is required.");

        if (parcel.AreaSqMeters <= 0)
            throw new ArgumentException("Area must be a positive number.");
    }
}
