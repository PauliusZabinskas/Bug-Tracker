import React, { useState } from 'react';
import axios from 'axios'; // import axios
import { useNavigate } from 'react-router-dom';

const Register: React.FC = () => {
    const [username, setUsername] = useState('');
    const [fullname, setFullname] = useState('');
    const [password, setPassword] = useState('');
    // const [email, setEmail] = useState('');
    const [showPassword, setShowPassword] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        // Handle registration logic here
        // create a user object

        if (username.length < 6) {
            alert("Username should be at least 6 characters long");
            return;
        }

        if (fullname.length < 6) {
            alert("Full name should be at least 6 characters long");
            return;
        }
        if (!/(?=.*[0-9])(?=.*[a-zA-Z])/.test(password)) {
            alert("Password should contain both digits and letters");
            return;
        }
        const user = {
            UserName: username,
            FullName: fullname,
            Password: password,
            // Email: email
        };

        // post the user object to the API
        try {
            const response = await axios.post('http://localhost:5047/auth/register', user); // replace with your API's URL
            if (response.data) {
                if (response.data) {
                    navigate('/home'); //redirects to home page
                }
            }
        } catch(error: any) {
            if (error.response) {
                // The request was made and the server responded with a status code
                // that falls out of the range of 2xx
                console.log(error.response.data);
                console.log(error.response.status);
                console.log(error.response.headers);
            } else if (error.request) {
                // The request was made but no response was received
                // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
                // http.ClientRequest in node.js
                console.log(error.request);
            } else {
                // Something happened in setting up the request that triggered an Error
                console.log('Error', error.message);
            }
            console.log(error.config);
        };
        
        
    }
    return (
        <div className="flex justify-center items-center h-screen bg-gray-200">
            <form onSubmit={handleSubmit} className="bg-white p-6 rounded shadow-md w-80">
                <h2 className="text-2xl font-bold mb-5 text-center">Register</h2>
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
                    <label className="block text-gray-700">Full Name</label>
                    <input
                        type="text"
                        value={fullname}
                        onChange={(e) => setFullname(e.target.value)}
                        className="mt-1 px-4 py-2 w-full border border-gray-300 rounded"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700">Password</label>
                    <input
                        type={showPassword ? 'text' : 'password'}
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="mt-1 px-4 py-2 w-full border border-gray-300 rounded"
                        required
                    />
                    <div className="mt-1">
                        <label className="inline-flex items-center">
                            <input
                                type="checkbox"
                                checked={showPassword}
                                onChange={(e) => setShowPassword(e.target.checked)}
                                className="form-checkbox"
                            />
                            <span className="ml-2">Show password</span>
                        </label>
                    </div>
                </div>
                {/* <div className="mb-4">
                    <label className="block text-gray-700">Email Address</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className="mt-1 px-4 py-2 w-full border border-gray-300 rounded"
                        required
                    />
                </div> */}
                <button type="submit"  className="w-full py-2 px-4 bg-blue-600 text-white rounded hover:bg-blue-700">Register</button>
            </form>
        </div>
    );
};

export default Register;
