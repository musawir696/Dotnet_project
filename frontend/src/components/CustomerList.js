import React from 'react';

function CustomerList({ customers, onEdit }) {
  return (
    <table>
      <thead>
        <tr><th>Name</th><th>Email</th><th>Phone</th><th>Action</th></tr>
      </thead>
      <tbody>
        {customers.map(c => (
          <tr key={c.id}>
            <td>{c.name}</td>
            <td>{c.email}</td>
            <td>{c.phone}</td>
            <td>
              <button onClick={() => onEdit(c)}>Edit</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default CustomerList;
