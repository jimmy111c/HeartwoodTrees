define(function (require) {

var React = require('react'),
    $ = require('jquery'),
    _ = require('underscore');

var SuccessNotification = React.createClass({
  render: function() {
    return (
      <div className="alert alert-success" role="alert">
        <strong>Success!</strong> {this.props.message}
      </div>
    );
  }
})﻿;

var ErrorNotification = React.createClass({
  render: function() {

    if(this.props.errors && _.isArray(this.props.errors)) {
      var errorMessages = this.props.errors.map(function (error) {
        return (
          <li>{error}</li>
        );
      });
    } else if(this.props.error) {
      var errorMessages = this.props.errors.map(function (error) {
        return (
          <li>{this.props.errors}</li>
        );
      });
    }

    return (
      <div className="alert alert-danger" role="alert">
        <strong>Oops, something went wrong!</strong>
        <ul>
          {errorMessages}
        </ul>
      </div>
    );
  }
})﻿;

React.createClass({
  render: function() {
    var notifications,
    isSuccess = this.props.notification.status;
    if(isSuccess) {
      notifications = <SuccessNotification message={this.props.notification.message}/>;
      } else {
        notifications = <ErrorNotification errors={this.props.notification.errors}/>;
        }
        return (
          notifications
        );
      }
    });

});
