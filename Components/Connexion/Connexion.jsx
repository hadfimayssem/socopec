var React = require('react');
var ReactDOM= require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

require("./Connexion.css");

class Connexion extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            login: "",
            password: ""
        };
    }
    handleLoginChange(e){
        this.setState({
            login: e.target.value
        });
    }
    handlePasswordChange(e){
        this.setState({
            password: e.target.value
        });
    }
    login(e){

        var login = this.state.login
        var password = this.state.password
        var utilisateur = USERS.find((u)=> u.login == login && u.password == password)
        if(typeof(utilisateur) == 'undefined'){
            //erreur login
            //redirect root
        }else if(utilisateur.admin == 0){
            //redirect user;
            this.props.navigate("/#/accueil");            
        }else if(utilisateur.admin == 1){
            //redirect accueil
            this.props.navigate("/#/administration");   
        }else{
            //redirect root
        }
        e.preventDefault();
    }
    render(){
        return(
            <div id="background-connexion">
                <div id="div-connexion">
                    <h1 id="titre-connexion">
                        Connexion 
                    </h1>

                    <form onSubmit={this.login.bind(this)}>
                        <input placeholder="Identifiant" type="text" name="login" onChange={this.handleLoginChange.bind(this)}/><br />
                        <input type="text" name="mdp" type="password" onChange={this.handlePasswordChange.bind(this)}/><br />
                        <button>Connexion</button>
                    </form>
                </div>
            </div>
        )
    }
}
var USERS=[
    {id:"1", nom:"HILCENKO", prenom:"Franck", login:"FHILCENKO", password:"1234", admin:1},
    {id:"1", nom:"DUBOIS", prenom:"Anthony", login:"ADUBOIS", password:"root", admin:0}
]
module.exports = Connexion; 