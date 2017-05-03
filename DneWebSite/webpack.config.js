var webpack = require('webpack');
var path = require('path');
var HtmlWebpackPlugin=require('html-webpack-plugin');

const VENDOR_LIBS=[
   'angular','angular-ui-router','angular-ui-bootstrap',
   'angular-ui-calendar','angular-ui-grid',
   'angular-animate','angular-scroll','ng-dialog',
  //  'qTip2',
  'jquery',
  'jquery-ui'

]

module.exports = {
  entry: {
    bundle:'./js/index.js',
    vendor:VENDOR_LIBS,
  },
  output: {
    path: path.join(__dirname, 'js/dist'),
    filename: '[name].[chunkhash].js',
    publicPath:'js/dist/'
  },
  module:{
    rules:[{
      use:'babel-loader',
      test:/\.js$/,
      exclude:/node_modules/
    },{
      use:['style-loader','css-loader'],
      test:/\.css$/
    },
    { 
      use: 'url-loader?limit=250000',
      test: /\.(png|woff|woff2|eot|ttf|svg|gif|jpg)(\?|$)/ 
    },
    {
      use: ['html-loader'],
      test:/\.html$/
      
    }
    // ,
    // {
    //   use:[{
    //     loader:'expose-loader',
    //     options:'jQuery'
    //   },{
    //     loader:'expose-loader',
    //     options:'$'
    //   }],
    //   test:require.resolve('jquery')
    // }
    // ,
    //  { test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/, use: "url-loader?limit=10000&mimetype=application/font-woff" },
    //  { test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/, use: "file-loader" }
    ]
  },
  plugins:[
    new webpack.optimize.CommonsChunkPlugin({
      //'manifest' is tell webpack that vendor code is changed
      names:['vendor','manifest']
    })
    ,
    new HtmlWebpackPlugin({
      template:'js/index.html'
    })
    // ,
    // new webpack.ProvidePlugin({
    //     $: "jquery",
    //     jquery:"jquery",
    //     "window.jQuery": "jquery",
    //     jQuery:"jquery",
    //     "moment": "moment",
    //     "window.moment":"moment"
    // })
  ]
  ,
  externals:{
    jquery:'jQuery',
    moment:'moment'
  }
};
