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
                        <div className="details-fabrication">Fabrication: {this.props.data.fabrication} </div>
                        <div className="details-hauteur">Hauteur: {this.props.data.hauteur} m </div>
                        <div className="details-largeur">Largeur: {this.props.data.largeur} m </div>
                    </div>
                    <div className="details-infos">
                        <div className="details-poids">Poids: {this.props.data.poids} t </div>
                        <div className="details-puissance">Puissance: {this.props.data.puissance} ch</div>
                        <div className="details-lieux">Lieux: {this.props.data.lieux} </div>
                    </div>
                    <div className="details-buttons">
                        <div className="details-edit" onClick={this.onClick.bind(this)}></div>
                        <div className="details-historique"></div>
                    </div>
                </div>
                <div className="historique"><RowDetails historique ={"ceci est une ligne d'historique"}/></div>
                <Toggle hidden={this.state.hidden}>
                    <div id='ajout-vehicule-overlay'>
                        <ModifVehicule addData ={this.props.addData} closePopup={this.onClick} data={this.props.data} />
                    </div>
                </Toggle>
            </div>
        );
    }
}

module.exports = VoletDetails;