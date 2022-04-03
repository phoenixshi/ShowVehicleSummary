import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import reducer from './redux/reducer';


export default function configureStore() {
  //Create store with redux-thunk
  return createStore(
    reducer,
    applyMiddleware(thunk)
  );
}
