import React, { useState } from 'react';
import axios from 'axios';

const ConsultarAlumno = () => {
  const [grado, setGrado] = useState('');
  const [alumnos, setAlumnos] = useState([]);

  const handleConsultar = async () => {
    try {
      const response = await axios.get(`http://localhost:5018/api/students/consultar-alumno/${grado}`);
      console.log('Datos de la respuesta:', response.data);

      // Ajuste para manejar diferentes estructuras
      const data = Array.isArray(response.data)
        ? response.data
        : [response.data]; // Cambiar 'alumnos' si el backend usa otra clave
      console.log(data);
      setAlumnos(data);
    } catch (error) {
      console.error('Error al consultar alumnos:', error);
      setAlumnos([]); // Reinicia la lista en caso de error
    }
  };

  return (
    <div className="p-4 border shadow">
      <h2>Consultar Alumnos</h2>
      <input
        type="text"
        className="form-control mb-3"
        placeholder="Grado"
        value={grado}
        onChange={(e) => setGrado(e.target.value)}
      />
      <button className="btn btn-primary" onClick={handleConsultar}>
        Consultar
      </button>
      <table className="table mt-3">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Grado</th>
            <th>Sección</th>
          </tr>
        </thead>
        <tbody>
          {alumnos.length > 0 ? (
            alumnos.map((alumno, index) => (
              <tr key={index}>
                <td>{alumno.Nombre || 'N/A'}</td>
                <td>{alumno.Grado || 'N/A'}</td>
                <td>{alumno.Seccion || 'N/A'}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="3">No se encontraron alumnos.</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default ConsultarAlumno;
