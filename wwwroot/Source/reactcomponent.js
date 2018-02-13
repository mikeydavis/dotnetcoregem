import * as React from 'react';
import * as ReactDOM from 'react-dom';


export default class Counter extends React.Component {
  constructor() {
    super();
    this.state = { currentCount: 5 };
   }
  render() {
   return <div>
     <h2>Rep Counter</h2>
      <p>This is a simple example of a React component.</p>    <p>Current count: <strong>{this.state.currentCount}</strong></p>
  <button onClick={() => { this.incrementCounter()    
                        }}>Increment
   </button>
   </div>;
  }
  
 incrementCounter() {
   this.setState({
     currentCount: this.state.currentCount + 1
         });
    }
}