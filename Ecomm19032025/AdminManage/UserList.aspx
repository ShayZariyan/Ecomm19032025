<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Ecomm19032025.AdminManage.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1>טבלת ניהול משתמשים</h1>
    <a href="UserAddEdit.aspx" class="btn btn-info">הוספת משתמש</a>

    <table class="table table-borderless table-hover">
        <thead>
            <tr>
                <th>קוד משתמש</th>
                <th>שם מלא</th>
                <th>אימייל</th>
                <th>טלפון</th>
                <th>ניהול</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RptUsers" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Uid") %></td>
                        <td><%# Eval("Fname") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Phone") %></td>
                        <td>
                            <button class="btn btn-sm dropdown-toggle more-horizontal" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="text-muted sr-only">ניהול</span>
                            </button>
                            <div class="dropdown-menu dropdown-menu-right">
                                <a class="dropdown-item" href="UserAddEdit.aspx?Uid=<%# Eval("Uid") %>">עריכה</a>
                                <a class="dropdown-item" href="#">הסרה</a>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server">
    <script src='js/jquery.dataTables.min.js'></script>
    <script src='js/dataTables.bootstrap4.min.js'></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server">
</asp:Content>
