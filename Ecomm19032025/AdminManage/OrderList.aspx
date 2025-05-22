<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Ecomm19032025.AdminManage.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/dataTables.bootstrap4.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1>טבלת הזמנות</h1>

    <table class="table table-borderless table-hover">
        <thead>
            <tr>
                <th>מספר הזמנה</th>
                <th>מזהה משתמש</th>
                <th>סכום כולל</th>
                <th>סטטוס</th>
                <th>תאריך הזמנה</th>
                <th>ניהול</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RptOrders" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Oid") %></td>
                        <td><%# Eval("Uid") %></td>
                        <td><%# Eval("TotalAmount") %></td>
                        <td><%# Eval("Status") %></td>
                        <td><%# Eval("OrderDate", "{0:dd/MM/yyyy HH:mm}") %></td>
                        <td>
                            <button class="btn btn-sm dropdown-toggle more-horizontal" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="text-muted sr-only">ניהול</span>
                            </button>
                            <div class="dropdown-menu dropdown-menu-right">
                                <a class="dropdown-item" href="OrderDetails.aspx?Oid=<%# Eval("Oid") %>">צפייה</a>
                                <a class="dropdown-item" href="#">ביטול</a>
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