import React, { useState, useEffect } from 'react';

const Home = () => {   
   const [flights, setFlights] = useState([]);
   // GET with fetch API
   useEffect(() => {
      const fetchPost = async () => {
         const response = await fetch(
            'https://localhost:5445/api/Flights'
         );
         const data = await response.json();
         console.log(data);
         setFlights(data);
      };
      fetchPost();
   }, []);

   return (
    <div>
    <ul>
          {flights.map(flight => (
            <li key={flight.id}>
             Airline:  {flight.airLine}; from : {flight.from};   To: {flight.to}
            </li>
          ))}
        </ul>
  </div>
   );
};

export default Home;