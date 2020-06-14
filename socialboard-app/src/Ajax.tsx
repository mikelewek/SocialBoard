import axios from 'axios';
import mockFeatured from './mockFeatured.json';

class Ajax {	
	readonly _t:any;
	readonly baseUrl = "https://localhost:5001/api";

	//constructor 
   constructor(t:any) { 
      this._t = t; 
   } 

	getPosts = () => {
		axios.get(`${this.baseUrl}/social/${this._t.state.socialType}/${this._t.state.type}/${this._t.state.id}`)
			.then(response => {	
				this.handleAjaxResponse(response);
        	})
        	.catch(error => {
			   	this.handleAjaxResponse(error.response);
			 });
	}

	getFeaturedPosts = () => {
		axios.get(`${this.baseUrl}/post`)
			.then(response => {	
				this.handleAjaxResponse(response, 'featured');
        	})
        	.catch(error => {
			   	this.handleAjaxResponse(error.response);
			 });
	}

	getFeaturedBoardPosts = () => {
		axios.get(`${this.baseUrl}/post`)
			.then(response => {	
				this.handleAjaxResponse(response, 'featuredboard');
        	})
        	.catch(error => {
			   	this.handleAjaxResponse(error.response);
			 });
	}

	savePost = (data:string) => {
		axios.post(`${this.baseUrl}/post`, data)
			.then(response => {
			    this.handleAjaxResponse(response);
			}).catch(error => {
				this.handleAjaxResponse(error.response);
			})
        	.catch(error => {
			   	this.handleAjaxResponse(error.response);
			 });
	}

	deletePost = (id:number) => {
		axios.delete(`${this.baseUrl}/post/${id}`)
			.then(response => {
			    this.handleAjaxResponse(response, 'delete');
			}).catch(error => {
				this.handleAjaxResponse(error.response);
			})
        	.catch(error => {
			   	this.handleAjaxResponse(error.response);
			 });
	}

	handleAjaxResponse = (response:any, postType = 'data') => {
		if (response === undefined) {
			this._t.setState({
				messageType: 'danger',
				message: `Oops. Someting went wrong: "${response}"`
			});
			return;
		}

		if(response.status === 429) {
			this._t.setState({
				messageType: 'danger',
				message: 'Too many requests. Please retry in 10 seconds.'
			});
			return;
		}

		if(response.status === 200) {
			let data:string[] = [];
			
			switch (postType) {
				case 'data':
					data = this.mergeFeatured(response.data)
					break;
				case 'featured':
					data = response.data.reverse();
					break;
				case 'featuredboard':
					postType = 'data';
					data = this.setFeatured(response.data);
					break;
				case 'delete':
					data = [];
					break;	
			}

			this._t.setState({
				loading: false,
				message: "",
    			[postType]: data
			});
		}
		else if (response.status === 400) {
			this._t.setState({
				message: "Oops. Something went wrong!"
			});
		}
	}

	mergeFeatured(responseData:any) {
        let data:any = responseData;

		for (var i in responseData) {
			const match = this.matchFeatured(data[i]);

			if (match) {
				data[i].isFeatured = true;
			}
        }
        return data;
	}

	matchFeatured(postData:any) {
		let isMatch = false;

		if(this._t.state === undefined) {
			return false;
		}

		this._t.state.featured.find(function (e:any) {
			if (e.id === postData.id) {
				isMatch = true;
				return true;
			}
			return false;
		});
		return isMatch;
	}

	// mock data to avoid db request
	getMockFeaturedPosts = () => { 
		new Promise(function(resolve, reject) {
		  setTimeout(function() {
		  	const data = {message: "Ok", status: 200, data: mockFeatured};
		    resolve(data);
		  }, 300);
		})
		.then(response => {
			this.handleAjaxResponse(response, 'featured');
		});;
	}

	setFeatured (posts:any) {
        let data = posts.reverse();
        for (var i in posts) {
            posts[i].isFeatured = true;
        }
        return data;
    }
}

export default Ajax;