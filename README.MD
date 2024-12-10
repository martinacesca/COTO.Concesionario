# API de Gestión de Ventas - COTO Concesionario 🚗

## Descripción
Esta API permite gestionar las ventas de una fábrica de automóviles, proporcionando información sobre:
- Inserción de ventas.
- Volumen total de ventas.
- Volumen de ventas por centro de distribución.
- Porcentajes de unidades vendidas por modelo y centro.

Incluye:
- **Swagger** para documentación interactiva.
- **Logs** detallados de errores y eventos.
- **Datos mock** iniciales almacenados en un archivo JSON.
- **Registros del tiempo de ejecución** que se pueden ver en los logs y en la ventana de output para monitoreo.

## Endpoints Disponibles

### 1. **Insertar una Venta**
**POST** `/api/Ventas`

- **Descripción**: Inserta una nueva venta en el sistema.
- **Body**:
  ```json
  {
    "Centro": "Palermo",
    "TipoCoche": "Suv"
  }
  
- **Valores válidos**: Los datos que van a ser validos para hacer ventas son los siguientes. No es case sensitive.
  - **Centro:**
    - "Palermo"
    - "Belgrano"
    - "Boedo"
    - "VillaCrespo"
  - **TipoCoche:**
    - "Suv"
    - "Offroad"
    - "Sport"
    - "Sedan"

- **Respuestas:**
  - **201 Created:** Venta creada exitosamente.
  - **400 Bad Request:** Error en los datos de la venta.
  - **500 Internal Server Error:** Error en el servidor.

### 2. **Obtener Todas las Ventas**
**GET** `/api/Ventas`

- **Descripción**: Devuelve todas las ventas registradas.
- **Nota**: Se agregó este endpoint para facilitar la lectura de las ventas en sistema. 
- **Respuestas:**
  - **200 OK:** Lista de ventas en formato JSON.
  - **500 Internal Server Error:** Error en el servidor.

### 3. **Obtener Volumen Total de Ventas**
**GET** `/api/Ventas/Volumen`

- **Descripción**: Devuelve el volumen total de ventas.
- **Nota**: Se optó por devolver un formato de texto descriptivo. Asumiendo que el cliente va a consumir de esta manera.
- **Respuestas:**
  - **200 OK:** Volumen total de ventas en formato string.
  - **500 Internal Server Error:** Error en el servidor.

### 4. **Obtener Volumen de Ventas por Centro**
**GET** `/api/Ventas/Centro/Volumen`

- **Descripción**: Devuelve el volumen de ventas desglosado por centro de distribución.
- **Nota**: Se optó por devolver un formato de texto descriptivo. Asumiendo que el cliente va a consumir de esta manera.
- **Respuestas:**
  - **200 OK:** Lista de volumenes de ventas por centro, en formato string.
  - **500 Internal Server Error:** Error en el servidor.

### 5. **Obtener Volumen de Ventas por Centro**
**GET** `/api/Ventas/Centro/Porcentaje`

- **Descripción**: Obtiene el porcentaje de unidades de cada modelo vendido por centro, sobre el total de ventas de ese modelo.
- **Nota**: Se optó por devolver un JSON. Asumiendo que el cliente va a consumir de esta manera.
- **Respuestas:**
  - **200 OK:** Devuelve los porcentajes de ventas por tipo de coche y centro.
  - **500 Internal Server Error:** Error en el servidor.
