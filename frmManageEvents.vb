' ************************************
' Neina Cichon
' 2020-07-26
' Golfathon - Assignment 8
' IT-102, Programming 2 
' ************************************



Option Strict On

Public Class frmManageEvents
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'Closes window
        Close()

    End Sub

    Private Sub frmManageEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

            ''Loop through the textboxes and clear them in case they have data in them after a delete
            'For Each cntrl As Control In Controls
            '    If TypeOf cntrl Is TextBox Then
            '        cntrl.Text = String.Empty
            '    End If
            'Next

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
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfers data.
            ' We are binding the column name to the combo box display and value members. 
            cboEvents.ValueMember = "intEventYearID"
            cboEvents.DisplayMember = "intEventYear"
            cboEvents.DataSource = dt

            ' Select the first item in the list by default
            If cboEvents.Items.Count > 0 Then cboEvents.SelectedIndex = 0

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        'create new instance of the add form
        Dim AddEvent As New frmAddEvent

        'show the new form so any past data is not still on form
        AddEvent.ShowDialog()

        'call the form load so the combo box refreshes with the current data
        frmManageEvents_Load(sender, e)


    End Sub
End Class