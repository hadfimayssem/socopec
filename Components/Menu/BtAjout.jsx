var React = require('react');
var ReactDOM = require('react-dom');


var Toggle = require('../Tools/Toggle/Toggle.jsx');
var AjoutVehicule = require('../AjoutVehicule/AjoutVehicule.jsx');

class BtAjout extends React.Component{
    constructor(props) {
        super(props);
        this.onClickMenu = this.onClickMenu.bind(this);
        this.onClick = this.onClick.bind(this);
        this.state = { 
            hiddenMenu:true,
            hidden: true 
        };
    }

    onClickMenu() {
        this.setState((prevState, props) => ({
            hiddenMenu: !(prevState.hiddenMenu)
        })) 
    }
    onClick() {
        this.setState((prevState, props) => ({
            hiddenMenu: true,
            hidden: !(prevState.hidden)
        })) 
    }
    
    render(){
        return(
            <div id="wrapper-bt-ajout">
                <div id="bt-ajout" onClick={this.onClickMenu.bind(this)}> </div>
                <Toggle hidden={this.state.hiddenMenu}>
                    <div id="choix-ajout">
                        <div id="choix-ajout-vehicule" className="icon-choix" onClick={this.onClick.bind(this)}></div>
                        <div id="choix-ajout-agent" className="icon-choix" onClick={this.onClick.bind(this)}></div>
                        <div id="choix-ajout-agence" className="icon-choix"onClick={this.onClick.bind(this)}></div> 
                        <div id="choix-ajout-etat" className="icon-choix"onClick={this.onClick.bind(this)}></div>
                    </div>
                </Toggle>
                <Toggle hidden={this.state.hidden}>
                    <div id='ajout-vehicule-overlay'>
                        <AjoutVehicule closePopup={this.onClick} />
                    </div>
                </Toggle>
            </div>
        )
    }
}

module.exports = BtAjout;