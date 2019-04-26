Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try

            cm = New OleDb.OleDbCommand
            With cm
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO Table1 (ID,custname,phnumber,Address) VALUES (@ID,@custname,@phnumber,@Address)"

                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@ID", System.Data.OleDb.OleDbType.VarChar, 255, Me.TextBox2.Text))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@custname", System.Data.OleDb.OleDbType.VarChar, 255, Me.TextBox5.Text))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@phnumber", System.Data.OleDb.OleDbType.VarChar, 255, Me.TextBox6.Text))
                .Parameters.Add(New System.Data.OleDb.OleDbParameter("@Address", System.Data.OleDb.OleDbType.VarChar, 255, Me.TextBox7.Text))


                ' RUN THE COMMAND
                cm.Parameters("@ID").Value = Me.TextBox2.Text
                cm.Parameters("@custname").Value = encrypt(Me.TextBox5.Text)
                cm.Parameters("@phnumber").Value = Me.TextBox6.Text
                cm.Parameters("@Address").Value = encrypt(Me.TextBox7.Text)


                cm.ExecuteNonQuery()
                MsgBox("Record saved.", MsgBoxStyle.Information)
                Me.TextBox2.Text = ""
                Me.TextBox5.Text = ""
                Me.TextBox6.Text = ""
                Me.TextBox7.Text = ""
                Exit Sub
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        
    End Sub
    Public Function encrypt(ByVal plainText As String) As String
        Dim cipherText As String = String.Empty
        Dim cipherInChars(plainText.Length) As Char
        For i As Integer = 0 To plainText.Length - 1
            cipherInChars(i) =
               Convert.ToChar((Convert.ToInt32(
               Convert.ToChar(plainText(i))) + -5))
        Next
        cipherText = New String(cipherInChars)
        Return cipherText
    End Function
    Public Function numberencrypt(ByVal number As Int64) As Int64
        Return number * 7
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frmSecond As New Form2
        Hide()
        frmSecond.ShowDialog()
    End Sub
End Class