import React, { useState, useEffect } from 'react';

function Equation({ equation }) {
  const [result, setResult] = useState(null);

  useEffect(() => {
    
    const operator = equation.split(' ')[1]; 
    const operands = equation.split(' '); 

    if (operator === 'and' || operator === 'or') {
      const [operandA, , operandB] = operands;
      fetch(`https://localhost:7118/api/ANDloogika/${operator}_operatsioon/${operandA}/${operandB}`)
        .then((res) => res.json())
        .then((json) => setResult(json));
    } else if (operator === 'not') {
      const [operandA] = operands;
      fetch(`https://localhost:7118/api/ANDloogika/${operator}_operatsioon/${operandA}`)
        .then((res) => res.json())
        .then((json) => setResult(json));
    }
  }, [equation]);

  return (
    <div className="equation">
      <div className="equation-text">
        <label>{equation} = {result !== null ? result : 'Calculating...'}</label>
      </div>
    </div>
  );
}

export default Equation;
