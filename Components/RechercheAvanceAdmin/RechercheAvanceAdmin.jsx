var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
var InputRange = require('react-input-range');
require('react-input-range/lib/css/index.css');
require('./RechercheAvanceAdmin.css');

class RechercheAvanceAdmin extends React.Component{
    constructor(props){
        super(props)
        this.state = {
            value: { min: 2, max: 10 },
            vehicule: true,
            agent: false,
            agence: false,
            etat: false
        };
        this.clickChangeActiveVehicule = this.clickChangeActiveVehicule.bind(this);
        this.clickChangeActiveAgent = this.clickChangeActiveAgent.bind(this);
        this.clickChangeActiveAgence = this.clickChangeActiveAgence.bind(this);
        this.clickChangeActiveEtat = this.clickChangeActiveEtat.bind(this);
    }
    handleClickOutside() {
        this.props.closeRecherche();
    }
    clickChangeActiveVehicule(){
        this.setState({
            vehicule: true,
            agent: false,
            agence: false,
            etat: false
        })
    }
    clickChangeActiveAgent(){
        this.setState({
            vehicule: false,
            agent: true,
            agence: false,
            etat: false
        })
    }
    clickChangeActiveAgence(){
        this.setState({
            vehicule: false,
            agent: false,
            agence: true,
            etat: false
        })
    }
    clickChangeActiveEtat(){
        this.setState({
            vehicule: false,
            agent: false,
            agence: false,
            etat: true
        })
    }
    // validerRecherche(){
    //     this.props.closePopup();
    // }

    render(){
        var activeVehicule, activeEtat, activeAgent,activeAgence;
        if(this.state.vehicule == true){
            activeVehicule = "active";
            activeAgent = "";
            activeAgence = "";
            activeEtat = "";
        }else if(this.state.agent == true){
            activeVehicule = "";
            activeAgent = "active";
            activeAgence = "";
            activeEtat = "";
        }else if(this.state.agence == true){
            activeVehicule = "";
            activeAgent = "";
            activeAgence = "active";
            activeEtat = "";
        }else if(this.state.etat == true){
            activeVehicule = "";
            activeAgent = "";
            activeAgence = "";
            activeEtat = "active";
        }

        return(
                <div id='recherche-avance-admin'>
                    <div id='wrapper-recherche-bt'>
                        <div id='recherche-bt-vehicule' className={activeVehicule} onClick={this.clickChangeActiveVehicule.bind(this)}></div>
                        <div id='recherche-bt-agent' className={activeAgent} onClick={this.clickChangeActiveAgent.bind(this)}></div>
                        <div id='recherche-bt-agence' className={activeAgence} onClick={this.clickChangeActiveAgence.bind(this)}></div>
                        <div id='recherche-bt-etat' className={activeEtat} onClick={this.clickChangeActiveEtat.bind(this)}></div>
                    </div>
                    <div id='recherche-avance-vehicule'>
                        <div>Recherche Avancée</div>
                        <label htmlFor="recherche-modele">Modèle:</label>
                        <select name="recherche-modele">
                            <option value="volvo">Volvo</option>
                            <option value="saab">Saab</option>
                            <option value="fiat">Fiat</option>
                            <option value="audi">Audi</option>
                        </select>
                        <label htmlFor="recherche-statut">Statut:</label>
                        <select name="recherche-statut">
                            <option value="loue">loué</option>
                            <option value="toto">toto</option>
                            <option value="rofl">Rofl</option>
                            <option value="mop">Mop</option>
                        </select>
                        <label htmlFor="recherche-lieu">Lieu:</label>
                        <select name="recherche-Lieu">
                            <option value="foo">foo</option>
                            <option value="toto">toto</option>
                            <option value="rofl">Rofl</option>
                            <option value="mop">Mop</option>
                        </select>
                        <InputRange
                            maxValue={20}
                            minValue={0}
                            value={this.state.value}
                            onChange={value => this.setState({ value })} 
                        />
                    </div>
                </div>
        )
    }
}
module.exports = enhanceWithClickOutside(RechercheAvanceAdmin);
