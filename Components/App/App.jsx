var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

// --- Components ---
var Menu = require('../Menu/Menu.jsx');
var Connexion = require('../Connexion/Connexion.jsx');
var AccueilUser = require('../AccueilUser/AccueilUser.jsx');
var AccueilAdmin = require('../AccueilAdmin/AccueilAdmin.jsx');

class App extends React.Component{
  constructor(props){
    super(props);
    this.state = {
        rechercheAvanceUser : [{model:"",statut:"", lieu:"", hauteurMin:"", hauteurMax:""}],
        rechercheUser: ""
      }
    }
    setRechercheUser(e){
      this.setState({
        rechercheUser: e.target.value
      })
    }
    navigate(url){
      browserHistory.push(url);
      this.forceUpdate();
      location.reload();
    }
    addVehicule(data){
      this.child.addData(data);
    }
    
    setRechercheAvanceUser(e, minHauteur, maxHauteur){

      if(e){
        if(e.target.name == "recherche-modele"){
          this.state.rechercheAvanceUser[0].model = e.target.value;
        }
        else if(e.target.name == "recherche-statut"){
          this.state.rechercheAvanceUser[0].statut = e.target.value;
        }
        else if(e.target.name == "recherche-lieu"){
          this.state.rechercheAvanceUser[0].lieu = e.target.value;
        }
        this.forceUpdate();
      }else{
        if(typeof(minHauteur) != 'undefined'){
          this.state.rechercheAvanceUser[0].hauteurMin = minHauteur;
        }
        if(typeof(maxHauteur) != 'undefined'){
          this.state.rechercheAvanceUser[0].hauteurMax = maxHauteur;
        }
        this.forceUpdate();
      }
      
    }
    clearRechercheAvanceUser(){
      this.setState({
        rechercheAvanceUser: [{model:"",statut:"", lieu:"", hauteurMin:"", hauteurMax:""}]
      })
    }

    render() {
      return (
        <div>     
          <Menu 
            setRechercheUser={this.setRechercheUser.bind(this)}
            addVehicule ={this.addVehicule.bind(this)} 
            setRechercheAvanceUser={this.setRechercheAvanceUser.bind(this)}
          />
          <Router history={hashHistory}>
              <Route path='/'  history={hashHistory} component={()=> (<Connexion navigate = {this.navigate.bind(this)} />)} />
              <Route path='/accueil' component={()=> (<AccueilUser  onRef={ref => (this.child = ref)} filtreRecherche = {this.state.rechercheUser} filtreRechercheAvance= {this.state.rechercheAvanceUser} />)} />
              <Route path='/administration' component={()=> (<AccueilAdmin />)} />
          </Router>
        </div>     
      );
    }
}

module.exports = App;