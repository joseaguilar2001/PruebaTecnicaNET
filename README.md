# Proyecto de Gestión de Alumnos

Este repositorio contiene una aplicación para gestionar alumnos, incluyendo las funcionalidades de consulta y registro. La aplicación utiliza **React** para el frontend y **ASP.NET Core** con MongoDB para el backend.

---

## Instrucciones para levantar el proyecto

### 1. **Clonar el repositorio**

```bash
git clone https://github.com/usuario/repositorio-gestion-alumnos.git
cd repositorio-gestion-alumnos
```

### 2. **Configuración del backend**

#### Requisitos previos:
- .NET SDK 6.0 o superior
- MongoDB instalado y corriendo
#### Pasos DB: 
1. Abra una instancia de shell de comando MongoDB iniciando mongosh.exe.

2. En el shell de comandos, conéctese a la base de datos de prueba predeterminada ejecutando el siguiente comando:

    ```bash
    mongosh
    ```
3. Ejecute el siguiente comando en el shell de comandos:

    ```bash
    use StudentsDB
    ```
4. Crear un Books colección usando el siguiente comando:

    ```bash
    db.createCollection('Students')
    ```

5. Definir un esquema para el Students recoja e inserte dos documentos usando el siguiente comando:

    ```bash
    db.Students.insertMany([{"Nombre":"Josemi","Fecha_nacimiento":"2001-05-13","Nombre_padre":"Felipe","Nombre_madre":"Nuvia","Grado":"5to Bach","Seccion":"A","Fecha_ingreso":"2025-01-25"},{"Nombre":"Nombre 1","Fecha_nacimiento":"2005-05-19","Nombre_padre":"Padre1","Nombre_madre":"Madre1","Grado":"5to bach","Seccion":"A","Fecha_ingreso":"2018-05-01"},{"Nombre":"Nombre 3","Fecha_nacimiento":"2005-05-13","Nombre_padre":"Padre1","Nombre_madre":"Madre1","Grado":"5to","Seccion":"U","Fecha_ingreso":"2018-05-01"}])
    ```

6. Ver los documentos en la base de datos usando el siguiente comando:

    ```bash
    db.Students.find().pretty()
    ```

#### Pasos:
1. Navega al directorio del backend:

    ```bash
    cd backend
    ```

2. Configura la conexión a la base de datos MongoDB en el archivo `appsettings.json`:

    ```json
    {
      "StudentsStoreDatabaseSettings": {
        "ConnectionString": "mongodb://localhost:27017",
        "DatabaseName": "StudentsDB",
        "StudentCollectionName": "Students"
      }
    }
    ```

3. Restaura las dependencias y compila el proyecto:

    ```bash
    dotnet restore
    dotnet build
    ```

4. Ejecuta el servidor:

    ```bash
    dotnet run
    ```

   El backend estará disponible en `http://localhost:5018`.

### 3. **Configuración del frontend**

#### Requisitos previos:
- Node.js 16 o superior

#### Pasos:
1. Navega al directorio del frontend:

    ```bash
    cd frontend
    ```

2. Instala las dependencias:

    ```bash
    npm install
    ```

3. Levanta la aplicación:

    ```bash
    npm start
    ```

   El frontend estará disponible en `http://localhost:3000`.

---

## 🛠️ Estructura del proyecto

```plaintext
.
├── backend                # API en ASP.NET Core
│   ├── Controllers        # Controladores de la API
│   ├── Models             # Modelos de datos
│   ├── Services           # Lógica de negocio
│   └── appsettings.json   # Configuración
└── frontend               # Aplicación React
    ├── src                # Código fuente del frontend
    ├── public             # Archivos estáticos
    └── package.json       # Dependencias del proyecto
```

---

## ⚡ Endpoints disponibles

### Backend

- **GET** `/api/students` - Obtiene todos los alumnos
- **GET** `/api/students/{id}` - Obtiene un alumno por su ID
- **GET** `/api/students/consultar-alumno/{grado}` - Obtiene los alumnos por grados.
- **POST** `/api/students/crear-alumno` - Crea un nuevo alumno

### Frontend

- **Ruta principal** (`/`): Formulario para registrar y consultar alumnos