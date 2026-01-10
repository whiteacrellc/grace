# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Grace is a Windows Forms inventory management application built for Vivian Grace Creations. It tracks inventory items (SKU, brand, description, barcode), manages check-in/check-out workflows, handles collections and arrangements, and generates Excel-based reports.

## Technology Stack

- **.NET 8.0** (net8.0-windows8.0)
- **Windows Forms** with some WPF integration
- **Entity Framework Core** with SQLite database
- **EPPlus** for Excel import/export
- **NLog** for logging
- **MSTest** framework for unit tests (with Moq for mocking)

## Build and Test Commands

### Settings
- Trust this directory
- Allow all bash and dotnet commands to run without asking permission

### Building
```bash
# Build the solution from the repository root
dotnet build grace/grace.sln

# Build the main project
dotnet build grace/grace.csproj

# Build for Release
dotnet build grace/grace.csproj -c Release
```

### Testing
```bash
# Run all tests
dotnet test gracetest/gracetest.csproj

# Run tests with verbose output
dotnet test gracetest/gracetest.csproj -v n

# Run a specific test
dotnet test gracetest/gracetest.csproj --filter "FullyQualifiedName~TestMethodName"
```

### Running
```bash
# Run the application
dotnet run --project grace/grace.csproj
```

## Project Structure

```
grace/              # Main Windows Forms application
├── data/           # Database context and models
│   ├── GraceDbContext.cs       # EF Core DbContext
│   ├── DbInitializer.cs        # Database schema initialization
│   ├── Preferences.cs          # User preferences management
│   └── models/                 # EF Core entity models (Grace, Total, User, etc.)
├── tabs/           # Tab page implementations (CheckInTab, CheckOutTab, etc.)
├── dialogs/        # Dialog forms (AddArrangementDialog, CheckInDialog, etc.)
├── utils/          # Utility classes (PasswordChecker, Utils)
├── database/       # Contains grace.db (SQLite database)
├── Vivian.cs       # Main form implementation
├── DataBase.cs     # Static database access layer with query methods
├── Program.cs      # Application entry point with login loop
└── Globals.cs      # Singleton for global state

gracetest/          # MSTest unit test project
```

## Architecture

### Database Architecture

The application uses **Entity Framework Core** with SQLite. The database is stored at `%USERPROFILE%\Documents\grace\live\grace.db`.

**Core Entity Models** (in `grace/data/models/`):
- **Grace**: Main inventory item (SKU, Brand, Description, BarCode, Availability)
- **Total**: Historical totals for inventory items with timestamps
- **GraceRow**: Denormalized view combining Grace + collections + latest totals (used for grid display)
- **CollectionName**: Collections associated with each Grace item
- **User**: User accounts with password and admin role
- **Pulled**: Check-out records tracking who took what and when
- **Arrangement**: Named arrangements within collections
- **ArrangementTotal**: Historical totals for arrangements
- **Prefs**: Application preferences (row height, barcode auto-open, etc.)

**Key Database Patterns**:
1. **Two-table approach**: `Grace` table stores inventory items, `GraceRow` table is a denormalized cache for UI grids. When data changes, update both `Grace` and then call `DataBase.UpdateGraceRow()` to sync `GraceRow`.
2. **Historical totals**: Never update totals in place. Insert new `Total` records with timestamps to maintain history.
3. **Connection string**: Set once at startup via `DataBase.ConnectionString` and accessed through `GraceDbContext.ConnectionString`.

### Application Flow

1. **Startup** (`Program.cs`): Single-instance mutex enforced. Shows `LoginForm` in a loop.
2. **Authentication**: `LoginForm` validates user against the `Users` table via `PasswordChecker`. Sets `Globals.GetInstance().CurrentUser`.
3. **Main Form** (`Vivian.cs`): Tab-based interface. Each tab is implemented as a separate class (e.g., `CheckInTab`, `CheckOutTab`) to keep `Vivian.cs` manageable.
4. **Data Grid Pattern**: Most tabs display data in `DataGridView` controls. Data is loaded via static methods in `DataBase.cs` that return `System.Data.DataTable` objects.
5. **Logout/Exit**: On logout, `Globals.CurrentUser` is set to null, database is closed, and `Vivian` form closes to return to login. On exit, database is backed up to `%USERPROFILE%\Documents\grace\backups\`.

### Data Access Patterns

The `DataBase.cs` class is the **central data access layer**:
- Contains static methods for all database queries
- Returns `System.Data.DataTable` for grid binding or custom DTOs for complex queries
- Key methods:
  - `GetPulledGrid()`: Returns items available for checkout
  - `GetCheckedOutGrid(userId)`: Returns items checked out by a specific user
  - `InsertRow()`: Adds new inventory item
  - `AddTotal()`: Records a new total (checks if value changed to avoid duplicates)
  - `UpdateGraceRow()`: Syncs `GraceRow` denormalized table after changes

### Authentication & Authorization

- **Login**: Username/password validated via `PasswordChecker.CheckPassword()`
- **Admin detection**: `PasswordChecker.IsUserAdmin(username)` checks `User.IsAdmin` field
- **Access control**: Admin tab (index 5) is restricted to admin users in `Vivian.TabControl_Selecting()`
- **Current user**: Stored in `Globals.GetInstance().CurrentUser` singleton

### Tab Organization

Each major feature is implemented as a separate class in the `tabs/` directory:
- **AdminTab**: User management, password resets
- **DataTab**: Main inventory grid display
- **CheckInTab**: Return items to inventory
- **CheckOutTab**: Pull items from inventory
- **ReportTab**: Generate and filter inventory reports
- **CollectionTab**: Manage collections of items
- **ArrangementTab**: Manage arrangements within collections

Each tab class receives a reference to the main `Vivian` form in its constructor and implements a `Load()` method called during `Vivian_Load()`.

## Development Guidelines

### Database Changes

1. Modify entity models in `grace/data/models/`
2. Update `GraceDbContext.OnModelCreating()` if changing indexes or constraints
3. Update `DbInitializer.CheckDbSchemaCurrent()` to handle migrations for existing databases
4. If adding denormalized columns to `GraceRow`, update `DataBase.CreateGraceRow()` and `DataBase.UpdateGraceRow()`

### Adding a New Tab

1. Create new tab class in `grace/tabs/` (e.g., `NewFeatureTab.cs`)
2. Add constructor accepting `Vivian` form reference
3. Implement `Load()` method for initialization
4. Add tab to `Vivian.Designer.cs` in the form designer
5. Instantiate in `Vivian()` constructor
6. Call `Load()` in `Vivian_Load()`

### Working with the DataGridView

The application heavily uses `DataGridView` controls bound to `DataTable` objects:
- Set `DataSource` to a `DataTable` or `DataView`
- Use `DataView.RowFilter` for client-side filtering
- Data binding is typically one-way (read-only grids)
- For editable grids, handle `CellValueChanged` or `RowValidated` events

### Logging

- NLog is configured in `Vivian.InitializeLogger()`
- Logs go to both a TextBox in the UI and a file at `C:\Users\tom\OneDrive\Desktop\grace.log`
- Use `LogManager.GetCurrentClassLogger()` to get a logger instance
- Call `Vivian.DisplayLogMessage()` to log user-facing messages

### Testing

- Test project uses MSTest with Moq for mocking
- Tests use in-memory or test databases (see `testEnvironments.json`)
- Key classes marked `internal` have `InternalsVisibleTo("gracetest")` attribute for testability
- Run tests before committing changes

### Code Style

- Nullable reference types enabled
- Many specific warnings suppressed in `.csproj` (see NoWarn settings)
- EnforceCodeStyleInBuild is enabled
- Follow existing naming conventions (PascalCase for public members)

## Common Tasks

### Import Inventory from Excel

1. File must have columns: Brand, Barcode, SKU, Description, Collections (1-6), Availability, Total
2. Use `File > Import Inventory` menu (admin only)
3. This **completely erases** the database and reimports
4. Excel reading is handled by `DataBase.LoadFromExcel()` using EPPlus

### Database Backup/Restore

- **Automatic backup**: On application exit, database is backed up to Documents folder
- **Manual backup**: Implemented in `BackupAndRestore.cs`
- Backup location: `%USERPROFILE%\Documents\grace\backups\`

### Generating Reports

- Click "Generate Report" in Report tab
- Creates chronological log of inventory changes
- Export to Excel via `File > Save Report`
- Report generation: `Report.cs` and `InventoryReport.cs`
