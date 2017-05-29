var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

require('./Menu.css');

var BtAjoutVehicule = require('./BtAjoutVehicule.jsx');
var BtAjout = require('./BtAjout.jsx');

var BtRecherche = require('./BtRecherche.jsx');
var BtRechercheAdmin = require('./BtRechercheAdmin.jsx');

class Menu extends React.Component{
    constructor(props){
        super(props);
    }
    render(){
        return(
            <Router history={hashHistory}>
                <Route path='/' component={MenuConnexion} />
                <Route path="/accueil" component={() => (<MenuAccueilUser setRechercheUser={this.props.setRechercheUser}  setRechercheAvanceUser={this.props.setRechercheAvanceUser}/>)}/>
                <Route path='/administration' component={MenuAccueilAdmin} />
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
    constructor(props){
        super(props);
    }
    render(){
        return(
            <div id="div-menu">
                <Link to='/' style={{display: 'inline-block'}}><div id="img-logo"></div></Link> 
                <div className ="verticalLine"></div>
                <BtRecherche setRechercheAvanceUser = {this.props.setRechercheAvanceUser} />
                <input type="text" id="recherche-user" onChange={this.props.setRechercheUser} />
                <BtAjoutVehicule />
                <Link to='/' style={{display: 'inline-block'}}><div id="bt-user"></div></Link>
            </div>
        );
    }
}

class MenuAccueilAdmin extends React.Component{
    render(){
        return(
            <div id="div-menu">
                <Link to='/' style={{display: 'inline-block'}}><div id="img-logo"></div></Link> 
               <div className ="verticalLine"></div>
               <BtRechercheAdmin />
                <input type="text" id="recherche-user" />
                <BtAjout />
                <Link to='/' style={{display: 'inline-block'}}><div id="bt-user"></div></Link>
            </div>
        );
    }
}
module.exports = Menu;