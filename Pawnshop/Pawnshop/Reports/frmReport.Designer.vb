<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport))
        Me.rv_display = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.webAds = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'rv_display
        '
        Me.rv_display.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rv_display.Location = New System.Drawing.Point(0, 0)
        Me.rv_display.Name = "rv_display"
        Me.rv_display.Size = New System.Drawing.Size(698, 493)
        Me.rv_display.TabIndex = 0
        '
        'webAds
        '
        Me.webAds.Location = New System.Drawing.Point(0, 27)
        Me.webAds.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAds.Name = "webAds"
        Me.webAds.ScrollBarsEnabled = False
        Me.webAds.Size = New System.Drawing.Size(315, 71)
        Me.webAds.TabIndex = 1
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 493)
        Me.Controls.Add(Me.webAds)
        Me.Controls.Add(Me.rv_display)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReport"
        Me.Text = "Report Viewer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_display As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents webAds As System.Windows.Forms.WebBrowser
End Class
