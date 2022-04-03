import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<App />, div);
  ReactDOM.unmountComponentAtNode(div);
});
/*I'm not good at react unit test but I think there should be a few unit test
1 We need to mock the loading value to check if loading is displayed
2 We need to check if all the element on page is loaded like select, table header, table body
3 We need to mock all api call return value to check the logic of the app render
4 We need to mock different dispatch action and check the reducer logic
*/