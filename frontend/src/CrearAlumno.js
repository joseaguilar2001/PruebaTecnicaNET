import React, { useState } from 'react';
import axios from 'axios';

const CrearAlumno = () => {
  const initialState = {
    Nombre: '',
    Fecha_nacimiento: '',
    Nombre_padre: '',
    Nombre_madre: '',
    Grado: '',
    Seccion: '',
    Fecha_ingreso: ''
  };

  const [alumno, setAlumno] = useState(initialState);

  const handleChange = (e) => {
    setAlumno({ ...alumno, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await axios.post('http://localhost:5018/api/students/crear-alumno', alumno);
    alert('Alumno registrado');
    setAlumno(initialState); // Limpiar los campos después de enviar
  };

  const handleReset = () => {
    setAlumno(initialState); // Restablecer los campos al estado inicial
  };

  return (
    <form onSubmit={handleSubmit} className="p-4 border shadow">
      <h2>Registrar Alumno</h2>
      {Object.keys(alumno).map((field) => (
        <div key={field} className="mb-3">
          <label className="form-label">{field}</label>
          <input
            type="text"
            name={field}
            value={alumno[field]} // Asegurarse de que el valor se actualice correctamente
            className="form-control"
            onChange={handleChange}
            required
          />
        </div>
      ))}
      <div className="d-flex justify-content-between">
        <button type="submit" className="btn btn-primary">
          Registrar
        </button>
        <button
          type="button"
          className="btn btn-secondary"
          onClick={handleReset}
        >
          Limpiar
        </button>
      </div>
    </form>
  );
};

export default CrearAlumno;