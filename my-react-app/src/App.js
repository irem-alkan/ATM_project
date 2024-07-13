import React from 'react';
import CustomerForm from './components/CustomerForm';
import CustomerJobForm from './components/CustomerJobForm';
import CustomerRelationForm from './components/CustomerRelationForm';
import AccountDetail from './components/AccountDetail';
import DebtPaymentForm from './components/DebtPaymentForm';
import CustomerList from './components/CustomerList';

const App = () => {
    return (
        <div>
            <h1>Customer Entry</h1>
            <CustomerForm />
            <h1>Customer Job Entry</h1>
            <CustomerJobForm customerId={1} />
            <h1>Customer Relation Entry</h1>
            <CustomerRelationForm customerId={1} />
            <h1>Debt Selection</h1>
            <DebtPaymentForm />
            <h1>Account Detail</h1>
            <AccountDetail ID_Account={1} />
            <h1>Customer List</h1>
            <CustomerList />
        </div>
    );
};

export default App;
