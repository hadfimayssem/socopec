var React = require('react');
var ReactDOM = require('react-dom');


var Toggle = require('../Tools/Toggle/Toggle.jsx');
var AjoutVehicule = require('../AjoutVehicule/AjoutVehicule.jsx');

class BtAjoutVehicule extends React.Component{
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
            <div id="wrapper-bt-ajout-vehicule">
                <div id="bt-ajout-vehicule" onClick={this.onClick.bind(this)}> </div>
                <Toggle hidden={this.state.hidden}>
                    <div id='ajout-vehicule-overlay'>
                        <AjoutVehicule addVehicule={this.props.addVehicule} closePopup={this.onClick} />
                    </div>
                </Toggle>
            </div>
        )
    }
}

module.exports = BtAjoutVehicule;