
import React, { useState } from 'react';

function EquationGenerator({ onGenerateEquation }) {
  const [equation, setEquation] = useState('');
  const [operator, setOperator] = useState('and');
  const [operandA, setOperandA] = useState(false);
  const [operandB, setOperandB] = useState(false);

  function handleGenerateClick() {
    const newEquation = `${operandA ? 'A' : 'B'} ${operator} ${operandB ? 'True' : 'False'}`;
    onGenerateEquation(newEquation);
  }

  return (
    <div className="equation-generator">
      <h3>Создание уравнения:</h3>
      <div>
        <label>
          Operand A:
          <input type="checkbox" checked={operandA} onChange={() => setOperandA(!operandA)} />
        </label>
      </div>
      <div>
        <label>
          Operator:
          <select value={operator} onChange={(e) => setOperator(e.target.value)}>
            <option value="and">AND</option>
            <option value="or">OR</option>
            <option value="no">NO</option>
          </select>
        </label>
      </div>
      <div>
        <label>
          Operand B:
          <input type="checkbox" checked={operandB} onChange={() => setOperandB(!operandB)} />
        </label>
      </div>
      <div>
        <button onClick={handleGenerateClick}>Сгенерировать уравнение</button>
      </div>
    </div>
  );
}

export default EquationGenerator;
