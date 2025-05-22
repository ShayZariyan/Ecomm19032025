<%@ Page Title="פרטי הזמנה" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="Ecomm19032025.AdminManage.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h1>פרטי הזמנה</h1>
    <a href="OrdersList.aspx" class="btn btn-secondary mb-3">חזרה לרשימת הזמנות</a>

    <table class="table table-bordered w-50">
        <tr>
            <th>קוד הזמנה:</th>
            <td><asp:Label ID="LblOid" runat="server" /></td>
        </tr>
        <tr>
            <th>קוד משתמש:</th>
            <td><asp:Label ID="LblUid" runat="server" /></td>
        </tr>
        <tr>
            <th>סה"כ לתשלום:</th>
            <td><asp:Label ID="LblTotalAmount" runat="server" /></td>
        </tr>
        <tr>
            <th>סטטוס:</th>
            <td><asp:Label ID="LblStatus" runat="server" /></td>
        </tr>
        <tr>
            <th>תאריך הזמנה:</th>
            <td><asp:Label ID="LblOrderDate" runat="server" /></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server">
</asp:Content>
