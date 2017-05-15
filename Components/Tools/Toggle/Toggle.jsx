var React = require('react');
var ReactDOM = require('react-dom');
import ReactCSSTransitionGroup from 'react-addons-css-transition-group';

require('./Toggle.css');

class Toggle extends React.Component {
  render() {
        return <div>
          <ReactCSSTransitionGroup
          transitionName="toggle"
          transitionEnterTimeout={300}
          transitionLeaveTimeout={300}>
            {this.props.hidden ? null : <div className="toggle-base">{this.props.children}</div>}
          </ReactCSSTransitionGroup>    
       </div>
  }
}

module.exports = Toggle;
