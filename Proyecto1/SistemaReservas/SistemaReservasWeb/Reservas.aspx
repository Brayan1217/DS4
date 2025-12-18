<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="SistemaReservas.Web.Reservas" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Reservas</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            padding: 20px;
        }
        .container { max-width: 1400px; margin: 0 auto; }
        .back-button {
            display: inline-block;
            background: white;
            color: #667eea;
            padding: 10px 20px;
            border-radius: 8px;
            text-decoration: none;
            margin-bottom: 20px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }
        .back-button:hover { background: #f5f5f5; }
        .header {
            background: white;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.2);
            margin-bottom: 30px;
        }
        h1 { color: #2196F3; font-size: 32px; }
        .header p { color: #666; margin-top: 10px; }
        .content-grid { display: grid; grid-template-columns: 1fr 2fr; gap: 30px; }
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
            border-bottom: 3px solid #2196F3;
            padding-bottom: 10px;
        }
        .form-group { margin-bottom: 20px; }
        label { display: block; margin-bottom: 8px; font-weight: bold; color: #555; }
        input[type="date"], input[type="time"], input[type="number"], input[type="text"], select, textarea {
            width: 100%;
            padding: 12px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 16px;
        }
        input:focus, select:focus, textarea:focus { outline: none; border-color: #2196F3; }
        .btn {
            padding: 12px 30px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
            width: 100%;
            transition: all 0.3s ease;
        }
        .btn-primary { background: #2196F3; color: white; }
        .btn-primary:hover { background: #1976D2; }
        .btn-success { background: #4CAF50; color: white; margin-top: 10px; }
        .btn-success:hover { background: #45a049; }
        .btn-danger {
            background: #f44336;
            color: white;
            width: auto;
            padding: 8px 20px;
            font-size: 14px;
        }
        .btn-danger:hover { background: #d32f2f; }
        .reservas-list { max-height: 700px; overflow-y: auto; }
        .reserva-item {
            padding: 20px;
            border: 2px solid #e0e0e0;
            border-radius: 10px;
            margin-bottom: 15px;
            position: relative;
        }
        .reserva-item.activa { border-left: 5px solid #4CAF50; background: #f1f8f4; }
        .reserva-item.cancelada { border-left: 5px solid #f44336; background: #fef5f5; opacity: 0.7; }
        .reserva-header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 10px;
        }
        .reserva-cliente { font-size: 18px; font-weight: bold; color: #333; }
        .reserva-estado {
            padding: 5px 15px;
            border-radius: 20px;
            font-size: 12px;
            font-weight: bold;
        }
        .estado-activa { background: #4CAF50; color: white; }
        .estado-cancelada { background: #f44336; color: white; }
        .reserva-info { color: #666; margin-bottom: 5px; }
        .mensaje { padding: 15px; border-radius: 8px; margin-bottom: 20px; display: none; }
        .mensaje.exito { background: #d4edda; color: #155724; }
        .mensaje.error { background: #f8d7da; color: #721c24; }
        .seccion-clientes {
            background: #f5f5f5;
            padding: 15px;
            border-radius: 8px;
            margin-bottom: 20px;
        }
        .cliente-rapido {
            display: grid;
            grid-template-columns: 1fr auto;
            gap: 10px;
            align-items: end;
        }
        @media (max-width: 968px) { 
            .content-grid { grid-template-columns: 1fr; }
            .cliente-rapido { grid-template-columns: 1fr; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <a href="WebForm1.aspx" class="back-button">← Volver al Dashboard</a>
            
            <div class="header">
                <h1>📅 Gestión de Reservas</h1>
                <p>Crea y administra las reservas de tus clientes</p>
            </div>
            
            <div class="content-grid">
                <div class="form-card">
                    <h2>Nueva Reserva</h2>
                    <div id="mensaje" class="mensaje"></div>
                    
                    <div class="seccion-clientes">
                        <h3 style="font-size: 16px; margin-bottom: 10px; color: #555;">Agregar Cliente Rápido</h3>
                        <div class="cliente-rapido">
                            <input type="text" id="txtNuevoCliente" placeholder="Nombre del cliente" />
                            <button type="button" class="btn btn-success" onclick="agregarClienteRapido()" style="width: auto; padding: 12px 20px;">+ Agregar</button>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <label for="selCliente">Cliente *</label>
                        <select id="selCliente" required>
                            <option value="">Seleccione un cliente</option>
                        </select>
                    </div>
                    
                    <div class="form-group">
                        <label for="txtFecha">Fecha *</label>
                        <input type="date" id="txtFecha" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtHoraInicio">Hora Inicio *</label>
                        <input type="time" id="txtHoraInicio" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtHoraFin">Hora Fin *</label>
                        <input type="time" id="txtHoraFin" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="txtPersonas">Número de Personas *</label>
                        <input type="number" id="txtPersonas" min="1" max="100" value="2" required />
                    </div>
                    
                    <div class="form-group">
                        <label for="selServicio">Tipo de Servicio *</label>
                        <select id="selServicio" required>
                            <option value="">Seleccione un servicio</option>
                            <option value="Restaurante">Restaurante</option>
                            <option value="Sala de Conferencias">Sala de Conferencias</option>
                            <option value="Salón de Eventos">Salón de Eventos</option>
                            <option value="Spa">Spa</option>
                            <option value="Consultorio">Consultorio</option>
                            <option value="Otro">Otro</option>
                        </select>
                    </div>
                    
                    <div class="form-group">
                        <label for="txtObservaciones">Observaciones</label>
                        <textarea id="txtObservaciones" rows="3" placeholder="Notas adicionales..."></textarea>
                    </div>
                    
                    <button type="button" class="btn btn-primary" onclick="crearReserva()">Crear Reserva</button>
                </div>
                
                <div class="list-card">
                    <h2>Lista de Reservas</h2>
                    <div id="reservasContainer" class="reservas-list">
                        <div style="text-align: center; color: #999; padding: 50px;">No hay reservas registradas</div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    
    <script>
        // Variables globales
        let clientes = [];
        let reservas = [];
        let clienteIdCounter = 1;
        let reservaIdCounter = 1;

        window.onload = function () {
            cargarDatos();
            cargarClientes();
            cargarReservas();
            establecerFechaMinima();
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

            const reservasGuardadas = localStorage.getItem('reservas');
            if (reservasGuardadas) {
                reservas = JSON.parse(reservasGuardadas);
                if (reservas.length > 0) {
                    reservaIdCounter = Math.max(...reservas.map(r => r.id)) + 1;
                }
            }
        }

        function guardarClientes() {
            localStorage.setItem('clientes', JSON.stringify(clientes));
        }

        function guardarReservas() {
            localStorage.setItem('reservas', JSON.stringify(reservas));
        }

        function establecerFechaMinima() {
            const hoy = new Date().toISOString().split('T')[0];
            document.getElementById('txtFecha').min = hoy;
            document.getElementById('txtFecha').value = hoy;
        }

        function agregarClienteRapido() {
            const nombre = document.getElementById('txtNuevoCliente').value.trim();

            if (!nombre) {
                mostrarMensaje('Por favor ingrese el nombre del cliente', 'error');
                return;
            }

            const nuevoCliente = {
                id: clienteIdCounter++,
                nombre: nombre,
                email: nombre.toLowerCase().replace(/\s/g, '') + '@cliente.com',
                telefono: '0000-0000',
                fechaRegistro: new Date().toISOString()
            };

            clientes.push(nuevoCliente);
            guardarClientes();
            cargarClientes();

            document.getElementById('txtNuevoCliente').value = '';
            document.getElementById('selCliente').value = nuevoCliente.id;

            mostrarMensaje('Cliente agregado exitosamente', 'exito');
        }

        function cargarClientes() {
            const select = document.getElementById('selCliente');
            select.innerHTML = '<option value="">Seleccione un cliente</option>';

            clientes.forEach(cliente => {
                const option = document.createElement('option');
                option.value = cliente.id;
                option.textContent = cliente.nombre;
                select.appendChild(option);
            });
        }

        function cargarReservas() {
            const container = document.getElementById('reservasContainer');

            if (reservas.length === 0) {
                container.innerHTML = '<div style="text-align: center; color: #999; padding: 50px;">No hay reservas registradas</div>';
                return;
            }

            const reservasOrdenadas = [...reservas].sort((a, b) => {
                const fechaA = new Date(a.fechaReserva + ' ' + a.horaInicio);
                const fechaB = new Date(b.fechaReserva + ' ' + b.horaInicio);
                return fechaB - fechaA;
            });

            container.innerHTML = reservasOrdenadas.map(reserva => {
                const cliente = clientes.find(c => c.id === reserva.clienteId);
                const clienteNombre = cliente ? cliente.nombre : 'Cliente desconocido';

                return `
                    <div class="reserva-item ${reserva.estado.toLowerCase()}">
                        <div class="reserva-header">
                            <div class="reserva-cliente">${clienteNombre}</div>
                            <span class="reserva-estado estado-${reserva.estado.toLowerCase()}">${reserva.estado}</span>
                        </div>
                        <div class="reserva-info">📅 ${formatearFecha(reserva.fechaReserva)}</div>
                        <div class="reserva-info">🕐 ${reserva.horaInicio} - ${reserva.horaFin}</div>
                        <div class="reserva-info">👥 ${reserva.numeroPersonas} personas</div>
                        <div class="reserva-info">🏷️ ${reserva.tipoServicio}</div>
                        ${reserva.observaciones ? `<div class="reserva-info">📝 ${reserva.observaciones}</div>` : ''}
                        ${reserva.estado === 'Activa' ?
                        `<button class="btn btn-danger" onclick="cancelarReserva(${reserva.id})">Cancelar Reserva</button>` :
                        ''}
                    </div>
                `;
            }).join('');
        }

        function crearReserva() {
            const clienteId = parseInt(document.getElementById('selCliente').value);
            const fecha = document.getElementById('txtFecha').value;
            const horaInicio = document.getElementById('txtHoraInicio').value;
            const horaFin = document.getElementById('txtHoraFin').value;
            const personas = document.getElementById('txtPersonas').value;
            const servicio = document.getElementById('selServicio').value;
            const observaciones = document.getElementById('txtObservaciones').value;

            if (!clienteId || !fecha || !horaInicio || !horaFin || !servicio) {
                mostrarMensaje('Por favor complete todos los campos obligatorios', 'error');
                return;
            }

            if (horaFin <= horaInicio) {
                mostrarMensaje('La hora de fin debe ser mayor que la hora de inicio', 'error');
                return;
            }

            const nuevaReserva = {
                id: reservaIdCounter++,
                clienteId: clienteId,
                fechaReserva: fecha,
                horaInicio: horaInicio,
                horaFin: horaFin,
                numeroPersonas: parseInt(personas),
                tipoServicio: servicio,
                observaciones: observaciones,
                estado: 'Activa'
            };

            reservas.push(nuevaReserva);
            guardarReservas();
            cargarReservas();
            limpiarFormulario();

            mostrarMensaje('Reserva creada exitosamente', 'exito');
        }

        function cancelarReserva(id) {
            if (!confirm('¿Está seguro de que desea cancelar esta reserva?')) return;

            const reserva = reservas.find(r => r.id === id);
            if (reserva) {
                reserva.estado = 'Cancelada';
                guardarReservas();
                cargarReservas();
                mostrarMensaje('Reserva cancelada exitosamente', 'exito');
            }
        }

        function mostrarMensaje(texto, tipo) {
            const mensaje = document.getElementById('mensaje');
            mensaje.textContent = texto;
            mensaje.className = 'mensaje ' + tipo;
            mensaje.style.display = 'block';
            setTimeout(() => { mensaje.style.display = 'none'; }, 5000);
        }

        function limpiarFormulario() {
            document.getElementById('selCliente').value = '';
            document.getElementById('txtHoraInicio').value = '';
            document.getElementById('txtHoraFin').value = '';
            document.getElementById('txtPersonas').value = '2';
            document.getElementById('selServicio').value = '';
            document.getElementById('txtObservaciones').value = '';
            establecerFechaMinima();
        }

        function formatearFecha(fecha) {
            const d = new Date(fecha + 'T00:00:00');
            return d.toLocaleDateString('es-ES', {
                weekday: 'long',
                year: 'numeric',
                month: 'long',
                day: 'numeric'
            });
        }
    </script>
</body>
</html>