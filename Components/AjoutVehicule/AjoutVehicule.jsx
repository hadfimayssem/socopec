var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
require('./AjoutVehicule.css')

class AjoutVehicule extends React.Component{
    constructor(props){
        super(props)
    }
    handleClickOutside() {
        this.props.closePopup();
    }
    validerAjout(){
        this.props.closePopup();
    }
    annulerAjout(){
        this.props.closePopup();
    }

    render(){
        return(
                <div id='ajout-vehicule' >
                    <h2>Ajout véhicule</h2>
                    <form>
                        <label htmlFor="ajout-date-fabrication">Date de frabrication:</label>
                        <input id="ajout-date-fabrication" type="date" />    
                        <label htmlFor="ajout-hauteur">Largeur:</label>
                        <input id="ajout-hauter" type="text" />   
                        <label htmlFor="ajout-poids">Poids:</label>
                        <input id="ajout-poids" type="text" />   
                        <label htmlFor="ajout-puissance">Puissance:</label>
                        <input id="ajout-puissace" type="text" />  
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
