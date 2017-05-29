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
            value: { min: 0, max: 6},
        };
    }
    handleClickOutside() {
        this.props.closeRecherche();
    }
    handleSlide() {
        this.props.setRechercheAvanceUser(false, this.state.value.min, this.state.value.max);
    }

    render(){
        return(
                <div id='recherche-avance'>
                    <h2>Recherche Avancée</h2>
                    <form>
                        <label htmlFor="recherche-modele">Modèle:</label>
                        <select name="recherche-modele" onChange={this.props.setRechercheAvanceUser}>
                            <option value="">Aucun</option>
                            <option value="Citroene">Citroene</option>
                            <option value="Opel">Opel</option>
                            <option value="Peugeot">Peugeot</option>
                            <option value="Fiesta">Fiesta</option>
                            <option value="Ferari">Ferari</option>
                            <option value="Renault">Renault</option>
                        </select>
                        <label htmlFor="recherche-statut">Statut:</label>
                        <select name="recherche-statut" onChange={this.props.setRechercheAvanceUser}>
                            <option value="">Aucun</option>
                            <option value="Loue">Loue</option>
                            <option value="Garage">Garage</option>
                            <option value="En reperation">En reperation</option>
                            <option value="En attente">En attente</option>
                        </select>
                        <label htmlFor="recherche-lieu">Lieu:</label>
                        <select name="recherche-lieu" onChange={this.props.setRechercheAvanceUser}>
                            <option value="">Aucun</option>
                            <option value="Nancy">Nancy</option>
                            <option value="Strasbourg">Strasbourg</option>
                        </select>
                    </form>
                    <label>Hauteur (en mètre)</label>
                    <InputRange
                            maxValue={6}
                            minValue={0}
                            value={this.state.value}
                            onChange={value => this.setState({ value })} 
                            onChangeComplete={this.handleSlide.bind(this)}
                        />
                </div>
        )
    }
}
module.exports = enhanceWithClickOutside(RechercheAvance);
