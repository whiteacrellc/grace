# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Grace is a Windows Forms inventory management application built for Vivian Grace Creations. It tracks inventory items (SKU, brand, description, barcode), manages check-in/check-out workflows, handles collections and arrangements, and generates Excel-based reports.

## Technology Stack

- **.NET 8.0** (net8.0-windows8.0)
- **Windows Forms** with some WPF integration
- **Entity Framework Core 9.0** with SQLite database
- **EPPlus 7.5.1** for Excel import/export
- **NLog 5.3.4** for logging
- **MSTest 3.6.3** framework for unit tests (with Moq 4.20.72 for mocking)
- **WinForms.DataVisualization** for charting

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
│   ├── GraceDbContext.cs       # EF Core DbContext with all entity configurations
│   ├── DbInitializer.cs        # Database schema initialization and migrations
│   ├── Preferences.cs          # User preferences management
│   └── models/                 # EF Core entity models
│       ├── Grace.cs            # Main inventory item
│       ├── GraceRow.cs         # Denormalized view for grid display
│       ├── Total.cs            # Historical totals for items
│       ├── Inventory.cs        # Inventory tracking with user association
│       ├── CollectionName.cs   # Collections associated with items
│       ├── User.cs             # User accounts
│       ├── Pulled.cs           # Check-out records
│       ├── Arrangement.cs      # Named arrangements within collections
│       ├── ArrangementTotal.cs # Historical totals for arrangements
│       └── Prefs.cs            # Application preferences
├── tabs/           # Tab page implementations
│   ├── AdminTab.cs             # User management, password resets
│   ├── DataTab.cs              # Main inventory grid display
│   ├── CheckInTab.cs           # Return items to inventory
│   ├── CheckOutTab.cs          # Pull items from inventory
│   ├── ReportTab.cs            # Generate and filter inventory reports
│   ├── CollectionTab.cs        # Manage collections of items
│   └── ArrangementTab.cs       # Manage arrangements within collections
├── dialogs/        # Dialog forms
│   ├── AddArrangementDialog.cs # Add new arrangements
│   ├── RenameArrangementDialog.cs # Rename existing arrangements
│   ├── CheckInDialog.cs        # Check-in workflow dialog
│   ├── CheckOutForm.cs         # Check-out workflow dialog
│   ├── EditRowForm.cs          # Edit inventory item details
│   ├── AddUserDialog.cs        # Add new user accounts
│   ├── PasswordChange.cs       # Change user passwords
│   └── SettingsForm.cs         # Application settings dialog
├── utils/          # Utility classes
│   ├── PasswordChecker.cs      # Password validation and admin checks
│   └── Utils.cs                # General utility methods
├── Vivian.cs       # Main form implementation
├── Vivian.Designer.cs # Main form designer file
├── DataBase.cs     # Static database access layer with query methods
├── DataGridLoader.cs # Grid data loading from GraceRows table
├── Program.cs      # Application entry point with login loop
├── Globals.cs      # Singleton for global state and preferences
├── Excel.cs        # ExcelReader class for importing Excel files
├── Report.cs       # Inventory report generation
├── InventoryReport.cs # Detailed inventory report functionality
├── ArrangementReport.cs # Arrangement-specific Excel reports
├── Chart.cs        # ReportChart form for data visualization
├── BackupAndRestore.cs # Database backup/restore functionality
├── AdminStuff.cs   # Admin-only functionality
├── LoginForm.cs    # User authentication form
├── AboutBox.cs     # About dialog
└── Settings.cs     # Settings management

gracetest/          # MSTest unit test project
├── GraceDbContextTest.cs       # Database context tests
├── DataBaseTest.cs             # DataBase class method tests
├── ArrangementReportTest.cs    # Arrangement report tests
├── InventoryReportTest.cs      # Inventory report tests
├── DataGridLoaderTest.cs       # Grid data loading tests
├── AddArrangementDialogTest.cs # Arrangement dialog tests
└── EditRowFormTest.cs          # Edit form tests
```

## Architecture

### Database Architecture

The application uses **Entity Framework Core 9.0** with SQLite. The database is stored at `%USERPROFILE%\Documents\grace\live\grace.db`.

**Core Entity Models** (in `grace/data/models/`):
- **Grace**: Main inventory item (ID, Sku, Brand, Description, BarCode, Availability, Note, Deleted)
- **Total**: Historical totals for inventory items with timestamps (CurrentTotal, PreviousAmount, Delta, LastUpdated, User)
- **GraceRow**: Denormalized view combining Grace + collections + latest totals (used for grid display)
- **Inventory**: Inventory tracking records with user association (PreviousAmount, Delta, CurrentTotal, UserId, GraceId)
- **CollectionName**: Collections associated with each Grace item (Name, GraceId)
- **User**: User accounts with password and admin role (Username, Password, IsAdmin)
- **Pulled**: Check-out records tracking who took what and when (CurrentTotal, CheckedInAmount, UserId, GraceId, CollectionId)
- **Arrangement**: Named arrangements within collections (Name, CollectionName, IsDeleted)
- **ArrangementTotal**: Historical totals for arrangements (CurrentTotal, User, LastUpdated, ArrangementId)
- **Prefs**: Application preferences stored as key-value pairs (Name, Value)

**Key Database Patterns**:
1. **Two-table approach**: `Grace` table stores inventory items, `GraceRow` table is a denormalized cache for UI grids. When data changes, update both `Grace` and then call `DataBase.UpdateGraceRow()` to sync `GraceRow`.
2. **Historical totals**: Never update totals in place. Insert new `Total` records with timestamps to maintain history.
3. **Soft deletes**: Some entities use soft delete patterns (Grace.Deleted, Arrangement.IsDeleted).
4. **Connection string**: Set once at startup via `DataBase.ConnectionString` and accessed through `GraceDbContext.ConnectionString`.
5. **Cascade deletes**: Grace deletions cascade to related Totals, Collections, GraceRows, Pulled, and Inventory records.

### Application Flow

1. **Startup** (`Program.cs`): Single-instance mutex enforced. Shows `LoginForm` in a loop.
2. **Authentication**: `LoginForm` validates user against the `Users` table via `PasswordChecker`. Sets `Globals.GetInstance().CurrentUser`.
3. **Main Form** (`Vivian.cs`): Tab-based interface. Each tab is implemented as a separate class (e.g., `CheckInTab`, `CheckOutTab`) to keep `Vivian.cs` manageable.
4. **Data Grid Pattern**: Most tabs display data in `DataGridView` controls. Data is loaded via `DataGridLoader.GetData()` or static methods in `DataBase.cs` that return `System.Data.DataTable` objects.
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
  - `CreateDatabaseFile()`: Creates database file in user's Documents folder

The `DataGridLoader.cs` class loads data for the main inventory grid:
- `GetData()`: Returns DataTable populated from GraceRows with all inventory columns

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

### Report Generation

The application has multiple report types:
- **InventoryReport** (`InventoryReport.cs`): Chronological log of inventory changes
- **ArrangementReport** (`ArrangementReport.cs`): Arrangement-specific reports with pagination (30 rows/page)
- **Report** (`Report.cs`): General report functionality

All reports use EPPlus for Excel generation.

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

### Adding a New Dialog

1. Create new dialog class in `grace/dialogs/` (e.g., `NewDialog.cs`)
2. Create corresponding designer file (`NewDialog.Designer.cs`)
3. Implement dialog logic with appropriate event handlers
4. Use `ShowDialog()` from calling code and check `DialogResult`

### Working with the DataGridView

The application heavily uses `DataGridView` controls bound to `DataTable` objects:
- Set `DataSource` to a `DataTable` or `DataView`
- Use `DataView.RowFilter` for client-side filtering
- Data binding is typically one-way (read-only grids)
- For editable grids, handle `CellValueChanged` or `RowValidated` events
- Use `DataGridLoader.GetData()` for the main inventory grid

### Logging

- NLog is configured in `Vivian.InitializeLogger()`
- Logs go to both a TextBox in the UI and a file at `C:\Users\tom\OneDrive\Desktop\grace.log`
- Use `LogManager.GetCurrentClassLogger()` to get a logger instance
- Call `Vivian.DisplayLogMessage()` to log user-facing messages

### Testing

- Test project uses MSTest with Moq for mocking
- Tests use in-memory or test databases
- Key classes marked `internal` have `InternalsVisibleTo("gracetest")` attribute for testability
- Run tests before committing changes
- Test coverage available via coverlet.collector

**Test files cover**:
- `GraceDbContextTest.cs`: Entity Framework context and model tests
- `DataBaseTest.cs`: Data access layer methods
- `ArrangementReportTest.cs`: Arrangement report generation
- `InventoryReportTest.cs`: Inventory report generation
- `DataGridLoaderTest.cs`: Grid data loading
- `AddArrangementDialogTest.cs`: Arrangement dialog behavior
- `EditRowFormTest.cs`: Edit form validation and behavior

### Code Style

- Nullable reference types enabled
- Many specific warnings suppressed in `.csproj` (CA1305, CA1707, CA1822, CA1805, CS8604, CA1860, CA1309, 8600, 8602)
- EnforceCodeStyleInBuild is enabled
- AnalysisLevel set to preview-recommended
- Follow existing naming conventions (PascalCase for public members)
- Copyright header required in source files (White Acre Software LLC)

## Common Tasks

### Import Inventory from Excel

1. File must have columns: Brand, Barcode, SKU, Description, Collections (1-6), Availability, Total
2. Use `File > Import Inventory` menu (admin only)
3. This **completely erases** the database and reimports
4. Excel reading is handled by `ExcelReader` class in `Excel.cs` using EPPlus

### Database Backup/Restore

- **Automatic backup**: On application exit, database is backed up to Documents folder
- **Manual backup**: Implemented in `BackupAndRestore.cs`
- Backup location: `%USERPROFILE%\Documents\grace\backups\`

### Generating Reports

- Click "Generate Report" in Report tab
- Creates chronological log of inventory changes
- Export to Excel via `File > Save Report`
- Report generation: `Report.cs` and `InventoryReport.cs`
- Arrangement reports: `ArrangementReport.cs` (paginated, 30 rows per page)

### User Preferences

Preferences are managed through the `Globals` singleton and stored in the database:
- `RowHeight`: Grid row height
- `RowsPerPage`: Pagination setting
- `HeaderHeight`: Grid header height
- `BarCodeAutoOpen`: Auto-open barcode scanner setting

Access via `Globals.GetInstance().RowHeight` etc., which internally uses the `Preferences` class.

### Working with Arrangements

Arrangements are named groupings within collections:
1. Create via `AddArrangementDialog`
2. Rename via `RenameArrangementDialog`
3. Soft delete by setting `IsDeleted = true`
4. Track totals via `ArrangementTotal` records (historical, never updated in place)
