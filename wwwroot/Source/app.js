//$ = require('jquery');
//import $ from 'jquery';
require('./lib');
import 'bootstrap/dist/css/bootstrap.min.css';
import '../css/site.css';
import ES6Lib from './es6codelib';
import React from 'react';
import ReactDOM from 'react-dom';
import Counter from './reactcomponent';
import FetchData from './fetchweatherdata';


$("#fillthis").html(getText());
$('#fillthiswithjquery').html('Filled by Jquery! Mike');

let es6Obj = new ES6Lib();

let destruct = {
    bar:1,
    baz:2
};

var {baz, bar} = destruct;


ReactDOM.render(
    baz,document.getElementById('value-component'),

);

ReactDOM.render(
    <Counter />,
    document.getElementById('basicreactcomponent')
);

ReactDOM.render(
    <FetchData />,
    document.getElementById('reactcomponentwithapidata')
);

//$('#fillthiswithes6lib1').html(es6Obj.getData());

//module.hot.accept();