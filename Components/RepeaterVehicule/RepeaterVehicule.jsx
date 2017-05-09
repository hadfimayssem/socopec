var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

var RowVehicule = require('./RowVehicule.jsx');

class RepeaterVehicule extends React.Component {
     render () {
        return (
            <div>
            {VEHICULES.map(function(VEHICULES, i){
                return <RowVehicule vehicule={VEHICULES} key={i} cle={i} />;
            })}
            </div>
        );
    }
}

var VEHICULES = [
  {id: 'XX6YT', modele: 'Citroene', etat: 'Loue'},
  {id: 'PTZD8', modele: 'Opel', etat: 'Garage'},
  {id: 'DS87T', modele: 'Peugeot', etat: 'Loue'},
  {id: 'RRSQP', modele: 'Fiesta', etat: 'En reparation'},
  {id: 'H13RE', modele: 'Ferari', etat: 'Garage'},
  {id: 'DORK3', modele: 'Renault', etat: 'En attente'}
];

module.exports = RepeaterVehicule;
