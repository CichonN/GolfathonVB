' ************************************
' Neina Cichon
' 2020-07-26
' Golfathon - Assignment 8
' IT-102, Programming 2 
' ************************************


Option Strict On

Public Class frmAddGolfer
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'Close form
        Close()

    End Sub

    Private Sub frmAddGolfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            'Loop through the textboxes and clear them in case they have data in them after a delete
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            ' Open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No- warn the user
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboShirtSize.ValueMember = "intShirtSizeID"
            cboShirtSize.DisplayMember = "strShirtSizeDesc"
            cboShirtSize.DataSource = dt

            ' Select the first item in the list by default
            If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = -1

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            'Loop through the textboxes and clear them in case they have data in them after a delete
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            ' Open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No- warn the user
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboGender.ValueMember = "intGenderID"
            cboGender.DisplayMember = "strGenderDesc"
            cboGender.DataSource = dt

            ' Select the first item in the list by default
            If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = -1

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub
    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' create variables for first and last name and phone number
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim cboState As String = ""
        Dim strZip As String = ""
        Dim strPhone As String = ""
        Dim strEmail As String = ""
        Dim strShirtSize As String = ""
        Dim strGender As String = ""

        ' call validation---we MUST validate ALL input
        If ValidateInput(strFirstName, strLastName, strAddress, strCity, cboState, strZip, strPhone, strEmail, strShirtSize, strGender) = True Then

            ' pass inputs, now validated to sub AddPlayer to enter in DB
            AddGolfer(strFirstName, strLastName, strAddress, strCity, cboState, strZip, strPhone, strEmail, strShirtSize, strGender)

        End If

    End Sub





    Private Sub AddGolfer(ByVal FirstName As String, ByVal LastName As String, ByVal Address As String, ByVal City As String, ByVal States As String, ByVal Zip As String, ByVal Phone As String, ByVal Email As String, ByVal ShirtSize As String, ByVal Gender As String)

        ' create command object and integer for number of returned rows
        Dim cmdAddGolfer As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer ' this is what we pass in as the stored procedure requires it

        Try

            ' open database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' text to call stored proc
            cmdAddGolfer.CommandText = "EXECUTE uspAddGolfer '" & intPKID & "','" & FirstName & "','" & LastName & "','" & Address & "','" & City & "','" & States & "','" & Zip & "','" & Phone & "','" & Email & "','" & ShirtSize & "','" & Gender & "'"
            cmdAddGolfer.CommandType = CommandType.StoredProcedure

            ' Call stored proc which will insert the record 
            cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)

            ' this return is the # of rows affected
            intRowsAffected = cmdAddGolfer.ExecuteNonQuery()

            ' close database connection
            CloseDatabaseConnection()

            ' have to let the user know what happened 
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Golfer " & LastName & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()  ' close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try


    End Sub


    'Check all inputs, not proceeding if error
    Function ValidateInput(ByRef FirstName As String, ByRef LastName As String, ByRef Address As String, ByRef City As String, ByRef States As String, ByRef Zip As String, ByRef Phone As String, ByRef Email As String, ByRef ShirtSize As String, ByRef Gender As String) As Boolean

        'Validate inputs
        If Validation() = True Then
            If ValidateFirstName(FirstName) = True Then
                If ValidateLastName(LastName) = True Then
                    If ValidateAddress(Address) = True Then
                        If ValidateCity(City) = True Then
                            If ValidateStates(States) = True Then
                                If ValidateZipCode(Zip) = True Then
                                    If ValidatePhone(Phone) = True Then
                                        If ValidateEmail(Email) = True Then
                                            If ValidateShirtSize(ShirtSize) = True Then
                                                If ValidateGender(Gender) = True Then
                                                    Return True
                                                Else
                                                    Return False
                                                End If
                                            Else
                                                Return False
                                            End If
                                        Else
                                            Return False
                                        End If
                                    Else
                                        Return False
                                    End If
                                Else
                                    Return False
                                End If
                            Else
                                Return False
                            End If
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If



    End Function

    Public Function Validation() As Boolean

        ' loop through the textboxes and clear them in case they have data in them after a delete
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        'every this is good so return true
        Return True

    End Function

    'Create Function to Validate First Name
    Function ValidateFirstName(ByRef FirstName As String) As Boolean

        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("Please enter first name.")
            txtFirstName.BackColor = Color.Yellow     'Set color to yellow
            txtFirstName.Focus()    'set focus back to errored cell for user
            Return False
        Else
            FirstName = txtFirstName.Text
            Return True
        End If

    End Function

    'Create Function to Validate Last Name
    Function ValidateLastName(ByRef LastName As String) As Boolean

        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please enter last name.")
            txtLastName.BackColor = Color.Yellow     'Set color to yellow
            txtLastName.Focus()    'set focus back to errored cell for user
            Return False
        Else
            LastName = txtLastName.Text
            Return True
        End If

    End Function

    'Create Function to Validate First Name
    Function ValidateAddress(ByRef Address As String) As Boolean

        If txtAddress.Text = String.Empty Then
            MessageBox.Show("Please enter Address.")
            txtAddress.BackColor = Color.Yellow     'Set color to yellow
            txtAddress.Focus()    'set focus back to errored cell for user
            Return False
        Else
            Address = txtAddress.Text
            Return True
        End If

    End Function

    'Create Function to Validate City
    Function ValidateCity(ByRef City As String) As Boolean

        'Required field - checking if field is empty
        If txtCity.Text = String.Empty Then
            MessageBox.Show("Please enter City.")
            txtCity.BackColor = Color.Yellow     'Set color to yellow
            txtCity.Focus()    'set focus back to errored cell for user
            Return False
        ElseIf isNumeric(txtCity.Text) Then
            MessageBox.Show("Please enter a valid city name.")
            txtCity.BackColor = Color.Yellow     'Set color to yellow
            txtCity.Focus()    'set focus back to errored cell for user
            Return False
        Else
            City = txtCity.Text
            Return True
        End If

    End Function

    'Create Function to Validate Shirt Size
    Function ValidateEmail(ByRef Email As String) As Boolean

        'Required field - checking if field is empty
        If txtEmail.Text = String.Empty Then
            MessageBox.Show("Please enter email.")
            txtEmail.BackColor = Color.Yellow     'Set color to yellow
            txtEmail.Focus()    'set focus back to errored cell for user
            Return False
        Else
            Email = txtEmail.Text
            Return True
        End If

    End Function

    Function ValidateShirtSize(ByRef ShirtSize As String) As Boolean

        'Checking to make sure state has been selected
        If cboShirtSize.SelectedIndex = -1 Then
            MessageBox.Show("Please select Shirt Size.")
            cboShirtSize.BackColor = Color.Yellow
            cboShirtSize.Focus()
            Return False
        Else
            ShirtSize = (cboShirtSize.SelectedValue.ToString)
            Return True
        End If

    End Function



    'Create Function to Validate Gender
    Function ValidateGender(ByRef Gender As String) As Boolean

        'Checking to make sure state has been selected
        If cboGender.SelectedIndex = -1 Then
            MessageBox.Show("Please select Gender.")
            cboGender.BackColor = Color.Yellow
            cboGender.Focus()
            Return False
        Else
            Gender = (cboGender.SelectedValue.ToString)
            Return True
        End If


    End Function

    'Create Function to Validate State Combobox
    Function ValidateStates(ByRef State As String) As Boolean

        'Checking to make sure state has been selected
        If cboState.SelectedIndex = -1 Then
            MessageBox.Show("Please select state.")
            cboState.BackColor = Color.Yellow
            cboState.Focus()
            Return False
        Else
            State = (cboState.Text)
            Return True
        End If

    End Function

    'Create Function to validate phone number
    Function ValidatePhone(ByRef Phone As String) As Boolean

        'Validating Numbers Only
        If IsNumeric(txtPhone.Text) Then
            Phone = txtPhone.Text
            'Validating 10 digits only
            If Phone.Length = 10 Then
                Return True
            Else
                MessageBox.Show("Please enter 10 digit phone number. Numbers Only!")
                txtPhone.BackColor = Color.Yellow     'Set color to yellow
                txtPhone.Focus()    'set focus back to errored cell for user
                Return False
            End If
        Else
            MessageBox.Show("Please enter 10 digit phone number.")
            txtPhone.BackColor = Color.Yellow     'Set color to yellow
            txtPhone.Focus()    'set focus back to errored cell for user
            Return False
        End If
    End Function

    'Create Function to validate ZipCode
    Function ValidateZipCode(ByRef Zip As String) As Boolean

        'Validating Numbers Only
        If IsNumeric(txtZip.Text) Then
            Zip = txtZip.Text
            'Validating 5 digits only
            If Zip.Length = 5 Then
                Return True
            Else
                MessageBox.Show("Please enter 5 digit zip code.")
                txtZip.BackColor = Color.Yellow     'Set color to yellow
                txtZip.Focus()    'set focus back to errored cell for user
                Return False
            End If
        Else
            MessageBox.Show("Please enter 5 digit zip code.")
            txtZip.BackColor = Color.Yellow     'Set color to yellow
            txtZip.Focus()    'set focus back to errored cell for user
            Return False
        End If
    End Function


End Class