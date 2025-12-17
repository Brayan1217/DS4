<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ClienteReservasUI.WebForm1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Inicio - Sistema de Reservas</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }
        .container {
            max-width: 1200px;
            margin: 0 auto;
            background-color: white;
            padding: 30px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        .menu-link {
            padding: 15px 25px;
            background-color: #5bc0de;
            color: white;
            text-decoration: none;
            margin-right: 10px;
            margin-bottom: 10px;
            display: inline-block;
            border-radius: 5px;
            font-weight: bold;
            transition: background-color 0.3s;
        }
        .menu-link:hover {
            background-color: #31b0d5;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1> Sistema de Reservas</h1>
            <hr />
            
            <h2>Bienvenido al Sistema de Gestión de Reservas</h2>
            
            <div style="margin-top: 30px;">
                <h3>Funcionalidades:</h3>
                <ul style="font-size: 16px; line-height: 2;">
                    <li>✅ Gestión de Clientes - Registrar y consultar pacientes</li>
                    <li>✅ Gestión de Reservas - Crear, ver y cancelar citas médicas</li>
                    <li>✅ Consultar Disponibilidad - Ver horarios disponibles de médicos</li>
                    <li>✅ Reportes - Estadísticas y reportes mensuales</li>
                </ul>
            </div>
            
            <div style="margin-top: 40px;">
                <h3> Acceso Rápido a Módulos:</h3>
                
                <asp:HyperLink ID="lnkClientes" runat="server" NavigateUrl="~/Clientes.aspx" CssClass="menu-link">
                    👤 Gestión de Clientes
                </asp:HyperLink>
                
                <asp:HyperLink ID="lnkReservas" runat="server" NavigateUrl="~/Reservas.aspx" CssClass="menu-link">
                    📅 Gestión de Reservas
                </asp:HyperLink>
                
                <asp:HyperLink ID="lnkDisponibilidad" runat="server" NavigateUrl="~/Disponibilidad.aspx" CssClass="menu-link">
                    🔍 Consultar Disponibilidad
                </asp:HyperLink>
                
                <asp:HyperLink ID="lnkReportes" runat="server" NavigateUrl="~/Reportes.aspx" CssClass="menu-link">
                    📊 Reportes e Informes
                </asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>