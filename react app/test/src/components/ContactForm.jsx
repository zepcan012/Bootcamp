import { useState } from "react";


function UserForm({addContact}){

    const [contactInfo, setContactInfo] = useState({
        name: "",
        email: "",
        phonenumber:"",
    });

    const handleChange=(event)=>{
        setContactInfo({...contactInfo, [event.target.name]: event.target.value});
      };

      const handleSubmit = (event) => {
        event.preventDefault();
        addContact(contactInfo);
        setContactInfo({ name: "", email: "", phonenumber: "" });
      };
   
    return(
        <div className="formContainer">
            <form onSubmit={handleSubmit}>
                <div>
                    <h3>Contact Form</h3>
                </div>
                <div>
                    <input type="text" name="name" placeholder="Name" value={contactInfo.name} onChange={handleChange}/>
                </div>
                <div>
                    <input type="email" name="email" placeholder="Email" value={contactInfo.email} onChange={handleChange}/>
                </div>
                <div>
                    <input type="number" name="phonenumber" placeholder="Phone Number" value={contactInfo.phonenumber} onChange={handleChange}/>
                </div>
                <div>
                    <button>Submit Contact</button>
                    <p>{contactInfo.email}</p>
                </div>
            </form>
        </div>
    );

   
  
}


export default UserForm