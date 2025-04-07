<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Ecomm19032025.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="auto">
<head runat="server">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600&display=swap" rel="stylesheet" />
    <style>
        body {
            font-family: 'Inter', sans-serif;
            background: linear-gradient(135deg, #1f1c2c, #928dab);
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
        }

        .login-card {
            background: rgba(255, 255, 255, 0.1);
            backdrop-filter: blur(16px);
            -webkit-backdrop-filter: blur(16px);
            border-radius: 20px;
            padding: 2rem;
            box-shadow: 0 8px 24px rgba(0, 0, 0, 0.25);
            color: #fff;
            width: 100%;
            max-width: 400px;
        }

        .form-control::placeholder {
            color: #ddd;
        }

        .form-control {
            background-color: rgba(255, 255, 255, 0.2);
            border: none;
            color: #fff;
        }

        .form-control:focus {
            background-color: rgba(255, 255, 255, 0.25);
            box-shadow: none;
            border: 1px solid #fff;
            color: #fff;
        }

        .btn-success {
            background-color: #28a745;
            border: none;
        }

        .btn-success:hover {
            background-color: #218838;
        }

        h3 {
            font-weight: 600;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-card text-center">
            <h3 class="mb-4">Welcome Back</h3>
            <div class="mb-3">
                <asp:TextBox ID="txtuser" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"
                    BackColor="Transparent" BorderStyle="None" BorderColor="Silver" BorderWidth="1px"/>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtpass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"
                    BackColor="Transparent" BorderStyle="None" BorderColor="LightGray" BorderWidth="1px"/>
            </div>
            <div class="d-grid mb-3">
                <asp:Button ID="btnlgn" runat="server" CssClass="btn btn-success" Text="Login" Font-Bold="true" BorderStyle="None" OnClick="CheckLgn" />
            </div>
            <div class="small">
                <asp:Literal ID="LtlMsg" runat="server" />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
