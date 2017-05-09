var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

require('./RowVehicule.css');
class RowVehicules extends React.Component{
    constructor(props){
        super(props);
    };
    render() {
        return(
            <div className = "rowVehicule" data-id={this.props.cle}>
                <span className="identifiant"> {this.props.vehicule.id} </span> 
                <span className="modele"> Modèle: {this.props.vehicule.modele} </span> 
                <span className="etat"> Statut: {this.props.vehicule.etat} </span>
                <span className="details" data-id={this.props.cle}></span>
            </div>
        );
    }
}

module.exports = RowVehicules;