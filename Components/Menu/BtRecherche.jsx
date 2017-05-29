var React = require('react');
var ReactDOM = require('react-dom');


var Toggle = require('../Tools/Toggle/Toggle.jsx');
var RechercheAvance = require('../RechercheAvance/RechercheAvance.jsx');

class BtRecherche extends React.Component{
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
                <div id="bt-recherche" onClick={this.onClick.bind(this)}> </div>
                <Toggle hidden={this.state.hidden}>
                        <RechercheAvance closeRecherche={this.onClick} setRechercheAvanceUser={this.props.setRechercheAvanceUser}/>
                </Toggle>
            </div>
        )
    }
}

module.exports = BtRecherche;