var React = require('react');
var ReactDOM = require('react-dom');

var RepeaterVehicule = require('../RepeaterVehicule/RepeaterVehicule.jsx');

class AccueilUser extends React.Component{
    render () {
        return (
            <div className="Accueil-backgound">
                <RepeaterVehicule />
            </div>
        );
    }
}


module.exports = AccueilUser;