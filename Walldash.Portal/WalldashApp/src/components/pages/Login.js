import React from "react";
import fire from "../../config/fire";

class Login extends React.Component {
  login() {
    const email = document.querySelector("#email").value;
    const password = document.querySelector("#password").value;

    fire
      .auth()
      .signInWithEmailAndPassword(email, password)
      .then(u => {
        console.log("Successfully Logged in");
      })
      .catch(err => {
        console.log("Error: " + err.toString());
      });
  }

  signUp() {
    const email = document.querySelector("#email").value;
    const password = document.querySelector("#password").value;

    fire
      .auth()
      .createUserWithEmailAndPassword(email, password)
      .then(u => {
        console.log("Successfully Signed up");
      })
      .catch(err => {
        console.log("Error: " + err.toString());
      });
  }
  render() {
    return (
      <div className='login-form'>
        <div className='title'>Walldash</div>
        <div className='content'>
          <div>
            <label>Email</label>
            <input id='email' placeholder='Enter Email..' type='text' />
          </div>
          <div>
            <label>Password</label>
            <input
              id='password'
              placeholder='Enter Password..'
              type='password'
            />
          </div>
          <button className='btn-sign-up' onClick={this.signUp}>
            Sign Up
          </button>
          <button className='btn-log-in' onClick={this.login}>
            Login
          </button>
        </div>
      </div>
    );
  }
}

export default Login;
