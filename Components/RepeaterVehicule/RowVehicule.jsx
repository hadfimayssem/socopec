var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router';
import ReactCSSTransitionGroup from 'react-addons-css-transition-group';

require('./RowVehicule.css');

var VoletDetails = require('./VoletDetails.jsx');

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
class RowVehicule extends React.Component {
  constructor(props) {
    super(props);
    this.onClick = this.onClick.bind(this);
    this.state = { hidden:true };
  }

  onClick() {
    this.setState((prevState, props) => ({
      hidden: !(prevState.hidden)
    }))   
  }
  render() {
    return (
        <div>
            <div id = {"rowVehicule-"+this.props.cle}>
                <span className="identifiant"> {this.props.vehicule.id} </span> 
                <span className="modele"> Modèle: {this.props.vehicule.modele} </span> 
                <span className="etat"> Statut: {this.props.vehicule.etat} </span>
                <span className="details" data-id={this.props.cle}  onClick={this.onClick.bind(this)}></span>
            </div>
            <Toggle hidden={this.state.hidden}><VoletDetails /></Toggle>

        </div>
    )
  }
}

module.exports = RowVehicule;