var React = require('react');
var ReactDOM = require('react-dom');


var Toggle = require('../Tools/Toggle/Toggle.jsx');
var RechercheAvanceAdmin = require('../RechercheAvanceAdmin/RechercheAvanceAdmin.jsx');

class BtRechercheAdmin extends React.Component{
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
            <div id="wrapper-bt-recherche">
                <div id="bt-recherche-admin" onClick={this.onClick.bind(this)}> </div>
                <Toggle hidden={this.state.hidden}>
                        <RechercheAvanceAdmin closeRecherche={this.onClick} />
                </Toggle>
            </div>
        )
    }
}

module.exports = BtRechercheAdmin;