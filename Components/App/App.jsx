var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

// --- Components ---
var Menu = require('../Menu/Menu.jsx');
var Connexion = require('../Connexion/Connexion.jsx');
var AccueilUser = require('../AccueilUser/AccueilUser.jsx');
var AccueilAdmin = require('../AccueilAdmin/AccueilAdmin.jsx');

class App extends React.Component{
  render() {
    return (
      <div>     
        <Menu />
        <Router history={hashHistory}>
            <Route path='/' component={Connexion} />
            <Route path='/accueil' component={AccueilUser} />
            <Route path='/administration' component={AccueilAdmin} />
        </Router>
      </div>     
    );
  }
}

module.exports = App;