const path = require('path');

module.exports = {
    entry: './src/index.js', // Replace with your entry file
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'wwwroot','dist'), // Replace with your output directory
        
    },
};
