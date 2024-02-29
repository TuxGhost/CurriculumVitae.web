const path = require('path');

module.exports = {
    entry: './src/js/index.js',
    output: {
        filename: 'bootstrap.js',
        path: path.resolve(__dirname,'wwwroot/dist'),
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
