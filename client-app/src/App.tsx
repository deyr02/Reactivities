import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List, ListItem } from 'semantic-ui-react';


function App() {

  const [Activities, setActivities] = useState([]);
  
  useEffect(()=>{
    axios.get("http://localhost:5000/api/activities").then(response =>{
    console.log(response);    
    setActivities(response.data);
    })
  }, [])
  return (
    <div >
      <Header as="h2" icon="users" content='Reactivities'/>
        <List>
            {Activities.map((activity:any) =>(
              <ListItem key ={activity.id}>{activity.title}</ListItem>
            ))}
        </List>
    </div>
  );
}

export default App;
