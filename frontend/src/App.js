import React from 'react';
import CrearAlumno from './CrearAlumno';
import ConsultarAlumno from './ConsultarAlumno';

const App = () => (
  <div className="container mt-5">
    <ConsultarAlumno />
    <CrearAlumno />
  </div>
);

export default App;