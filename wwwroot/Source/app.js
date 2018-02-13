//$ = require('jquery');
//import $ from 'jquery';
require('./lib');
import 'bootstrap/dist/css/bootstrap.min.css';
import '../css/site.css';
import ES6Lib from './es6codelib';
import React from 'react';
import ReactDOM from 'react-dom';
import Counter from './reactcomponent';


$("#fillthis").html(getText());
$('#fillthiswithjquery').html('Filled by Jquery! Mike');

let es6Obj = new ES6Lib();

ReactDOM.render(
    <Counter />,
    document.getElementById('basicreactcomponent')
);

//$('#fillthiswithes6lib1').html(es6Obj.getData());

//module.hot.accept();