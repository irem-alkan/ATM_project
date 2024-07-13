import React, { useEffect, useState } from 'react';
import axios from 'axios';

const AccountDetail = ({ ID_Account }) => {
    const [account, setAccount] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchAccountDetails = async () => {
            try {
                const response = await axios.get(`/api/accounts/${ID_Account}`);

                setAccount(response.data);
            } catch (err) {
                setError(err);
            } finally {
                setLoading(false);
            }
        };

        fetchAccountDetails();
    }, [ID_Account]);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error.message}</div>;
    }

    return (
        <div>
            <h2>Account</h2>
            {account ? (
                <div>
                    <p>ID: {account.ID_Account}</p>
                    <p>Balance: {account.balance}</p>
                </div>
            ) : (
                <p>No account found</p>
            )}
        </div>
    );
};

export default AccountDetail;
