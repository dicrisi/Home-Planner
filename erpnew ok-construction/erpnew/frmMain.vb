Public Class frmMain



    Private Sub ADMINLOGINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADMINLOGINToolStripMenuItem.Click
        Dim frm As New frmEmployee
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub USERLOGINToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERLOGINToolStripMenuItem.Click
        Dim frm As New frmCustomer
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        Dim frm As New frmSupplier
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RawMaterialsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RawMaterialsToolStripMenuItem.Click
        Dim frm As New frmRawMat
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim frm As New frmChangePwd
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AddUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUserToolStripMenuItem.Click
        Dim frm As New frmAddUser
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub LabourDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabourDetailsToolStripMenuItem.Click
        Dim frm As New frmLabour
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionToolStripMenuItem.Click
        Dim frm As New frmTrans
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        Dim frm As New frmCustRpt
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem1.Click
        Dim frm As New frmSupRpt
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsToolStripMenuItem.Click
        Dim frm As New frmProdRpt
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub QuotationReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationReportToolStripMenuItem.Click
        Dim frm As New frmQuotReport
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
