<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="StudentSolution.Student.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Edit Student</title>
    <link href="../public/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">EDIT STUDENT</div>
                <div class="panel-body">
                    <ol class="breadcrumb">
                        <li><a href="index.aspx">Home</a></li>
                        <li class="active">Edit Student</li>
                    </ol>

                    <!-- form -->
                    <form runat="server" method="post" id="form">
                        <p>
                            <asp:ValidationSummary runat="server" HeaderText="" DisplayMode="BulletList" CssClass="alert alert-danger" />
                        </p>
                        <p>
                            <asp:Label runat="server">Type</asp:Label>
                            <asp:DropDownList runat="server" ID="typeDropDownList" CssClass="form-control">
                            </asp:DropDownList>
                        </p>
                        <p>
                            <asp:Label runat="server">Name</asp:Label>
                            <asp:TextBox ID="name" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="name" ErrorMessage="The Name Field is Required." Display="none"></asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label runat="server">Gender</asp:Label>
                            <asp:DropDownList runat="server" ID="gender" CssClass="form-control">
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                        <hr />
                        <asp:HiddenField runat="server" ID="id" />
                        <asp:Button ID="send_form" runat="server" text="Save" CssClass="btn btn-default" OnClick="saveData" />
                    </form>
                    <!-- /form -->

                </div>
            </div>
        </div>
    </div>
</body>
</html>
