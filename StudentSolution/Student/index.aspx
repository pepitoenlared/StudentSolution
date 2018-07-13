<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StudentSolution.Student.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Students</title>
    <link href="~/public/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <br />
    <div class="container">
        <div class="row">
            <div class="panel panel-primary">
                <div class="panel-heading">STUDENTS</div>
                <div class="panel-body">
                    <p>
                        <a href="new.aspx" class="btn btn-success">New</a>
                    </p>
                    <form runat="server" id="form1">
                        <table class="table">
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList runat="server" ID="searchTypeList" CssClass="form-control">
                                        <asp:ListItem Value="0">Select an Item (Type)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="searchName" CssClass="form-control" placeholder="Search Name..."></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="searchGender" CssClass="form-control">
                                        <asp:ListItem Value="0">Select an Item (Gender)</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="send_form" runat="server" text="Search" CssClass="btn btn-info" OnClick="searchData" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <asp:GridView ID="dataGridView" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                            <columns>
                                <asp:boundfield datafield="Id" headertext="ID"/>
                                <asp:boundfield datafield="Type.Name" headertext="Type"/>
                                <asp:boundfield datafield="Name" headertext="Name"/>
                                <asp:boundfield datafield="Gender" headertext="Gender"/>
                                <asp:boundfield datafield="Time" headertext="Time"/>
                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="edit.aspx?id={0}" />
                                <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="delete.aspx?id={0}" />
                            </columns>
                        </asp:GridView>
                    </form>

                    <%--<table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Type</th>
                                <th>Name</th>
                                <th>Gender</th>
                                <th>Time</th>
                                <th>Options</th>
                            </tr>
                            
                            <tr>
                                <td></td>
                                <td>
                                    <asp:DropDownList runat="server" ID="searchTypeList" CssClass="form-control">
                                        <asp:ListItem Value="0">Select an Item</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="searchName" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="searchGender" CssClass="form-control">
                                        <asp:ListItem Value="0">Select an Item</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td>
                                    <asp:Button ID="send_form" runat="server" text="Search" CssClass="btn btn-info" OnClick="searchData" />
                                </td>
                            </tr>
                            
                        </thead>
                        <tbody>
                            <% 
                                var count = 0;
                                foreach (var item in this.entities)
                                {
                                    count++; %>
                                    <tr>
                                        <td><%= item.Id %></td>
                                        <td><%= item.Type.Name %></td>
                                        <td><%= item.Name %></td>
                                        <td><%= item.Gender %></td>
                                        <td><%= item.Time %></td>
                                        <td>
                                            <a href="edit.aspx?id=<%= item.Id %>">Edit</a> &nbsp;
                                            <a href="javascript:void(0);" onclick="javascript: deleteItem('delete.aspx?id=<%= item.Id %>');">Delete</a>
                                        </td>
                                    </tr>
                            <%
                                }
                                %>
                        </tbody>
                    </table>--%>
                </div>
            </div>
        </div>
    </div>
   

    <script type="text/javascript" src="../public/js/funciones.js"></script>
</body>
</html>
