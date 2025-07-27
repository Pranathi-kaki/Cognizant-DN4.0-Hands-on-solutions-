import React from 'react';
import { useParams } from 'react-router-dom';
import trainers from './TrainersMock';

function TrainerDetail() {
  const { id } = useParams(); // Get ID from URL
  const trainer = trainers.find(t => t.TrainerId === parseInt(id));

  if (!trainer) {
    return <h2 style={{ textAlign: 'center' }}>Trainer not found!</h2>;
  }

  return (
    <div style={{ padding: '30px', textAlign: 'center', fontFamily: 'Arial' }}>
      <h2>👤 Trainer Details</h2>
      <p><strong>Name:</strong> {trainer.Name}</p>
      <p><strong>Email:</strong> {trainer.Email}</p>
      <p><strong>Phone:</strong> {trainer.Phone}</p>
      <p><strong>Technology:</strong> {trainer.Technology}</p>
      <p><strong>Skills:</strong></p>
      <ul style={{ listStyle: 'none', padding: 0 }}>
        {trainer.Skills.map((skill, index) => (
          <li key={index} style={{ margin: '5px 0' }}>✅ {skill}</li>
        ))}
      </ul>
    </div>
  );
}

export default TrainerDetail;
