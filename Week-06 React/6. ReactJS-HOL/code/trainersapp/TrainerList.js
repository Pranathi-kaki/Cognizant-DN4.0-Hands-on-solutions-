import React from 'react';
import { Link } from 'react-router-dom';

function TrainersList({ trainers }) {
  return (
    <div style={{ textAlign: 'center', padding: '20px' }}>
      <h2>👥 Trainers List</h2>
      <ul style={{ listStyleType: 'none', padding: 0 }}>
        {trainers.map(trainer => (
          <li key={trainer.TrainerId} style={{ margin: '10px 0' }}>
            <Link to={`/trainers/${trainer.TrainerId}`} style={{ textDecoration: 'none', color: 'blue' }}>
              {trainer.Name}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default TrainersList;
