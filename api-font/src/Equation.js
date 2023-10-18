
import React, {useState, useEffect} from 'react';

function Equation({ equation, operator}) {
    const [loogika, setLoogika] = useState([]);

    function AND_operator({ operandA, operandB }){
        useEffect(() => {
            fetch("https://localhost:7118/api/ANDloogika/and_operatsioon/" + {operandA} + "/" + {operandB})
              .then(res => res.json())
              .then(json => setLoogika(json));
            }, []);
    }

    return (
        <div className="equation">
            <div className="equation-text">
                <label>{equation} {operator} = {loogika}</label>
            </div>
        </div>
    );
}

export default Equation;