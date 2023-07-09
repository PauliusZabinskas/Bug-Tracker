import { Link } from 'react-router-dom';
import { useState } from 'react';

const NavigationBar: React.FC = () => {
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    return (
        <nav className="flex justify-between px-10 py-5 bg-blue-500 text-white">
            <ul className="flex space-x-4">
                <li className="hover:text-lg hover:font-bold"><Link to="/">Home</Link></li>
            </ul>
            <ul className="flex space-x-4">
                <li className="group relative " onMouseEnter={() => setIsMenuOpen(true)}>
                    <button onClick={() => setIsMenuOpen(!isMenuOpen)} >Menu</button>
                    {isMenuOpen && (
                        <ul className="absolute right-0 mt-2 space-y-2 bg-white text-black p-2 rounded shadow-lg" onMouseLeave={() => setIsMenuOpen(false)}>
                            <li className='hover:text-lg hover:font-bold'><Link to="/login">Login</Link></li>
                            <li className='hover:text-lg hover:font-bold'><Link to="/register">Register</Link></li>
                            <li className='hover:text-lg hover:font-bold'><Link to="/logout">Logout</Link></li>
                            <li className='hover:text-lg hover:font-bold'><Link to="/changePassword">Chnage Password</Link></li>
                            <li className='hover:text-lg hover:font-bold'><Link to="/tasks">Tasks</Link></li>
                        </ul>
                    )}
                </li>
            </ul>
        </nav>
    );
};

export default NavigationBar;
