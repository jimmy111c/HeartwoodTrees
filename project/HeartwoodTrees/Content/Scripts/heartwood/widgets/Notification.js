define(['react', 'jquery', 'underscore'], function (React, $, _) {

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

        if(this.props.errors && _.isArray(this.props.errors)) {
          var errorMessages = this.props.errors.map(function (error) {
            return (
              React.createElement("li", null, error)
            );
          });
        } else if(this.props.error) {
          var errorMessages = this.props.errors.map(function (error) {
            return (
              React.createElement("li", null, this.props.errors)
            );
          });
        }

        return (
          React.createElement("div", {className: "alert alert-danger", role: "alert"}, 
            React.createElement("strong", null, "Oops, something went wrong!"), 
            React.createElement("ul", null, 
              errorMessages
            )
          )
        );
      }
    })﻿;

    return React.createClass({
        render: function() {
            var notifications,
            isSuccess = this.props.notification.status;
            if(isSuccess) {
                notifications = React.createElement(SuccessNotification, {message: this.props.notification.message});
            } else {
                notifications = React.createElement(ErrorNotification, {errors: this.props.notification.errors});
            }
            return (
              notifications
            );
        }
    });

});
