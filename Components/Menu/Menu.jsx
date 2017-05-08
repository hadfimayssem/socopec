var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

require('./Menu.css');

class Menu extends React.Component{
    render(){
        return(
            <Router history={hashHistory}>
                <Route path='/' component={MenuConnexion} />
                <Route path='/accueil' component={MenuAccueilUser} />
            </Router>
        )
    }
}

class MenuConnexion extends React.Component{
    render(){
        return(
            <div id="div-menu">
                <Link to='/' style={{display: 'inline-block'}}><div id="img-logo"></div></Link> 
                <div className ="verticalLine"></div>
            </div>
        );
    }
}

class MenuAccueilUser extends React.Component{
    render(){
        return(
            <div id="div-menu">
                <Link to='/' style={{display: 'inline-block'}}><div id="img-logo"></div></Link> 
                <div className ="verticalLine"></div>
                <div id="img-loupe-voiture"></div>
                <input type="text" id="recherche-user" />
            </div>
        );
    }
}

module.exports = Menu;