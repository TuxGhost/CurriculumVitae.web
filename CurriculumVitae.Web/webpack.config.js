const path = require('path');

module.exports = {
    entry: {
        bootstrap: './src/js/index.js', // Replace with your entry file
        jquery: './src/js/jquery.js'
    },
    output: {
        filename: '[name]-cv.js',
        path: path.resolve(__dirname, 'wwwroot','dist'), // Replace with your output directory
        
    },   
    module: {
        rules: [
            {
                test: /\.css$/,
                use: ['style-loader', {
                    loader: 'css-loader',
                    options: {
                        sourceMap: true,
                    },
                }]
            },
        ]
    }
};
