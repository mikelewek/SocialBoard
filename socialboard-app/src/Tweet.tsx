import React, { Component, ReactNode } from 'react';

interface TweetProps extends React.Props<any> {
	props?: any;
    onFeatureClick(e:any): void;
    data: any;
}

interface TweetState {
}


class Tweet extends Component<TweetProps, TweetState> {
	constructor(props: TweetProps) {
	   super(props);
	 }

    handleFeatureClick = (e:any) => {
        this.props.onFeatureClick(e);
    }

	render() {
		return (		
			<>
				
			</>
		);
	}
}

export default Tweet;
