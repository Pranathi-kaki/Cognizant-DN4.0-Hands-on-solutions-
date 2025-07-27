import React from 'react';
import '../Stylesheets/mystyle.css';

const percentToDecimal = (decimal) => {
  return (decimal.toFixed(2) + '%');
};

const calcScore = (total, goal) => {
  return percentToDecimal(total / goal);
};

function CalculateScore(props) {
  return (
    <div className="formatstyle">
      <h2 className="Name">Name: {props.Name}</h2>
      <h2 className="School">School: {props.School}</h2>
      <h2 className="Total">Total Marks: {props.total}</h2>
      <h2 className="Score">Average Score: {calcScore(props.total, props.goal)}</h2>
    </div>
  );
}

export default CalculateScore;
