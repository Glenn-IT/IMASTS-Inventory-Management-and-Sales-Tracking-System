<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDevelopers
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
        lblPageHeader = New Label()
        lblPageSub = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        flpContainer = New FlowLayoutPanel()
        pnlDev1 = New Panel()
        lblDev1Badge = New Label()
        lblDev1Name = New Label()
        lblDev1Role = New Label()
        lblDev1EmailLbl = New Label()
        lblDev1Email = New Label()
        lblDev1ContribLbl = New Label()
        lblDev1Contrib = New Label()
        pnlDev2 = New Panel()
        lblDev2Badge = New Label()
        lblDev2Name = New Label()
        lblDev2Role = New Label()
        lblDev2EmailLbl = New Label()
        lblDev2Email = New Label()
        lblDev2ContribLbl = New Label()
        lblDev2Contrib = New Label()
        pnlProjectInfo = New Panel()
        lblProjectTitle = New Label()
        lblProjectDesc = New Label()
        lblTechStack = New Label()
        lblVersion = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        flpContainer.SuspendLayout()
        pnlDev1.SuspendLayout()
        pnlDev2.SuspendLayout()
        pnlProjectInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPageHeader
        ' 
        lblPageHeader.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblPageHeader.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblPageHeader.Location = New Point(12, 14)
        lblPageHeader.Name = "lblPageHeader"
        lblPageHeader.Size = New Size(400, 32)
        lblPageHeader.TabIndex = 0
        lblPageHeader.Text = "Developers Page"
        ' 
        ' lblPageSub
        ' 
        lblPageSub.Font = New Font("Segoe UI", 9F)
        lblPageSub.ForeColor = Color.FromArgb(CByte(100), CByte(110), CByte(125))
        lblPageSub.Location = New Point(14, 46)
        lblPageSub.Name = "lblPageSub"
        lblPageSub.Size = New Size(600, 20)
        lblPageSub.TabIndex = 1
        lblPageSub.Text = "Meet the software development team behind IMASTS"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblPageHeader)
        Panel1.Controls.Add(lblPageSub)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(980, 74)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.Controls.Add(flpContainer)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 74)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(12)
        Panel2.Size = New Size(980, 651)
        Panel2.TabIndex = 1
        ' 
        ' flpContainer
        ' 
        flpContainer.AutoScroll = True
        flpContainer.Controls.Add(pnlDev1)
        flpContainer.Controls.Add(pnlDev2)
        flpContainer.Controls.Add(pnlProjectInfo)
        flpContainer.Dock = DockStyle.Fill
        flpContainer.Location = New Point(12, 12)
        flpContainer.Name = "flpContainer"
        flpContainer.Size = New Size(956, 627)
        flpContainer.TabIndex = 0
        ' 
        ' pnlDev1
        ' 
        pnlDev1.BackColor = Color.White
        pnlDev1.Controls.Add(lblDev1Badge)
        pnlDev1.Controls.Add(lblDev1Name)
        pnlDev1.Controls.Add(lblDev1Role)
        pnlDev1.Controls.Add(lblDev1EmailLbl)
        pnlDev1.Controls.Add(lblDev1Email)
        pnlDev1.Controls.Add(lblDev1ContribLbl)
        pnlDev1.Controls.Add(lblDev1Contrib)
        pnlDev1.Location = New Point(10, 10)
        pnlDev1.Margin = New Padding(10)
        pnlDev1.Name = "pnlDev1"
        pnlDev1.Padding = New Padding(20)
        pnlDev1.Size = New Size(450, 290)
        pnlDev1.TabIndex = 0
        ' 
        ' lblDev1Badge
        ' 
        lblDev1Badge.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblDev1Badge.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblDev1Badge.ForeColor = Color.White
        lblDev1Badge.Location = New Point(20, 18)
        lblDev1Badge.Name = "lblDev1Badge"
        lblDev1Badge.Size = New Size(110, 24)
        lblDev1Badge.TabIndex = 0
        lblDev1Badge.Text = "DEVELOPER 1"
        lblDev1Badge.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDev1Name
        ' 
        lblDev1Name.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblDev1Name.ForeColor = Color.FromArgb(CByte(28), CByte(43), CByte(74))
        lblDev1Name.Location = New Point(18, 50)
        lblDev1Name.Name = "lblDev1Name"
        lblDev1Name.Size = New Size(410, 36)
        lblDev1Name.TabIndex = 1
        lblDev1Name.Text = "Developer 1"
        ' 
        ' lblDev1Role
        ' 
        lblDev1Role.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDev1Role.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
        lblDev1Role.Location = New Point(20, 88)
        lblDev1Role.Name = "lblDev1Role"
        lblDev1Role.Size = New Size(410, 24)
        lblDev1Role.TabIndex = 2
        lblDev1Role.Text = "Lead Software Engineer / Full Stack Developer"
        ' 
        ' lblDev1EmailLbl
        ' 
        lblDev1EmailLbl.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblDev1EmailLbl.ForeColor = Color.FromArgb(CByte(130), CByte(140), CByte(155))
        lblDev1EmailLbl.Location = New Point(20, 124)
        lblDev1EmailLbl.Name = "lblDev1EmailLbl"
        lblDev1EmailLbl.Size = New Size(410, 18)
        lblDev1EmailLbl.TabIndex = 3
        lblDev1EmailLbl.Text = "CONTACT / EMAIL"
        ' 
        ' lblDev1Email
        ' 
        lblDev1Email.Font = New Font("Segoe UI", 9.5F)
        lblDev1Email.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblDev1Email.Location = New Point(20, 144)
        lblDev1Email.Name = "lblDev1Email"
        lblDev1Email.Size = New Size(410, 22)
        lblDev1Email.TabIndex = 4
        lblDev1Email.Text = "dev1@example.com"
        ' 
        ' lblDev1ContribLbl
        ' 
        lblDev1ContribLbl.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblDev1ContribLbl.ForeColor = Color.FromArgb(CByte(130), CByte(140), CByte(155))
        lblDev1ContribLbl.Location = New Point(20, 180)
        lblDev1ContribLbl.Name = "lblDev1ContribLbl"
        lblDev1ContribLbl.Size = New Size(410, 18)
        lblDev1ContribLbl.TabIndex = 5
        lblDev1ContribLbl.Text = "AREAS OF RESPONSIBILITY"
        ' 
        ' lblDev1Contrib
        ' 
        lblDev1Contrib.Font = New Font("Segoe UI", 9.5F)
        lblDev1Contrib.ForeColor = Color.FromArgb(CByte(60), CByte(65), CByte(75))
        lblDev1Contrib.Location = New Point(20, 202)
        lblDev1Contrib.Name = "lblDev1Contrib"
        lblDev1Contrib.Size = New Size(410, 68)
        lblDev1Contrib.TabIndex = 6
        lblDev1Contrib.Text = "• System Architecture & Data Modeling" & vbCrLf & "• SQL Server Database & Transactions" & vbCrLf & "• Point of Sale (POS) & Inventory Core Engine"
        ' 
        ' pnlDev2
        ' 
        pnlDev2.BackColor = Color.White
        pnlDev2.Controls.Add(lblDev2Badge)
        pnlDev2.Controls.Add(lblDev2Name)
        pnlDev2.Controls.Add(lblDev2Role)
        pnlDev2.Controls.Add(lblDev2EmailLbl)
        pnlDev2.Controls.Add(lblDev2Email)
        pnlDev2.Controls.Add(lblDev2ContribLbl)
        pnlDev2.Controls.Add(lblDev2Contrib)
        pnlDev2.Location = New Point(480, 10)
        pnlDev2.Margin = New Padding(10)
        pnlDev2.Name = "pnlDev2"
        pnlDev2.Padding = New Padding(20)
        pnlDev2.Size = New Size(450, 290)
        pnlDev2.TabIndex = 1
        ' 
        ' lblDev2Badge
        ' 
        lblDev2Badge.BackColor = Color.FromArgb(CByte(142), CByte(68), CByte(173))
        lblDev2Badge.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblDev2Badge.ForeColor = Color.White
        lblDev2Badge.Location = New Point(20, 18)
        lblDev2Badge.Name = "lblDev2Badge"
        lblDev2Badge.Size = New Size(110, 24)
        lblDev2Badge.TabIndex = 0
        lblDev2Badge.Text = "DEVELOPER 2"
        lblDev2Badge.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDev2Name
        ' 
        lblDev2Name.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblDev2Name.ForeColor = Color.FromArgb(CByte(28), CByte(43), CByte(74))
        lblDev2Name.Location = New Point(18, 50)
        lblDev2Name.Name = "lblDev2Name"
        lblDev2Name.Size = New Size(410, 36)
        lblDev2Name.TabIndex = 1
        lblDev2Name.Text = "Developer 2"
        ' 
        ' lblDev2Role
        ' 
        lblDev2Role.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDev2Role.ForeColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
        lblDev2Role.Location = New Point(20, 88)
        lblDev2Role.Name = "lblDev2Role"
        lblDev2Role.Size = New Size(410, 24)
        lblDev2Role.TabIndex = 2
        lblDev2Role.Text = "Software Developer / UI & Reporting Specialist"
        ' 
        ' lblDev2EmailLbl
        ' 
        lblDev2EmailLbl.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblDev2EmailLbl.ForeColor = Color.FromArgb(CByte(130), CByte(140), CByte(155))
        lblDev2EmailLbl.Location = New Point(20, 124)
        lblDev2EmailLbl.Name = "lblDev2EmailLbl"
        lblDev2EmailLbl.Size = New Size(410, 18)
        lblDev2EmailLbl.TabIndex = 3
        lblDev2EmailLbl.Text = "CONTACT / EMAIL"
        ' 
        ' lblDev2Email
        ' 
        lblDev2Email.Font = New Font("Segoe UI", 9.5F)
        lblDev2Email.ForeColor = Color.FromArgb(CByte(40), CByte(44), CByte(52))
        lblDev2Email.Location = New Point(20, 144)
        lblDev2Email.Name = "lblDev2Email"
        lblDev2Email.Size = New Size(410, 22)
        lblDev2Email.TabIndex = 4
        lblDev2Email.Text = "dev2@example.com"
        ' 
        ' lblDev2ContribLbl
        ' 
        lblDev2ContribLbl.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblDev2ContribLbl.ForeColor = Color.FromArgb(CByte(130), CByte(140), CByte(155))
        lblDev2ContribLbl.Location = New Point(20, 180)
        lblDev2ContribLbl.Name = "lblDev2ContribLbl"
        lblDev2ContribLbl.Size = New Size(410, 18)
        lblDev2ContribLbl.TabIndex = 5
        lblDev2ContribLbl.Text = "AREAS OF RESPONSIBILITY"
        ' 
        ' lblDev2Contrib
        ' 
        lblDev2Contrib.Font = New Font("Segoe UI", 9.5F)
        lblDev2Contrib.ForeColor = Color.FromArgb(CByte(60), CByte(65), CByte(75))
        lblDev2Contrib.Location = New Point(20, 202)
        lblDev2Contrib.Name = "lblDev2Contrib"
        lblDev2Contrib.Size = New Size(410, 68)
        lblDev2Contrib.TabIndex = 6
        lblDev2Contrib.Text = "• UI/UX Layout & Form Synchronization" & vbCrLf & "• Report Generation & Analytics Engine" & vbCrLf & "• Chrome Receipt Printing & PDF Output"
        ' 
        ' pnlProjectInfo
        ' 
        pnlProjectInfo.BackColor = Color.White
        pnlProjectInfo.Controls.Add(lblProjectTitle)
        pnlProjectInfo.Controls.Add(lblProjectDesc)
        pnlProjectInfo.Controls.Add(lblTechStack)
        pnlProjectInfo.Controls.Add(lblVersion)
        pnlProjectInfo.Location = New Point(10, 320)
        pnlProjectInfo.Margin = New Padding(10)
        pnlProjectInfo.Name = "pnlProjectInfo"
        pnlProjectInfo.Padding = New Padding(20)
        pnlProjectInfo.Size = New Size(920, 180)
        pnlProjectInfo.TabIndex = 2
        ' 
        ' lblProjectTitle
        ' 
        lblProjectTitle.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblProjectTitle.ForeColor = Color.FromArgb(CByte(28), CByte(43), CByte(74))
        lblProjectTitle.Location = New Point(20, 16)
        lblProjectTitle.Name = "lblProjectTitle"
        lblProjectTitle.Size = New Size(880, 28)
        lblProjectTitle.TabIndex = 0
        lblProjectTitle.Text = "IMASTS — Inventory Management and Sales Tracking System"
        ' 
        ' lblProjectDesc
        ' 
        lblProjectDesc.Font = New Font("Segoe UI", 9.5F)
        lblProjectDesc.ForeColor = Color.FromArgb(CByte(80), CByte(85), CByte(95))
        lblProjectDesc.Location = New Point(20, 50)
        lblProjectDesc.Name = "lblProjectDesc"
        lblProjectDesc.Size = New Size(880, 40)
        lblProjectDesc.TabIndex = 1
        lblProjectDesc.Text = "Designed and engineered to deliver real-time inventory control, fast barcode scanning, automated sales tracking, and business intelligence."
        ' 
        ' lblTechStack
        ' 
        lblTechStack.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblTechStack.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lblTechStack.Location = New Point(20, 100)
        lblTechStack.Name = "lblTechStack"
        lblTechStack.Size = New Size(880, 24)
        lblTechStack.TabIndex = 2
        lblTechStack.Text = "Technology Stack:  .NET 8.0 Windows Forms (VB.NET)  |  Microsoft SQL Server  |  BCrypt.Net"
        ' 
        ' lblVersion
        ' 
        lblVersion.Font = New Font("Segoe UI", 8.5F)
        lblVersion.ForeColor = Color.FromArgb(CByte(120), CByte(125), CByte(135))
        lblVersion.Location = New Point(20, 134)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Size(880, 20)
        lblVersion.TabIndex = 3
        lblVersion.Text = "Release Version: v5.06  •  2026 All Rights Reserved"
        ' 
        ' frmDevelopers
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(245), CByte(246), CByte(248))
        ClientSize = New Size(980, 725)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmDevelopers"
        Text = "Developers Page"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        flpContainer.ResumeLayout(False)
        pnlDev1.ResumeLayout(False)
        pnlDev2.ResumeLayout(False)
        pnlProjectInfo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblPageHeader As Label
    Friend WithEvents lblPageSub As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents flpContainer As FlowLayoutPanel
    Friend WithEvents pnlDev1 As Panel
    Friend WithEvents lblDev1Badge As Label
    Friend WithEvents lblDev1Name As Label
    Friend WithEvents lblDev1Role As Label
    Friend WithEvents lblDev1EmailLbl As Label
    Friend WithEvents lblDev1Email As Label
    Friend WithEvents lblDev1ContribLbl As Label
    Friend WithEvents lblDev1Contrib As Label
    Friend WithEvents pnlDev2 As Panel
    Friend WithEvents lblDev2Badge As Label
    Friend WithEvents lblDev2Name As Label
    Friend WithEvents lblDev2Role As Label
    Friend WithEvents lblDev2EmailLbl As Label
    Friend WithEvents lblDev2Email As Label
    Friend WithEvents lblDev2ContribLbl As Label
    Friend WithEvents lblDev2Contrib As Label
    Friend WithEvents pnlProjectInfo As Panel
    Friend WithEvents lblProjectTitle As Label
    Friend WithEvents lblProjectDesc As Label
    Friend WithEvents lblTechStack As Label
    Friend WithEvents lblVersion As Label

End Class
