var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router';
import ReactCSSTransitionGroup from 'react-addons-css-transition-group';

require('./RowVehicule.css');

var VoletDetails = require('./VoletDetails.jsx');
var Toggle = require('../Tools/Toggle/Toggle.jsx');

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
    var arrow;
    if (this.state.hidden) {
        arrow =  'details dwn';
    } else {
        arrow =  'details up';
    }
    return (
        <div>
            <div id = {"rowVehicule-"+this.props.cle}>
                <span className="identifiant"> {this.props.vehicule.id.toUpperCase()} </span> 
                <span className="modele"> Modèle: {this.props.vehicule.modele} </span> 
                <span className="etat"> Statut: {this.props.vehicule.etat} </span>
                <span className={arrow} data-id={this.props.cle}  onClick={this.onClick.bind(this)}></span>
            </div>
            <Toggle hidden={this.state.hidden}><VoletDetails data={this.props.vehicule}/></Toggle>

        </div>
    )
  }
}

module.exports = RowVehicule;