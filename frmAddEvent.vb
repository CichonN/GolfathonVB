' ************************************
' Neina Cichon
' 2020-07-26
' Golfathon - Assignment 8
' IT-102, Programming 2 
' ************************************


Option Strict On

Public Class frmAddEvent
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'Close Window
        Close()

    End Sub

    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        ' create variables for first and last name and phone number
        Dim intEventYear As Integer


        ' call validation---we MUST validate ALL input
        If Validation(intEventYear) = True Then

            ' pass inputs, now validated to sub AddPlayer to enter in DB
            AddEvent(intEventYear)

        End If




    End Sub

    Private Sub AddEvent(ByVal EventYear As Integer)

        ' create command object and integer for number of returned rows
        Dim cmdAddEvent As New OleDb.OleDbCommand()
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
            cmdAddEvent.CommandText = "EXECUTE uspAddEvent '" & intPKID & "','" & EventYear & "'"
            cmdAddEvent.CommandType = CommandType.StoredProcedure

            ' Call stored proc which will insert the record 
            cmdAddEvent = New OleDb.OleDbCommand(cmdAddEvent.CommandText, m_conAdministrator)

            ' this return is the # of rows affected
            intRowsAffected = cmdAddEvent.ExecuteNonQuery()

            ' close database connection
            CloseDatabaseConnection()

            ' have to let the user know what happened 
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert successful Event " & EventYear & " has been added.")

            Else
                MessageBox.Show("Insert failed")

            End If

            Close()  ' close the form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try



    End Sub

    Public Function Validation(ByRef EventYear As Integer) As Boolean

        txtYear.BackColor = Color.White


        ' check if something is entered in first name text box
        If txtYear.Text <> String.Empty Then
            If IsNumeric(txtYear.Text) Then
                If txtYear.Text.Length = 4 Then
                    If CInt(txtYear.Text) > 1900 Then
                        EventYear = CInt(txtYear.Text)   ' If something there put it in first name variable passed in
                        Return True 'Cause everything is swell. Woot
                    Else
                        ' text box is blank so tell user to enter Year, change back color to yellow,
                        ' put focus in text box and return false we don't want to continue
                        MessageBox.Show("Please enter a valid year. No time traveling to the past.")
                        txtYear.BackColor = Color.Yellow
                        txtYear.Focus()
                        Return False ' Return False cause 
                    End If
                Else
                        ' text box is blank so tell user to enter Year, change back color to yellow,
                        ' put focus in text box and return false we don't want to continue
                        MessageBox.Show("Please enter a 4 digit year.")
                    txtYear.BackColor = Color.Yellow
                    txtYear.Focus()
                    Return False ' Return False cause 
                End If
            Else
                ' text box is blank so tell user to enter Year, change back color to yellow,
                ' put focus in text box and return false we don't want to continue
                MessageBox.Show("Event Name must be a Year (Numeric).")
                txtYear.BackColor = Color.Yellow
                txtYear.Focus()
                Return False ' Return False because events cannot be made thousands of years in the future or past.
            End If
        Else
            ' text box is blank so tell user to enter Year, change back color to yellow,
            ' put focus in text box and return false we don't want to continue
            MessageBox.Show("Please enter Event Name.")
            txtYear.BackColor = Color.Yellow
            txtYear.Focus()
            Return False ' Return False cause someone forgot to type
        End If
    End Function



End Class