var React = require('react');
var ReactDOM = require('react-dom');
var enhanceWithClickOutside = require('react-click-outside');
require('./RechercheAvance.css')

class RechercheAvance extends React.Component{
    constructor(props){
        super(props)
    }
    handleClickOutside() {
        this.props.closeRecherche();
    }
    // validerRecherche(){
    //     this.props.closePopup();
    // }

    render(){
        return(
                <div id='recherche-avance'>
                   
                </div>
        )
    }
}
module.exports = enhanceWithClickOutside(RechercheAvance);
