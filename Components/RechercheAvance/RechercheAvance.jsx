var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
var InputRange = require('react-input-range');
require('react-input-range/lib/css/index.css');
require('./RechercheAvance.css');

class RechercheAvance extends React.Component{
    constructor(props){
        super(props)
        this.state = {
            value: { min: 2, max: 10 },
        };
    }
    handleClickOutside() {
        this.props.closeRecherche();
    }
    // validerRecherche(){
    //     this.props.closePopup();
    // }

    render(){
        return(
                <div id='recherche-avance'>
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
        )
    }
}
module.exports = enhanceWithClickOutside(RechercheAvance);
