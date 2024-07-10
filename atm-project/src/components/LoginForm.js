// src/components/LoginForm.js
import React, { useState } from 'react';

const LoginForm = ({ onLogin }) => {
    const [cardNumber, setCardNumber] = useState('');
    const [pin, setPin] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onLogin(cardNumber, pin);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Kart Numarası:</label>
                <input
                    type="text"
                    value={cardNumber}
                    onChange={(e) => setCardNumber(e.target.value)}
                />
            </div>
            <div>
                <label>PIN:</label>
                <input
                    type="password"
                    value={pin}
                    onChange={(e) => setPin(e.target.value)}
                />
            </div>
            <button type="submit">Giriş Yap</button>
        </form>
    );
};

export default LoginForm;
