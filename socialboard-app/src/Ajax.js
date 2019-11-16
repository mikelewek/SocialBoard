import axios from 'axios';
import mockFeatured from './mockFeatured';

class Ajax {	
	constructor() {
       this.baseUrl = "https://socialboarddemo.azurewebsites.net/api";
       // this.baseUrl = "https://localhost:5001/api";
    }

	getPosts = (t) => {
		axios.get(`${this.baseUrl}/social/${t.state.socialType}/${t.state.type}/${t.state.id}`)
			.then(response => {	
				this.handleAjaxResponse(t, response);
        	});
	}

	getFeaturedPosts = (t) => {
		axios.get(`${this.baseUrl}/post`)
			.then(response => {	
				this.handleAjaxResponse(t, response, 'featured');
        	});
	}

	getFeaturedBoardPosts = (t) => {
		axios.get(`${this.baseUrl}/post`)
			.then(response => {	
				this.handleAjaxResponse(t, response, 'featuredboard');
        	});
	}

	savePost = (t, data) => {
		axios.post(`${this.baseUrl}/post`, data)
			.then(response => {
			    this.handleAjaxResponse(t, response);
			}).catch(error => {
				this.handleAjaxResponse(t, error.response);
			});
	}

	deletePost = (t, id) => {
		axios.delete(`${this.baseUrl}/post/${id}`)
			.then(response => {
			    this.handleAjaxResponse(t, response, 'delete');
			}).catch(error => {
				this.handleAjaxResponse(t, error.response);
			});
	}

	handleAjaxResponse = (t, response, postType = 'data') => {
		if (response === undefined) {
			t.setState({
				messageType: 'error',
				message: `Oops. Someting went wrong: "${response}"`
			});
			return;
		}

		if(response.status === 200) {
			let data = [];
			
			switch (postType) {
				case 'data':
					data = this.mergeFeatured(this, response.data)
					break;
				case 'featured':
					data = response.data.reverse();
					break;
				case 'featuredboard':
					postType = 'data';
					data = this.setFeatured(response.data);
					break;
				case 'delete':
					data = true;
					break;	
				default:
					data = true;
			}

			t.setState({
				loading: false,
				message: "",
    			[postType]: data
			});
		}
		else if (response.status === 400) {
			t.setState({
				message: "Oops. Something went wrong!"
			});
		}
	}

	mergeFeatured(t, responseData) {
        var data = responseData;
		for (var i in responseData) {
			let match = this.matchFeatured(t, responseData[i]);

			if (match) {
				responseData[i].isFeatured = true;
			}
        }
        return data;
	}

	matchFeatured(t, postData) {
		let isMatch = false;

		if(t.state === undefined) {
			return false;
		}

		t.state.featured.find(function (e) {
			if (e.idString === postData.idString) {
				isMatch = true;
				return true;
			}
			return false;
		});
		return isMatch;
	}

	// mock data to avoid db request
	getMockFeaturedPosts = (t) => { 
		new Promise(function(resolve, reject) {
		  setTimeout(function() {
		  	const data = {message: "Ok", status: 200, data: mockFeatured};
		    resolve(data);
		  }, 300);
		})
		.then(response => {
			this.handleAjaxResponse(t, response, 'featured');
		});;
	}

	setFeatured (posts) {
        let data = posts.reverse();
        for (var i in posts) {
            posts[i].isFeatured = true;
        }
        return data;
    }
}

export default Ajax;