<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="SistemaReservas.Web.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Clientes</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }
        
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            padding: 20px;
        }
        
        .container {
            max-width: 1200px;
            margin: 0 auto;
        }
        
        .back-button {
            display: inline-block;
            background: white;
            color: #667eea;
            padding: 10px 20px;
            border-radius: 8px;
            text-decoration: none;
            margin-bottom: 20px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
            transition: all 0.3s ease;
        }
        
        .back-button:hover {
            transform: translateY(-2px);
            box-shadow: 0 4px 10px rgba(0,0,0,0.2);
        }
        
        .header {
            background: white;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.2);
            margin-bottom: 30px;
        }
        
        h1 {
            color: #4CAF50;
            font-size: 32px;
            margin-bottom: 10px;
        }
        
        .content-grid {
            display: grid;
            grid-template-columns: 1fr 2fr;
            gap: 30px;
        }
        
        .form-card, .list-card {
            background: white;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.1);
        }
        
        h2 {
            color: #333;
            margin-bottom: 20px;
            font-size: 24px;
            border-bottom: 3px solid #4CAF50;
            padding-bottom: 10px;
        }
        
        .form-group {
            margin-bottom: 20px;
        }
        
        label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
            color: #555;
        }
        
        input[type="text"],
        input[type="email"],
        input[type="tel"] {
            width: 100%;
            padding: 12px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 16px;
            transition: border-color 0.3s;
        }
        
        input:focus {
            outline: none;
            border-color: #4CAF50;
        }
        
        .btn {
            background: #4CAF50;
            color: white;
            padding: 12px 30px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
            width: 100%;
            transition: all 0.3s ease;
        }
        
        .btn:hover {
            background: #45a049;
            transform: translateY(-2px);
            box-shadow: 0 4px 10px rgba(0,0,0,0.2);
        }
        
        .clientes-list {
            max-height: 600px;
            overflow-y: auto;
        }
        
        .cliente-item {
            padding: 20px;
            border: 2px solid #e0e0e0;
            border-radius: 10px;
            margin-bottom: 15px;
            transition: all 0.3s ease;
        }
        
        .cliente-item:hover {
            border-color: #4CAF50;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
        }
        
        .cliente-nombre {
            font-size: 20px;
            font-weight: bold;
            color: #333;
            margin-bottom: 8px;
        }
        
        .cliente-info {
            color: #666;
            font-size: 14px;
            margin-bottom: 4px;
        }
        
        .cliente-fecha {
            color: #999;
            font-size: 12px;
            margin-top: 8px;
        }
        
        .mensaje {
            padding: 15px;
            border-radius: 8px;
            margin-bottom: 20px;
            display: none;
        }
        
        .mensaje.exito {
            background: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }
        
        .mensaje.error {
            background: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
        
        .no-clientes {
            text-align: center;
            color: #999;
            padding: 50px;
        }
        
        @media (max-width: 968px) {
            .content-grid {
                grid-template-columns: 1fr;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <a href="WebForm1.aspx" class="back-button">← Volver</a>
            
            <div class="header">
                <h1> Gestión de Clientes</h1>
                <p>Registra y administra la información de tus clientes</p>
            </div>
            
            <div class="content-grid">
                <div class="form-card">
                    <h2>Nuevo Cliente</h2>
                    
                    <div id="mensaje" class="mensaje"></div>
                    
                    <div class="form-group">
                        <label for="txtNombre">Nombre Completo *</label>
                        <input type="text" id="txtNombre" placeholder="" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtEmail">Email *</label>
                        <input type="email" id="txtEmail" placeholder="@correo.com" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtTelefono">Teléfono *</label>
                        <input type="tel" id="txtTelefono" placeholder="" required />
                    </div>
                    
                    <button type="button" class="btn" onclick="registrarCliente()">
                        Registrar Cliente
                    </button>
                </div>
                
                <div class="list-card">
                    <h2>Lista de Clientes</h2>
                    <div id="clientesContainer" class="clientes-list">
                        <div class="no-clientes">
                            Cargando clientes...
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    
    <script>
        const API_URL = 'https://localhost:44309/api/reservas';
        
        window.onload = function() {
            cargarClientes();
        };
        
        async function cargarClientes() {
            try {
                const response = await fetch(API_URL + '/clientes');
                const clientes = await response.json();
                
                const container = document.getElementById('clientesContainer');
                
                if (clientes.length === 0) {
                    container.innerHTML = '<div class="no-clientes">No hay clientes registrados</div>';
                } else {
                    container.innerHTML = clientes.map(cliente => `
                        <div class="cliente-item">
                            <div class="cliente-nombre">${cliente.Nombre}</div>
                            <div class="cliente-info">📧 ${cliente.Email}</div>
                            <div class="cliente-info">📱 ${cliente.Telefono}</div>
                            <div class="cliente-fecha">Registrado: ${formatearFecha(cliente.FechaRegistro)}</div>
                        </div>
                    `).join('');
                }
            } catch (error) {
                console.error('Error al cargar clientes:', error);
                document.getElementById('clientesContainer').innerHTML = 
                    '<div class="no-clientes" style="color: red;">Error al cargar los clientes</div>';
            }
        }
        
        async function registrarCliente() {
            const nombre = document.getElementById('txtNombre').value.trim();
            const email = document.getElementById('txtEmail').value.trim();
            const telefono = document.getElementById('txtTelefono').value.trim();
            
            if (!nombre || !email || !telefono) {
                mostrarMensaje('Por favor complete todos los campos', 'error');
                return;
            }
            
            if (!validarEmail(email)) {
                mostrarMensaje('Por favor ingrese un email válido', 'error');
                return;
            }
            
            try {
                const response = await fetch(API_URL + '/clientes', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        Nombre: nombre,
                        Email: email,
                        Telefono: telefono
                    })
                });
                
                if (response.ok) {
                    const cliente = await response.json();
                    mostrarMensaje('Cliente registrado exitosamente', 'exito');
                    limpiarFormulario();
                    cargarClientes();
                } else {
                    const error = await response.json();
                    mostrarMensaje(error.Message || 'Error al registrar cliente', 'error');
                }
            } catch (error) {
                console.error('Error:', error);
                mostrarMensaje('Error de conexión con la API', 'error');
            }
        }
        
        function mostrarMensaje(texto, tipo) {
            const mensaje = document.getElementById('mensaje');
            mensaje.textContent = texto;
            mensaje.className = 'mensaje ' + tipo;
            mensaje.style.display = 'block';
            
            setTimeout(() => {
                mensaje.style.display = 'none';
            }, 5000);
        }
        
        function limpiarFormulario() {
            document.getElementById('txtNombre').value = '';
            document.getElementById('txtEmail').value = '';
            document.getElementById('txtTelefono').value = '';
        }
        
        function validarEmail(email) {
            const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return re.test(email);
        }
        
        function formatearFecha(fecha) {
            const d = new Date(fecha);
            return d.toLocaleDateString('es-ES');
        }
    </script>
</body>
</html>