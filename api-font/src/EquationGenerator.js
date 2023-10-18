
import React, { useState } from 'react';

function EquationGenerator({ onGenerateEquation }) {
  const [equation, setEquation] = useState('');
  const [operator, setOperator] = useState('and');
  const [operandA, setOperandA] = useState(false);
  const [operandB, setOperandB] = useState(false);
  const [notcheck, setnotcheck] = useState(true);

  function handleGenerateClick() {
      if    (operator == "and" || operator == "or"){
        const newEquation = `${operandA ? 'True' : 'False'} ${operator} ${operandB ? 'True' : 'False'}`;
        onGenerateEquation(newEquation);
      }
      else if (operator == "not"){
        const newEquation = `${operandA ? 'True' : 'False'} ${operator}`;
        onGenerateEquation(newEquation);
    }

  }

  function OperationCheck(e){
    setOperator(e)
    if  (e == "not"){
        setnotcheck(false)
    }
    else {
        setnotcheck(true)
    }
  }

  return (
    <div className="equation-generator">
      <h3>Создание уравнения:</h3>
      <div>
        <label>
          Operand A: {operandA}
          <input type="checkbox" checked={operandA} onChange={() => setOperandA(!operandA)} />
          
        </label>
      </div>
      <div>
        <label>
          Operator:
          <select value={operator} onChange={(e) => setOperator(e.target.value)}>
            <option value="and">AND</option>
            <option value="or">OR</option>
            <option value="not">NOT</option>
          </select>
        </label>
      </div>
      {operator != "not" && (
        <div>
            <label>
            Operand B:
            <input type="checkbox" checked={operandB} onChange={() => setOperandB(!operandB)} />
            </label>
        </div>
      )}
      
      <div>
        <button onClick={handleGenerateClick}>Сгенерировать уравнение</button>
      </div>
    </div>
  );
}

export default EquationGenerator;