var webpack = require('webpack');
var path = require('path');
var HtmlWebpackPlugin=require('html-webpack-plugin');

const VENDOR_LIBS=[
   'angular','angular-ui-router','angular-bootstrap',
   'angular-ui-calendar','angular-ui-grid',
   'angular-animate','angular-scroll','ng-dialog',
  //  'qTip2',
  'jquery',
  'jquery-ui'

]

module.exports = {
  entry: {
    bundle:'./js/index.js',
    vendor:VENDOR_LIBS
  },
  output: {
    path: path.join(__dirname, 'js/dist'),
    filename: '[name].[chunkhash].js',
  },
  module:{
    rules:[{
      use:'babel-loader',
      test:/\.js$/,
      exclude:/node_modules/
    },{
      use:['style-loader','css-loader'],
      test:/\.css$/
    }
    ]
  },
  plugins:[
    new webpack.optimize.CommonsChunkPlugin({
      //'manifest' is tell webpack that vendor code is changed
      names:['vendor','manifest']
    })
    // ,
    // new HtmlWebpackPlugin({
    //   template:'js/dist/index.html'
    // })
  ]
};
