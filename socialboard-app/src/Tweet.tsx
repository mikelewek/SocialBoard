import React, { Component, ReactNode } from 'react';

interface ITweetProps extends React.Props<any> {
	props?: ReactNode;
    onFeatureClick?: any;
    live?: string;
    data?: string[];
}

interface ITweetState {
}


class Tweet extends Component<ITweetProps, ITweetState> {
	render() {
		const live = this.props.live || 'false';
		const data = this.props.data || [];
		const onFeatureClick = this.props.onFeatureClick;

		return (		
			<>
				{data.map(function (item:any, index:number) {
					let isFeatured: string = (item.isFeatured === true ? ' Unfeature' : ' Feature');
            		const screenName: string = item.user !== null ? item.user.screenNameResponse : item.screenName;
            		const username: string = item.user !== null ? item.user.username : item.username;
            		const profileImageUrl: string = item.user !== null ? item.user.profileImageUrl : item.profileImageUrl;

					return (
						<div key={index} className={'card post key-' + (index) + ' post-id-' + (item.idString) + (item.user === undefined ? ' hidden' : '') + isFeatured.toLowerCase()}>
							<div dangerouslySetInnerHTML={{ __html: item.mediaUrl}}></div>

							{live === 'true' ? '' : <div className={'featured-toggle' + isFeatured.toLowerCase()} onClick={() => onFeatureClick(item)}>{isFeatured}</div>}
							 <div className="body">
								<div className="user">
									<img src={profileImageUrl} alt="avatar" />
									<div className="name"><strong>{username}</strong></div>
									<div className="username">@<a href={'https://twitter.com/' + screenName} target="_blank" rel="noopener noreferrer">{screenName}</a></div>

									<div className="text" dangerouslySetInnerHTML={{ __html: item.fullText }} />
								</div>

								<div className="footer">
									<div className="post-time col-xs-8">{item.createdAtString}</div>

                                    <div className="favorite-count col-xs-1">{item.favoritedCount > 0 ? item.favoritedCount : ''}</div>
                                    <div className="icon favorite-count-icon col-xs-1"></div>

                                    <div className="retweet-count col-xs-1">{item.retweetCount > 0 ? item.retweetCount : ''}</div>
                                    <div className="icon retweet-count-icon col-xs-1"></div>
								</div>
							</div>
						</div>
					)
				}, this)}
			</>
		);
	}
}

export default Tweet;
