/*import { useState } from "react";*/
import './App.css';
/*import ContactForm from "./components/ContactForm.jsx";
import ContactList from "./components/ContactList.jsx";*/
import ClassForm from "./components/ClassForm";

function App() {
  {/*const [contacts, updateContacts] = useState([]);

  const addContact = (contact) => {
    updateContacts([...contacts, contact]);
  };*/}



  return (
      <div className="App">
      {/*<ContactForm addContact={addContact} />
      <ContactList contacts={contacts} /> */}

      <ClassForm/>
    </div>
  );
}


export default App;
