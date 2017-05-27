var React = require('react');
var ReactDOM = require('react-dom');

var RepeaterVehicule = require('../RepeaterVehicule/RepeaterVehicule.jsx');

require('./AccueilAdmin.css');

class AccueilAdmin extends React.Component{
    render () {
        return (
            <div className="Accueil-backgound">
                <RepeaterVehicule data={DATA} />
            </div>
        );
    }
}
var DATA = [
  {id: 'XX6YT', modele: 'Citroene', etat: 'Loue'},
  {id: 'PTZD8', modele: 'Opel', etat: 'Garage'},
  {id: 'DS87T', modele: 'Peugeot', etat: 'Loue'},
  {id: 'RRSQP', modele: 'Fiesta', etat: 'En reparation'},
  {id: 'H13RE', modele: 'Ferari', etat: 'Garage'},
  {id: 'DORK3', modele: 'Renault', etat: 'En attente'}
];


module.exports = AccueilAdmin;