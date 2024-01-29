const path = require('path');

module.exports = {
    entry: './src/js/index.js', // Replace with your entry file
    output: {
        filename: 'bootstrap-cv.js',
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
