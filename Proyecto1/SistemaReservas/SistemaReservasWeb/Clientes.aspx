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
        
        .header p {
            color: #666;
            margin-top: 10px;
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
                <h1>👥 Gestión de Clientes</h1>
                <p>Registra y administra la información de tus clientes</p>
            </div>
            
            <div class="content-grid">
                <div class="form-card">
                    <h2>Nuevo Cliente</h2>
                    
                    <div id="mensaje" class="mensaje"></div>
                    
                    <div class="form-group">
                        <label for="txtNombre">Nombre Completo *</label>
                        <input type="text" id="txtNombre" placeholder="Ej: Juan Pérez" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtEmail">Email *</label>
                        <input type="email" id="txtEmail" placeholder="ejemplo@correo.com" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtTelefono">Teléfono *</label>
                        <input type="tel" id="txtTelefono" placeholder="6000-0000" required />
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
        let clientes = [];
        let clienteIdCounter = 1;

        window.onload = function () {
            cargarDatos();
            mostrarClientes();
        };

        function cargarDatos() {
            const clientesGuardados = localStorage.getItem('clientes');
            if (clientesGuardados) {
                clientes = JSON.parse(clientesGuardados);
                if (clientes.length > 0) {
                    clienteIdCounter = Math.max(...clientes.map(c => c.id)) + 1;
                }
            } else {
                clientes = [
                    { id: 1, nombre: 'Juan Pérez', email: 'juan@email.com', telefono: '6000-0001', fechaRegistro: new Date().toISOString() },
                    { id: 2, nombre: 'María García', email: 'maria@email.com', telefono: '6000-0002', fechaRegistro: new Date().toISOString() },
                    { id: 3, nombre: 'Carlos López', email: 'carlos@email.com', telefono: '6000-0003', fechaRegistro: new Date().toISOString() },
                    { id: 4, nombre: 'Ana Martínez', email: 'ana@email.com', telefono: '6000-0004', fechaRegistro: new Date().toISOString() },
                    { id: 5, nombre: 'Pedro Rodríguez', email: 'pedro@email.com', telefono: '6000-0005', fechaRegistro: new Date().toISOString() }
                ];
                clienteIdCounter = 6;
                guardarClientes();
            }
        }

        function guardarClientes() {
            localStorage.setItem('clientes', JSON.stringify(clientes));
        }

        function mostrarClientes() {
            const container = document.getElementById('clientesContainer');

            if (clientes.length === 0) {
                container.innerHTML = '<div class="no-clientes">No hay clientes registrados</div>';
                return;
            }

            container.innerHTML = clientes.map(cliente => `
                <div class="cliente-item">
                    <div class="cliente-nombre">${cliente.nombre}</div>
                    <div class="cliente-info">📧 ${cliente.email}</div>
                    <div class="cliente-info">📱 ${cliente.telefono}</div>
                    <div class="cliente-fecha">Registrado: ${formatearFecha(cliente.fechaRegistro)}</div>
                </div>
            `).join('');
        }

        function registrarCliente() {
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

            if (clientes.some(c => c.email.toLowerCase() === email.toLowerCase())) {
                mostrarMensaje('Ya existe un cliente con ese email', 'error');
                return;
            }

            const nuevoCliente = {
                id: clienteIdCounter++,
                nombre: nombre,
                email: email,
                telefono: telefono,
                fechaRegistro: new Date().toISOString()
            };

            clientes.push(nuevoCliente);
            guardarClientes();
            mostrarClientes();
            limpiarFormulario();
            mostrarMensaje('Cliente registrado exitosamente', 'exito');
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