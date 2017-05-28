var React = require('react');
var ReactDOM = require('react-dom');

var RepeaterVehicule = require('../RepeaterVehicule/RepeaterVehicule.jsx');

require('./AccueilUser.css');

class AccueilUser extends React.Component{
    render () {
        return (
            <div className="Accueil-backgound">
                <RepeaterVehicule data={VEHICULES}/>
            </div>
        );
    }
}
var VEHICULES = [
  {type: "vehicule", id: 'XX6YT', modele: 'Citroene', etat: 'Loue', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "aspirateur", lieux:"nancy" },
  {type: "vehicule", id: 'PTZD8', modele: 'Opel', etat: 'Garage', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "aspirateur", lieux:"nancy"},
  {type: "vehicule", id: 'DS87T', modele: 'Peugeot', etat: 'Loue', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "aspirateur", lieux:"nancy"},
  {type: "vehicule", id: 'RRSQP', modele: 'Fiesta', etat: 'En reparation', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "aspirateur", lieux:"nancy"},
  {type: "vehicule", id: 'H13RE', modele: 'Ferari', etat: 'Garage', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "aspirateur", lieux:"nancy"},
  {type: "vehicule", id: 'DORK3', modele: 'Renault', etat: 'En attente', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "aspirateur", lieux:"nancy"}
];

module.exports = AccueilUser;