import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [excavators, setExcavators] = useState();

    useEffect(() => {
        populateExcavatorData();
    }, []);

    const contents = excavators === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Model</th>
                    <th>Manufacturer</th>
                    <th>Year</th>
                    <th>Weight</th>
                    <th>Type</th>
                </tr>
            </thead>
            <tbody>
                {excavators.map(excavator =>
                    <tr key={excavator.model}>
                        <td>{excavator.manufacturer}</td>
                        <td>{excavator.yearOfFabrication}</td>
                        <td>{excavator.weight}</td>
                        <td>{excavator.excavatorType.type}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Excavators</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
    
    async function populateExcavatorData() {
        const response = await fetch('http://localhost:5029/api/excavator');
        const data = await response.json();
        setExcavators(data);
    }
}

export default App;