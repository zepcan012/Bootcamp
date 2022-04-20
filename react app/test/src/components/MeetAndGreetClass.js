import React, { Component } from 'react';

class MeetAndGreetClass extends Component {
    render() {
        return (
            <h1>Hello {this.props.name} also known as {this.props.heroName} (Example of Class props)</h1>
        );
    }
}

export default MeetAndGreetClass;