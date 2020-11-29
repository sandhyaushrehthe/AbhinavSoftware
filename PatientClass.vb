#Region "Import"
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Web.Configuration
#End Region

Public Class PatientClass
#Region "Private Variable"
    Dim objCon As SqlConnection
    Dim objCom As SqlCommand
    Dim objDataAdapter As SqlDataAdapter
    Dim msg As Int16
    Dim Str As String = ""


#End Region



#Region "Constructors"
    Sub New()
        objCon = New SqlConnection("Data Source=ADMIN-PC;Initial Catalog=HospitalManagementSystem;User ID=sandy;Password=abc123")
    End Sub

#End Region
#Region "Private Methods"

    Private Sub OpenConnection()
        If Not objCon.State = ConnectionState.Open Then
            objCon.Open()
        End If
    End Sub
#End Region
#Region "Public Methods"

    Private Sub CloseConnection()
        If Not objCon.State = ConnectionState.Closed Then
            objCon.Close()
        End If
    End Sub

#End Region

#Region "Save Patient Detail"
    Public Sub SavePatientDetail(ByVal Name As String, ByVal Age As Integer, ByVal DOB As DateTime, ByVal BloodGroup As String, ByVal Address As String, ByVal Mobile As String, ByVal Email As String, ByVal DateOfAppointment As Date, ByVal FileUpload As String)
        OpenConnection()
        objCom = New SqlCommand()
        objCom.Connection = objCon
        objCom.CommandType = CommandType.StoredProcedure
        objCom.CommandText = "[sp_InsertHMS_PatientRecord]"
        objCom.Parameters.AddWithValue("@Name", Name)
        objCom.Parameters.AddWithValue("@Age", Age)
        objCom.Parameters.AddWithValue("@DOB", DOB)
        objCom.Parameters.AddWithValue("@BloodGroup", BloodGroup)
        objCom.Parameters.AddWithValue("@Address", Address)
        objCom.Parameters.AddWithValue("@Mobile", Mobile)
        objCom.Parameters.AddWithValue("@Email", Email)
        objCom.Parameters.AddWithValue("@DateOfAppointment", DateOfAppointment)
        objCom.Parameters.AddWithValue("@fileUpload", FileUpload)

        objCom.Parameters.AddWithValue("@PatientID", 1)
        Str = objCom.ExecuteNonQuery()
        CloseConnection()
    End Sub
#End Region
End Class







