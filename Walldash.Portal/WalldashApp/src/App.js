import React, { useEffect, useState } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Dashboard from "./components/pages/Dashboard";
import Portal from "./components/pages/Portal";
import Login from "./components/pages/Login";
import fire from "./config/fire";
import Navbar from "./components/Navbar";
import ApiClient from "./api/ApiClient";

function App() {
  const [user, setUser] = useState([null]);
  const [authenticated, setAuthenticated] = useState(false);

  useEffect(() => {
    fire.auth().onAuthStateChanged(user => {
      if (user) {
        setUser(user);
      } else {
        setUser(null);
      }
    });
    ApiClient.getBearerToken().then(response => {
      setAuthenticated(true);
    });
  }, []);

  const renderApp = () => {
    if (!authenticated) {
      return "loading";
    }
    return (
      <BrowserRouter>
        <Navbar />
        <Switch>
          <Route path='/dashboard/:id' component={Dashboard} />
          <Route path='/portal' component={Portal} />
          <Route path='/' component={Portal} />
        </Switch>
      </BrowserRouter>
    );
  };

  return user ? renderApp() : <Login />;
}

export default App;
