Imports System.Data.SqlClient
Public Class frmChangePwd

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If TextBox3.Text = TextBox4.Text Then
                If cn.State = ConnectionState.Closed Then cn.Open()
                cmd = New SqlCommand("select * from logdet where uid= '" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                If dr.Read Then
                    dr.Close()
                    cmd = New SqlCommand("update logdet set pass='" & TextBox3.Text & "' where uid= '" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    MsgBox("Password Changed Successfully")

                Else
                    MsgBox("Old Password is Wrong")
                End If
                cn.Close()
            Else
                MsgBox("Retype Password Mismatch")
            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub frmChangePwd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox1.Text = uName
        TextBox5.Text = uType
    End Sub
End Class