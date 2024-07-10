// src/App.js
import React, { useState } from 'react';
import LoginForm from './components/LoginForm';
import TransactionForm from './components/TransactionForm';

const App = () => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    const handleLogin = (cardNumber, pin) => {
        // Bu bölümde, API çağrısı ile kimlik doğrulaması yapın
        if (cardNumber === '1234567890' && pin === '1234') {
            setIsAuthenticated(true);
        } else {
            alert('Geçersiz kart numarası veya PIN');
        }
    };

    return (
        <div>
            {isAuthenticated ? (
                <TransactionForm />
            ) : (
                <LoginForm onLogin={handleLogin} />
            )}
        </div>
    );
};

export default App;
