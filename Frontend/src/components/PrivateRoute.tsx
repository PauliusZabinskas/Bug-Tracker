import React, { useContext } from 'react';
import { Navigate } from 'react-router-dom';
import { UserContext } from './UserContext';

const PrivateRoute = ({ component: Component, ...props }: any) => {
  const context = useContext(UserContext);

  // if context is undefined, return null or redirect to some error page
  if (!context) return null;

  const { user } = context;

  // if user is not logged in, redirect to login page
  if (!user) return <Navigate to="/login" />;

  // if user is logged in, render the component
  return <Component {...props} />;
};

export default PrivateRoute;