
import {applyMiddleware, combineReducers, createStore} from 'redux';
import thunk from 'redux-thunk';


import {reducers as data} from './redusers';



const rootReducer = combineReducers({
    data
});


export default function configureStore() {
    return createStore(rootReducer, applyMiddleware(thunk));
}