import React, { Component } from 'react';
import axios from 'axios';

class Login extends Component {
  constructor() {
    super();

    this.handleSubmit = this.handleSubmit.bind(this);
  
    this.state = {
      Login: '',
      Password: '',
    }
  }

  handleSubmit(event) {
    event.preventDefault();

    const data = {
      Login: this.state.Login,
      Password: this.state.Password
    }; 
    console.log(JSON.stringify(data));

    axios.post('http://matgorzynski.hostingasp.pl/user/login', data)
  .then(response => console.log('Success:', JSON.stringify(response))
  );
  }

  handleChange(e) {
    let change = {}
    change[e.target.name] = e.target.value
    this.setState(change)
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label htmlFor="Login">Login</label>
        <br />
        <input id="Login" name="Login" type="text" value={this.state.Login} onChange={this.handleChange.bind(this)} />

        <br />

        <label htmlFor="Password">Hasloo</label>
        <br />
        <input id="Password" name="Password" type="password" value={this.state.Password} onChange={this.handleChange.bind(this)} />

        <br />
        <button>Send data!</button>
      </form>
    );
  }
}

export default Login;