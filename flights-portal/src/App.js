import './App.css';
import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './components/Home';
import Login from './components/Login';
import Logout from './components/Logout';

class App extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      user: null,
      isLoadingUser: true,
    };
  }

  async componentDidMount() {    
  }

  render() {  
    return (    
   <BrowserRouter>
     <Routes>
     <Route path='/' element={<Home />}>
       <Route index element={<Home />} />     
     </Route>
      </Routes>
    </BrowserRouter>
    );
  }
}
export default App;


