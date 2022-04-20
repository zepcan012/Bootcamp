export default function UserList({contacts}) {
    return (
      <div>
        {contacts.map((contact) => (
          <div className="card" key={contact.phonenumber}>
            <p className="card-name">Ime: {contact.name}</p>
            <p>Prezime: {contact.lastname}</p>
            <p>E-mail: {contact.email}</p>
            <p>Kontakt: {contact.phonenumber}</p>
          </div>
        ))}
      </div>
    );
  }