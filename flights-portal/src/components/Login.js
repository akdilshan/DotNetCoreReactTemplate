import React, { useEffect } from 'react';
import userManager from '../utils/userManager';

const Login = () => {
    useEffect(() => {
        userManager.signinRedirectCallback().then(user => {
          // Save the access token to local storage
          localStorage.setItem('accessToken', user.access_token);
    
          // Redirect to the home page
          window.location = '/';
        });
      }, []);
    
      return (
        <div>
          <p>Redirecting...</p>
        </div>
      );
}

export default Login;