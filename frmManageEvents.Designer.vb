<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageEvents
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
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAddEvent = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboEvents
        '
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.Location = New System.Drawing.Point(86, 65)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.Size = New System.Drawing.Size(222, 24)
        Me.cboEvents.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(214, 137)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(94, 49)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddEvent
        '
        Me.btnAddEvent.Location = New System.Drawing.Point(86, 136)
        Me.btnAddEvent.Name = "btnAddEvent"
        Me.btnAddEvent.Size = New System.Drawing.Size(103, 50)
        Me.btnAddEvent.TabIndex = 2
        Me.btnAddEvent.Text = "Add New Event"
        Me.btnAddEvent.UseVisualStyleBackColor = True
        '
        'frmManageEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 233)
        Me.Controls.Add(Me.btnAddEvent)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.cboEvents)
        Me.Name = "frmManageEvents"
        Me.Text = "Manage Events"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboEvents As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnAddEvent As Button
End Class
