var React = require('react');
var ReactDOM = require('react-dom');

var RepeaterVehicule = require('../RepeaterVehicule/RepeaterVehicule.jsx');

require('./AccueilUser.css');

class AccueilUser extends React.Component{
   componentDidMount() {
    this.props.onRef(this)
  }
  componentWillUnmount() {
    this.props.onRef(undefined)
  }
   getInitialState() {
    return {
      isHidden: false
    };
  }
    constructor(props){
        super(props);
        this.state = {
            vehicule: VEHICULES
        }
    }
    addData(data){
        var temp = this.state.vehicule.slice();
        if(temp.find((t) => t.id == data.id)){
            var index = temp.findIndex((t) => t.id == data.id);
            temp[index].type = data.type;
            temp[index].modele = data.modele;
            temp[index].etat = data.etat;
            temp[index].fabrication = data.fabrication;
            temp[index].poids = data.poids;
            temp[index].hauteur = data.hauteur;
            temp[index].largeur = data.largeur;
            temp[index].puissance = data.puissance;
            temp[index].lieux = data.lieux;
            temp[index].historique = data.historique
        }else{
            temp.push(data)
        }
        this.setState({ vehicule: temp })
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
            data = data.filter((d)=> d.modele.toUpperCase().includes(this.props.filtreRechercheAvance[0].model.toUpperCase()))
        }
        if(this.props.filtreRechercheAvance[0].statut != ""){
            data = data.filter((d)=> d.etat.toUpperCase().includes(this.props.filtreRechercheAvance[0].statut.toUpperCase()))
        }
        if(this.props.filtreRechercheAvance[0].lieu != ""){
            data = data.filter((d)=> d.lieux.toUpperCase().includes(this.props.filtreRechercheAvance[0].lieu.toUpperCase()))
        }
        if(this.props.filtreRechercheAvance[0].hauteurMin !="" && this.props.filtreRechercheAvance[0].hauteurMax != ""){
            data = data.filter((d)=> d.hauteur >= parseFloat(this.props.filtreRechercheAvance[0].hauteurMin) && d.hauteur <= parseFloat(this.props.filtreRechercheAvance[0].hauteurMax))
        }
        return (
            <div className="Accueil-backgound">
                <RepeaterVehicule data={data} addData={this.addData.bind(this)}/>
            </div>
        );
    }
}
var VEHICULES = [
  {type: "vehicule", id: 'XX6YT', modele: 'Citroene', etat: 'Loue', fabrication: '12/10/2008', poids: 3.5, hauteur: 2.5, largeur: 1.5, puissance: "20", lieux:"nancy", historique: ["Ajouté en base le 03/05/2017", "Etat modifié en loué le 04/05/2017","Etat modifié en garage le 04/05/2017", "Etat modifié en loué le 04/05/2017","Etat modifié en garage le 04/05/2017", "Etat modifié en loué le 04/05/2017","Etat modifié en garage le 04/05/2017", "Etat modifié en loué le 04/05/2017","Etat modifié en garage le 04/05/2017", "Etat modifié en loué le 04/05/2017","Etat modifié en garage le 04/05/2017", "Etat modifié en loué le 04/05/2017","Etat modifié en garage le 04/05/2017"]},
  {type: "vehicule", id: 'PTZD8', modele: 'Opel', etat: 'Garage', fabrication: '12/10/2008', poids: 3.5, hauteur: 3, largeur: 1.5, puissance: "50", lieux:"nancy", historique: ["Ajouté en base le 03/05/2017"]},
  {type: "vehicule", id: 'DS87T', modele: 'Peugeot', etat: 'Loue', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "15", lieux:"nancy", historique: ["Ajouté en base le 03/05/2017"]},
  {type: "vehicule", id: 'RRSQP', modele: 'Fiesta', etat: 'En reparation', fabrication: '12/10/2008', poids: 1.5, hauteur: 1.5, largeur: 1.5, puissance: "60", lieux:"nancy", historique: ["Ajouté en base le 03/05/2017"]},
  {type: "vehicule", id: 'H13RE', modele: 'Ferari', etat: 'Garage', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "30", lieux:"nancy", historique: ["Ajouté en base le 03/05/2017"]},
  {type: "vehicule", id: 'DORK3', modele: 'Renault', etat: 'En attente', fabrication: '12/10/2008', poids: 3.5, hauteur: 2.5, largeur: 1.5, puissance: "40", lieux:"nancy", historique: ["Ajouté en base le 03/05/2017"]},
  {type: "vehicule", id: 'KKAR4', modele: 'Citroene', etat: 'Loue', fabrication: '12/10/2008', poids: 3.5, hauteur: 2.5, largeur: 1.5, puissance: "20", lieux:"strasbourg", historique: ["Ajouté en base le 25/05/2017"]},
  {type: "vehicule", id: 'B8B8A', modele: 'Opel', etat: 'Garage', fabrication: '12/10/2008', poids: 3.5, hauteur: 3, largeur: 1.5, puissance: "50", lieux:"strasbourg", historique: ["Ajouté en base le 25/05/2017"]},
  {type: "vehicule", id: 'DARF2', modele: 'Peugeot', etat: 'Loue', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "15", lieux:"strasbourg", historique: ["Ajouté en base le 25/05/2017"]},
  {type: "vehicule", id: 'CLART', modele: 'Fiesta', etat: 'En reparation', fabrication: '12/10/2008', poids: 1.5, hauteur: 1.5, largeur: 1.5, puissance: "60", lieux:"strasbourg", historique: ["Ajouté en base le 25/05/2017"]},
  {type: "vehicule", id: 'MTF2G', modele: 'Ferari', etat: 'Garage', fabrication: '12/10/2008', poids: 3.5, hauteur: 2, largeur: 1.5, puissance: "30", lieux:"strasbourg", historique: ["Ajouté en base le 25/05/2017"]},
  {type: "vehicule", id: '55PAR', modele: 'Renault', etat: 'En attente', fabrication: '12/10/2008', poids: 3.5, hauteur: 2.5, largeur: 1.5, puissance: "40", lieux:"strasbourg", historique: ["Ajouté en base le 25/05/2017"]}
];

module.exports = AccueilUser;