Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.Extensions.Configuration

Public Class Patient_Registration
    Inherits System.Web.UI.Page
#Region "Private Variable"

    Dim objBR As New PatientClass
    Dim dsSaveuserDetail1 As New DataSet
    Dim dr As DataRow
    Dim strFile As String
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Sub CreateDsForSave()
        dsSaveuserDetail1 = New DataSet
        dsSaveuserDetail1.Tables.Add("HMS_PatientRecord")
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("PatientID", Type.GetType("System.Int32"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("Name", Type.GetType("System.String"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("Age", Type.GetType("System.Int32"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("DOB", Type.GetType("System.DateTime"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("BloodGroup", Type.GetType("System.String"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("Address", Type.GetType("System.String"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("Mobile", Type.GetType("System.String"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("Email", Type.GetType("System.String"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("DateOfAppointment", Type.GetType("System.DateTime"))
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Columns.Add("fileUpload", Type.GetType("System.String"))

    End Sub


    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If txtName.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter Your Name')</script>", False)
            Exit Sub
        End If
        If txtAge.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter your Age')</script>", False)
            Exit Sub
        End If
        If txtAge.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter your Age')</script>", False)
            Exit Sub
        End If
        If txtDOB.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter your Date Of Birth')</script>", False)
            Exit Sub
        End If
        If txtBloodGroup.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Select your Blood Group')</script>", False)
            Exit Sub
        End If
        If txtMobile.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter your Mobile No')</script>", False)
            Exit Sub
        End If
        If txtEmail.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter your EmailID')</script>", False)
            Exit Sub
        End If

        If txtDate.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter Date Of Appointment')</script>", False)
            Exit Sub
        End If
        If txtAddress.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('Please Enter your Address')</script>", False)
            Exit Sub
        End If


        CreateDsForSave()
        Dim dr As DataRow
        dr = dsSaveuserDetail1.Tables("HMS_PatientRecord").NewRow()
        dr("Name") = txtName.Text
        dr("Age") = txtAge.Text
        dr("DOB") = CDate(txtDOB.Text)
        dr("BloodGroup") = txtBloodGroup.Text
        dr("Address") = txtAddress.Text
        dr("Mobile") = txtMobile.Text
        dr("Email") = txtEmail.Text
        dr("DateOfAppointment") = CDate(txtDate.Text)
        dr("fileUpload") = FileUpload1.FileName
        dsSaveuserDetail1.Tables("HMS_PatientRecord").Rows.Add(dr)
        dsSaveuserDetail1.AcceptChanges()

        If dsSaveuserDetail1.Tables("HMS_PatientRecord").Rows.Count <> 0 Then

            objBR.SavePatientDetail(txtName.Text, txtAge.Text, CDate(txtDOB.Text), txtBloodGroup.Text, txtAddress.Text, txtMobile.Text, txtEmail.Text, CDate(txtDate.Text), FileUpload1.FileName)
            'objBR.SavePatientDetail(dsSaveuserDetail1)
            Dim strMessage As String = "Patient Detail Save Successfully!."

            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Save", "<script>alert('" & strMessage & "')</script>", False)
            fnEmail()

            txtName.Text = ""
            txtAge.Text = ""
            txtDOB.Text = ""
            txtBloodGroup.Text = ""
            txtAddress.Text = ""
            txtMobile.Text = ""
            txtEmail.Text = ""
            txtDate.Text = ""
            'Response.Redirect("Patient_Registration.aspx")

        End If
    End Sub

    Public Sub fnEmail()
        Try
            Using mailMessage As New MailMessage("EmailFrom_ID", txtEmail.Text)               'FromEmailID , and ToEmailID

                mailMessage.Subject = "Confirmation Mail"
                mailMessage.Body = "Your Doctor appoinment today on time."
                mailMessage.IsBodyHtml = False
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential("userID", "Password")                  'USERID, PASSWORD
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = 587
                smtp.Send(mailMessage)
                ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)
            End Using
        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

    End Sub

End Class