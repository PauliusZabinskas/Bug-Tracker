import axios from 'axios';
import React, { useState } from 'react';

const ChangePassword: React.FC = () => {
    const [username, setUsername] = useState('');
    
    const [oldPassword, setOldPassword] = useState('');
    const [newPassword, setNewPassword] = useState('');

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const user = {
            UserName: username,
            OldPassword: oldPassword,
            NewPassword: newPassword
        };

        // post the user object to the API
        try {
            const response = await axios.post('http://localhost:5047/auth/forgot-password', user);
            if (response.data) {
                // handle success here - perhaps show a success message to the user
            }
        } catch (error: any) {
            if (error.response) {
                console.log(error.response.data);
                console.log(error.response.status);
                console.log(error.response.headers);
            } else if (error.request) {
                console.log(error.request);
            } else {
                console.log('Error', error.message);
            }
            console.log(error.config);
        };
    };

    return (
        <div className="flex justify-center items-center h-screen bg-gray-200">
            <form onSubmit={handleSubmit} className="bg-white p-6 rounded shadow-md w-80">
                <h2 className="text-2xl font-bold mb-5 text-center">Forgot Password</h2>
                <div className="mb-4">
                    <label className="block text-gray-700">Username</label>
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        className="mt-1 px-4 py-2 w-full border border-gray-300 rounded"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700">Old password</label>
                    <input
                        type="text"
                        value={oldPassword}
                        onChange={(e) => setOldPassword(e.target.value)}
                        className="mt-1 px-4 py-2 w-full border border-gray-300 rounded"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700">New password</label>
                    <input
                        type="email"
                        value={newPassword}
                        onChange={(e) => setNewPassword(e.target.value)}
                        className="mt-1 px-4 py-2 w-full border border-gray-300 rounded"
                        required
                    />
                </div>
                <button type="submit" className="w-full py-2 px-4 bg-blue-600 text-white rounded hover:bg-blue-700">Reset Password</button>
            </form>
        </div>
    );
};

export default ChangePassword;
