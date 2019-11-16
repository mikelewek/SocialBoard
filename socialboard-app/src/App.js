import React, { Component } from 'react';
import {HashRouter, Route} from 'react-router-dom';
import Home from './Home';
import Search from './Search';
import Featured from './Featured';

class App extends Component {
  render() {
    return (
      <HashRouter>
        <div className="main">
          <Route path='/' render={() => (<Home />)}/>
          <Route path='/search' render={() => (<Search />)}/>
		      <Route path='/featured' render={() => (<Featured />)} />
          <Route path='/live' render={(props)=>(<Featured live='true' />)} />
        </div>
      </HashRouter>
    );
  }
}

export default App;
