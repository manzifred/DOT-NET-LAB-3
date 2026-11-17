# Land Registration System

A C# WinForms desktop application built with **MVC architecture** and **ADO.NET** connected to **MariaDB (XAMPP)**.

## Technology Stack
| Area | Technology |
|---|---|
| Language | C# (.NET 8) |
| UI | Windows Forms |
| Database | MariaDB (XAMPP) |
| Data Access | ADO.NET (MySqlConnector) |
| Architecture | MVC |

## Project Structure
```
LandRegistrationSystem/
├── Models/
│   ├── LandParcel.cs              ← Data model (properties only)
│   └── LandParcelRepository.cs   ← All SQL / ADO.NET code
├── Controllers/
│   └── LandParcelController.cs   ← Validation & coordination
├── Views/
│   ├── MainForm.cs                ← UI events (no SQL here)
│   └── MainForm.Designer.cs      ← Form layout
├── Program.cs
├── database_setup.sql             ← Run this in phpMyAdmin first
└── README.md
```

## Setup Instructions

### 1. Start XAMPP
- Open XAMPP Control Panel
- Click **Start** next to **MySQL**
- Click **Start** next to **Apache** (needed for phpMyAdmin)

### 2. Create the Database
- Open browser → `http://localhost/phpmyadmin/`
- Click **SQL** tab
- Paste the contents of `database_setup.sql` and click **Go**

### 3. Run the Application
- Open the solution in Visual Studio
- Press **F5** or **Ctrl+F5**

## Features
- Register new land parcels (INSERT)
- View all parcels in a DataGridView (SELECT)
- Update parcel details (UPDATE)
- Delete parcels with confirmation (DELETE)
- Search by parcel number, owner, location, or land use (LIKE)
- Refresh to show all records

## MVC Flow
```
User clicks Save
  → MainForm (View) reads controls → creates LandParcel object
  → LandParcelController validates input
  → LandParcelRepository executes parameterized INSERT
  → MariaDB stores record
  → MainForm refreshes grid
```
