<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UnderConstructionForm
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
        lblEmoji = New Label()
        lblTitle = New Label()
        lblVersion = New Label()
        lblDescription = New Label()
        btnGoBack = New Button()
        SuspendLayout()
        '
        ' UnderConstructionForm
        '
        Me.BackColor = Drawing.Color.FromArgb(26, 35, 126)
        Me.ClientSize = New Drawing.Size(520, 380)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UnderConstructionForm"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "Under Construction"
        '
        ' lblEmoji
        '
        lblEmoji.AutoSize = False
        lblEmoji.Font = New Drawing.Font("Segoe UI Emoji", 36.0!, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        lblEmoji.ForeColor = Drawing.Color.White
        lblEmoji.Location = New Drawing.Point(0, 30)
        lblEmoji.Name = "lblEmoji"
        lblEmoji.Size = New Drawing.Size(520, 70)
        lblEmoji.Text = "🚧"
        lblEmoji.TextAlign = Drawing.ContentAlignment.MiddleCenter
        '
        ' lblTitle
        '
        lblTitle.AutoSize = False
        lblTitle.Font = New Drawing.Font("Segoe UI", 24.0!, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        lblTitle.ForeColor = Drawing.Color.White
        lblTitle.Location = New Drawing.Point(0, 110)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Drawing.Size(520, 50)
        lblTitle.Text = "Under Construction"
        lblTitle.TextAlign = Drawing.ContentAlignment.MiddleCenter
        '
        ' lblVersion
        '
        lblVersion.AutoSize = False
        lblVersion.Font = New Drawing.Font("Segoe UI", 13.0!, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        lblVersion.ForeColor = Drawing.Color.FromArgb(255, 167, 38)
        lblVersion.Location = New Drawing.Point(0, 170)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Drawing.Size(520, 35)
        lblVersion.Text = "Current Version: v1.00"
        lblVersion.TextAlign = Drawing.ContentAlignment.MiddleCenter
        '
        ' lblDescription
        '
        lblDescription.AutoSize = False
        lblDescription.Font = New Drawing.Font("Segoe UI", 10.0!, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        lblDescription.ForeColor = Drawing.Color.FromArgb(200, 200, 200)
        lblDescription.Location = New Drawing.Point(40, 220)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Drawing.Size(440, 50)
        lblDescription.Text = "This feature is not yet available in the current presentation version."
        lblDescription.TextAlign = Drawing.ContentAlignment.MiddleCenter
        '
        ' btnGoBack
        '
        btnGoBack.BackColor = Drawing.Color.FromArgb(255, 167, 38)
        btnGoBack.FlatStyle = FlatStyle.Flat
        btnGoBack.FlatAppearance.BorderSize = 0
        btnGoBack.Font = New Drawing.Font("Segoe UI", 11.0!, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        btnGoBack.ForeColor = Drawing.Color.White
        btnGoBack.Location = New Drawing.Point(185, 295)
        btnGoBack.Name = "btnGoBack"
        btnGoBack.Size = New Drawing.Size(150, 42)
        btnGoBack.Text = "← Go Back"
        btnGoBack.UseVisualStyleBackColor = False
        '
        ' Controls
        '
        Me.Controls.Add(lblEmoji)
        Me.Controls.Add(lblTitle)
        Me.Controls.Add(lblVersion)
        Me.Controls.Add(lblDescription)
        Me.Controls.Add(btnGoBack)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblEmoji As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents btnGoBack As Button

End Class
