Imports System.Data.SqlClient

Public Class frmEmployee

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox1.Enabled = False
        If cn.State = ConnectionState.Closed Then cn.Open()
        cmd = New SqlCommand("select max(eid) from emp", cn)
        Dim i As Integer = IIf(IsDBNull(cmd.ExecuteScalar), 0, cmd.ExecuteScalar) + 1
        TextBox1.Text = i
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
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
            cmd = New SqlCommand("insert into emp values('" & TextBox2.Text & "','" & DateTimePicker1.Value & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & DateTimePicker2.Value & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "'," & TextBox11.Text & ",'" & TextBox12.Text & "','" & TextBox13.Text & "')", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Successfully Saved", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()

    End Sub
    Private Sub fillgrid()
        Dim da As New SqlDataAdapter("select * from emp", cn)
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
            cmd = New SqlCommand("delete from emp where eid=" & i & "", cn)
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
            cmd = New SqlCommand("select * from emp where eid=" & iId & "", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                DateTimePicker1.Value = dr(2)
                TextBox4.Text = dr(3)
                TextBox5.Text = dr(4)
                TextBox6.Text = dr(5)
                DateTimePicker1.Value = dr(6)
                TextBox8.Text = dr(7)
                TextBox9.Text = dr(8)
                TextBox10.Text = dr(9)
                TextBox11.Text = dr(10)
                TextBox12.Text = dr(11)
                TextBox13.Text = dr(12)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("update emp set name='" & TextBox2.Text & "', dob='" & DateTimePicker1.Value & "',qft='" & TextBox4.Text & "',exp='" & TextBox5.Text & "',design='" & TextBox6.Text & "',doj='" & DateTimePicker2.Value & "',addr1='" & TextBox8.Text & "',addr2='" & TextBox9.Text & "',addr3='" & TextBox10.Text & "',pin=" & TextBox11.Text & ",ph='" & TextBox12.Text & "',mail='" & TextBox13.Text & "' where eid=" & iId & "", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Data are Successfully Updated", MsgBoxStyle.Exclamation)
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        fillgrid()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class