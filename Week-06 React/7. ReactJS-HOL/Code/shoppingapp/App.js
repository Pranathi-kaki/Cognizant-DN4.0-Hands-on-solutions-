import React, { Component } from 'react';
import Cart from './Cart';

class OnlineShopping extends Component {
  constructor(props) {
    super(props);

    // Array of cart items
    this.state = {
      cartItems: [
        { Itemname: 'Laptop', Price: 55000 },
        { Itemname: 'Mobile', Price: 22000 },
        { Itemname: 'Headphones', Price: 2000 },
        { Itemname: 'Keyboard', Price: 1500 },
        { Itemname: 'Smart Watch', Price: 5000 }
      ]
    };
  }

  render() {
    return (
      <div style={{ textAlign: 'center', padding: '20px', fontFamily: 'Arial' }}>
        <h1>🛒 Welcome to Online Shopping</h1>
        <div>
          {this.state.cartItems.map((item, index) => (
            <Cart key={index} Itemname={item.Itemname} Price={item.Price} />
          ))}
        </div>
      </div>
    );
  }
}

export default OnlineShopping;
