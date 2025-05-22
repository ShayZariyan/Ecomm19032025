<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderAddEdit.aspx.cs" Inherits="Ecomm19032025.AdminManage.OrderAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .ddl-bigger {
            height: 48px;
            font-size: 18px;
            padding: 6px 12px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h2 class="page-title">עריכת הזמנה</h2>
    <p class="text-muted">נא להזין את פרטי ההזמנה ולבצע שמירה</p>

    <div class="card-deck">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">פרטי ההזמנה</strong>
            </div>
            <div class="card-body">

                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtUid" runat="server" Text="מזהה משתמש" />
                        <asp:TextBox ID="TxtUid" runat="server" CssClass="form-control" placeholder="יש להזין מזהה משתמש" />
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtTotal" runat="server" Text="סכום כולל" />
                        <asp:TextBox ID="TxtTotal" runat="server" CssClass="form-control" placeholder="יש להזין סכום ההזמנה" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="DDLStatus" runat="server" Text="סטטוס הזמנה" />
                        <asp:DropDownList ID="DDLStatus" runat="server" CssClass="form-control ddl-bigger">
                            <asp:ListItem Text="חדש" Value="חדש" />
                            <asp:ListItem Text="שולם" Value="שולם" />
                            <asp:ListItem Text="נשלח" Value="נשלח" />
                            <asp:ListItem Text="בוטל" Value="בוטל" />
                        </asp:DropDownList>
                    </div>

                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtDate" runat="server" Text="תאריך ההזמנה" />
                        <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control" placeholder="תאריך" />
                    </div>
                </div>

                <asp:HiddenField ID="HidOid" runat="server" Value="-1" />

                <asp:Button ID="BtnSave" Text="שמור" runat="server" OnClick="BtnSave_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server" />
<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server" />