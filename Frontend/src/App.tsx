import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './Pages/HomePage';
import TaskManager from './components/TaskManager';
import NavigationBar from './components/NavigationBar';
import './styles.css'
import Login from './Pages/LoginPage';
import ForgotPassword from './Pages/ForgotPasswordPage';
import Register from './Pages/RegisterPage';

const App: React.FC = () => {
  return (
    <div className="bg-gradient-to-b from-yellow-500 via-blue-500 to-grey-700 ...">
      <Router>
      <NavigationBar />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/resetPassword" element={<ForgotPassword />} />
        <Route path="/logout" element={<TaskManager />} />
        <Route path="/tasks" element={<TaskManager />} />
      </Routes>
    </Router>
    </div>
    
  );
};

export default App;
