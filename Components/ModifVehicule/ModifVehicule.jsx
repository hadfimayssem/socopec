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
            

    handleClickOutside() {
        this.props.closePopup();
    }
    validerModif(){ 
         var data = this.props.data;
         if(this.state.modele != ""){
             data.modele = this.state.modele;
         }
         if(this.state.etat != ""){
             data.etat = this.state.etat;
         }
         if(this.state.fabrication != ""){
             data.fabrication = String(this.state.fabrication);
         }
         if(this.state.poids != ""){
             data.poids = this.state.poids;
         }
         if(this.state.hauteur != ""){
             data.hauteur = this.state.hauteur;
         }
         if(this.state.largeur != ""){
             data.largeur = this.state.largeur;
         }
         if(this.state.puissance != ""){
             data.puissance = this.state.puissance;
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
