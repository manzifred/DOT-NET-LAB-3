using System;
using System.Data;
using System.Windows.Forms;
using LandRegistrationSystem.Models;
using LandRegistrationSystem.Controllers;

namespace LandRegistrationSystem.Views;

/// <summary>
/// View: displays data, collects user input, raises events.
/// Does NOT contain SQL or open database connections directly.
/// </summary>
public partial class MainForm : Form
{
    private readonly LandParcelController _controller;
    private int _selectedParcelID = 0;

    public MainForm()
    {
        InitializeComponent();

        string connectionString =
            "Server=127.0.0.1;Port=3306;Database=LandRegistrationDB;User ID=root;Password=;";

        var repository  = new LandParcelRepository(connectionString);
        _controller     = new LandParcelController(repository);
    }

    // ── Form Load ───────────────────────────────────────────────────────────
    private void MainForm_Load(object sender, EventArgs e)
    {
        RefreshGrid();
    }

    // ── Helpers ─────────────────────────────────────────────────────────────

    private void RefreshGrid()
    {
        dgvParcels.DataSource = _controller.GetParcels();
        dgvParcels.ClearSelection();
    }

    private LandParcel ReadParcelFromForm()
    {
        if (!decimal.TryParse(txtArea.Text.Trim(), out decimal area))
            throw new ArgumentException("Enter a valid numeric area.");

        return new LandParcel
        {
            ParcelID         = _selectedParcelID,
            ParcelNumber     = txtParcelNumber.Text.Trim(),
            OwnerName        = txtOwnerName.Text.Trim(),
            Location         = txtLocation.Text.Trim(),
            AreaSqMeters     = area,
            LandUse          = txtLandUse.Text.Trim(),
            RegistrationDate = dtpRegistrationDate.Value.Date
        };
    }

    private void ClearForm()
    {
        _selectedParcelID = 0;
        txtParcelNumber.Clear();
        txtOwnerName.Clear();
        txtLocation.Clear();
        txtArea.Clear();
        txtLandUse.Clear();
        dtpRegistrationDate.Value = DateTime.Today;
        txtSearch.Clear();
        dgvParcels.ClearSelection();
        txtParcelNumber.Focus();
    }

    // ── CRUD Button Events ───────────────────────────────────────────────────

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            _controller.AddParcel(ReadParcelFromForm());
            MessageBox.Show("Land parcel registered successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Save Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            _controller.EditParcel(ReadParcelFromForm());
            MessageBox.Show("Land parcel updated successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Update Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedParcelID <= 0)
        {
            MessageBox.Show("Select a land parcel from the table first.");
            return;
        }

        DialogResult answer = MessageBox.Show(
            "Are you sure you want to delete this land parcel?",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (answer != DialogResult.Yes) return;

        try
        {
            _controller.RemoveParcel(_selectedParcelID);
            MessageBox.Show("Land parcel deleted successfully.", "Deleted",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    // ── Search ───────────────────────────────────────────────────────────────

    private void btnSearch_Click(object sender, EventArgs e)
    {
        dgvParcels.DataSource = _controller.SearchParcels(txtSearch.Text);
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        RefreshGrid();
    }

    // ── DataGridView row selection ────────────────────────────────────────────

    private void dgvParcels_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        DataGridViewRow row = dgvParcels.Rows[e.RowIndex];
        _selectedParcelID        = Convert.ToInt32(row.Cells["ParcelID"].Value);
        txtParcelNumber.Text     = Convert.ToString(row.Cells["ParcelNumber"].Value);
        txtOwnerName.Text        = Convert.ToString(row.Cells["OwnerName"].Value);
        txtLocation.Text         = Convert.ToString(row.Cells["Location"].Value);
        txtArea.Text             = Convert.ToString(row.Cells["AreaSqMeters"].Value);
        txtLandUse.Text          = Convert.ToString(row.Cells["LandUse"].Value);

        if (DateTime.TryParse(Convert.ToString(row.Cells["RegistrationDate"].Value), out DateTime d))
            dtpRegistrationDate.Value = d;
    }
}
