Imports System.Data.OleDb
Imports System.Data
Imports System.Data.SqlClient

Module modConnection

    Public cn As New OleDb.OleDbConnection
    Public cm As New OleDb.OleDbCommand
    Public dr As OleDbDataReader

    Public Sub connection()
        cn = New OleDb.OleDbConnection
        With cn
            .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../Program database.accdb;
Persist Security Info=False;"
            .Open()
        End With
    End Sub
End Module
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Table1TableAdapter.Fill(Me.Program_databaseDataSet.Table1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result = MessageBox.Show(" Are you sure you want to delete this id from the database", "MsgBox", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            'do things and delete
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        Me.Table1TableAdapter.Fill(Me.Program_databaseDataSet.Table1)
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
    Public Function Decipher(ByVal cipherText As String) As String
        Dim plainText As String = String.Empty
        Dim cipherInChars(cipherText.Length) As Char
        For i As Integer = 0 To cipherText.Length - 1
            cipherInChars(i) =
               Convert.ToChar((Convert.ToInt32(
               Convert.ToChar(cipherText(i))) + 5))
        Next
        plainText = New String(cipherInChars)
        Return plainText
    End Function
    Public Function numberencrypt(ByVal number As Int64) As Int64
        Return number * 7
    End Function
    Public Function numberdecrypt(ByVal number As Int64) As Int64
        Return number / 7
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ComboBox1.Text = Decipher(ComboBox1.Text)
        TextBox4.Text = Decipher(TextBox4.Text)
        TextBox3.Text = numberdecrypt(TextBox3.Text)
    End Sub

    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.Table1TableAdapter.FillBy(Me.Program_databaseDataSet.Table1)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class