' ************************************
' Neina Cichon
' 2020-07-26
' Golfathon - Assignment 8
' IT-102, Programming 2 
' ************************************

Option Strict On

Public Class frmManageEventGolfers
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'Closes the Program
        Close()

    End Sub

    Private Sub frmManageEventGolfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' form load will load the combo box. If you setup the combo box with a
        ' selected index change (see below) it will load the golfers from the
        ' event selected into to event golfers list box. Form load will also pull 
        ' golfers from the view in the DB that has golfers not on a event and load
        ' them into the Available golfers list box.

        Try

            ' *************************************************************************************
            ' LOAD EVENTS COMBO BOX
            ' *************************************************************************************

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            cboNames.BeginUpdate()

            ' Build the select statement for combo box for event
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboNames.ValueMember = "intEventYearID"
            cboNames.DisplayMember = "intEventYear"
            cboNames.DataSource = dt

            ' Select the first item in the list by default
            If cboNames.Items.Count > 0 Then cboNames.SelectedIndex = 0

            ' Show any changes
            cboNames.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()


            ' *************************************************************************************
            ' LOAD AVAILABLE GOLFERS LISTBOX
            ' *************************************************************************************
            Dim dt1 As DataTable = New DataTable ' this is the table we will load from our reader

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            lstAvailable.BeginUpdate()

            ' Build the select statement
            strSelect = "SELECT intGolferID, strLastName FROM vAvailableGolfers"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt1.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstAvailable.ValueMember = "intGolferID"
            lstAvailable.DisplayMember = "strLastName"
            lstAvailable.DataSource = dt1



            ' Select the first item in the list by default
            If lstAvailable.Items.Count > 0 Then lstAvailable.SelectedIndex = 0

            ' Show any changes
            lstAvailable.EndUpdate()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub



    Private Sub cboNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNames.SelectedIndexChanged
        ' create this SUB by double clicking on the combo box. This will load
        ' golfers on event based on index (DB PK) into the list box for event 
        ' golfer when combo box index changes.
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Show changes all at once at end (MUCH faster). 
            lstOnEvent.BeginUpdate()

            ' Build the select statement for listbox with golfers on event selected
            strSelect = "SELECT intGolferID, strLastName FROM vNotAvailableGolfers WHERE intEventYearID = ".ToString + cboNames.SelectedValue.ToString

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            lstOnEvent.ValueMember = "intGolferID"
            lstOnEvent.DisplayMember = "strLastName"
            lstOnEvent.DataSource = dt

            ' Select the first item in the list by default
            If lstOnEvent.Items.Count > 0 Then lstOnEvent.SelectedIndex = 0

            ' Show any changes
            lstOnEvent.EndUpdate()

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

        ' this SUB will add an available golfer to the event in the combo box. The 
        ' golfer will then show up in the event golfers list box when the event is selected
        ' in the combo box.

        Try

            Dim strInsert As String = ""
            Dim cmdInsert As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
            Dim intRowsAffected As Integer

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If


            ' Build the select statement
            strInsert = "INSERT INTO TGolferEventYears ( intEventYearID, intGolferID)" &
                        "Values (" & cboNames.SelectedValue.ToString & ", " & lstAvailable.SelectedValue.ToString & ")"

            ' Retrieve all the records 
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)


            intRowsAffected = cmdInsert.ExecuteNonQuery()


            ' close the database connection
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            frmManageEventGolfers_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnDropGolfer_Click(sender As Object, e As EventArgs) Handles btnDropGolfer.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult

        Try



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

            ' always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & lstOnEvent.Text & " from " & cboNames.Text & " ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from name selected
                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & lstOnEvent.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


            End Select


            ' close the database connection
            CloseDatabaseConnection()

            ' refresh the form so changes can be seen
            frmManageEventGolfers_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub
End Class