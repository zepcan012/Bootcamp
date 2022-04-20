import { useState } from "react";

export default function UserForm({addContact}) {

  const [contactInfo, setContactInfo] = useState({
    name: "",
    lastname:"",
    email: "",
    phonenumber: "",
  });

  const handleChange = (event) => {
    setContactInfo({ ...contactInfo, [event.target.name]: event.target.value });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    addContact(contactInfo);
    setContactInfo({ name: "",lastname:"", email: "", phonenumber: "" });
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit}> 
        <div className="contact-text">
          <h3>Contact Form</h3>
        </div>
        <div>
          <input
            className="inputClass"
            type="text"
            name="name"
            placeholder="Name"
            value={contactInfo.name}
            onChange={handleChange}
          />
        </div>
        <div>
          <input
            className="inputClass"
            type="text"
            name="lastname"
            placeholder="Lastname"
            value={contactInfo.lastname}
            onChange={handleChange}
          />
        </div>
        <div>
          <input
            className="inputClass"
            type="email"
            name="email"
            placeholder="Email"
            value={contactInfo.email}
            onChange={handleChange}

          />
        </div>
        <div>
          <input
            className="inputClass"
            type="number"
            name="phonenumber"
            placeholder="Phone Number"
            value={contactInfo.phonenumber}
            onChange={handleChange}

          />
        </div>
        <div>
          <button className="button-form">Submit Contact</button>
        </div>
      </form>
    </div>
  );
}