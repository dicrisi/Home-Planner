Imports System.Data.SqlClient

Module Module1
    Public cn As New SqlConnection("server=.\sqlexpress;integrated security=true;database=erp")
    Public cmd As New SqlCommand()
    Public uName As String
    Public uType As String

End Module
