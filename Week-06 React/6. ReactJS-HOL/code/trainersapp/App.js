import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from './Home';
import TrainersList from './TrainerList';
import trainers from './TrainersMock';
import TrainerDetail from './TrainerDetails'; // We'll create this next

function App() {
  return (
    <Router>
      <div style={{ padding: '20px', fontFamily: 'Arial' }}>
        <nav style={{ marginBottom: '20px', textAlign: 'center' }}>
          <Link to="/" style={{ margin: '0 15px', textDecoration: 'none' }}>Home</Link>
          <Link to="/trainers" style={{ margin: '0 15px', textDecoration: 'none' }}>Trainers</Link>
        </nav>

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/trainers" element={<TrainersList trainers={trainers} />} />
          <Route path="/trainers/:id" element={<TrainerDetail />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
