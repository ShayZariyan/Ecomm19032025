<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManage.aspx.cs" Inherits="Ecomm19032025.AdminManage.AdminManage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="auto">
<head runat="server">
    <title>Admin Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;600&display=swap" rel="stylesheet" />
    <style>
        body {
            font-family: 'Inter', sans-serif;
            background: linear-gradient(135deg, #1f1c2c, #928dab);
            min-height: 100vh;
            margin: 0;
            padding: 2rem;
            color: #fff;
        }

        .dashboard-card {
            background: rgba(255, 255, 255, 0.08);
            backdrop-filter: blur(12px);
            -webkit-backdrop-filter: blur(12px);
            border-radius: 20px;
            padding: 2rem;
            box-shadow: 0 8px 24px rgba(0, 0, 0, 0.25);
            color: #fff;
        }

        .dashboard-card h3 {
            font-weight: 600;
            margin-bottom: 1.5rem;
        }

        .stat-box {
            background: rgba(255, 255, 255, 0.1);
            padding: 1rem;
            border-radius: 12px;
            text-align: center;
            transition: 0.3s;
        }

        .stat-box:hover {
            background: rgba(255, 255, 255, 0.2);
        }

        .stat-title {
            font-size: 1rem;
            opacity: 0.8;
        }

        .stat-value {
            font-size: 1.8rem;
            font-weight: 600;
        }

        .btn-manage {
            background-color: #28a745;
            border: none;
            transition: 0.3s;
        }

        .btn-manage:hover {
            background-color: #218838;
        }

        .section-title {
            font-size: 1.2rem;
            font-weight: 600;
            margin-top: 2rem;
            margin-bottom: 1rem;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="container dashboard-card">
            <h3 class="text-center mb-4">Admin Dashboard</h3>

            <div class="row g-4">
                <div class="col-md-3">
                    <div class="stat-box">
                        <div class="stat-title">Total Products</div>
                        <div class="stat-value">125</div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="stat-box">
                        <div class="stat-title">Total Orders</div>
                        <div class="stat-value">300</div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="stat-box">
                        <div class="stat-title">Total Users</div>
                        <div class="stat-value">95</div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="stat-box">
                        <div class="stat-title">Pending Orders</div>
                        <div class="stat-value">12</div>
                    </div>
                </div>
            </div>

            <div class="row mt-4 text-center">
                <div class="col-md-3">
                    <asp:Button ID="btnManageProducts" runat="server" CssClass="btn btn-manage w-100" Text="Manage Products" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnManageOrders" runat="server" CssClass="btn btn-manage w-100" Text="Manage Orders" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnManageUsers" runat="server" CssClass="btn btn-manage w-100" Text="Manage Users" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnManageCategories" runat="server" CssClass="btn btn-manage w-100" Text="Manage Categories" />
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger px-5" Text="Logout" />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
