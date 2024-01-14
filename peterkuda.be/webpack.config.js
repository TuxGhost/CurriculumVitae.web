const path = require('path');

module.exports = {
    entry: './src/index.js',
    output: {
        filename: 'bootstrap.js',
        path: path.resolve(__dirname,'wwwroot/dist'),
    },
};
