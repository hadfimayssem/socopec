var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
require('./ModifVehicule.css')

class ModifVehicule extends React.Component{
    constructor(props){
        super(props)
        this.state ={
            type: "",
            id: "",
            modele: "",
            etat: "",
            fabrication: "",
            poids: "",
            hauteur: "",
            largeur: "",
            puissance: "",
            lieu: ""
        }
    }
    handleChangeType(e) {
        this.setState({type: e.target.value});
    }
    handleChangeId(e) {
        this.setState({id: e.target.value});
    }
    handleChangeModele(e) {
        this.setState({modele: e.target.value});
    }
    handleChangeEtat(e) {
        this.setState({etat: e.target.value});
    }
    handleChangeFabrication(e) {
        this.setState({fabrication: e.target.value});
    }
    handleChangePoids(e) {
        this.setState({poids: e.target.value});
    }
    handleChangeHauteur(e) {
        this.setState({hauteur: e.target.value});
    }
    handleChangeLargeur(e) {
        this.setState({largeur: e.target.value});
    }
    handleChangePuissance(e) {
        this.setState({puissance: e.target.value});
    }
    handleChangeLieu(e) {
        this.setState({lieu: e.target.value})
    }
            

    handleClickOutside() {
        this.props.closePopup();
    }
    validerModif(){ 
         var data = this.props.data;
         var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth()+1; //January is 0!
        var yyyy = today.getFullYear();

        if(dd<10) {
            dd='0'+dd
        } 

        if(mm<10) {
            mm='0'+mm
        } 
        today = dd+'/'+mm+'/'+yyyy;

         if(this.state.modele != ""){
             data.modele = this.state.modele;
             data.historique.push("Modèle modifié en " + this.state.modele + " le " + today);
         }
         if(this.state.etat != ""){
             data.etat = this.state.etat;
             data.historique.push("Etat modifié en " + this.state.etat + " le " + today);
         }
         if(this.state.fabrication != ""){
             data.fabrication = String(this.state.fabrication);
             data.historique.push("Date de frabrication modifié en " + String(this.state.fabrication) + " le " + today);
         }
         if(this.state.poids != ""){
             data.poids = this.state.poids;
             data.historique.push("Poids modifié en " + this.state.poids + "t le " + today);
         }
         if(this.state.hauteur != ""){
             data.hauteur = this.state.hauteur;
             data.historique.push("Hauteur modifié en " + this.state.hauteur + "m le " + today);
         }
         if(this.state.largeur != ""){
             data.largeur = this.state.largeur;
             data.historique.push("Largeur modifié en " + this.state.largeur + "m le " + today);
         }
         if(this.state.puissance != ""){
             data.puissance = this.state.puissance;
             data.historique.push("Puissance modifié en " + this.state.puissance + "cv le " + today);
         }
         if(this.state.lieu != ""){
             data.lieux = this.state.lieu;
             data.historique.push("Lieu modifié en " + this.state.lieu + " le " + today);
         }
         data.type = "vehicule";
        this.props.addData(data);
        this.props.closePopup();
    }
    annulerModif(){
        this.props.closePopup();
    }

    render(){
        return(
                <div id='modif-vehicule' >
                    <h2>Modification véhicule</h2>
                    <form>
                        <label htmlFor="modif-date-fabrication">Date de frabrication:</label>
                        <input id="modif-date-fabrication" onChange={this.handleChangeFabrication.bind(this)} type="date" />    
                        <label htmlFor="modif-hauteur">Hauteur:</label>
                        <input id="modif-hauter" onChange={this.handleChangeHauteur.bind(this)}  type="text" />  
                        <label htmlFor="modif-largeur">Largeur:</label>
                        <input id="modif-largeur" onChange={this.handleChangeLargeur.bind(this)}  type="text" />    
                        <label htmlFor="modif-poids">Poids:</label>
                        <input id="modif-poids" onChange={this.handleChangePoids.bind(this)}  type="text" />   
                        <label htmlFor="modif-puissance">Puissance:</label>
                        <input id="modif-puissace" onChange={this.handleChangePuissance.bind(this)} type="text" />
                        <label htmlFor="modif-lieu">Lieu:</label>
                        <input id="modif-lieu" onChange={this.handleChangeLieu.bind(this)} type="text" />   
                    </form>
                    <div className="buttons">
                        <div id="modif-valider" onClick = {this.validerModif.bind(this)}></div>
                        <div id="modif-annuler" onClick = {this.annulerModif.bind(this)}></div>
                    </div>
                </div>
        )
    }
}
module.exports = enhanceWithClickOutside(ModifVehicule);
