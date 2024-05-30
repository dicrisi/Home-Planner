Imports System.Data.SqlClient
Public Class frmSupplier

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd = New SqlCommand("select max(supid) from Supplier", cn)
        Dim i As Integer = IIf(IsDBNull(cmd.ExecuteScalar), 0, cmd.ExecuteScalar)
        TextBox1.Text = i + 1
        TextBox2.Text = ""
        TextBox3.Text = ""
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
            cmd = New SqlCommand("insert into Supplier values('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "'," & TextBox10.Text & ",'" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "')", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Saved", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()

    End Sub
    Private Sub fillgrid()
        Dim da As New SqlDataAdapter("select * from Supplier", cn)
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
            Dim i As Integer = InputBox("Enter Supplier Id to Delete", "Delete")
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("delete from Supplier where supid=" & i & "", cn)
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
            cmd = New SqlCommand("select * from Supplier where supid=" & iId & "", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(2)
                TextBox8.Text = dr(3)
                TextBox9.Text = dr(4)
                TextBox10.Text = dr(5)
                TextBox11.Text = dr(6)
                TextBox12.Text = dr(7)
                TextBox13.Text = dr(8)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("update Supplier set supname='" & TextBox2.Text & "',addr='" & TextBox3.Text & "',city='" & TextBox8.Text & "',state='" & TextBox9.Text & "',pin=" & TextBox10.Text & ",mail='" & TextBox11.Text & "',contactperson='" & TextBox12.Text & "',phno='" & TextBox13.Text & "' where supid=" & iId & "", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Data are Successfully Updated", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()
    End Sub
End Class