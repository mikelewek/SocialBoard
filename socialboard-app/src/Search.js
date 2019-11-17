import React, { Component } from 'react';
import Header from './Header';
import Tweet from './Tweet';
import Ajax from './Ajax';

class Search extends Component {
	constructor(props) {
		super(props);
    
		this.state = {
			id: 'Rangers',
			type: "screenname",
			socialType: "tweets",
			data: [],
			featured: [],
			loading: false,
			message: '',
			messageType: ''
		};

		this.ajax = new Ajax();
		this.handleInputChange = this.handleInputChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
        this.handleFeatureClick = this.handleFeatureClick.bind(this);
	}
    
	handleFeatureClick = (e) => {
        if(e.isFeatured !== true) {
			// save featured post
			this.ajax.savePost(this, e);
        }
        else {
            // delete saved post
            this.ajax.deletePost(this, e.idString);
        }

        // get clicked post and toggle the featured prop
		let objIndex = this.getDataIndex(e);
		let newData = this.state.data;
		newData[objIndex].isFeatured = !newData[objIndex].isFeatured;

		this.setState({
			data: newData,
		});
    }

	handleInputChange(e) {
		const target = e.target;
		const value = target.type === 'checkbox' ? target.checked : target.value;
		const name = target.name;

		this.setState({
			[name]: value
		});
	}

	handleSubmit(e) {
		e.preventDefault();
		this.setState({
			data: [],
			loading: true
		});
       
        //this.ajax.getMockFeaturedPosts(this);
        this.ajax.getFeaturedPosts(this);  
        this.ajax.getPosts(this);      

        // set featured/saved post array
        // setInterval(function() { 
        //     this.ajax.getPosts(this);   
        // }, 6000);
   	}

    getDataIndex(e) {
		return this.state.data.findIndex((obj => obj.idString === e.idString));
	}

  render() {
	  return (
		<>
			<div className="container-fluid search-container mt-55">
			  <Header/>
				  <div className="col-md-4">
					<h4>Search</h4>
					<p class={this.state.message === "" ? "collapse" : "expand alert alert-" + this.state.messageType}>{this.state.message}</p>
					  <form onSubmit={this.handleSubmit}>
						  <div className="input-group mb-2">
							  <div className="input-group-prepend">
								  <span className="input-group-text">by:</span>
							  </div>
							  <select className="custom-select input-group" name="type" value={this.state.type} onChange={this.handleInputChange}>
							  	  <option value="term">Term/Hashtag</option>
								  <option value="screenname">ScreenName</option>
								  <option value="id">Id</option>
							  </select>
						  </div>

						<div className="input-group mb-2">
						  <div className="input-group-prepend">
							<span className="input-group-text">id:</span>
						  </div>
						  <input className="input-group-append input-group-prepend text-left" type="text" name="id" value={this.state.id} onChange={this.handleInputChange} />
						  <select className="custom-select input-group-append" value={this.state.socialType} name="socialType" onChange={this.handleInputChange}>
                            <option value="instatweets">Both</option>
                            <option value="tweets">Twitter</option>
							<option value="instas">Instagram</option>
						  </select>
						</div>
						<button className="btn btn-secondary col-xs-12 col-sm-3" type="submit" value="Submit">Search</button>
					</form>
				</div>
			</div>
			<div id="results" className="container-fluid">
				  <div className="card-columns">
				  	  <Tweet onFeatureClick={this.handleFeatureClick} data={this.state.data} />
				</div>
			</div> 
		</>
    );
  }
}

export default Search;
