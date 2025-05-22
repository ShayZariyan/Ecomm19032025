<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ProductAddEdit.aspx.cs" Inherits="Ecomm19032025.AdminManage.ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="tinymce/tinymce.min.js"></script>
    <style>
        .ddl-bigger {
            height: 48px;
            font-size: 18px;
            padding: 6px 12px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h2 class="page-title">עריכת מוצרים</h2>
    <p class="text-muted">נא להזין את פרטי המוצר המבוקש ולבצע שמירה</p>

    <div class="card-deck">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">פרטי המוצר</strong>
            </div>
            <div class="card-body">

                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtPname" runat="server" Text="שם המוצר" />
                        <asp:TextBox ID="TxtPname" runat="server" CssClass="form-control" placeholder="יש להזין שם מוצר" />
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtPrice" runat="server" Text="מחיר" />
                        <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control" placeholder="יש להזין מחיר מוצר" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group col-md-3">
                        <asp:Label AssociatedControlID="TxtPicname" runat="server" Text="תמונת המוצר" />
                        <asp:HiddenField ID="HidPid" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtPicname" runat="server" CssClass="form-control" placeholder="יש להזין שם תמונת מוצר" />
                    </div>

                    <div class="form-group col-md-3">
                        <asp:Label AssociatedControlID="DDLCategory" runat="server" Text="בחר קטגוריה" />
                        <asp:DropDownList ID="DDLCategory" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group col-md-3">
                        <asp:Label AssociatedControlID="DDLStatus" runat="server" Text="סטטוס מוצר" />
                        <asp:DropDownList ID="DDLStatus" runat="server" CssClass="form-control ddl-bigger">
                            <asp:ListItem Text="פעיל" Value="1" />
                            <asp:ListItem Text="לא פעיל" Value="0" />
                        </asp:DropDownList>
                    </div>
                     <asp:Label runat="server" AssociatedControlID="UplPic" CssClass="form-label">הוסף תמונה</asp:Label>
                        <asp:FileUpload ID="UplPic" runat="server" CssClass="form-control mt-2" />

                    <div class="form-group col-md-6">
                        <asp:Label AssociatedControlID="TxtPdesc" runat="server" Text="תאור" />
                        <asp:TextBox ID="TxtPdesc" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="40" Rows="10" placeholder="יש להזין תאור" />
                    </div>
                </div>

                <asp:Button ID="BtnSave" Text="שמור" runat="server" OnClick="BtnSave_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server">
    <script>tinymce.init({
    selector: 'textarea#MainCnt_TxtPdesc',
            height: 500,
            plugins: [
                'advlist', 'autolink', 'lists', 'link', 'image', 'charmap', 'preview',
                'anchor', 'searchreplace', 'visualblocks', 'code', 'fullscreen',
                'insertdatetime', 'media', 'table', 'help', 'wordcount'
            ],
            toolbar: 'undo redo | blocks | ' +
                'bold italic backcolor | alignleft aligncenter ' +
                'alignright alignjustify | bullist numlist outdent indent | ' +
                'removeformat | help',
            content_style: 'body { font-family:Helvetica,Arial,sans-serif; font-size:16px }'
        });</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server">
</asp:Content>
