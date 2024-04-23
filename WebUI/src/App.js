import './App.css';
import { Skills } from './Skills';
import { Employee } from './Employee';
import { Employees } from './Employees';
import { BrowserRouter, Route, Routes, NavLink } from 'react-router-dom';

  function App() {
    return (
      <BrowserRouter>
      <div className="App container">
        <h3 className='d-flex justify-content-center m-3'>Employee Management</h3>

        <nav className='navbar navbar-expand-sm bg-light navbar-dark'>
          <ul className='navbar-nav'>
            <li className='nac-item- m-1'>
              <NavLink className={"btn btn-light btn-outline-primary"} to="/Skills">Skills</NavLink>
            </li>
            <li className='nac-item- m-1'>
              <NavLink className={"btn btn-light btn-outline-primary"} to="/Employees">Employees</NavLink>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" to="/Skills" element={<Skills/>}/>
          <Route path="/Skills" element={<Skills/>}/>
          <Route path="/Employee" element={<Employee/>}/>
          <Route path="/Employees" element={<Employees/>}/>
        </Routes>

      </div>
      </BrowserRouter>
    );
  }

export default App;
