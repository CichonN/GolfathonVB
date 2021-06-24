' ************************************
' Neina Cichon
' 2020-07-26
' Golfathon - Assignment 8
' IT-102, Programming 2 
' ************************************

Option Strict On

Public Class frmManageGolfers

    Private Sub frmManageGolfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboGolfer.ValueMember = "intGolferID"
            cboGolfer.DisplayMember = "strLastName"
            cboGolfer.DataSource = dt

            ' Select the first item in the list by default
            If cboGolfer.Items.Count > 0 Then cboGolfer.SelectedIndex = 0

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

        If cboState.Items.Count > 0 Then
            cboState.SelectedIndex = -1
        End If



    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        ' open the database
        If OpenDatabaseConnectionSQLServer() = False Then

            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' and close the form/application
            Me.Close()

        End If

        ' Build the select statement using PK from name selected
        strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID FROM TGolfers Where intGolferID = " & cboGolfer.SelectedValue.ToString

        ' Retrieve all the records 
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        ' load the data table from the reader
        dt.Load(drSourceTable)

        ' populate the text boxes with the data
        txtFirstName.Text = dt.Rows(0).Item(0).ToString
        txtLastName.Text = dt.Rows(0).Item(1).ToString
        txtAddress.Text = dt.Rows(0).Item(2).ToString
        txtCity.Text = dt.Rows(0).Item(3).ToString
        cboState.Text = dt.Rows(0).Item(4).ToString
        txtZip.Text = dt.Rows(0).Item(5).ToString
        txtPhone.Text = dt.Rows(0).Item(6).ToString
        txtEmail.Text = dt.Rows(0).Item(7).ToString
        cboShirtSize.SelectedValue = dt.Rows(0).Item(8).ToString
        cboGender.SelectedValue = dt.Rows(0).Item(9).ToString

        ' close the database connection
        CloseDatabaseConnection()

        'Set background colors to white
        txtFirstName.BackColor = Color.White
        txtLastName.BackColor = Color.White
        txtAddress.BackColor = Color.White
        txtCity.BackColor = Color.White
        cboState.BackColor = Color.White
        txtZip.BackColor = Color.White
        txtPhone.BackColor = Color.White
        txtEmail.BackColor = Color.White
        cboShirtSize.BackColor = Color.White
        cboGender.BackColor = Color.White

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' closes the program
        Close()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim strSelect As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intShirtSizeID As String
        Dim intGenderID As String
        Dim intRowsAffected As String

        'Set background colors to white
        txtFirstName.BackColor = Color.White
        txtLastName.BackColor = Color.White
        txtAddress.BackColor = Color.White
        txtCity.BackColor = Color.White
        cboState.BackColor = Color.White
        txtZip.BackColor = Color.White
        txtPhone.BackColor = Color.White
        txtEmail.BackColor = Color.White
        cboShirtSize.BackColor = Color.White
        cboGender.BackColor = Color.White

        ' thie will hold our Update statement
        Dim cmdUpdate As OleDb.OleDbCommand

        ' check to make sure all text boxes have data. No data no update!
        If Validation() = True Then
            ' open database
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No- warn the user
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' after you validate there is data put values into variables
            If Validation() = True Then

                strFirstName = txtFirstName.Text
                strLastName = txtLastName.Text
                strStreetAddress = txtAddress.Text
                strCity = txtCity.Text
                strState = cboState.Text
                strZip = txtZip.Text
                strPhoneNumber = txtPhone.Text
                strEmail = txtEmail.Text
                intShirtSizeID = (cboShirtSize.SelectedValue.ToString)
                intGenderID = (cboGender.SelectedValue.ToString)


                ' Build the select statement using PK from name selected
                strSelect = "Update TGolfers Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                "', " & "strStreetAddress = '" & strStreetAddress & "', " & "strCity = '" & strCity & "', " &
                 "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strPhoneNumber = '" & strPhoneNumber &
                 "', " & "strEmail = '" & strEmail & "', " & "intShirtSizeID = '" & cboShirtSize.SelectedValue.ToString & "', " & "intGenderID = '" & cboGender.SelectedValue.ToString & "' " &
                 "Where intGolferID = " & cboGolfer.SelectedValue.ToString



                ' uncomment out the following message box line to use as a tool to check your sql statement
                ' remember anything not a numeric value going into SQL Server must have single quotes '
                ' around it, including dates.

                'MessageBox.Show(strSelect)


                ' make the connection
                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowsAffected = CStr(cmdUpdate.ExecuteNonQuery())

                ' have to let the user know what happened 
                If intRowsAffected = CStr(1) Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                ' close the database connection
                CloseDatabaseConnection()

                ' call the Form Load sub to refresh the combo box data after a delete
                frmManageGolfers_Load(sender, e)
            End If
        End If


    End Sub

    'Public Function Validation() As Boolean

    '    ' loop through the textboxes and check to make sure there is data in them
    '    For Each cntrl As Control In Controls
    '        If TypeOf cntrl Is TextBox Then
    '            cntrl.BackColor = Color.White
    '            If cntrl.Text = String.Empty Then
    '                cntrl.BackColor = Color.Yellow
    '                cntrl.Focus()
    '                Return False
    '            End If
    '        End If
    '    Next

    '    'everything is good so return true
    '    Return True

    'End Function

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        'create new instance of the add form
        Dim AddGolfer As New frmAddGolfer

        'show the new form so any past data is not still on form
        AddGolfer.ShowDialog()

        'call the form load so the combo box refreshes with the current data
        frmManageGolfers_Load(sender, e)


    End Sub

    Private Sub btnDeleteGolfer_Click(sender As Object, e As EventArgs) Handles btnDeleteGolfer.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects

        ' open the database this is in module
        If OpenDatabaseConnectionSQLServer() = False Then

            ' No, warn the user ...
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' and close the form/application
            Me.Close()

        End If

        ' always ask before deleting!!!!
        result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & cboGolfer.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
        Select Case result
            Case DialogResult.Cancel
                MessageBox.Show("Action Canceled")
            Case DialogResult.No
                MessageBox.Show("Action Canceled")
            Case DialogResult.Yes


                ' Build the delete statement using PK from name selected
                ' must delete any child revords first
                strDelete = "Delete FROM TGolferEventYearSponsors Where intGolferID = " & cboGolfer.SelectedValue.ToString

                ' Delete the record(s) 
                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()

                ' now we can delete the parent record
                strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & cboGolfer.SelectedValue.ToString

                ' Delete the record(s) 
                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()

                strDelete = "Delete FROM TGolfers Where intGolferID = " & cboGolfer.SelectedValue.ToString

                ' Delete the record(s) 
                cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                intRowsAffected = cmdDelete.ExecuteNonQuery()

                ' Did it work?
                If intRowsAffected > 0 Then

                    ' Yes, success
                    MessageBox.Show("Delete successful")

                End If

        End Select


        ' close the database connection
        CloseDatabaseConnection()

        ' call the Form Load sub to refresh the combo box data after a delete
        frmManageGolfers_Load(sender, e)

        ''Set background colors to white
        'txtFirstName.BackColor = Color.White
        'txtLastName.BackColor = Color.White
        'txtAddress.BackColor = Color.White
        'txtCity.BackColor = Color.White
        'cboState.BackColor = Color.White
        'txtZip.BackColor = Color.White
        'txtPhone.BackColor = Color.White
        'txtEmail.BackColor = Color.White
        'cboShirtSize.BackColor = Color.White
        'cboGender.BackColor = Color.White

    End Sub

    Public Function Validation() As Boolean

        ' loop through the textboxes and check to make sure there is data in them
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

        'every thing is good so return true
        Return True

    End Function

    Private Sub cboNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGolfer.SelectedIndexChanged

        ' this Sub is called anytime the selected item is changed in the combo box.
        btnSubmit_Click(sender, e)

    End Sub

End Class