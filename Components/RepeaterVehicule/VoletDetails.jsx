var React = require('react');
var ReactDOM = require('react');
require('./VoletDetails.css');

var RowDetails = require('./RowDetails.jsx');
var Toggle = require('../Tools/Toggle/Toggle.jsx');
var ModifVehicule = require('../ModifVehicule/ModifVehicule.jsx');
class VoletDetails extends React.Component{
    constructor(props) {
        super(props);
        this.onClick = this.onClick.bind(this);
        this.state = { hidden:true };
    }

    onClick() {
        this.setState((prevState, props) => ({
            hidden: !(prevState.hidden)
        })) 
    }
    render(){
        return(
            <div className="volet-details">
                <div className="wrapper-details">
                    <div className="details-img"></div>
                    <div className="details-infos">
                        <div className="details-fabrication">Fabrication: {this.props.fabrication} </div>
                        <div className="details-hauteur">Hauteur: {this.props.hauteur} </div>
                        <div className="details-largeur">Largeur: {this.props.largeur} </div>
                    </div>
                    <div className="details-infos">
                        <div className="details-poids">Poids: {this.props.poids} </div>
                        <div className="details-puissance">Puissance: {this.props.puissance} </div>
                        <div className="details-lieux">Lieux: {this.props.lieux} </div>
                    </div>
                    <div className="details-buttons">
                        <div className="details-edit" onClick={this.onClick.bind(this)}></div>
                        <div className="details-historique"></div>
                    </div>
                </div>
                <div className="historique"><RowDetails historique ={"ceci est une ligne d'historique"}/></div>
                <Toggle hidden={this.state.hidden}>
                    <div id='ajout-vehicule-overlay'>
                        <ModifVehicule closePopup={this.onClick} />
                    </div>
                </Toggle>
            </div>
        );
    }
}

module.exports = VoletDetails;