// src/components/TransactionForm.js
import React, { useState } from 'react';

const TransactionForm = () => {
    const [amount, setAmount] = useState('');
    const [transactionType, setTransactionType] = useState('deposit');

    const handleSubmit = (e) => {
        e.preventDefault();
        // Bu bölümde, API çağrısı ile para çekme/yükleme işlemlerini gerçekleştirin
        alert(`İşlem Türü: ${transactionType}, Miktar: ${amount}`);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>İşlem Türü:</label>
                <select
                    value={transactionType}
                    onChange={(e) => setTransactionType(e.target.value)}
                >
                    <option value="deposit">Para Yatırma</option>
                    <option value="withdraw">Para Çekme</option>
                </select>
            </div>
            <div>
                <label>Miktar:</label>
                <input
                    type="number"
                    value={amount}
                    onChange={(e) => setAmount(e.target.value)}
                />
            </div>
            <button type="submit">İşlemi Gerçekleştir</button>
        </form>
    );
};

export default TransactionForm;
