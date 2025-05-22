<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CategoryAddEdit.aspx.cs" Inherits="Ecomm19032025.AdminManage.CategoryAddEdit" %>


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
    <h2 class="page-title">עריכת קטגוריה</h2>
    <p class="text-muted">נא להזין את פרטי הקטגוריה ולבצע שמירה</p>

    <div class="card-deck">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">פרטי הקטגוריה</strong>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtCname" runat="server" Text="שם הקטגוריה" />
                        <asp:TextBox ID="TxtCname" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-12">
                        <asp:Label AssociatedControlID="TxtCdesc" runat="server" Text="תיאור הקטגוריה" />
                        <asp:TextBox ID="TxtCdesc" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="40" Rows="6" />
                    </div>
                </div>

                <asp:HiddenField ID="HidCid" runat="server" Value="-1" />

                <asp:Button ID="BtnSave" runat="server" Text="שמור" CssClass="btn btn-primary" OnClick="BtnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server" />
<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server" />