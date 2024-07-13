import React, { useState } from 'react';
import axios from 'axios';

const CustomerForm = () => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [customerIdNumber, setCustomerIdNumber] = useState('');
    const [netIncomeAmount, setNetIncomeAmount] = useState('');
    const [message, setMessage] = useState(null); // Mesaj durumu

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/customers', {
                Name: firstName,
                Surname: lastName,
                CustomerType: 'Default',
                ID_Customer: customerIdNumber, // ID_Customer olarak güncellendi
                NetIncomeAmount: netIncomeAmount || null
            });
            console.log(response.data);
            setMessage('Customer saved successfully!'); // Başarı mesajı
            // Formu sıfırlayın
            setFirstName('');
            setLastName('');
            setCustomerIdNumber('');
            setNetIncomeAmount('');
        } catch (error) {
            console.error(error);
            setMessage('Failed to save customer.'); // Hata mesajı
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>First Name:</label>
                <input
                    type="text"
                    value={firstName}
                    onChange={(e) => setFirstName(e.target.value)}
                    placeholder="First Name"
                    required
                />
            </div>
            <div>
                <label>Last Name:</label>
                <input
                    type="text"
                    value={lastName}
                    onChange={(e) => setLastName(e.target.value)}
                    placeholder="Last Name"
                    required
                />
            </div>
            <div>
                <label>ID Number:</label>
                <input
                    type="text"
                    value={customerIdNumber}
                    onChange={(e) => setCustomerIdNumber(e.target.value)}
                    placeholder="ID Number"
                    pattern="\d{0,11}"
                    title="Please enter up to 11 digits"
                    required
                />
            </div>
            <div>
                <label>Net Income Amount:</label>
                <input
                    type="number"
                    value={netIncomeAmount}
                    onChange={(e) => setNetIncomeAmount(e.target.value)}
                    placeholder="Net Income Amount"
                    min="0"
                />
            </div>
            <button type="submit">Add Customer</button>
            {message && <p>{message}</p>} {/* Mesajı göster */}
        </form>
    );
};

export default CustomerForm;
