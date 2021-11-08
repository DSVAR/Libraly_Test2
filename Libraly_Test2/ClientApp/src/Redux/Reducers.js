import React from 'react';
import bookReducer from './bookReducer'
import {applyMiddleware, combineReducers, compose, createStore} from "redux";
import thunkMiddleware from 'redux-thunk'

let reducers = combineReducers({
    book:bookReducer
})

const composeEnhancers=window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;


const store=createStore(reducers,composeEnhancers( applyMiddleware(thunkMiddleware)  ));

export default store;