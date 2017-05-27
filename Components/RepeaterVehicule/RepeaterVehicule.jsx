var React = require('react');
var ReactDOM = require('react-dom');
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

var RowVehicule = require('./RowVehicule.jsx');

class RepeaterVehicule extends React.Component {
     constructor(props){
         super(props);
         
     }
     render () {
         var data = this.props.data
        return (
            <div>
            {data.map(function(data, i){
                return <RowVehicule vehicule={data} key={i} cle={i} />;
            })}
            </div>
        );
    }
}


module.exports = RepeaterVehicule;
