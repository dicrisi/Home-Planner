Imports System.Data.SqlClient

Public Class frmTrans
    

    'Private Sub TextBox33_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox33.GotFocus
    '    TextBox33.Text = Val(TextBox31.Text) * Val(ComboBox11.SelectedItem)

    'End Sub

    'Private Sub TextBox36_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox36.GotFocus
    '    TextBox36.Text = Val(TextBox34.Text) * Val(TextBox35.Text)

    'End Sub

    Private Sub frmTrans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select * from cust", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr(0))
            End While
            dr.Close()

            cmd = New SqlCommand("select * from prod", cn)
            Dim dr1 As SqlDataReader
            dr1 = cmd.ExecuteReader
            While dr1.Read
                If dr1(3).ToString = "Bricks" Then
                    ComboBox2.Items.Add(dr1(1))
                    ComboBox7.Items.Add(dr1(7))
                    ComboBox14.Items.Add(dr1(2))
                ElseIf dr1(3).ToString = "Stone" Then
                    ComboBox3.Items.Add(dr1(1))
                    ComboBox8.Items.Add(dr1(7))
                    ComboBox15.Items.Add(dr1(2))
                ElseIf dr1(3).ToString = "Mud and Clay" Then
                    ComboBox4.Items.Add(dr1(1))
                    ComboBox9.Items.Add(dr1(7))
                    ComboBox16.Items.Add(dr1(2))
                ElseIf dr1(3).ToString = "Cement" Then
                    ComboBox5.Items.Add(dr1(1))
                    ComboBox10.Items.Add(dr1(7))
                    ComboBox17.Items.Add(dr1(2))
                ElseIf dr1(3).ToString = "Metal" Then
                    ComboBox12.Items.Add(dr1(1))
                    ComboBox13.Items.Add(dr1(7))
                    ComboBox18.Items.Add(dr1(2))
                ElseIf dr1(3).ToString = "Paint" Then
                    ComboBox6.Items.Add(dr1(1))
                    ComboBox20.Items.Add(dr1(7))
                    ComboBox19.Items.Add(dr1(2))
                End If

            End While
            dr1.Close()

            cmd = New SqlCommand("select * from labdetails", cn)
            Dim dr2 As SqlDataReader
            dr2 = cmd.ExecuteReader
            While dr2.Read
                If dr2(3) = "Painter" Then
                    ComboBox11.Items.Add(dr2(1))
                End If

            End While
            dr2.Close()

            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select * from cust where cid=" & ComboBox1.Text & "", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(6)
            End If
            dr.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        TabControl1.SelectedIndex = TabControl1.SelectedIndex - 1
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged, ComboBox15.SelectedIndexChanged
        TextBox13.Text = getRate(ComboBox3.Text, ComboBox8.Text, ComboBox15.Text)
    End Sub

    Private Sub ComboBox14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox14.SelectedIndexChanged
        TextBox12.Text = getRate(ComboBox2.Text, ComboBox7.Text, ComboBox14.Text)
    End Sub

    Private Function getRate(ByVal pName As String, ByVal sup As String, ByVal qual As String) As Integer
        Dim iRate As Integer
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select prorate from prod where proname='" & pName & "' and supname='" & sup & "' and proqual='" & qual & "'", cn)
            iRate = cmd.ExecuteScalar
            If iRate = 0 Then
                MsgBox("No Product Quality Found")
            End If

            cn.Close()
            Return iRate
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox17.SelectedIndexChanged
        TextBox15.Text = getRate(ComboBox5.Text, ComboBox10.Text, ComboBox17.Text)
    End Sub

    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox16.SelectedIndexChanged
        TextBox14.Text = getRate(ComboBox4.Text, ComboBox9.Text, ComboBox16.Text)
    End Sub

    Private Sub ComboBox18_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox18.SelectedIndexChanged
        TextBox37.Text = getRate(ComboBox12.Text, ComboBox13.Text, ComboBox18.Text)
    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged
        TextBox47.Text = Val(TextBox6.Text) * Val(TextBox68.Text) * Val(TextBox18.Text)
    End Sub

    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged
        TextBox46.Text = Val(TextBox7.Text) * Val(TextBox67.Text) * Val(TextBox17.Text)
    End Sub

    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.TextChanged
        TextBox50.Text = Val(TextBox8.Text) * Val(TextBox71.Text) * Val(TextBox21.Text)
    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged
        TextBox49.Text = Val(TextBox10.Text) * Val(TextBox70.Text) * Val(TextBox20.Text)
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged
        TextBox48.Text = Val(TextBox9.Text) * Val(TextBox69.Text) * Val(TextBox19.Text)
    End Sub

    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox22.TextChanged
        TextBox51.Text = Val(TextBox11.Text) * Val(TextBox72.Text) * Val(TextBox22.Text)
    End Sub

    Private Sub TextBox23_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox23.TextChanged
        TextBox52.Text = Val(TextBox16.Text) * Val(TextBox73.Text) * Val(TextBox23.Text)
    End Sub
    Dim iTotWidth, iTotLength As Integer

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox24.Text = Val(TextBox47.Text) + Val(TextBox46.Text) + Val(TextBox50.Text) + Val(TextBox49.Text) + Val(TextBox48.Text) + Val(TextBox51.Text) + Val(TextBox52.Text)
        iTotWidth = Val(TextBox67.Text) + Val(TextBox68.Text) + Val(TextBox71.Text) + Val(TextBox70.Text) + Val(TextBox69.Text) + Val(TextBox72.Text) + Val(TextBox73.Text)
        iTotLength = Val(TextBox18.Text) + Val(TextBox17.Text) + Val(TextBox21.Text) + Val(TextBox20.Text) + Val(TextBox19.Text) + Val(TextBox22.Text) + Val(TextBox23.Text)
        TextBox35.Text = (iTotWidth * 9 * 2) + (iTotLength * 9 * 2)
        TextBox5.Text = Val(TextBox6.Text) + Val(TextBox7.Text) + Val(TextBox8.Text) + Val(TextBox10.Text) + Val(TextBox9.Text) + Val(TextBox11.Text) + Val(TextBox16.Text)
        TextBox75.Text = (Val(TextBox12.Text) + Val(TextBox13.Text) + Val(TextBox14.Text) + Val(TextBox15.Text) + Val(TextBox37.Text)) * Val(TextBox24.Text)
    End Sub

    Private Sub TextBox27_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox27.TextChanged
        TextBox28.Text = (Val(TextBox25.Text) * Val(TextBox26.Text)) + Val(TextBox27.Text)
    End Sub

    Private Sub TextBox32_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox32.TextChanged
        TextBox29.Text = Val(TextBox30.Text) + Val(TextBox32.Text)
    End Sub

    Private Sub ComboBox19_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox19.SelectedIndexChanged
        TextBox74.Text = getRate(ComboBox6.Text, ComboBox20.Text, ComboBox19.Text)
        TextBox36.Text = Val(TextBox74.Text) * Val(TextBox35.Text)

    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox11.SelectedIndexChanged
        Try
            If cn.State = ConnectionState.Closed Then cn.Open()
            cmd = New SqlCommand("select salsft from labdetails where labname='" & ComboBox11.Text & "' and worktype='Painter'", cn)
            Dim iPaintRate As Integer
            iPaintRate = cmd.ExecuteScalar
            TextBox31.Text = iPaintRate
            TextBox33.Text = Val(TextBox35.Text) * Val(TextBox31.Text)
            TextBox34.Text = Val(TextBox36.Text) + Val(TextBox33.Text)
            cn.Close()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub TabPage7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage7.Click
        TextBox54.Text = TextBox24.Text
        TextBox53.Text = TextBox75.Text
        TextBox61.Text = Val(TextBox54.Text) * 350

        TextBox56.Text = TextBox25.Text
        TextBox57.Text = Val(TextBox25.Text) * Val(TextBox26.Text)
        TextBox62.Text = Val(TextBox25.Text) * Val(TextBox27.Text)

        TextBox77.Text = TextBox30.Text
        TextBox78.Text = TextBox32.Text

        TextBox55.Text = TextBox35.Text
        TextBox58.Text = TextBox36.Text
        TextBox63.Text = TextBox33.Text

        TextBox59.Text = Val(TextBox39.Text) + Val(TextBox43.Text)
        TextBox60.Text = (Val(TextBox39.Text) * Val(TextBox38.Text)) + (Val(TextBox43.Text) * Val(TextBox42.Text))
        TextBox64.Text = (Val(TextBox39.Text) * Val(TextBox41.Text)) + (Val(TextBox43.Text) * Val(TextBox45.Text))

        If CheckBox1.Checked = True Then
            TextBox65.Text = Val(TextBox53.Text) + Val(TextBox57.Text) + Val(TextBox77.Text) + Val(TextBox58.Text) + Val(TextBox60.Text) + 20000
            TextBox66.Text = Val(TextBox61.Text) + Val(TextBox62.Text) + Val(TextBox78.Text) + Val(TextBox63.Text) + Val(TextBox64.Text) + 10000

        Else
            TextBox65.Text = Val(TextBox53.Text) + Val(TextBox57.Text) + Val(TextBox77.Text) + Val(TextBox58.Text) + Val(TextBox60.Text)
            TextBox66.Text = Val(TextBox61.Text) + Val(TextBox62.Text) + Val(TextBox78.Text) + Val(TextBox63.Text) + Val(TextBox64.Text)
        End If

       
        
    End Sub

    Private Sub TextBox41_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox41.TextChanged
        TextBox40.Text = (Val(TextBox39.Text) * Val(TextBox38.Text)) + Val(TextBox41.Text)
    End Sub

    Private Sub TextBox45_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox45.TextChanged
        TextBox44.Text = (Val(TextBox43.Text) * Val(TextBox42.Text)) + Val(TextBox45.Text)
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox54.Text = TextBox24.Text
        TextBox53.Text = TextBox75.Text
        TextBox61.Text = Val(TextBox54.Text) * 350

        TextBox56.Text = TextBox25.Text
        TextBox57.Text = Val(TextBox25.Text) * Val(TextBox26.Text)
        TextBox62.Text = Val(TextBox25.Text) * Val(TextBox27.Text)

        TextBox77.Text = TextBox30.Text
        TextBox78.Text = TextBox32.Text

        TextBox55.Text = TextBox35.Text
        TextBox58.Text = TextBox36.Text
        TextBox63.Text = TextBox33.Text

        TextBox59.Text = Val(TextBox39.Text) + Val(TextBox43.Text)
        TextBox60.Text = (Val(TextBox39.Text) * Val(TextBox38.Text)) + (Val(TextBox43.Text) * Val(TextBox42.Text))
        TextBox64.Text = (Val(TextBox39.Text) * Val(TextBox41.Text)) + (Val(TextBox43.Text) * Val(TextBox45.Text))

        If CheckBox1.Checked = True Then
            TextBox65.Text = Val(TextBox53.Text) + Val(TextBox57.Text) + Val(TextBox77.Text) + Val(TextBox58.Text) + Val(TextBox60.Text) + 20000
            TextBox66.Text = Val(TextBox61.Text) + Val(TextBox62.Text) + Val(TextBox78.Text) + Val(TextBox63.Text) + Val(TextBox64.Text) + 10000

        Else
            TextBox65.Text = Val(TextBox53.Text) + Val(TextBox57.Text) + Val(TextBox77.Text) + Val(TextBox58.Text) + Val(TextBox60.Text)
            TextBox66.Text = Val(TextBox61.Text) + Val(TextBox62.Text) + Val(TextBox78.Text) + Val(TextBox63.Text) + Val(TextBox64.Text)
        End If
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cmd As New SqlCommand("insert into quotation values ('" & System.DateTime.Now.Date & "'," & ComboBox1.Text & ",'" & TextBox2.Text & "'," & TextBox54.Text & "," & TextBox53.Text & "," & TextBox61.Text & "," & TextBox56.Text & "," & TextBox57.Text & "," & TextBox62.Text & "," & TextBox77.Text & "," & TextBox78.Text & "," & TextBox55.Text & "," & TextBox58.Text & "," & TextBox63.Text & "," & TextBox59.Text & "," & TextBox60.Text & "," & TextBox64.Text & "," & TextBox65.Text & "," & TextBox66.Text & ")", cn)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Quotation Updated Successfully")
    End Sub
End Class