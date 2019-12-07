import React, { Component } from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import Home from './Home';
import Search from './Search';
import Featured from './Featured';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div className="main">
          <Route exact path='/' render={() => (<Home />)}/>
          <Route exact path='/search' render={() => (<Search />)}/>
		      <Route exact path='/featured'render={() => (<Featured />)}/>
          <Route exact path='/live' render={(props)=>(<Featured live='true' />)} />
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
