import React, { Component } from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Home from './Home';
import Search from './Search';
import Featured from './Featured';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div className="main">
          <Route exact={true} path='/' render={() => (<Home />)}/>
          <Route exact={true} path='/search' render={() => (<Search />)}/>
		    <Route exact={true} path='/featured' render={() => (<Featured />)} />
        <Route exact={true} path='/live' render={(props)=>(<Featured live='true' />)} />
        </div>
      </BrowserRouter>
    );
  }
}

export default App;
