' ************************************
' Neina Cichon
' 2020-07-26
' Golfathon - Assignment 8
' IT-102, Programming 2 
' ************************************



Option Strict On

Public Class frmMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        'Closes the Program
        Close()

    End Sub

    Private Sub btnManageGolfers_Click(sender As Object, e As EventArgs) Handles btnManageGolfers.Click

        ' create a new instance of the purchase form
        Dim ManageGolfers As New frmManageGolfers

        ' show new instance to user
        ManageGolfers.ShowDialog()

    End Sub

    Private Sub btnManageEvents_Click(sender As Object, e As EventArgs) Handles btnManageEvents.Click

        ' create a new instance of the purchase form
        Dim ManageEvents As New frmManageEvents

        ' show new instance to user
        ManageEvents.ShowDialog()

    End Sub

    Private Sub btnManageGolferEvents_Click(sender As Object, e As EventArgs) Handles btnManageGolferEvents.Click

        ' create a new instance of the manage team/players form
        Dim frmManage As New frmManageEventGolfers

        ' show the new form
        frmManage.ShowDialog()

    End Sub
End Class
