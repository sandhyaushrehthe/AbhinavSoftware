<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Patient_Registration.aspx.vb" Inherits="HospitalManagementSystem.Patient_Registration" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet" href="css/bootstrap.min.css">
     <link rel="stylesheet" href="css/font-awesome.min.css">
     <link rel="stylesheet" href="css/animate.css">
     <link rel="stylesheet" href="css/owl.carousel.css">
     <link rel="stylesheet" href="css/owl.theme.default.min.css">
    <style type="text/css" >
        #appointment {
            padding-top: 30px;
          }
          #appointment .form-control {
            background: #f9f9f9;
            border: none;
            border-radius: 3px;
            box-shadow: none;
            font-size: 14px;
            font-weight: normal;
            margin-bottom: 15px;
            transition: all ease-in-out 0.4s;
          }
           #appointment button#cf-submit {
            background: #a5c422;
            color: #ffffff;
            font-weight: 600;
            height: 55px;
          }

          #appointment button#cf-submit:hover {
            background: #393939;
            color: #ffffff;
          }
          .form-control_display{
  display: block;
  width: 100%;
  height: 34px;
  padding: 6px 12px;
  font-size: 14px;
  line-height: 1.42857143;
  color: #555555;
  background-color: #fff;
  background-image: none;
  border: 1px solid #ccc;
  border-radius: 4px;
  -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
  -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
  -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
  -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
  transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
  transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
  transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
}
    </style>
    <section id="appointment" data-stellar-background-ratio="10" style="background-position: 0px 355.25px;">
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-sm-6">
                    <img src="Image/appoinment.jpg" style="width:100%;height:100%;" alt="">
                </div>
                <div class="col-md-6 col-sm-6">                         
                    <form id="appointment-form" role="form" method="post" action="#">
                        <div class="section-title wow fadeInUp" data-wow-delay="0.3s">
                            <h2 style="text-decoration: underline;font-variant-position: sub;">Make an appointment</h2>
                        </div>

                        <div class="wow fadeInUp" data-wow-delay="0.8s">
                            <div class="col-md-6 col-sm-6">
                                <label for="name">Name</label>                                
                                <asp:TextBox runat="server"  type="text" id="txtName" placeholder="Full Name" class="form-control"/>
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label for="age">Age</label>
                                <asp:TextBox runat="server" id="txtAge" name="age" placeholder="Your age"  MaxLength="2" class="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"/>
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <asp:Label for="date">DOB</asp:Label>
                                <asp:TextBox runat="server" type="date" id="txtDOB" name="txtdate" class="form-control" />
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label for="bg">Blood Group</label>
                                <asp:TextBox runat="server" id="txtBloodGroup" name="bg" placeholder="Your Blood Group" class="form-control" />
                            </div>                            
                            <div class="col-md-6 col-sm-6">
                                <label for="mobile">Mobile</label>
                                <asp:TextBox runat="server" type="tel" id="txtMobile" name="phone" placeholder="Your Mobile" maxlength="10" class="form-control" onkeypress="return isNumberKey(event)" />
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label for="email">Email</label>
                                <asp:TextBox runat="server" type="email" id="txtEmail" name="email" placeholder="abc@gmail.com" class="form-control"/>

                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label for="date">Select Date</label>
                                <asp:TextBox runat="server" type="date" ID="txtDate" name="date" class="form-control" />
                            </div>
                            <div class="col-md-6 col-sm-6">
                                <label for="address">Address</label>                               
                                <asp:TextBox runat="server" class="form-control" rows="1" id="txtAddress" name="message" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            
                            <%--<div class="col-xs-12 col-sm-12 col-md-12">                                     
                                <asp:Button runat="server" type="button" class="form-control" id="btnsave"  Text="Submit Button" style="background:#a5c422;" />
                            </div>--%>
                            <div class="col-md-12 col-sm-12 ">
                                <label for="date">Upload</label>
                               <asp:FileUpload ID="FileUpload1" runat="server"  /> <br /><br />
                               <asp:Button ID="btnUpload" Text="Upload file" onclick="btnUpload_Click"  />
                               <asp:Label runat="server" ID="lblFiles" ></asp:Label>
                                <asp:Button runat="server" type="submit" class="form-control" id="btnsave" Text="Submit Button"  style="background:#a5c422;color:#ffffff;font-weight: 600;height: 45px;width :500px !important;text-align:center;border-radius: 50px;" />
                                
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : evt.keyCode
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;
                return true;
            }

            //function CheckFile(Cntrl) {
            //    var file = document.getElementById(Cntrl.name);
            //    alert(file);
            //    var len = file.value.length;
            //    var ext = file.value;
            //    if (ext.substr(len - 3, len) != "pdf") {
            //        alert("Please select a doc or pdf file ");
            //        return false;
            //    }
            //}
        </script>        
    </section>
</asp:Content>
