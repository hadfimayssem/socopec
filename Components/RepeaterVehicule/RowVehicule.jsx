var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router';

require('./RowVehicule.css');

var VoletDetails = require('./VoletDetails.jsx');

class RowVehicules extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            showVoletDetail: false
        }
    }
    onClick(e){
        if(this.state == true){
            this.setState({showVoletDetail: false});
        }else{
            this.setState({showVoletDetail: true});
        }
    }
    render() {
        let volet;

        if (this.state.showVoletDetail) {
            volet = ( <VoletDetails /> )
        }else{
            volet = ( <div></div>)
        }
        return(
            <div>
                <div className = "rowVehicule" data-id={this.props.cle}>
                    <span className="identifiant"> {this.props.vehicule.id} </span> 
                    <span className="modele"> Modèle: {this.props.vehicule.modele} </span> 
                    <span className="etat"> Statut: {this.props.vehicule.etat} </span>
                    <span className="details" data-id={this.props.cle}  onClick={this.onClick.bind(this)}></span>
                </div>
                { volet }  
            </div>
        );
    }
}     

module.exports = RowVehicules;