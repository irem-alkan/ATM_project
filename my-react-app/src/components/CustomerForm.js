import React, { useState } from 'react';
import axios from 'axios';

const CustomerForm = () => {
    const [Name, setName] = useState('');
    const [Surname, setSurname] = useState('');
    const [CustomerType, setCustomerType] = useState('');
    const [NetIncomeAmount, setNetIncomeAmount] = useState('');
    const [message, setMessage] = parseFloat(null); 

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/Customer', {
                Name: Name,
                Surname: Surname,
                CustomerType: CustomerType,
                NetIncomeAmount: Number(NetIncomeAmount),
            });
            console.log(response.data);
            setMessage('Customer saved successfully!');
            
            setName('');
            setSurname('');
            setCustomerType('');
            setNetIncomeAmount('');
        } catch (error) {
            console.error('Error details:', error);
            setMessage('Failed to save customer.');
        }
        
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>First Name:</label>
                <input
                    type="text"
                    value={Name}
                    onChange={(e) => setName(e.target.value)}
                    placeholder="First Name"
                    required
                />
            </div>
            <div>
                <label>Last Name:</label>
                <input
                    type="text"
                    value={Surname}
                    onChange={(e) => setSurname(e.target.value)}
                    placeholder="Last Name"
                    required
                />
            </div>
            <div>
                <label>Customer Type:</label>
                <input
                    type="text"
                    value={CustomerType}
                    onChange={(e) => setCustomerType(e.target.value)}
                    placeholder="Customer Type"
                />
            </div>
            <div>
                <label>Net Income Amount:</label>
                <input
                    type="text"
                    value={NetIncomeAmount}
                    onChange={(e) => setNetIncomeAmount(e.target.value)}
                    placeholder="Net Income Amount"
                    min="0"
                />
            </div>
            <button type="submit">Add Customer</button>
            {message && <p>{message}</p>}
        </form>
    );
};

export default CustomerForm;
