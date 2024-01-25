import React, { useState } from 'react';
import axios from 'axios';

const AddEventForm = () => {

    const [location, setLocation] = useState('');
    const [name, setName] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        try{
            axios.post('http://localhost:5029/api/event', {
                id: Math.floor(Math.random() * 10000),
                location,
                name
            });

        }
        catch(e){
            console.log(e);
        }
        console.log('Form submitted:', { title, date, description });
    };

    return (
        <form onSubmit={handleSubmit}>
            <label htmlFor="title">Name:</label>
            <input
                type="text"
                id="name"
                value={name}
                onChange={(e) => setTitle(e.target.value)}
            />

            <label htmlFor="date">Location:</label>
            <input
                type="text"
                id="location"
                value={location}
                onChange={(e) => setDate(e.target.value)}
            />

            <button type="submit">Add Event</button>
        </form>
    );
};

export default AddEventForm;
