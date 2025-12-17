<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="SistemaReservas.Web.Reportes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes e Informes</title>
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
        h1 { color: #9C27B0; font-size: 32px; }
        .tabs {
            display: flex;
            gap: 10px;
            margin-bottom: 30px;
            background: white;
            padding: 10px;
            border-radius: 15px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.1);
        }
        .tab {
            flex: 1;
            padding: 15px;
            background: #f0f0f0;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
            transition: all 0.3s ease;
        }
        .tab:hover { background: #e0e0e0; }
        .tab.active { background: #9C27B0; color: white; }
        .tab-content { display: none; }
        .tab-content.active { display: block; }
        .card {
            background: white;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.1);
            margin-bottom: 30px;
        }
        h2 {
            color: #333;
            margin-bottom: 20px;
            font-size: 24px;
            border-bottom: 3px solid #9C27B0;
            padding-bottom: 10px;
        }
        .filter-group {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            margin-bottom: 20px;
        }
        .form-group { margin-bottom: 15px; }
        label { display: block; margin-bottom: 8px; font-weight: bold; color: #555; }
        input[type="number"], select {
            width: 100%;
            padding: 12px;
            border: 2px solid #ddd;
            border-radius: 8px;
            font-size: 16px;
        }
        .btn {
            background: #9C27B0;
            color: white;
            padding: 12px 30px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            font-size: 16px;
            font-weight: bold;
            transition: all 0.3s ease;
        }
        .btn:hover { background: #7B1FA2; }
        .stats-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
            gap: 20px;
            margin: 20px 0;
        }
        .stat-box {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            padding: 25px;
            border-radius: 10px;
            text-align: center;
        }
        .stat-number { font-size: 36px; font-weight: bold; margin-bottom: 5px; }
        .stat-label { font-size: 14px; opacity: 0.9; }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th {
            background: #9C27B0;
            color: white;
            padding: 15px;
            text-align: left;
            font-weight: bold;
        }
        td { padding: 12px 15px; border-bottom: 1px solid #ddd; }
        tr:hover { background: #f5f5f5; }
        .badge {
            padding: 5px 12px;
            border-radius: 20px;
            font-size: 12px;
            font-weight: bold;
        }
        .badge-activa { background: #4CAF50; color: white; }
        .badge-cancelada { background: #f44336; color: white; }
        .loading { text-align: center; padding: 50px; color: #666; }
        .no-data { text-align: center; padding: 50px; color: #999; }
        .cliente-card {
            border: 2px solid #e0e0e0;
            border-radius: 10px;
            padding: 20px;
            margin-bottom: 15px;
        }
        .cliente-card:hover { border-color: #9C27B0; box-shadow: 0 4px 10px rgba(0,0,0,0.1); }
        .cliente-nombre { font-size: 20px; font-weight: bold; color: #333; margin-bottom: 10px; }
        .cliente-info { color: #666; margin-bottom: 5px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <a href="WebForm1.aspx" class="back-button">← Volver al Dashboard</a>
            
            <div class="header">
                <h1>📊 Reportes e Informes</h1>
                <p>Analiza las estadísticas de tu sistema de reservas</p>
            </div>
            
            <div class="tabs">
                <button type="button" class="tab active" onclick="cambiarTab(0)">Reporte por Mes</button>
                <button type="button" class="tab" onclick="cambiarTab(1)">Reporte por Cliente</button>
                <button type="button" class="tab" onclick="cambiarTab(2)">Lista de Clientes</button>
            </div>
            
            <!-- TAB 1: Reporte por Mes -->
            <div id="tab0" class="tab-content active">
                <div class="card">
                    <h2>Reservas por Mes</h2>
                    
                    <div class="filter-group">
                        <div class="form-group">
                            <label for="selMes">Mes</label>
                            <select id="selMes">
                                <option value="1">Enero</option>
                                <option value="2">Febrero</option>
                                <option value="3">Marzo</option>
                                <option value="4">Abril</option>
                                <option value="5">Mayo</option>
                                <option value="6">Junio</option>
                                <option value="7">Julio</option>
                                <option value="8">Agosto</option>
                                <option value="9">Septiembre</option>
                                <option value="10">Octubre</option>
                                <option value="11">Noviembre</option>
                                <option value="12">Diciembre</option>
                            </select>
                        </div>
                        
                        <div class="form-group">
                            <label for="txtAnio">Año</label>
                            <input type="number" id="txtAnio" min="2020" max="2030" value="2025" />
                        </div>
                        
                        <div class="form-group">
                            <label>&nbsp;</label>
                            <button type="button" class="btn" onclick="generarReporteMes()">Generar Reporte</button>
                        </div>
                    </div>
                    
                    <div id="estadisticasMes"></div>
                    <div id="tablaMes"></div>
                </div>
            </div>
            
            <!-- TAB 2: Reporte por Cliente -->
            <div id="tab1" class="tab-content">
                <div class="card">
                    <h2>Historial de Cliente</h2>
                    
                    <div class="filter-group">
                        <div class="form-group">
                            <label for="selClienteReporte">Seleccionar Cliente</label>
                            <select id="selClienteReporte">
                                <option value="">Seleccione un cliente</option>
                            </select>
                        </div>
                        
                        <div class="form-group">
                            <label>&nbsp;</label>
                            <button type="button" class="btn" onclick="generarReporteCliente()">Ver Historial</button>
                        </div>
                    </div>
                    
                    <div id="estadisticasCliente"></div>
                    <div id="tablaCliente"></div>
                </div>
            </div>
            
            <!-- TAB 3: Lista de Clientes -->
            <div id="tab2" class="tab-content">
                <div class="card">
                    <h2>Lista Completa de Clientes</h2>
                    <div id="listaClientes"></div>
                </div>
            </div>
        </div>
    </form>
    
    <script>
        const API_URL = 'https://localhost:44309/api/reservas';

        window.onload = function () {
            const fecha = new Date();
            document.getElementById('selMes').value = fecha.getMonth() + 1;
            document.getElementById('txtAnio').value = fecha.getFullYear();

            cargarClientesSelect();
            cargarListaClientes();
        };

        function cambiarTab(index) {
            const tabs = document.querySelectorAll('.tab');
            const contents = document.querySelectorAll('.tab-content');

            tabs.forEach(tab => tab.classList.remove('active'));
            contents.forEach(content => content.classList.remove('active'));

            tabs[index].classList.add('active');
            contents[index].classList.add('active');
        }

        async function cargarClientesSelect() {
            try {
                const response = await fetch(API_URL + '/clientes');
                const clientes = await response.json();

                const select = document.getElementById('selClienteReporte');
                clientes.forEach(cliente => {
                    const option = document.createElement('option');
                    option.value = cliente.ClienteID;
                    option.textContent = `${cliente.Nombre} (${cliente.Email})`;
                    select.appendChild(option);
                });
            } catch (error) {
                console.error('Error al cargar clientes:', error);
            }
        }

        async function generarReporteMes() {
            const mes = document.getElementById('selMes').value;
            const anio = document.getElementById('txtAnio').value;

            const estadisticas = document.getElementById('estadisticasMes');
            const tabla = document.getElementById('tablaMes');

            estadisticas.innerHTML = '<div class="loading">Cargando reporte...</div>';
            tabla.innerHTML = '';

            try {
                const response = await fetch(`${API_URL}/reportes/por-mes?mes=${mes}&anio=${anio}`);
                const data = await response.json();

                estadisticas.innerHTML = `
                    <div class="stats-grid">
                        <div class="stat-box">
                            <div class="stat-number">${data.totalReservas}</div>
                            <div class="stat-label">Total Reservas</div>
                        </div>
                        <div class="stat-box">
                            <div class="stat-number">${data.reservasActivas}</div>
                            <div class="stat-label">Activas</div>
                        </div>
                        <div class="stat-box">
                            <div class="stat-number">${data.reservasCanceladas}</div>
                            <div class="stat-label">Canceladas</div>
                        </div>
                    </div>
                `;

                if (data.reservas.length === 0) {
                    tabla.innerHTML = '<div class="no-data">No hay reservas en este mes</div>';
                } else {
                    tabla.innerHTML = `
                        <table>
                            <thead>
                                <tr>
                                    <th>Cliente</th>
                                    <th>Fecha</th>
                                    <th>Horario</th>
                                    <th>Personas</th>
                                    <th>Servicio</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                                ${data.reservas.map(r => `
                                    <tr>
                                        <td>${r.ClienteNombre}</td>
                                        <td>${formatearFecha(r.FechaReserva)}</td>
                                        <td>${formatearHora(r.HoraInicio)} - ${formatearHora(r.HoraFin)}</td>
                                        <td>${r.NumeroPersonas}</td>
                                        <td>${r.TipoServicio}</td>
                                        <td><span class="badge badge-${r.Estado.toLowerCase()}">${r.Estado}</span></td>
                                    </tr>
                                `).join('')}
                            </tbody>
                        </table>
                    `;
                }
            } catch (error) {
                console.error('Error:', error);
                estadisticas.innerHTML = '<div class="no-data" style="color: red;">Error al cargar el reporte</div>';
            }
        }

        async function generarReporteCliente() {
            const clienteId = document.getElementById('selClienteReporte').value;
            alert(clienteId);
            if (!clienteId) {
                alert('Por favor seleccione un cliente');
                return;
            }

            const estadisticas = document.getElementById('estadisticasCliente');
            const tabla = document.getElementById('tablaCliente');

            estadisticas.innerHTML = '<div class="loading">Cargando historial...</div>';
            tabla.innerHTML = '';

            try {
                const response = await fetch(`${API_URL}/reportes/clientes/${clienteId}`);
                const data = await response.json();

                estadisticas.innerHTML = `
                    <div class="cliente-card">
                        <div class="cliente-nombre">${data.cliente.Nombre}</div>
                        <div class="cliente-info">📧 ${data.cliente.Email}</div>
                        <div class="cliente-info">📱 ${data.cliente.Telefono}</div>
                        <div class="cliente-info">📅 Registrado: ${formatearFecha(data.cliente.FechaRegistro)}</div>
                    </div>
                    
                    <div class="stats-grid">
                        <div class="stat-box">
                            <div class="stat-number">${data.estadisticas.totalReservas}</div>
                            <div class="stat-label">Total Reservas</div>
                        </div>
                        <div class="stat-box">
                            <div class="stat-number">${data.estadisticas.reservasActivas}</div>
                            <div class="stat-label">Activas</div>
                        </div>
                        <div class="stat-box">
                            <div class="stat-number">${data.estadisticas.reservasCanceladas}</div>
                            <div class="stat-label">Canceladas</div>
                        </div>
                    </div>
                `;

                if (data.reservas.length === 0) {
                    tabla.innerHTML = '<div class="no-data">Este cliente no tiene reservas</div>';
                } else {
                    tabla.innerHTML = `
                        <table>
                            <thead>
                                <tr>
                                    <th>Fecha</th>
                                    <th>Horario</th>
                                    <th>Personas</th>
                                    <th>Servicio</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                                ${data.reservas.map(r => `
                                    <tr>
                                        <td>${formatearFecha(r.FechaReserva)}</td>
                                        <td>${formatearHora(r.HoraInicio)} - ${formatearHora(r.HoraFin)}</td>
                                        <td>${r.NumeroPersonas}</td>
                                        <td>${r.TipoServicio}</td>
                                        <td><span class="badge badge-${r.Estado.toLowerCase()}">${r.Estado}</span></td>
                                    </tr>
                                `).join('')}
                            </tbody>
                        </table>
                    `;
                }
            } catch (error) {
                console.error('Error:', error);
                estadisticas.innerHTML = '<div class="no-data" style="color: red;">Error al cargar el historial</div>';
            }
        }

        async function cargarListaClientes() {
            const container = document.getElementById('listaClientes');
            container.innerHTML = '<div class="loading">Cargando clientes...</div>';

            try {
                const response = await fetch(API_URL + '/clientes');
                const clientes = await response.json();

                if (clientes.length === 0) {
                    container.innerHTML = '<div class="no-data">No hay clientes registrados</div>';
                } else {
                    container.innerHTML = clientes.map(cliente => `
                        <div class="cliente-card">
                            <div class="cliente-nombre">${cliente.Nombre}</div>
                            <div class="cliente-info">📧 ${cliente.Email}</div>
                            <div class="cliente-info">📱 ${cliente.Telefono}</div>
                            <div class="cliente-info">📅 Registrado: ${formatearFecha(cliente.FechaRegistro)}</div>
                        </div>
                    `).join('');
                }
            } catch (error) {
                console.error('Error:', error);
                container.innerHTML = '<div class="no-data" style="color: red;">Error al cargar los clientes</div>';
            }
        }

        function formatearFecha(fecha) {
            const d = new Date(fecha);
            return d.toLocaleDateString('es-ES');
        }

        function formatearHora(hora) {
            return hora.substring(0, 5);
        }
    </script>
</body>
</html>