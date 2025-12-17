<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BufeteAbogados.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Gestión de Casos</title>
    <style>
        body { font-family: Arial; margin: 0; padding: 20px; background: #f0f4f8; }
        .container { max-width: 1200px; margin: 0 auto; background: white; padding: 30px; border-radius: 10px; box-shadow: 0 4px 20px rgba(0,0,0,0.1); }
        h1 { color: #1e3a8a; border-bottom: 3px solid #1e3a8a; padding-bottom: 10px; }
        .nav { background: #1e3a8a; padding: 15px; margin: -30px -30px 20px -30px; border-radius: 10px 10px 0 0; }
        .nav a { color: white; text-decoration: none; padding: 10px 20px; margin: 0 5px; background: rgba(255,255,255,0.2); border-radius: 5px; display: inline-block; }
        .nav a:hover { background: rgba(255,255,255,0.3); }
        .form-section { background: #f8fafc; padding: 20px; border-radius: 8px; margin-bottom: 30px; }
        .form-group { margin-bottom: 15px; }
        label { display: block; font-weight: bold; margin-bottom: 5px; color: #374151; }
        input[type="text"], input[type="date"], select, textarea { width: 100%; padding: 10px; border: 1px solid #d1d5db; border-radius: 5px; font-size: 14px; }
        .btn { padding: 12px 30px; margin: 5px; border: none; border-radius: 5px; cursor: pointer; font-size: 14px; font-weight: bold; }
        .btn-primary { background: #1e3a8a; color: white; }
        .btn-success { background: #16a34a; color: white; }
        .btn-primary:hover { background: #1e40af; }
        .btn-success:hover { background: #15803d; }
        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
        th { background: #1e3a8a; color: white; padding: 12px; text-align: left; }
        td { padding: 10px; border-bottom: 1px solid #e5e7eb; }
        tr:hover { background: #f9fafb; }
        .alert { padding: 15px; margin-bottom: 20px; border-radius: 5px; }
        .alert-success { background: #d1fae5; color: #065f46; border: 1px solid #6ee7b7; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="nav">
                <a href="Default.aspx" style="background: rgba(255,255,255,0.4);">📋 Gestión de Casos</a>
                <a href="Documentos.aspx">📁 Gestión de Documentos</a>
            </div>

            <h1>📋 FUNCIONALIDAD 1: Gestión de Casos Legales</h1>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
            
            <div class="form-section">
                <h2 style="margin-top: 0; color: #1e3a8a;">➕ Registrar Nuevo Caso</h2>
                
                <div class="form-group">
                    <label>Número de Caso: *</label>
                    <asp:TextBox ID="txtNumeroCaso" runat="server" placeholder="Ej: CASO-006"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNumeroCaso" runat="server" 
                        ControlToValidate="txtNumeroCaso" 
                        ErrorMessage="El número de caso es obligatorio" 
                        ForeColor="Red" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label>Título del Caso: *</label>
                    <asp:TextBox ID="txtTitulo" runat="server" placeholder="Ej: Demanda Laboral"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" 
                        ControlToValidate="txtTitulo" 
                        ErrorMessage="El título es obligatorio" 
                        ForeColor="Red" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label>Nombre del Cliente: *</label>
                    <asp:TextBox ID="txtCliente" runat="server" placeholder="Ej: Pedro González"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCliente" runat="server" 
                        ControlToValidate="txtCliente" 
                        ErrorMessage="El nombre del cliente es obligatorio" 
                        ForeColor="Red" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label>Abogado Asignado: *</label>
                    <asp:TextBox ID="txtAbogado" runat="server" placeholder="Ej: Dr. Carlos Mendoza"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label>Tipo de Caso:</label>
                    <asp:DropDownList ID="ddlTipoCaso" runat="server">
                        <asp:ListItem Value="">-- Seleccione --</asp:ListItem>
                        <asp:ListItem Value="Laboral">Laboral</asp:ListItem>
                        <asp:ListItem Value="Familia">Familia</asp:ListItem>
                        <asp:ListItem Value="Civil">Civil</asp:ListItem>
                        <asp:ListItem Value="Penal">Penal</asp:ListItem>
                        <asp:ListItem Value="Corporativo">Corporativo</asp:ListItem>
                        <asp:ListItem Value="Comercial">Comercial</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form-group">
                    <label>Fecha de Inicio: *</label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label>Descripción:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" placeholder="Descripción del caso..."></asp:TextBox>
                </div>
                
                <asp:Button ID="btnGuardar" runat="server" Text=" Guardar Caso" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text=" Limpiar Formulario" CssClass="btn btn-primary" OnClick="btnLimpiar_Click" CausesValidation="false" />
            </div>
            
            <h2 style="color: #1e3a8a;"> Lista de Casos Registrados</h2>
            <asp:GridView ID="gvCasos" runat="server" 
                AutoGenerateColumns="False" 
                OnRowDeleting="gvCasos_RowDeleting"
                DataKeyNames="CasoId"
                EmptyDataText="No hay casos registrados">
                <Columns>
                    <asp:BoundField DataField="NumeroCaso" HeaderText="Número" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="AbogadoAsignado" HeaderText="Abogado" />
                    <asp:BoundField DataField="TipoCaso" HeaderText="Tipo" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText=" Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>