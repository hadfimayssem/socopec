var React = require('react');
var ReactDOM = require('react-dom');

class RowDetails extends React.Component{
    constructor(props){
        super(props);
    }
    render(){
        return(
            <span className="row-details">{this.props.historique}</span>
        )
    }
}

module.exports = RowDetails;