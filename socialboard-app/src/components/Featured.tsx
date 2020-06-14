import React, { Component } from 'react';
import Tweet from './Tweet';
import Header from './Header';
import Ajax from '../Ajax';
import Utils from '../Utils';

interface IFeaturedProps {
    live?: string;
    data?: string[];
}

interface IFeaturedState {
    data: any;
    loading: string;
    message: string;
    messageType: string;
}

class Featured extends Component<IFeaturedProps, IFeaturedState> {	
    ajax:Ajax;

    constructor(props: IFeaturedProps) {
		super(props);
    
		this.state = {
			data: '',
			loading: 'true',
			message: '',
			messageType: ''
		};

		// load saved featured posts from db
		this.ajax = new Ajax(this);     
        this.ajax.getFeaturedBoardPosts();
	}

	handleFeatureClick = (e:any) => {  
        // delete featured post
        this.ajax = new Ajax(this);     
        this.ajax.deletePost(e.id);

        // remove post from data state 
        let objIndex = new Utils().getDataIndex(this.state.data, e);
        let newData = this.state.data;
        newData.splice(objIndex, 1);

        // update state
        this.setState({
            data: newData,
        });
    }

	render = () => {
        const live = this.props.live;

		return (
    		<>
                <div className="mt-75" data-live={live}>
                    <Header/>  
                    <p className={this.state.message === "" ? "collapse" : "expand mr-2 ml-2 alert alert-" + this.state.messageType}>{this.state.message}</p>
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
