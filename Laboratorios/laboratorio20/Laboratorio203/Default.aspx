<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio203._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Productos - Laptops</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 400px; margin: 30px auto; border: 1px solid #ccc; padding: 20px;">
            <h2>CRUD Laptops</h2>

            <!-- Búsqueda por ID -->
            <div>
                <asp:Label ID="Label5" runat="server" Text="Buscar por ID: "></asp:Label>
                <asp:TextBox ID="tstId" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
            <hr />

            <!-- Campos -->
            <div>
                <asp:Label ID="Label1" runat="server" Text="ID: "></asp:Label>
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Precio: "></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Stock: "></asp:Label>
                <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            </div>

            <br />

            <!-- Botones CRUD -->
            <div>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            </div>

            <br />

            <!-- Salir -->
            <div>
                <asp:Button ID="btnSalir" runat="server" Text="Salir" OnClick="btnSalir_Click" />
            </div>

            <br />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
