Imports System.Data.SqlClient
Public Class frmCustomer

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd = New SqlCommand("select max(cid) from cust", cn)
        Dim i As Integer = IIf(IsDBNull(cmd.ExecuteScalar), 0, cmd.ExecuteScalar)
        TextBox1.Text = i + 1
        TextBox2.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("insert into cust values('" & TextBox2.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "'," & TextBox11.Text & ",'" & TextBox12.Text & "','" & TextBox13.Text & "')", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Saved", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()

    End Sub
    Private Sub fillgrid()
        Dim da As New SqlDataAdapter("select * from cust", cn)
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
            Dim i As Integer = InputBox("Enter Emp Id to Delete", "Delete")
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("delete from cust where cid=" & i & "", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Deleted Successfully", MsgBoxStyle.Exclamation)
            cn.Close()
            fillgrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Dim iId As Integer
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        iId = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select * from cust where cid=" & iId & "", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                TextBox8.Text = dr(2)
                TextBox9.Text = dr(3)
                TextBox10.Text = dr(4)
                TextBox11.Text = dr(5)
                TextBox12.Text = dr(6)
                TextBox13.Text = dr(7)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("update cust set cname='" & TextBox2.Text & "',addr1='" & TextBox8.Text & "',addr2='" & TextBox9.Text & "',addr3='" & TextBox10.Text & "',pin=" & TextBox11.Text & ",ph='" & TextBox12.Text & "',mail='" & TextBox13.Text & "' where cid=" & iId & "", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Data are Successfully Updated", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()
    End Sub
End Class