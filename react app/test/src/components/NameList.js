import React from 'react'


function NameList(){
    const persons = [
        {
            id:1,
            name:'Bruce',
            age: 29
        },
        {
            id:2,
            name:'Clark',
            age: 33
        },
        {
            id:3,
            name:'Diana',
            age: 25
        },
    ]

    const personList = persons.map(person =><h2>I am {person.name} and I am {person.age} years old</h2>)
return(
    <div>
        <p>List example:</p>
        {personList}
    </div>
)

}

export default NameList