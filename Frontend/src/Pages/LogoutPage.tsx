import React from 'react';
import { Link } from 'react-router-dom';

const Logout: React.FC = () => {
    // You can add your logout logic here

    return (
        <div className="flex flex-col justify-center items-center h-screen bg-gray-200">
            <h2 className="text-2xl font-bold mb-5">Logged Out</h2>
            <Link to="/login" className="mb-4 bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">Log In</Link>
            <Link to="/" className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">Home</Link>
        </div>
    );
};

export default Logout;
