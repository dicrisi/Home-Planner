Imports System.Data.SqlClient
Public Class frmRawMat

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd = New SqlCommand("select max(proid) from prod", cn)
        Dim i As Integer = IIf(IsDBNull(cmd.ExecuteScalar), 0, cmd.ExecuteScalar)
        TextBox1.Text = i + 1
        TextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox3.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("insert into prod values('" & TextBox2.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox3.Text & "'," & TextBox4.Text & "," & ComboBox3.Text & ",'" & TextBox5.Text & "')", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Saved", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()

    End Sub
    Private Sub fillgrid()
        Dim da As New SqlDataAdapter("select * from prod", cn)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        cn.Close()
    End Sub
    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cmd As New SqlCommand("select supid,supname from supplier", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        ComboBox3.Items.Clear()
        While dr.Read
            ComboBox3.Items.Add(dr(0))
        End While
        dr.Close()
        fillgrid()
        Button1_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim i As Integer = InputBox("Enter Prod ID to Delete", "Delete")
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("delete from prod where proid=" & i & "", cn)
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
            cmd = New SqlCommand("select * from prod where proid=" & iId & "", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                ComboBox1.Text = dr(2)
                ComboBox2.Text = dr(3)
                TextBox3.Text = dr(4)
                TextBox4.Text = dr(5)
                ComboBox3.Text = dr(6)
                TextBox5.Text = dr(7)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("update prod set proname='" & TextBox2.Text & "',proqual='" & ComboBox1.Text & "',procategory='" & ComboBox2.Text & "',proRate=" & TextBox3.Text & ",unitperSqft=" & TextBox4.Text & ",supid=" & ComboBox3.Text & ",supname='" & TextBox5.Text & "' where proid=" & iId & "", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Data are Successfully Updated", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()
    End Sub

    Private Sub ComboBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.Leave
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select supname from supplier where supid=" & ComboBox3.Text & "", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox5.Text = dr(0)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
