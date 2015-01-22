var QueryForm = React.createClass({
	handleSubmit: function(e) {
		e.preventDefault();
		var name = this.refs.customer-name.getDOMNode().value.trim();
		var email = this.refs.email-address.getDOMNode().value.trim();
		var phone = this.refs.phone-number.getDOMNode().value.trim();
		var query = this.refs.customer-query.getDOMNode().value.trim();
		if (!name || !query || (phone || query)) {
			return;
		}
		this.props.onCommentSubmit({name: name, email: email, phone: phone, query: query});
		return;
	},

	render: function() {
		return (
			<form className="contact-form" onSubmit={this.handleSubmit}>
				<div class="form-group">
					<label for="customer-name-input">Your name</label>
					<input id="customer-name-input" class="form-control" type="text" placeholder="your name" ref="customer-name" />
				</div>
				<div class="form-group">
					<label for="customer-email-input">Your email address</label>
					<input id="customer-email-input" class="form-control" type="text" placeholder="email addresss" ref="email-address" />
				</div>
				<div class="form-group">
					<label for="customer-phone-input">Your phone number</label>
					<input id="customer-phone-input" class="form-control" type="text" placeholder="phone number" ref="phone-number" />
				</div>
				<div class="form-group">
					<label for="customer-message-input">Your query</label>
					<input id="customer-message-input" class="form-control" type="text" placeholder="your query" ref="customer-query" />
				</div>
				<button type="submit" class="btn btn-default">Send Query</button>
			</form>
		);
	}
});

var ContactBox = React.createClass({
	handleCommentSubmit: function(message) {
		var self = this;
		$.ajax({
			type: 'POST',
			data: JSON.stringify(message),
			url: this.props.submitUrl,
			contentType: 'application/json',
			dataType: 'json'
		}).done(function (data) {
			self.loadCommentsFromServer();
		}).fail(function (jqXHR, textStatus, errorThrown) {
			debugger;
			console.log("FAIL: " + errorThrown);
		});
	},
	render: function() {
		return (
			<div classname="contact-container">
				<h1>Contact</h1>
        <QueryForm onCommentSubmit={this.handleCommentSubmit} />
			</div>
		);
	}
});

React.render(
	<ContactBox submitUrl="sendQuery/"/>,
	document.getElementById('contact')
);
