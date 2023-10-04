import {useEffect,useRef, useState} from 'react';

function App() {
  const [isTest, setTest] = useState(false);

  function Firstlayer(){
    setTest(true);
    
  }
  return (
    <body>
      <header>
      <h1>Ülalt-alla loogiskaskeem</h1>
    </header>
    <form action={Firstlayer}>
    <div className="choise">Choose final value:
      {isTest === false && <select name="logmath" id="bool1">
        <option value="true">True</option>
        <option value="false">False</option>
      </select>}
      {isTest === true && <h2>TEST</h2>}
      {isTest === false && <input type="submit" id='layer1' value='Ready'/>}
      
    </div>
    
    </form>
    
    
    </body>
  );
}



export default App;


