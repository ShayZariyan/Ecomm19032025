<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Ecomm19032025.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" dir="auto">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="constainer">
            <div class ="row">
                <div class="col-md-2 col-sm-4 col-lg=6">
                    <div><asp:TextBox BackColor="LightCyan" ID="txtuser" BorderStyle="Outset" BorderColor="Silver" BorderWidth="20px" runat="server" CssClass="form-control" placeholder="Enter User Name"/></div>
                    <div><asp:TextBox BackColor="LightCyan" ID="txtpass" BorderStyle="Outset" BorderColor="LightGray" BorderWidth="20px" runat="server" CssClass="form-control" placeholder="Enter Password"/></div>
                    <div><asp:Button BorderColor="YellowGreen" ID="btnlgn" Font-Bold="true"  BorderStyle="Groove" runat="server" CssClass="btn btn-success" Text="Login" OnClick="btnlgn_Click"/></div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"/></script>
</body>
</html>
