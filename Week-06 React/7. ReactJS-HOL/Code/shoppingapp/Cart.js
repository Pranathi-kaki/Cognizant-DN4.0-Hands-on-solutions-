import React, { Component } from 'react';

class Cart extends Component {
  render() {
    const { Itemname, Price } = this.props;

    return (
      <div style={{ 
        border: '1px solid #ccc', 
        padding: '10px', 
        margin: '10px auto', 
        width: '300px', 
        borderRadius: '8px', 
        backgroundColor: '#f9f9f9',
        textAlign: 'left',
        fontFamily: 'Arial'
      }}>
        <p><strong>Item:</strong> {Itemname}</p>
        <p><strong>Price:</strong> ₹{Price}</p>
      </div>
    );
  }
}

export default Cart;
