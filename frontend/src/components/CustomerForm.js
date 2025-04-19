import React, { useState, useEffect } from 'react';

function CustomerForm({ onSave, editingCustomer }) {
  const [customer, setCustomer] = useState({ name: '', email: '', phone: '' });

  useEffect(() => {
    if (editingCustomer) setCustomer(editingCustomer);
  }, [editingCustomer]);

  const handleChange = e => setCustomer({ ...customer, [e.target.name]: e.target.value });

  const handleSubmit = e => {
    e.preventDefault();
    onSave(customer);
    setCustomer({ name: '', email: '', phone: '' });
  };

  return (
    <form onSubmit={handleSubmit}>
      <input name="name" placeholder="Name" value={customer.name} onChange={handleChange} required />
      <input name="email" placeholder="Email" value={customer.email} onChange={handleChange} required />
      <input name="phone" placeholder="Phone" value={customer.phone} onChange={handleChange} required />
      <button type="submit">{customer.id ? "Update" : "Create"}</button>
    </form>
  );
}

export default CustomerForm;
