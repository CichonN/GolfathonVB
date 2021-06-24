<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnManageGolfers = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnManageEvents = New System.Windows.Forms.Button()
        Me.btnManageGolferEvents = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnManageGolfers
        '
        Me.btnManageGolfers.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageGolfers.Location = New System.Drawing.Point(41, 79)
        Me.btnManageGolfers.Name = "btnManageGolfers"
        Me.btnManageGolfers.Size = New System.Drawing.Size(142, 69)
        Me.btnManageGolfers.TabIndex = 0
        Me.btnManageGolfers.Text = "Manage Golfers"
        Me.btnManageGolfers.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(222, 206)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(113, 44)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnManageEvents
        '
        Me.btnManageEvents.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageEvents.Location = New System.Drawing.Point(205, 79)
        Me.btnManageEvents.Name = "btnManageEvents"
        Me.btnManageEvents.Size = New System.Drawing.Size(142, 69)
        Me.btnManageEvents.TabIndex = 1
        Me.btnManageEvents.Text = "Manage Events"
        Me.btnManageEvents.UseVisualStyleBackColor = True
        '
        'btnManageGolferEvents
        '
        Me.btnManageGolferEvents.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageGolferEvents.Location = New System.Drawing.Point(369, 79)
        Me.btnManageGolferEvents.Name = "btnManageGolferEvents"
        Me.btnManageGolferEvents.Size = New System.Drawing.Size(142, 69)
        Me.btnManageGolferEvents.TabIndex = 3
        Me.btnManageGolferEvents.Text = "Manage Events/Golfers"
        Me.btnManageGolferEvents.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 330)
        Me.Controls.Add(Me.btnManageGolferEvents)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnManageEvents)
        Me.Controls.Add(Me.btnManageGolfers)
        Me.Name = "frmMain"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnManageGolfers As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnManageEvents As Button
    Friend WithEvents btnManageGolferEvents As Button
End Class
