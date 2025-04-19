import React, { useState, useEffect } from 'react';
import CustomerForm from './components/CustomerForm';
import CustomerList from './components/CustomerList';
import './App.css';


const API_URL = "http://localhost:5276/api/customers";

function App() {
  const [customers, setCustomers] = useState([]);
  const [editingCustomer, setEditingCustomer] = useState(null);

  const fetchCustomers = async () => {
    const res = await fetch(API_URL);
    const data = await res.json();
    setCustomers(data);
  };

  const saveCustomer = async (customer) => {
    const res = await fetch(`${API_URL}${customer.id ? `/${customer.id}` : ''}`, {
      method: customer.id ? 'PUT' : 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(customer)
    });
    await res.json().catch(() => {});
    setEditingCustomer(null);
    fetchCustomers();
  };

  useEffect(() => {
    fetchCustomers();
  }, []);

  return (
    <div className="container">
      <h2>CRM System</h2>
      <CustomerForm onSave={saveCustomer} editingCustomer={editingCustomer} />
      <CustomerList customers={customers} onEdit={setEditingCustomer} />
    </div>
  );
}

export default App;
