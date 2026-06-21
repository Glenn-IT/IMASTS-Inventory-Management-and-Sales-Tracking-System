See the end of this message for details on invoking 
just-in-time (JIT) debugging instead of this dialog box.

************** Exception Text **************
System.ArgumentException: Column named CategoryID cannot be found. (Parameter 'columnName')
   at System.Windows.Forms.DataGridViewCellCollection.get_Item(String columnName)
   at IMASTS_Inventory_Management_and_Sales_Tracking_System.frmCategories.dgvCategories_SelectionChanged(Object sender, EventArgs e) in C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\Forms\frmCategories.vb:line 48
   at System.Windows.Forms.DataGridView.ClearSelection(Int32 columnIndexException, Int32 rowIndexException, Boolean selectExceptionElement)
   at System.Windows.Forms.DataGridView.SetAndSelectCurrentCellAddress(Int32 columnIndex, Int32 rowIndex, Boolean setAnchorCellAddress, Boolean validateCurrentCell, Boolean throughMouseClick, Boolean clearSelection, Boolean forceCurrentCellSelection)
   at System.Windows.Forms.DataGridView.MakeFirstDisplayedCellCurrentCell(Boolean includeNewRow)
   at System.Windows.Forms.DataGridView.OnRowCollectionChanged_PostNotification(Boolean recreateNewRow, Boolean allowSettingCurrentCell, CollectionChangeAction cca, DataGridViewRow dataGridViewRow, Int32 rowIndex)
   at System.Windows.Forms.DataGridViewRowCollection.OnCollectionChanged_PostNotification(CollectionChangeAction cca, Int32 rowIndex, Int32 rowCount, DataGridViewRow dataGridViewRow, Boolean changeIsDeletion, Boolean changeIsInsertion, Boolean recreateNewRow, Point newCurrentCell)
   at System.Windows.Forms.DataGridViewRowCollection.OnCollectionChanged(CollectionChangeEventArgs e, Int32 rowIndex, Int32 rowCount)
   at System.Windows.Forms.DataGridViewRowCollection.AddInternal(DataGridViewRow dataGridViewRow)
   at System.Windows.Forms.DataGridView.RefreshRows(Boolean scrollIntoView)
   at System.Windows.Forms.DataGridView.OnDataSourceChanged(EventArgs e)
   at IMASTS_Inventory_Management_and_Sales_Tracking_System.frmCategories.LoadCategories() in C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\Forms\frmCategories.vb:line 31
   at IMASTS_Inventory_Management_and_Sales_Tracking_System.frmCategories.btnAdd_Click(Object sender, EventArgs e) in C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\Forms\frmCategories.vb:line 69
   at System.Windows.Forms.Button.OnClick(EventArgs e)
   at System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
   at System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.ButtonBase.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.Callback(HWND hWnd, MessageId msg, WPARAM wparam, LPARAM lparam)


************** Loaded Assemblies **************
System.Private.CoreLib
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Private.CoreLib.dll
----------------------------------------
IMASTS-Inventory-Management-and-Sales-Tracking-System
    Assembly Version: 1.0.0.0
    Location: C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\bin\Debug\net8.0-windows\IMASTS-Inventory-Management-and-Sales-Tracking-System.dll
----------------------------------------
Microsoft.VisualBasic.Forms
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\Microsoft.VisualBasic.Forms.dll
----------------------------------------
System.Runtime
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Runtime.dll
----------------------------------------
System.Windows.Forms.Primitives
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\System.Windows.Forms.Primitives.dll
----------------------------------------
Microsoft.Extensions.DotNetDeltaApplier
    Assembly Version: 17.0.0.0
    Location: c:\program files\microsoft visual studio\2022\community\common7\ide\commonextensions\microsoft\hotreload\Microsoft.Extensions.DotNetDeltaApplier.dll
----------------------------------------
System.IO.Pipes
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.IO.Pipes.dll
----------------------------------------
System.Linq
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Linq.dll
----------------------------------------
System.Collections
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Collections.dll
----------------------------------------
System.Windows.Forms
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\System.Windows.Forms.dll
----------------------------------------
System.Collections.Concurrent
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Collections.Concurrent.dll
----------------------------------------
System.Diagnostics.TraceSource
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Diagnostics.TraceSource.dll
----------------------------------------
System.ComponentModel.Primitives
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.ComponentModel.Primitives.dll
----------------------------------------
System.Drawing.Primitives
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Drawing.Primitives.dll
----------------------------------------
System.Console
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Console.dll
----------------------------------------
System.Runtime.InteropServices
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Runtime.InteropServices.dll
----------------------------------------
System.Threading
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Threading.dll
----------------------------------------
System.Threading.Overlapped
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Threading.Overlapped.dll
----------------------------------------
System.Collections.Specialized
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Collections.Specialized.dll
----------------------------------------
System.Security.AccessControl
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Security.AccessControl.dll
----------------------------------------
System.Security.Principal.Windows
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Security.Principal.Windows.dll
----------------------------------------
System.Security.Claims
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Security.Claims.dll
----------------------------------------
System.Threading.Thread
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Threading.Thread.dll
----------------------------------------
System.ComponentModel.EventBasedAsync
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.ComponentModel.EventBasedAsync.dll
----------------------------------------
System.Runtime.Loader
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Runtime.Loader.dll
----------------------------------------
System.ComponentModel
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.ComponentModel.dll
----------------------------------------
System.Drawing.Common
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\System.Drawing.Common.dll
----------------------------------------
Microsoft.Win32.Primitives
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\Microsoft.Win32.Primitives.dll
----------------------------------------
Accessibility
    Assembly Version: 4.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\Accessibility.dll
----------------------------------------
System.ComponentModel.TypeConverter
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.ComponentModel.TypeConverter.dll
----------------------------------------
System.Numerics.Vectors
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Numerics.Vectors.dll
----------------------------------------
System.Memory
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Memory.dll
----------------------------------------
Microsoft.Win32.SystemEvents
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\Microsoft.Win32.SystemEvents.dll
----------------------------------------
System.Collections.NonGeneric
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Collections.NonGeneric.dll
----------------------------------------
Microsoft.VisualBasic.Core
    Assembly Version: 13.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\Microsoft.VisualBasic.Core.dll
----------------------------------------
System.Data.Common
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Data.Common.dll
----------------------------------------
System.Xml.ReaderWriter
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Xml.ReaderWriter.dll
----------------------------------------
System.Private.Xml
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Private.Xml.dll
----------------------------------------
Microsoft.Data.SqlClient
    Assembly Version: 5.0.0.0
    Location: C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\bin\Debug\net8.0-windows\runtimes\win\lib\net8.0\Microsoft.Data.SqlClient.dll
----------------------------------------
System.Transactions.Local
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Transactions.Local.dll
----------------------------------------
System.Diagnostics.DiagnosticSource
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Diagnostics.DiagnosticSource.dll
----------------------------------------
System.Diagnostics.Tracing
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Diagnostics.Tracing.dll
----------------------------------------
Microsoft.Win32.Registry
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\Microsoft.Win32.Registry.dll
----------------------------------------
System.Diagnostics.StackTrace
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Diagnostics.StackTrace.dll
----------------------------------------
System.Configuration.ConfigurationManager
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.28\System.Configuration.ConfigurationManager.dll
----------------------------------------
System.Private.Uri
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Private.Uri.dll
----------------------------------------
System.Net.WebClient
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Net.WebClient.dll
----------------------------------------
System.Text.Encoding.Extensions
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Text.Encoding.Extensions.dll
----------------------------------------
System.Security.Cryptography
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Security.Cryptography.dll
----------------------------------------
System.Threading.ThreadPool
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Threading.ThreadPool.dll
----------------------------------------
Microsoft.Identity.Client
    Assembly Version: 4.61.3.0
    Location: C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\bin\Debug\net8.0-windows\Microsoft.Identity.Client.dll
----------------------------------------
System.Text.Encoding.CodePages
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Text.Encoding.CodePages.dll
----------------------------------------
System.Net.Primitives
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Net.Primitives.dll
----------------------------------------
System.Diagnostics.Process
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Diagnostics.Process.dll
----------------------------------------
Microsoft.SqlServer.Server
    Assembly Version: 1.0.0.0
    Location: C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\bin\Debug\net8.0-windows\Microsoft.SqlServer.Server.dll
----------------------------------------
netstandard
    Assembly Version: 2.1.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\netstandard.dll
----------------------------------------
System.Runtime.Numerics
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Runtime.Numerics.dll
----------------------------------------
BCrypt-Net-Next
    Assembly Version: 4.2.0.0
    Location: C:\Users\GLENN\source\repos\IMASTS-Inventory-Management-and-Sales-Tracking-System\IMASTS-Inventory-Management-and-Sales-Tracking-System\bin\Debug\net8.0-windows\BCrypt-Net-Next.dll
----------------------------------------
System.ObjectModel
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.ObjectModel.dll
----------------------------------------
System.Reflection.Metadata
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Reflection.Metadata.dll
----------------------------------------
System.Collections.Immutable
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.Collections.Immutable.dll
----------------------------------------
System.IO.MemoryMappedFiles
    Assembly Version: 8.0.0.0
    Location: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.28\System.IO.MemoryMappedFiles.dll
----------------------------------------

************** JIT Debugging **************


