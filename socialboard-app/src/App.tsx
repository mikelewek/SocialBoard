import React, { Component } from 'react';
import { HashRouter, Route } from 'react-router-dom';
import Home from './Home';
import Search from './Search';
import Featured from './Featured';

class App extends Component {
  render() {
    return (
      <HashRouter>
        <div className="main">
          <Route exact path='/' render={() => (<Home />)}/>
          <Route exact path='/search' render={() => (<Search />)}/>
		      <Route exact path='/featured'render={() => (<Featured />)}/>
          <Route exact path='/live' render={(props)=>(<Featured live='true' />)} />
        </div>
      </HashRouter>
    );
  }
}

export default App;
