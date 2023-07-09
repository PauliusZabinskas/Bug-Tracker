import React, { useContext, useState } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './Pages/HomePage';
import TaskManager from './components/TaskManager';
import NavigationBar from './components/NavigationBar';
import './styles.css'
import Login from './Pages/LoginPage';
import ForgotPassword from './Pages/ForgotPasswordPage';
import Register from './Pages/RegisterPage';
import LogoutPage from './Pages/LogoutPage';
import ChangePassword from './Pages/ChangePassword';
import { UserContext, User } from './components/UserContext';
import PrivateRoute from './components/PrivateRoute';

const App: React.FC = () => {
  const [user, setUser] = useState<User | null>(null);

  return (
    <div className="bg-gradient-to-b from-yellow-500 via-blue-500 to-grey-700 ...">
      <UserContext.Provider value={{ user, setUser }}>
        <Router>
          <NavigationBar />
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/forgotPassword" element={<ForgotPassword />} />
            <Route path="/logout" element={<LogoutPage />} />
            <Route path="/tasks" element={<PrivateRoute component={TaskManager} />} />
            <Route path="/changePassword" element={<PrivateRoute component={ChangePassword} />} />
          </Routes>
        </Router>
      </UserContext.Provider>
    </div>

  );
};

export default App;
