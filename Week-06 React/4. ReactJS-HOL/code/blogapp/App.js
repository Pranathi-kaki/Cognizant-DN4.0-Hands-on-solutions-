import React from 'react';
import Posts from './Posts';

function App() {
  return (
    <div className="App">
      <h1 style={{ textAlign: 'center', paddingTop: '20px', fontFamily: 'sans-serif' }}>
        ✨ Welcome to Blog App
      </h1>
      <Posts />
    </div>
  );
}

export default App;
