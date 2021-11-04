import React from 'react';
import Item from "./Components/Item";
import Classes from "./SomePages.module.css";
import Order from "../../StyledComponents/FullComponents/Order";
import Div from "../../StyledComponents/LittleComponents/Div";

const SomePages = () => {
    return (
        <div className={Classes.page}>
            <Div gridTemplateColumns="1fr 1fr 1fr "  display="grid">

                <Order/>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
                <Order/>
            </Div>
        </div>
    );
};

export default SomePages;