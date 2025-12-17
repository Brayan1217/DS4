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
        .header {
            background: white;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.2);
            margin-bottom: 30px;
        }
        h1 { color: #2196F3; font-size: 32px; }
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
        input[type="date"], input[type="time"], input[type="number"], select, textarea {
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
        @media (max-width: 968px) { .content-grid { grid-template-columns: 1fr; } }
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
                        <div style="text-align: center; color: #999; padding: 50px;">Cargando reservas...</div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    
    <script>
        const API_URL = 'https://localhost:44309/api/reservas';

        window.onload = function () {
            cargarClientes();
            cargarReservas();
            establecerFechaMinima();
        };

        function establecerFechaMinima() {
            const hoy = new Date().toISOString().split('T')[0];
            document.getElementById('txtFecha').min = hoy;
            document.getElementById('txtFecha').value = hoy;
        }

        async function cargarClientes() {
            try {
                const response = await fetch(API_URL + '/clientes');
                const clientes = await response.json();

                const select = document.getElementById('selCliente');
                clientes.forEach(cliente => {
                    const option = document.createElement('option');
                    option.value = cliente.Id;
                    option.textContent = cliente.Nombre;
                    select.appendChild(option);
                });
            } catch (error) {
                console.error('Error al cargar clientes:', error);
            }
        }

        async function cargarReservas() {
            try {
                const response = await fetch(API_URL);
                const reservas = await response.json();

                const container = document.getElementById('reservasContainer');

                if (reservas.length === 0) {
                    container.innerHTML = '<div style="text-align: center; color: #999; padding: 50px;">No hay reservas registradas</div>';
                } else {
                    reservas.sort((a, b) => new Date(b.FechaReserva) - new Date(a.FechaReserva));

                    container.innerHTML = reservas.map(reserva => `
                        <div class="reserva-item ${reserva.Estado.toLowerCase()}">
                            <div class="reserva-header">
                                <div class="reserva-cliente">${reserva.ClienteNombre || 'Cliente desconocido'}</div>
                                <span class="reserva-estado estado-${reserva.Estado.toLowerCase()}">${reserva.Estado}</span>
                            </div>
                            <div class="reserva-info">📅 ${formatearFecha(reserva.FechaReserva)}</div>
                            <div class="reserva-info">🕐 ${formatearHora(reserva.HoraInicio)} - ${formatearHora(reserva.HoraFin)}</div>
                            <div class="reserva-info">👥 ${reserva.NumeroPersonas} personas</div>
                            <div class="reserva-info">🏷️ ${reserva.TipoServicio}</div>
                            ${reserva.Observaciones ? `<div class="reserva-info">📝 ${reserva.Observaciones}</div>` : ''}
                            ${reserva.Estado === 'Activa' ?
                            `<button class="btn btn-danger" onclick="cancelarReserva(${reserva.Id})">Cancelar Reserva</button>` :
                            ''}
                        </div>
                    `).join('');
                }
            } catch (error) {
                console.error('Error al cargar reservas:', error);
            }
        }

        async function crearReserva() {
            const clienteId = document.getElementById('selCliente').value;

            console.log('ClienteID:', clienteID);
            console.log('Datos a enviar:', {
                ClienteId: parseInt(clienteID),
                Fecha: fecha,
                HoraInicio: horaInicio,
                HoraFin: horaFin,
                Descripcion: descripcion
            });

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

            try {
                const response = await fetch(API_URL, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        ClienteId: parseInt(clienteId),
                        FechaReserva: fecha,
                        HoraInicio: horaInicio + ':00',
                        HoraFin: horaFin + ':00',
                        NumeroPersonas: parseInt(personas),
                        TipoServicio: servicio,
                        Observaciones: observaciones
                    })
                });

                if (response.ok) {
                    mostrarMensaje('Reserva creada exitosamente', 'exito');
                    limpiarFormulario();
                    cargarReservas();
                } else {
                    const error = await response.json();
                    mostrarMensaje(error.Message || 'Error al crear reserva', 'error');
                }
            } catch (error) {
                console.error('Error:', error);
                mostrarMensaje('Error de conexión con la API', 'error');
            }
        }

        async function cancelarReserva(id) {
            if (!confirm('¿Está seguro de que desea cancelar esta reserva?')) return;

            try {
                const response = await fetch(API_URL + '/' + id + '/cancelar', { method: 'PUT' });

                if (response.ok) {
                    mostrarMensaje('Reserva cancelada exitosamente', 'exito');
                    cargarReservas();
                } else {
                    mostrarMensaje('Error al cancelar reserva', 'error');
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
            const d = new Date(fecha);
            return d.toLocaleDateString('es-ES', { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' });
        }

        function formatearHora(hora) {
            return hora.substring(0, 5);
        }
    </script>
</body>
</html>