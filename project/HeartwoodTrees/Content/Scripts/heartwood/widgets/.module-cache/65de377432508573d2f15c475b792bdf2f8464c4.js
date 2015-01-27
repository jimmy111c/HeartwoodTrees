define(function (require) {

	 var $ = require('jquery'),
    	 React = require('react'),
		 Bootstrap = require('bootstrap');

	var SuccessNotification = React.createClass({displayName: "SuccessNotification",
		render: function() {
			return (
				React.createElement("div", {className: "alert alert-success", role: "alert"}, 
					React.createElement("strong", null, "Success!"), " ", this.props.message
				)
			);
		}
	})﻿;

	var ErrorNotification = React.createClass({displayName: "ErrorNotification",
		render: function() {
			return (
				React.createElement("div", {className: "alert alert-danger", role: "alert"}, 
					React.createElement("strong", null, "Oops, something went wrong!"), " ", this.props.message
				)
			);
		}
	})﻿;

	var Notification = React.createClass({displayName: "Notification",
		render: function() {
			var notifications,
				isSuccess = this.props.notification.status;
			if(isSuccess) {
				notifications = React.createElement(SuccessNotification, {message: this.props.notification.message});
			} else {
				notifications = React.createElement(ErrorNotification, {message: this.props.notification.message});
			}
			return (
				notifications
			);
		}
	});

	var ContactForm = React.createClass({displayName: "ContactForm",

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
				React.createElement("form", {className: "contact-form", onSubmit: this.handleSubmit}, 
					React.createElement("div", {className: "form-group"}, 
						React.createElement("label", {for: "customer-name-input"}, "name"), 
						React.createElement("input", {id: "customer-name-input", className: "form-control", type: "text", placeholder: "your name", ref: "customerName", required: true})
					), 
					React.createElement("div", {className: "form-group"}, 
						React.createElement("label", {for: "customer-email-input"}, "email address"), 
						React.createElement("input", {id: "customer-email-input", className: "form-control", type: "text", placeholder: "your email addresss", ref: "emailAddress", required: true})
					), 
					React.createElement("div", {className: "form-group"}, 
						React.createElement("label", {for: "customer-phone-input"}, "phone number"), 
						React.createElement("input", {id: "customer-phone-input", className: "form-control", type: "text", placeholder: "your phone number", ref: "phoneNumber", required: true})
					), 
					React.createElement("div", {className: "form-group"}, 
						React.createElement("label", {for: "customer-message-input"}, "query"), 
						React.createElement("textarea", {id: "customer-message-input", className: "form-control", rows: "5", placeholder: "your query", ref: "customerQuery", required: true})
					), 
					React.createElement("button", {type: "submit", className: "btn btn-primary", "data-loading-text": "Sending...", ref: "sendButton"}, "Send Query")
				)
			);
		}
	});

	var ContactBox = React.createClass({displayName: "ContactBox",
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
				self.refs.contactForm.resetButton()
				self.setState({ notification: {status: false, message: textStatus}, isNotificationVisible: true });
			});
		},
		render: function() {
			var alert,
				form;

			if(this.state.isNotificationVisible) {
				alert = React.createElement(Notification, {notification: this.state.notification})
			}

			if(this.state.isFormVisible) {
				form = React.createElement(ContactForm, {onQuerySubmit: this.handleQuerySubmit, ref: "contactForm"});
			}

			return (
				React.createElement("div", {classname: "contact-container"}, 
					alert, 
					form
				)
			);
		}
	});

	$(function () {
		React.render(
			React.createElement(ContactBox, {submitUrl: "sendQuery/"}),
			document.getElementById('contact')
		);
	});
});
