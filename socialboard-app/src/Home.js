import React, { Component } from 'react';
import Header from './Header';

class Home extends Component {
  render() {
	  return (
		<div className="container-fluid">
		<Header />
			<br /><br /><br />
			<ul>
				<li><a href="/SocialBoard/#/search">Search</a></li>
				<li><a href="/SocialBoard/#/featured">Featured</a></li>
				<li><a href="/SocialBoard/#/live">Live</a></li>
			</ul>
      </div>
    );
  }
}

export default Home;
