<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblPlaceholder = New System.Windows.Forms.Label()
        Me.SuspendLayout()

        ' lblPlaceholder
        Me.lblPlaceholder.AutoSize  = False
        Me.lblPlaceholder.Dock      = System.Windows.Forms.DockStyle.Fill
        Me.lblPlaceholder.Font      = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular)
        Me.lblPlaceholder.ForeColor = System.Drawing.Color.FromArgb(180, 185, 195)
        Me.lblPlaceholder.Name      = "lblPlaceholder"
        Me.lblPlaceholder.Text      = "Dashboard — Phase 4"
        Me.lblPlaceholder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' frmDashboard
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor           = System.Drawing.Color.FromArgb(245, 246, 248)
        Me.ClientSize          = New System.Drawing.Size(980, 640)
        Me.Controls.Add(Me.lblPlaceholder)
        Me.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None
        Me.Name                = "frmDashboard"
        Me.Text                = "Dashboard"

        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents lblPlaceholder As System.Windows.Forms.Label

End Class
