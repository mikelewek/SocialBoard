import React, { Component } from 'react';
import Header from './Header';

class Home extends Component {
  render() {
	  return (
		<div className="container-fluid">
		<Header />
			<br /><br /><br />
			<ul>
				<li><a href="search">Search</a></li>
				<li><a href="featured">Featured</a></li>
				<li><a href="live">Live</a></li>
			</ul>
      </div>
    );
  }
}

export default Home;
