
import React, { useState } from 'react';
import Equation from './Equation'; 
import EquationGenerator from './EquationGenerator'; 
import './App.css';

function App() {
  const [isTest, setTest] = useState(false);
  const [selectedValue, setSelectedValue] = useState(null);
  const [equations, setEquations] = useState([]); 

  function handleFormSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const selectedOption = formData.get('logmath');
    setSelectedValue(selectedOption);
    setTest(true);
  }

  function addEquation(newEquation) {
    setEquations([...equations, newEquation]);
  }

  return (
    <div>
      <header>
        <h1>Ülalt-alla loogiskaskeem</h1>
      </header>
      <form onSubmit={handleFormSubmit}>
        <div className="choise">
          {!isTest ? (
            <div>
              <label htmlFor="bool1">Choose final value:</label>
              <select name="logmath" id="bool1">
                <option value="true">True</option>
                <option value="false">False</option>
              </select>
              <input type="submit" id="layer1" value="Ready" />
            </div>
          ) : (
            <div>
              {selectedValue !== null && (
                <div>
                  <label>Вы выбрали: {selectedValue}</label>
                </div>
              )}
            </div>
          )}
        </div>
      </form>
      {isTest && (
        <div>
          {selectedValue !== null && (
            
            <div>
              <EquationGenerator onGenerateEquation={addEquation} />
              <p>Вы выбрали: {selectedValue}</p>
            </div>
          )}
          
          <div className="equations">
            {equations.map((equation, index) => (
              <Equation key={index} equation={equation} />
            ))}
          </div>

          
        </div>
      )}
    </div>
  );
}

export default App;