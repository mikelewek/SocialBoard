import React, { Component } from 'react';
import Tweet from './Tweet';
import Header from './Header';
import Ajax from './Ajax';

class Featured extends Component {
	constructor(props) {
		super(props);
    
		this.baseurl = 'https://localhost:5001'
		this.state = {
			data: [],
			loading: false,
			message: '',
			messageType: ''
		};

		// load saved featured posts from db
		this.ajax = new Ajax();     
        this.ajax.getFeaturedFeaturedBoardPosts(this);
	}

    getDataIndex(e) {
        return this.state.data.findIndex((obj => obj.idString === e.idString));
    }

	handleFeatureClick = (e) => {  
        // delete featured post
        this.ajax.deletePost(this, e.idString);

        // remove post from data state 
        let objIndex = this.getDataIndex(e);
        let newData = this.state.data;
        newData.splice(objIndex, 1);

        // update state
        this.setState({
            data: newData,
        });
    }

	render() {
        const live = this.props.live;

		return (
    		<>
                <div className="mt-75" data-live={live}>
                    <Header/>  
        		    <div id="results" className="container-fluid">
        					<div className="card-columns">
        					<Tweet onFeatureClick={this.handleFeatureClick} data={this.state.data} />
        				</div>
                    </div> 
                </div> 
    		</>
	    );
	}
}

export default Featured;
