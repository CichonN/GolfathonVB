<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGolfers
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
        Me.cboGolfer = New System.Windows.Forms.ComboBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDeleteGolfer = New System.Windows.Forms.Button()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.lblShirtSize = New System.Windows.Forms.Label()
        Me.cboShirtSize = New System.Windows.Forms.ComboBox()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cboGolfer
        '
        Me.cboGolfer.FormattingEnabled = True
        Me.cboGolfer.Location = New System.Drawing.Point(59, 45)
        Me.cboGolfer.Name = "cboGolfer"
        Me.cboGolfer.Size = New System.Drawing.Size(342, 24)
        Me.cboGolfer.TabIndex = 0
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(56, 103)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(76, 17)
        Me.lblFirstName.TabIndex = 1
        Me.lblFirstName.Text = "First Name"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(56, 141)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(76, 17)
        Me.lblLastName.TabIndex = 2
        Me.lblLastName.Text = "Last Name"
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Location = New System.Drawing.Point(56, 179)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(102, 17)
        Me.lblStreet.TabIndex = 3
        Me.lblStreet.Text = "Street Address"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(56, 217)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(31, 17)
        Me.lblCity.TabIndex = 4
        Me.lblCity.Text = "City"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(56, 255)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(41, 17)
        Me.lblState.TabIndex = 5
        Me.lblState.Text = "State"
        '
        'lblZip
        '
        Me.lblZip.AutoSize = True
        Me.lblZip.Location = New System.Drawing.Point(56, 293)
        Me.lblZip.Name = "lblZip"
        Me.lblZip.Size = New System.Drawing.Size(65, 17)
        Me.lblZip.TabIndex = 6
        Me.lblZip.Text = "Zip Code"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(56, 331)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(103, 17)
        Me.lblPhone.TabIndex = 7
        Me.lblPhone.Text = "Phone Number"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(56, 369)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(42, 17)
        Me.lblEmail.TabIndex = 8
        Me.lblEmail.Text = "Email"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(56, 445)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(56, 17)
        Me.lblGender.TabIndex = 10
        Me.lblGender.Text = "Gender"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(180, 100)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(221, 22)
        Me.txtFirstName.TabIndex = 1
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(180, 138)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(221, 22)
        Me.txtLastName.TabIndex = 2
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(180, 176)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(221, 22)
        Me.txtAddress.TabIndex = 3
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(180, 214)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(221, 22)
        Me.txtCity.TabIndex = 4
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(180, 290)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(221, 22)
        Me.txtZip.TabIndex = 6
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(180, 328)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(221, 22)
        Me.txtPhone.TabIndex = 7
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(180, 366)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(221, 22)
        Me.txtEmail.TabIndex = 8
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(19, 510)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(98, 44)
        Me.btnSubmit.TabIndex = 11
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(128, 510)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(98, 44)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(180, 572)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 44)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(237, 510)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(98, 44)
        Me.btnAddNew.TabIndex = 13
        Me.btnAddNew.Text = "Add New Golfer"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDeleteGolfer
        '
        Me.btnDeleteGolfer.Location = New System.Drawing.Point(346, 510)
        Me.btnDeleteGolfer.Name = "btnDeleteGolfer"
        Me.btnDeleteGolfer.Size = New System.Drawing.Size(98, 44)
        Me.btnDeleteGolfer.TabIndex = 14
        Me.btnDeleteGolfer.Text = "Delete Golfer"
        Me.btnDeleteGolfer.UseVisualStyleBackColor = True
        '
        'cboGender
        '
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Location = New System.Drawing.Point(180, 441)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(221, 24)
        Me.cboGender.TabIndex = 10
        '
        'lblShirtSize
        '
        Me.lblShirtSize.AutoSize = True
        Me.lblShirtSize.Location = New System.Drawing.Point(56, 407)
        Me.lblShirtSize.Name = "lblShirtSize"
        Me.lblShirtSize.Size = New System.Drawing.Size(68, 17)
        Me.lblShirtSize.TabIndex = 9
        Me.lblShirtSize.Text = "Shirt Size"
        '
        'cboShirtSize
        '
        Me.cboShirtSize.FormattingEnabled = True
        Me.cboShirtSize.Location = New System.Drawing.Point(180, 403)
        Me.cboShirtSize.Name = "cboShirtSize"
        Me.cboShirtSize.Size = New System.Drawing.Size(221, 24)
        Me.cboShirtSize.TabIndex = 9
        '
        'cboState
        '
        Me.cboState.FormattingEnabled = True
        Me.cboState.Items.AddRange(New Object() {"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"})
        Me.cboState.Location = New System.Drawing.Point(180, 252)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(221, 24)
        Me.cboState.Sorted = True
        Me.cboState.TabIndex = 5
        '
        'frmManageGolfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 660)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.cboGender)
        Me.Controls.Add(Me.cboShirtSize)
        Me.Controls.Add(Me.btnDeleteGolfer)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.lblShirtSize)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblZip)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.lblStreet)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.cboGolfer)
        Me.Name = "frmManageGolfers"
        Me.Text = "Manage Golfers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboGolfer As ComboBox
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblStreet As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblState As Label
    Friend WithEvents lblZip As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents txtCity As TextBox
    Friend WithEvents txtZip As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnDeleteGolfer As Button
    Friend WithEvents cboGender As ComboBox
    Friend WithEvents lblShirtSize As Label
    Friend WithEvents cboShirtSize As ComboBox
    Friend WithEvents cboState As ComboBox
End Class
