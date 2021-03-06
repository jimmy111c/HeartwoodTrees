define(['react', 'jquery', 'underscore', './Notification', 'bootstrap'], function (React, $, _, Notification) {

	var ContactForm = React.createClass({

		loadingButton: function () {
			var buttonNode = this.refs.sendButton.getDOMNode();
			$(buttonNode).button('loading')
		},

		resetButton: function() {
			var buttonNode = this.refs.sendButton.getDOMNode();
			$(buttonNode).button('reset')
		},

		handleSubmit: function(e) {
			e.preventDefault();

			this.loadingButton();

			var name = this.refs.customerName.getDOMNode().value.trim();
			var email = this.refs.emailAddress.getDOMNode().value.trim();
			var phone = this.refs.phoneNumber.getDOMNode().value.trim();
			var query = this.refs.customerQuery.getDOMNode().value.trim();
			if (!name || !query || (!phone || !query)) {
				return;
			}
			this.props.onQuerySubmit({ query: {Name: name, Email: email, Phone: phone, Query: query}});
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
					<button type="submit" className="btn btn-primary" data-loading-text="Sending..." ref="sendButton">Send Query</button>
				</form>
			);
		}
	});

	var ContactBox = React.createClass({
		getInitialState: function() {
			return { notification: {}, isNotificationVisible: false, isFormVisible: true };
		},
		handleQuerySubmit: function(message) {
			var self = this;
			$.ajax({
				type: 'POST',
				data: JSON.stringify(message),
				url: this.props.submitUrl,
				dataType: 'json',
				contentType: 'application/json',
			}).done(function (response) {
				self.setState({ notification: response, isNotificationVisible: true, isFormVisible: false });
			}).fail(function (jqXHR, textStatus, errorThrown) {
				var errors = jqXHR.responseJSON.errors || [];
				if(jqXHR.responseJSON.error) {
					errors.push(jqXHR.responseJSON.error);
				}
				self.refs.contactForm.resetButton()
				self.setState({ notification: {status: false, errors: errors}, isNotificationVisible: true });
			});
		},
		render: function() {
			var alert,
				form;

			if(this.state.isNotificationVisible) {
				alert = <Notification notification={this.state.notification} />
			}

			if(this.state.isFormVisible) {
				form = <ContactForm onQuerySubmit={this.handleQuerySubmit} ref="contactForm"/>;
			}

			return (
				<div classname='contact-container'>
					<h1 className='contact-header'>contact us</h1>
					{alert}
					{form}
				</div>
			);
		}
	});

	$(function () {
		React.render(
			<ContactBox submitUrl='sendQuery/'/>,
			document.getElementById('contact')
		);
	});
});
