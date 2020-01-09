import React from "react";
import { Link } from "react-router-dom";
import FullscreenToggle from "./patials/FullscreenToggle";

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
          <div className='logout'>Logout</div>
        </li>
        <li style={{ float: "right" }}>
          <FullscreenToggle />
        </li>
      </ul>
    </div>
  );
};

export default Navbar;
