<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEvent
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
        Me.lblEventYear = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.btnAddEvent = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblEventYear
        '
        Me.lblEventYear.AutoSize = True
        Me.lblEventYear.Location = New System.Drawing.Point(78, 74)
        Me.lblEventYear.Name = "lblEventYear"
        Me.lblEventYear.Size = New System.Drawing.Size(82, 17)
        Me.lblEventYear.TabIndex = 0
        Me.lblEventYear.Text = "Event Year:"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(177, 74)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(115, 22)
        Me.txtYear.TabIndex = 1
        '
        'btnAddEvent
        '
        Me.btnAddEvent.Location = New System.Drawing.Point(77, 156)
        Me.btnAddEvent.Name = "btnAddEvent"
        Me.btnAddEvent.Size = New System.Drawing.Size(93, 35)
        Me.btnAddEvent.TabIndex = 2
        Me.btnAddEvent.Text = "Add Event"
        Me.btnAddEvent.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(209, 156)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(93, 35)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAddEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 244)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddEvent)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.lblEventYear)
        Me.Name = "frmAddEvent"
        Me.Text = "Add An Event"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEventYear As Label
    Friend WithEvents txtYear As TextBox
    Friend WithEvents btnAddEvent As Button
    Friend WithEvents btnCancel As Button
End Class
