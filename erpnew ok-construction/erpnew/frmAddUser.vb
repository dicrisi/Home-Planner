Imports System.Data.SqlClient
Public Class frmAddUser
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            If TextBox2.Text = TextBox3.Text Then
                cmd = New SqlCommand("insert into logDet values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Successfully Saved", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Password Miss Match", MsgBoxStyle.Critical)
            End If
            
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()

    End Sub
    Private Sub fillgrid()
        Dim da As New SqlDataAdapter("select * from logDet", cn)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        cn.Close()
    End Sub
    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillgrid()
        Button1_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim i As String = InputBox("Enter User ID to Delete", "Delete")
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("delete from logDet where uid='" & i & "'", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Deleted Successfully", MsgBoxStyle.Exclamation)
            cn.Close()
            fillgrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Dim iId As String
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        iId = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select * from logDet where uid='" & iId & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                ComboBox1.Text = dr(2)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("update logDet set pass='" & TextBox2.Text & "', utype='" & ComboBox1.Text & "' where uid=" & iId & "", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Data are Successfully Updated", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()
    End Sub
End Class