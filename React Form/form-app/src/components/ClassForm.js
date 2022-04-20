import React from "react";



class ClassForm extends React.Component{

    constructor(props){
        super(props)
        this.state={
            firstName: "",
            lastName:"",
            email: "",
            phoneNumber: "",
            submittedList:[]
        }

        this.changeFirstNameHandler=this.changeFirstNameHandler.bind(this);
        this.changeLastNameHandler=this.changeLastNameHandler.bind(this);
        this.changeEmailHandler=this.changeEmailHandler.bind(this);
        this.changePhoneNumberHandler=this.changePhoneNumberHandler.bind(this);
        this.handleSubmit=this.handleSubmit.bind(this);

    }


changeFirstNameHandler=(event)=>{
    this.setState({firstName:event.target.value});
}

changeLastNameHandler=(event)=>{
    this.setState({lastName:event.target.value});
}

changeEmailHandler=(event)=>{
    this.setState({email:event.target.value});
}

changePhoneNumberHandler=(event)=>{
    this.setState({phoneNumber:event.target.value});
}

handleSubmit=(event)=>{
    event.preventDefault();
    let formData = {
        firstName: this.state.firstName,
        lastName:this.state.lastName,
        email: this.state.email,
        phoneNumber:this.state.phoneNumber
    };
    this.setState({firstName:"", lastName:"", email:"", phoneNumber:""});
    
    let mergeList = this.state.submittedList.concat(formData);
    this.setState({submittedList: mergeList});
   
};

displayList = () =>{
    return this.state.submittedList.map((data)=> {
        return (
          <div>
            <p className="card-name">Ime: {data.firstName}</p>
            <p>Prezime: {data.lastName}</p>
            <p>E-mail: {data.email}</p>
            <p>Kontakt: {data.phoneNumber}</p>
          </div>
        );
      });
};


    render(){
        return(
            <div>
                <div className="form-container">
                    <form onSubmit={this.handleSubmit}> 
                        <div className="contact-text">
                            <h3>Contact Form</h3>
                        </div>
                        <div>
                            <input
                                className="inputClass"
                                type="text"
                                name="firstName"
                                 placeholder="First Name"
                                value={this.state.firstName}
                                onChange={this.changeFirstNameHandler}
                            />
                        </div>
                         <div>
                             <input
                                className="inputClass"
                                type="text"
                                name="lastName"
                                placeholder="Last Name"
                                value={this.state.lastName}
                                onChange={this.changeLastNameHandler}
                            />
                        </div>
                        <div>
                            <input
                                className="inputClass"
                                type="email"
                                name="email"
                                placeholder="Email"
                                value={this.state.email}
                                onChange={this.changeEmailHandler}

                            />
                        </div>
                        <div>
                            <input
                                className="inputClass"
                                type="number"
                                name="phoneNumber"
                                placeholder="Phone Number"
                                value={this.state.phoneNumber}
                                onChange={this.changePhoneNumberHandler}

                            />
                        </div>
                        <div>
                            <button className="button-form">Submit Contact</button>
                        </div>
                    </form>
                    {this.displayList()}
                </div>
            </div>
        )
    }
}

export default ClassForm