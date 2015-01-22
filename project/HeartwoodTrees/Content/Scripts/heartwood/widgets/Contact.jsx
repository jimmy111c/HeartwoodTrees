var SuccessMessage = React.createClass({
	render: function() {
		return (
			<div className="comment">
				<h2 className="commentAuthor">
					Sucess Title
				</h2>
				{this.props.notification.message}
			</div>
		);
	}
});

var Notification = React.createClass({
	render: function() {
		return (
			<SuccessMessage notification={this.props.notification}/>
		);
	}
})﻿;

var ContactForm = React.createClass({
	handleSubmit: function(e) {
		e.preventDefault();
		var name = this.refs.customerName.getDOMNode().value.trim();
		var email = this.refs.emailAddress.getDOMNode().value.trim();
		var phone = this.refs.phoneNumber.getDOMNode().value.trim();
		var query = this.refs.customerQuery.getDOMNode().value.trim();
		if (!name || !query || (!phone || !query)) {
			return;
		}
		this.props.onQuerySubmit({name: name, email: email, phone: phone, query: query});
		return;
	},

	render: function() {
		return (
			<form className="contact-form" onSubmit={this.handleSubmit}>
				<div className="form-group">
					<label for="customer-name-input">name</label>
					<input id="customer-name-input" className="form-control" type="text" placeholder="your name" ref="customerName" required />
				</div>
				<div className="form-group">
					<label for="customer-email-input">email address</label>
					<input id="customer-email-input" className="form-control" type="text" placeholder="your email addresss" ref="emailAddress" required />
				</div>
				<div className="form-group">
					<label for="customer-phone-input">phone number</label>
					<input id="customer-phone-input" className="form-control" type="text" placeholder="your phone number" ref="phoneNumber" required />
				</div>
				<div className="form-group">
					<label for="customer-message-input">query</label>
					<textarea id="customer-message-input" className="form-control" rows="5" placeholder="your query" ref="customerQuery" required />
				</div>
				<button type="submit" className="btn btn-default">Send Query</button>
			</form>
		);
	}
});

var ContactBox = React.createClass({
	getInitialState: function() {
		return { notification: {} };
	},
	handleQuerySubmit: function(message) {
		var self = this;
		$.ajax({
			type: 'POST',
			data: JSON.stringify(message),
			url: this.props.submitUrl,
			contentType: 'application/json',
			dataType: 'json'
		}).done(function (response) {
			self.setState({ notification: response });
		}).fail(function (jqXHR, textStatus, errorThrown) {
			self.setState({ notification: response });
		});
	},
	render: function() {
		return (
			<div classname="contact-container">
				<h1>Contact</h1>
        		<ContactForm onQuerySubmit={this.handleQuerySubmit} />
				<Notification notification={this.state.notification} />
			</div>
		);
	}
});

React.render(
	<ContactBox submitUrl="sendQuery/"/>,
	document.getElementById('contact')
);
