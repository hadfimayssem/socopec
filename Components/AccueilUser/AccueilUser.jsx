var React = require('react');
var ReactDOM = require('react-dom');

var RepeaterVehicule = require('../RepeaterVehicule/RepeaterVehicule.jsx');

require('./AccueilUser.css');

class AccueilUser extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            vehicule: VEHICULES
        }
    }
    render () {
        var data;
        if(this.props.filtreRecherche != ""){           
            data = this.state.vehicule.filter((d)=>
                d.id.toUpperCase().includes(this.props.filtreRecherche.toUpperCase()) ||
                d.modele.toUpperCase().includes(this.props.filtreRecherche.toUpperCase()) ||
                d.etat.toUpperCase().includes(this.props.filtreRecherche.toUpperCase()) 
             );
        }else{
            data = this.state.vehicule
        }
        if(this.props.filtreRechercheAvance[0].model != ""){
            data = this.state.vehicule.filter((d)=> d.modele.toUpperCase().includes(this.props.filtreRechercheAvance[0].model.toUpperCase()))
        }
        if(this.props.filtreRechercheAvance[0].statut != ""){
            data = this.state.vehicule.filter((d)=> d.etat.toUpperCase().includes(this.props.filtreRechercheAvance[0].statut.toUpperCase()))
        }
        if(this.props.filtreRechercheAvance[0].lieu != ""){
            data = this.state.vehicule.filter((d)=> d.lieux.toUpperCase().includes(this.props.filtreRechercheAvance[0].lieu.toUpperCase()))
        }
        return (
            <div className="Accueil-backgound">
                <RepeaterVehicule data={data}/>
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