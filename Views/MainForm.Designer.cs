namespace LandRegistrationSystem.Views;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        // ── Controls declaration ────────────────────────────────────────────
        lblTitle            = new System.Windows.Forms.Label();
        lblParcelNumber     = new System.Windows.Forms.Label();
        txtParcelNumber     = new System.Windows.Forms.TextBox();
        lblOwnerName        = new System.Windows.Forms.Label();
        txtOwnerName        = new System.Windows.Forms.TextBox();
        lblLocation         = new System.Windows.Forms.Label();
        txtLocation         = new System.Windows.Forms.TextBox();
        lblArea             = new System.Windows.Forms.Label();
        txtArea             = new System.Windows.Forms.TextBox();
        lblLandUse          = new System.Windows.Forms.Label();
        txtLandUse          = new System.Windows.Forms.TextBox();
        lblRegDate          = new System.Windows.Forms.Label();
        dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
        btnSave             = new System.Windows.Forms.Button();
        btnUpdate           = new System.Windows.Forms.Button();
        btnDelete           = new System.Windows.Forms.Button();
        btnClear            = new System.Windows.Forms.Button();
        lblSearch           = new System.Windows.Forms.Label();
        txtSearch           = new System.Windows.Forms.TextBox();
        btnSearch           = new System.Windows.Forms.Button();
        btnRefresh          = new System.Windows.Forms.Button();
        dgvParcels          = new System.Windows.Forms.DataGridView();
        pnlInput            = new System.Windows.Forms.Panel();
        pnlButtons          = new System.Windows.Forms.Panel();
        pnlSearch           = new System.Windows.Forms.Panel();

        ((System.ComponentModel.ISupportInitialize)dgvParcels).BeginInit();
        pnlInput.SuspendLayout();
        pnlButtons.SuspendLayout();
        pnlSearch.SuspendLayout();
        SuspendLayout();

        // ── Form ────────────────────────────────────────────────────────────
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize          = new System.Drawing.Size(1000, 680);
        Font                = new System.Drawing.Font("Segoe UI", 10F);
        Text                = "Land Registration System";
        StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
        MinimumSize         = new System.Drawing.Size(1000, 680);
        BackColor           = System.Drawing.Color.WhiteSmoke;
        Load               += MainForm_Load;

        // ── Title label ─────────────────────────────────────────────────────
        lblTitle.Text      = "🏡  Land Registration System";
        lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 80, 160);
        lblTitle.AutoSize  = true;
        lblTitle.Location  = new System.Drawing.Point(12, 12);

        // ── Input panel ─────────────────────────────────────────────────────
        pnlInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlInput.BackColor   = System.Drawing.Color.White;
        pnlInput.Location    = new System.Drawing.Point(12, 55);
        pnlInput.Size        = new System.Drawing.Size(970, 170);

        int lx = 10, tx = 160, row1 = 15, row2 = 55, row3 = 95;
        int lw = 145, tw = 200, th = 28;

        // Row 1
        SetLabel(lblParcelNumber, "Parcel Number:",  lx,  row1, lw);
        SetText (txtParcelNumber,                    tx,  row1, tw, th);

        SetLabel(lblOwnerName,    "Owner Name:",    380,  row1, lw);
        SetText (txtOwnerName,                      530,  row1, tw, th);

        SetLabel(lblRegDate,      "Reg. Date:",     740,  row1, lw);
        dtpRegistrationDate.Location = new System.Drawing.Point(880, row1);
        dtpRegistrationDate.Size     = new System.Drawing.Size(80,  th);
        dtpRegistrationDate.Format   = System.Windows.Forms.DateTimePickerFormat.Short;

        // Row 2
        SetLabel(lblLocation, "Location:",          lx,  row2, lw);
        SetText (txtLocation,                        tx,  row2, 580, th);

        // Row 3
        SetLabel(lblArea,    "Area (sq m):",         lx,  row3, lw);
        SetText (txtArea,                             tx,  row3, tw,  th);

        SetLabel(lblLandUse, "Land Use:",           380,  row3, lw);
        SetText (txtLandUse,                         530,  row3, tw,  th);

        pnlInput.Controls.AddRange(new System.Windows.Forms.Control[] {
            lblParcelNumber, txtParcelNumber,
            lblOwnerName,    txtOwnerName,
            lblRegDate,      dtpRegistrationDate,
            lblLocation,     txtLocation,
            lblArea,         txtArea,
            lblLandUse,      txtLandUse
        });

        // ── Buttons panel ───────────────────────────────────────────────────
        pnlButtons.BackColor = System.Drawing.Color.White;
        pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlButtons.Location  = new System.Drawing.Point(12, 234);
        pnlButtons.Size      = new System.Drawing.Size(970, 50);

        SetButton(btnSave,    "💾 Save",    10,  10, 120, 32, System.Drawing.Color.FromArgb(39,174,96),  System.Drawing.Color.White);
        SetButton(btnUpdate,  "✏ Update",  140, 10, 120, 32, System.Drawing.Color.FromArgb(41,128,185),  System.Drawing.Color.White);
        SetButton(btnDelete,  "🗑 Delete",  270, 10, 120, 32, System.Drawing.Color.FromArgb(192,57,43),   System.Drawing.Color.White);
        SetButton(btnClear,   "✖ Clear",   400, 10, 120, 32, System.Drawing.Color.FromArgb(127,140,141),  System.Drawing.Color.White);

        btnSave.Click   += btnSave_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnClear.Click  += btnClear_Click;

        pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
            btnSave, btnUpdate, btnDelete, btnClear
        });

        // ── Search panel ────────────────────────────────────────────────────
        pnlSearch.BackColor   = System.Drawing.Color.White;
        pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlSearch.Location    = new System.Drawing.Point(12, 293);
        pnlSearch.Size        = new System.Drawing.Size(970, 44);

        lblSearch.Text     = "Search:";
        lblSearch.AutoSize = true;
        lblSearch.Location = new System.Drawing.Point(10, 12);

        txtSearch.Location = new System.Drawing.Point(75,  8);
        txtSearch.Size     = new System.Drawing.Size(400, 28);

        SetButton(btnSearch,  "🔍 Search",  485, 7, 110, 30, System.Drawing.Color.FromArgb(142,68,173),  System.Drawing.Color.White);
        SetButton(btnRefresh, "↺ Refresh",  605, 7, 110, 30, System.Drawing.Color.FromArgb(44,62,80),    System.Drawing.Color.White);

        btnSearch.Click  += btnSearch_Click;
        btnRefresh.Click += btnRefresh_Click;

        pnlSearch.Controls.AddRange(new System.Windows.Forms.Control[] {
            lblSearch, txtSearch, btnSearch, btnRefresh
        });

        // ── DataGridView ────────────────────────────────────────────────────
        dgvParcels.Location            = new System.Drawing.Point(12, 346);
        dgvParcels.Size                = new System.Drawing.Size(970, 310);
        dgvParcels.Anchor              = System.Windows.Forms.AnchorStyles.Top
                                       | System.Windows.Forms.AnchorStyles.Bottom
                                       | System.Windows.Forms.AnchorStyles.Left
                                       | System.Windows.Forms.AnchorStyles.Right;
        dgvParcels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvParcels.ReadOnly            = true;
        dgvParcels.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvParcels.AllowUserToAddRows  = false;
        dgvParcels.BackgroundColor     = System.Drawing.Color.White;
        dgvParcels.BorderStyle         = System.Windows.Forms.BorderStyle.FixedSingle;
        dgvParcels.RowHeadersVisible   = false;
        dgvParcels.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
        dgvParcels.ColumnHeadersDefaultCellStyle.Font =
            new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        dgvParcels.CellClick += dgvParcels_CellClick;

        // ── Add to form ─────────────────────────────────────────────────────
        Controls.AddRange(new System.Windows.Forms.Control[] {
            lblTitle, pnlInput, pnlButtons, pnlSearch, dgvParcels
        });

        ((System.ComponentModel.ISupportInitialize)dgvParcels).EndInit();
        pnlInput.ResumeLayout(false);
        pnlButtons.ResumeLayout(false);
        pnlSearch.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Helper builders ─────────────────────────────────────────────────────
    private static void SetLabel(System.Windows.Forms.Label lbl, string text, int x, int y, int w)
    {
        lbl.Text      = text;
        lbl.AutoSize  = false;
        lbl.Size      = new System.Drawing.Size(w, 24);
        lbl.Location  = new System.Drawing.Point(x, y + 2);
        lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        lbl.Font      = new System.Drawing.Font("Segoe UI", 10F);
    }

    private static void SetText(System.Windows.Forms.TextBox txt, int x, int y, int w, int h)
    {
        txt.Location = new System.Drawing.Point(x, y);
        txt.Size     = new System.Drawing.Size(w, h);
    }

    private static void SetButton(System.Windows.Forms.Button btn, string text,
        int x, int y, int w, int h,
        System.Drawing.Color back, System.Drawing.Color fore)
    {
        btn.Text      = text;
        btn.Location  = new System.Drawing.Point(x, y);
        btn.Size      = new System.Drawing.Size(w, h);
        btn.BackColor = back;
        btn.ForeColor = fore;
        btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        btn.Cursor    = System.Windows.Forms.Cursors.Hand;
    }

    #endregion

    // ── Control fields ──────────────────────────────────────────────────────
    private System.Windows.Forms.Label            lblTitle;
    private System.Windows.Forms.Panel            pnlInput;
    private System.Windows.Forms.Panel            pnlButtons;
    private System.Windows.Forms.Panel            pnlSearch;
    private System.Windows.Forms.Label            lblParcelNumber;
    private System.Windows.Forms.TextBox          txtParcelNumber;
    private System.Windows.Forms.Label            lblOwnerName;
    private System.Windows.Forms.TextBox          txtOwnerName;
    private System.Windows.Forms.Label            lblLocation;
    private System.Windows.Forms.TextBox          txtLocation;
    private System.Windows.Forms.Label            lblArea;
    private System.Windows.Forms.TextBox          txtArea;
    private System.Windows.Forms.Label            lblLandUse;
    private System.Windows.Forms.TextBox          txtLandUse;
    private System.Windows.Forms.Label            lblRegDate;
    private System.Windows.Forms.DateTimePicker   dtpRegistrationDate;
    private System.Windows.Forms.Button           btnSave;
    private System.Windows.Forms.Button           btnUpdate;
    private System.Windows.Forms.Button           btnDelete;
    private System.Windows.Forms.Button           btnClear;
    private System.Windows.Forms.Label            lblSearch;
    private System.Windows.Forms.TextBox          txtSearch;
    private System.Windows.Forms.Button           btnSearch;
    private System.Windows.Forms.Button           btnRefresh;
    private System.Windows.Forms.DataGridView     dgvParcels;
}
