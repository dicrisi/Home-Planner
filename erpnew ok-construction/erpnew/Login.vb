Imports System.Data.SqlClient

Public Class Login
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd = New SqlCommand("SELECT * FROM logDet WHERE uid = '" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'", cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        If dr.Read Then
            uName = dr(0)
            uType = dr(2)
            MsgBox("Welcome " & TextBox1.Text & "")

            Dim frm As New frmMain
            frm.Show()
            Me.Hide()
        Else
            MsgBox("Invalid User ID ! Please Try Again")
        End If
        cn.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class