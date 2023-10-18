
import React from 'react';

function Equation({ equation, operator, value }) {
  return (
    <div className="equation">
      <div className="equation-text">
        {equation} {operator} {value ? 'True' : 'False'}
      </div>
    </div>
  );
}

export default Equation;
