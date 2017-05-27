var React = require('react');
var ReactDOM= require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

require("./Connexion.css");

class Connexion extends React.Component{
    render(){
        return(
            <div id="background-connexion">
                <div id="div-connexion">
                    <h1 id="titre-connexion">
                        Connexion 
                    </h1>

                        <form action="/action_page.php">
                        Identifiant: <input type="text" name="login" /><br />
                        Mot de passe: <input type="text" name="mdp" /><br />
                        <Link to='/accueil'>connexion1</Link>
                        <Link to='/administration'>connexion2</Link>
                    </form>
                </div>
            </div>
        )
    }
}

module.exports = Connexion; 