var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
require('./ModifVehicule.css')

class ModifVehicule extends React.Component{
    constructor(props){
        super(props)
    }
    handleClickOutside() {
        this.props.closePopup();
    }
    validerModif(){
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
                        <input id="modif-date-fabrication" type="date" />    
                        <label htmlFor="modif-hauteur">Largeur:</label>
                        <input id="modif-hauter" type="text" />   
                        <label htmlFor="modif-poids">Poids:</label>
                        <input id="modif-poids" type="text" />   
                        <label htmlFor="modif-puissance">Puissance:</label>
                        <input id="modif-puissace" type="text" />  
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
