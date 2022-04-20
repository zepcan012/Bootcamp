import { useState } from "react";
import logo from './logo.svg';
import './App.css';
import Greet from './components/Greet';
import Welcome from './components/Welcome';
import Hello from './components/Hello';
import MeetAndGreet from './components/MeetAndGreet';
import MeetAndGreetClass from './components/MeetAndGreetClass';
import NameList from './components/NameList';
import ContactForm from './components/ContactForm';
import ContactList from './components/ContactForm';


function App() {

  const [contacts, updateContacts] = useState([]);

  const addContact = (contact) => {
    updateContacts([...contacts, contact]);
  };
  
  return (
  
    <div className="App">
      <ContactForm addContact={addContact}/>
      <ContactList contacts={contacts}/>
     <header className="App-header">
        
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>

        
      </header> 
      <Greet />
      <Welcome />
      <Hello />
      <MeetAndGreet name= "Bruce" heroName="Batman">
        <p>This is exapmle of children props.</p>
      </MeetAndGreet>

      <MeetAndGreet name= "Clark" heroName="Superman"/>
      <MeetAndGreet name= "Diana" heroName="Wonder Woman"/> 

      <MeetAndGreetClass name="Peter" heroName="Superman"/>

      <NameList/>
     
    </div>
  );
}

export default App;
