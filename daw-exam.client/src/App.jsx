import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [events, setEvents] = useState([]);
    const [participants, setParticipants] = useState([]);

    useEffect(() => {
        populateEventsdata();
        populalateParticipantsData();
    }, []);

    const contents = events === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Location</th>
                    <th>Name</th>
                    <th>Participants</th>
                </tr>
            </thead>
            <tbody>
                {events.map(event =>
                    <tr key={event.location}>
                        <td>{event.location}</td>
                        <td>{event.name}</td>
                        <td>
                            <ul>
                                {event.participants.map(participant =>
                                    <li key={participant.name}>{participant.name}{` | Age:${participant.age} | Email:${participant.email}`}
                                    </li>
                                )}
                            </ul>
                        </td>
                    </tr>
                )}
            </tbody>
        </table>;

    const contents2 = participants === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Age</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                {participants.map(participant =>
                    <tr key={participant.name}>
                        <td>{participant.name}</td>
                        <td>{participant.age}</td>
                        <td>{participant.email}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Events</h1>
            <p>Examen Dezvoltarea Aplicatiilor Web - C# .Net</p>
            {contents}
            <h1 id="tabelLabel">Participants</h1>
            <p>Examen Dezvoltarea Aplicatiilor Web - C# .Net</p>
            {contents2}
        </div>
    );
    
    async function populateEventsdata() {
        const response = await fetch('http://localhost:5029/api/event');
        const data = await response.json();
        setEvents(data);
    }

    async function populalateParticipantsData() {
        const response = await fetch('http://localhost:5029/api/participant');
        const data = await response.json();
        setParticipants(data);
    }

}

export default App;