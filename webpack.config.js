const path = require('path');


module.exports = {
    // configuration
    
    context: __dirname + "/javascript/",
    entry: "./index.js",
    output: {
        path: __dirname + "/javascript/",
        filename: "bundle.js"
    },
    module: {
        loaders: [
            { test: /\.js$/, loader: 'babel-loader', exclude: /node_modules/ },
            { test: /\.jsx$/, loader: 'babel-loader', exclude: /node_modules/ },
            { test: /\.css$/, loader: "style-loader!css-loader" },
            { test: /\.(png|jpg)$/, loader: 'file-loader?name=assets/images/[name].[ext]' },
        ]
    },
    
}
