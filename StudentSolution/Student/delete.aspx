<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="StudentSolution.Student.delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Delete Item</title>
    <link href="~/public/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">Delete Item</div>
                <div class="panel-body">
                    <h3>Are you sure to delete the record?</h3>
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Type</th>
                                <th>Name</th>
                                <th>Gender</th>
                                <th>Time</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><%= this.entity.Id %></td>
                                <td><%= this.entity.Type.Name %></td>
                                <td><%= this.entity.Name %></td>
                                <td><%= this.entity.Gender %></td>
                                <td><%= this.entity.Time %></td>
                            </tr>
                        </tbody>
                    </table>
                    <hr />
                    <form id="form2" runat="server">
                        <a href="index.aspx" class="btn btn-default">Cancel</a> &nbsp;&nbsp;
                        <asp:Button ID="send_form" runat="server" text="Delete" CssClass="btn btn-danger" OnClick="deleteItem" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
