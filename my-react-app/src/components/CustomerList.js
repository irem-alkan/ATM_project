import React, { useState, useEffect } from 'react';

const CustomerList = () => {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        fetch("/api/customer")
            .then(response => response.json())
            .then(data => setCustomers(data))
            .catch(error => console.error('Error:', error));
    }, []);

    return (
        <div>
            <h1>Customers</h1>
            <ul>
                {customers.map(customer => (
                    <li key={customer.id}>{customer.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default CustomerList;
