import React, {Component} from 'react';
import SomePages from "./SomePages";
import {connect} from 'react-redux';
import {getBooker} from "../../Redux/bookReducer";

class SomePagesContainer extends Component {

    componentDidMount() {
        this.props.getBooker();
    }

    render() {
        return (
            <SomePages/>
        )
    }
}

let mapStateToProps = (state) => {
    return {
        books: getBooker(state)
    }
}

export default connect(mapStateToProps,{getBooker})(SomePagesContainer);