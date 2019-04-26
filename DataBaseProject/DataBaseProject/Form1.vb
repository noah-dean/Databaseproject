
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "Admin" And TextBox2.Text = "Password" Then
            Dim frmSecond As New Form2
            Hide()
            frmSecond.ShowDialog()
        Else
            MsgBox("Wrong username or password")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Call connection()
            MsgBox("Connected")
        Catch ex As Exception
            MsgBox("Failed to connect")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frmSecond As New Form2
        Hide()
        frmSecond.ShowDialog()
    End Sub
End Class
