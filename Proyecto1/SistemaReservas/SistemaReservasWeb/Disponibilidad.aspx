<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disponibilidad.aspx.cs" Inherits="SistemaReservas.Web.Disponibilidad" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de Disponibilidad</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
            padding: 20px;
        }
        .container { max-width: 900px; margin: 0 auto; }
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
        h1 { color: #FF9800; font-size: 32px; }
        .card {
            background: white;
            padding: 40px;
            border-radius: 15px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.1);
        }
        h2 {
            color: #333;
            margin-bottom: 30px;
            font-size: 24px;
            text-align: center;
        }
        .form-group { margin-bottom: 25px; }
        label {
            display: block;
            margin-bottom: 8px;
            font-weight: bold;
            color: #555;
            font-size: 16px;
        }
        input[type="date"], input[type="time"] {
            width: 100%;
            padding: 15px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 18px;
        }
        input:focus { outline: none; border-color: #FF9800; }
        .btn {
            background: #FF9800;
            color: white;
            padding: 15px 40px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 18px;
            font-weight: bold;
            width: 100%;
            transition: all 0.3s ease;
            margin-top: 10px;
        }
        .btn:hover { background: #F57C00; transform: translateY(-2px); }
        .resultado {
            margin-top: 30px;
            padding: 30px;
            border-radius: 10px;
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            display: none;
        }
        .disponible {
            background: #d4edda;
            color: #155724;
            border: 3px solid #4CAF50;
        }
        .no-disponible {
            background: #f8d7da;
            color: #721c24;
            border: 3px solid #f44336;
        }
        .icono { font-size: 50px; margin-bottom: 15px; }
        .mensaje-detalle {
            font-size: 16px;
            margin-top: 10px;
            font-weight: normal;
        }
        .loading { text-align: center; padding: 20px; display: none; }
        .info-box {
            background: #e3f2fd;
            padding: 20px;
            border-radius: 8px;
            margin-bottom: 30px;
            border-left: 4px solid #2196F3;
        }
        .info-box h3 { color: #1976D2; margin-bottom: 10px; }
        .info-box p { color: #555; line-height: 1.6; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <a href="WebForm1.aspx" class="back-button">← Volver al Dashboard</a>
            
            <div class="header">
                <h1>🔍 Consulta de Disponibilidad</h1>
                <p>Verifica la disponibilidad de horarios para reservas</p>
            </div>
            
            <div class="card">
                <div class="info-box">
                </div>
                
                <h2>Selecciona Fecha y Horario</h2>
                
                <div class="form-group">
                    <label for="txtFecha"> Fecha</label>
                    <input type="date" id="txtFecha" required />
                </div>
                
                <div class="form-group">
                    <label for="txtHoraInicio"> Hora de Inicio</label>
                    <input type="time" id="txtHoraInicio" required />
                </div>
                
                <div class="form-group">
                    <label for="txtHoraFin"> Hora de Fin</label>
                    <input type="time" id="txtHoraFin" required />
                </div>
                
                <button type="button" class="btn" onclick="consultarDisponibilidad()">Consultar Disponibilidad</button>
                
                <div id="loading" class="loading">
                    <p>Consultando...</p>
                </div>
                
                <div id="resultado" class="resultado"></div>
            </div>
        </div>
    </form>
    
    <script>
        const API_URL = 'http://localhost:44309/api/reservas';

        window.onload = function () {
            establecerFechaMinima();
        };

        function establecerFechaMinima() {
            const hoy = new Date().toISOString().split('T')[0];
            document.getElementById('txtFecha').min = hoy;
            document.getElementById('txtFecha').value = hoy;
        }

        async function consultarDisponibilidad() {
            const fecha = document.getElementById('txtFecha').value;
            const horaInicio = document.getElementById('txtHoraInicio').value;
            const horaFin = document.getElementById('txtHoraFin').value;

            if (!fecha || !horaInicio || !horaFin) {
                alert('Por favor complete todos los campos');
                return;
            }

            if (horaFin <= horaInicio) {
                alert('La hora de fin debe ser posterior a la hora de inicio');
                return;
            }

            const loading = document.getElementById('loading');
            const resultado = document.getElementById('resultado');

            loading.style.display = 'block';
            resultado.style.display = 'none';

            try {
                const url = `${API_URL}/disponibilidad?fecha=${fecha}&horaInicio=${horaInicio}&horaFin=${horaFin}`;
                const response = await fetch(url);
                const data = await response.json();

                loading.style.display = 'none';
                resultado.style.display = 'block';

                if (data.disponible) {
                    resultado.className = 'resultado disponible';
                    resultado.innerHTML = `
                        <div class="icono">✅</div>
                        <div>¡DISPONIBLE!</div>
                        <div class="mensaje-detalle">
                            El horario de ${formatearHora(horaInicio)} a ${formatearHora(horaFin)}<br>
                            el día ${formatearFecha(fecha)} está disponible.
                        </div>
                    `;
                } else {
                    resultado.className = 'resultado no-disponible';
                    resultado.innerHTML = `
                        <div class="icono">❌</div>
                        <div>NO DISPONIBLE</div>
                        <div class="mensaje-detalle">
                            Ya existe una reserva en el horario solicitado.<br>
                            Por favor selecciona otro horario.
                        </div>
                    `;
                }
            } catch (error) {
                console.error('Error:', error);
                loading.style.display = 'none';
                resultado.style.display = 'block';
                resultado.className = 'resultado no-disponible';
                resultado.innerHTML = `
                    <div class="icono"></div>
                    <div>ERROR</div>
                    <div class="mensaje-detalle">No se pudo consultar la disponibilidad.</div>
                `;
            }
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

        function formatearHora(hora) {
            return hora;
        }
    </script>
</body>
</html>