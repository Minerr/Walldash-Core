import React from "react";
import { Link } from "react-router-dom";
import FullscreenToggle from "./patials/FullscreenToggle";
import fire from "../config/fire";

const Navbar = () => {
  return (
    <div className='nav-bar'>
      <ul>
        <li>
          <Link to='/'>Walldash</Link>
        </li>
        <li>
          <Link to='/portal'>Portal</Link>
        </li>
        <li style={{ float: "right" }}>
          <div className='logout' onClick={() => fire.auth().signOut()}>
            Logout
          </div>
        </li>
        <li style={{ float: "right" }}>
          <FullscreenToggle />
        </li>
      </ul>
    </div>
  );
};

export default Navbar;
