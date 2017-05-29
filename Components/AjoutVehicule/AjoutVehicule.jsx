var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
require('./AjoutVehicule.css')

class AjoutVehicule extends React.Component{
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
            lieu: "",
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
        this.setState({lieu: e.target.value});
    }

    handleClickOutside() {
        this.props.closePopup();
    }
    validerAjout(){ 
         var tempData = {type:"", id: "", modele:"",etat:"",fabrication:"",poids:"",hauteur:"",largeur:"",puissance:"", lieu:"",historique:[]};
         if(this.state.modele != "" && this.state.etat != "" && this.state.fabrication != "" &&
             this.state.poids != "" && this.state.hauteur != "" && this.state.largeur != "" &&
              this.state.puissance != "" && this.state.id != ""  && this.state.lieu != ""){
            tempData.id = this.state.id;
            tempData.modele = this.state.modele;
            tempData.etat = this.state.etat;
            tempData.fabrication = String(this.state.fabrication);
            tempData.poids = this.state.poids;
            tempData.hauteur = this.state.hauteur;
            tempData.largeur = this.state.largeur;
            tempData.puissance = this.state.puissance;
            tempData.lieu = this.state.lieu;
            tempData.type = "vehicule";
            
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
            tempData.historique.push("Ajouté en base le "+today)
            this.props.addVehicule(tempData);
            this.props.closePopup();
         }
    }
    annulerAjout(){
        this.props.closePopup();
    }

    render(){
        return(
                <div id='ajout-vehicule' >
                    <h2>Ajout véhicule</h2>
                    <form>
                        <label htmlFor="ajout-date-id">Identifiant:</label>
                        <input id="ajout-date-id" type="text" onChange ={this.handleChangeId.bind(this)}/>  
                        <label htmlFor="ajout-date-modele">Modele:</label>
                        <input id="ajout-date-modele" type="text" onChange={this.handleChangeModele.bind(this)} />  
                        <label htmlFor="ajout-date-fabrication">Date de frabrication:</label>
                        <input id="ajout-date-fabrication" type="date" onChange={this.handleChangeFabrication.bind(this)} />    
                        <label htmlFor="ajout-hauteur">Hauteur:</label>
                        <input id="ajout-hauter" type="text"  onChange={this.handleChangeHauteur.bind(this)} />
                        <label htmlFor="ajout-largeur">Largeur:</label>
                        <input id="ajout-hauter" type="text" onChange={this.handleChangeLargeur.bind(this)} />     
                        <label htmlFor="ajout-largeur">Poids:</label>
                        <input id="ajout-poids" type="text" onChange={this.handleChangePoids.bind(this)} />   
                        <label htmlFor="ajout-puissance">Puissance:</label>
                        <input id="ajout-puissace" type="text" onChange={this.handleChangePuissance.bind(this)} />
                        <label htmlFor="ajout-lieu">Lieu:</label>
                        <input id="ajout-lieu" type="text" onChange={this.handleChangeLieu.bind(this)}/>   
                        <label htmlFor="ajout-etat">Statut:</label>
                        <input id="ajout-etat" type="text" onChange={this.handleChangeEtat.bind(this)}/>   
                    </form>
                    <div className="buttons">
                        <div id="ajout-valider" onClick = {this.validerAjout.bind(this)}></div>
                        <div id="ajout-annuler" onClick = {this.annulerAjout.bind(this)}></div>
                    </div>
                </div>
        )
    }
}
module.exports = enhanceWithClickOutside(AjoutVehicule);
