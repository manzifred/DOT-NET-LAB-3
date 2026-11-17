using System.Data;
using MySqlConnector;

namespace LandRegistrationSystem.Models;

/// <summary>
/// Repository: all SQL and MySqlConnector code lives here.
/// No UI controls, no business validation — data access only.
/// </summary>
public class LandParcelRepository
{
    private readonly string _connectionString;

    public LandParcelRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // READ — return all parcels ordered by ParcelID
    public DataTable GetAll()
    {
        const string sql = @"
            SELECT ParcelID, ParcelNumber, OwnerName,
                   Location, AreaSqMeters, LandUse, RegistrationDate
            FROM LandParcels
            ORDER BY ParcelID";

        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        con.Open();
        using var reader = cmd.ExecuteReader();
        var table = new DataTable();
        table.Load(reader);
        return table;
    }

    // CREATE — insert a new parcel
    public void Insert(LandParcel parcel)
    {
        const string sql = @"
            INSERT INTO LandParcels
                (ParcelNumber, OwnerName, Location, AreaSqMeters, LandUse, RegistrationDate)
            VALUES
                (@parcelNo, @owner, @location, @area, @landUse, @regDate)";

        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@parcelNo",  MySqlDbType.VarChar,  30).Value  = parcel.ParcelNumber;
        cmd.Parameters.Add("@owner",     MySqlDbType.VarChar, 100).Value  = parcel.OwnerName;
        cmd.Parameters.Add("@location",  MySqlDbType.VarChar, 150).Value  = parcel.Location;
        cmd.Parameters.Add("@area",      MySqlDbType.Decimal).Value        = parcel.AreaSqMeters;
        cmd.Parameters.Add("@landUse",   MySqlDbType.VarChar, 100).Value  = parcel.LandUse;
        cmd.Parameters.Add("@regDate",   MySqlDbType.Date).Value           = parcel.RegistrationDate;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // UPDATE — modify an existing parcel
    public void Update(LandParcel parcel)
    {
        const string sql = @"
            UPDATE LandParcels
            SET ParcelNumber    = @parcelNo,
                OwnerName       = @owner,
                Location        = @location,
                AreaSqMeters    = @area,
                LandUse         = @landUse,
                RegistrationDate= @regDate
            WHERE ParcelID = @id";

        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@parcelNo",  MySqlDbType.VarChar,  30).Value  = parcel.ParcelNumber;
        cmd.Parameters.Add("@owner",     MySqlDbType.VarChar, 100).Value  = parcel.OwnerName;
        cmd.Parameters.Add("@location",  MySqlDbType.VarChar, 150).Value  = parcel.Location;
        cmd.Parameters.Add("@area",      MySqlDbType.Decimal).Value        = parcel.AreaSqMeters;
        cmd.Parameters.Add("@landUse",   MySqlDbType.VarChar, 100).Value  = parcel.LandUse;
        cmd.Parameters.Add("@regDate",   MySqlDbType.Date).Value           = parcel.RegistrationDate;
        cmd.Parameters.Add("@id",        MySqlDbType.Int32).Value          = parcel.ParcelID;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // DELETE — remove a parcel by primary key
    public void Delete(int parcelID)
    {
        const string sql = "DELETE FROM LandParcels WHERE ParcelID = @id";
        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = parcelID;
        con.Open();
        cmd.ExecuteNonQuery();
    }

    // SEARCH — search by parcel number, owner, location, or land use
    public DataTable Search(string keyword)
    {
        const string sql = @"
            SELECT ParcelID, ParcelNumber, OwnerName,
                   Location, AreaSqMeters, LandUse, RegistrationDate
            FROM LandParcels
            WHERE ParcelNumber LIKE @key
               OR OwnerName    LIKE @key
               OR Location     LIKE @key
               OR LandUse      LIKE @key
            ORDER BY ParcelID";

        using var con = new MySqlConnection(_connectionString);
        using var cmd = new MySqlCommand(sql, con);
        cmd.Parameters.Add("@key", MySqlDbType.VarChar, 200).Value = "%" + keyword + "%";
        con.Open();
        using var reader = cmd.ExecuteReader();
        var table = new DataTable();
        table.Load(reader);
        return table;
    }
}
