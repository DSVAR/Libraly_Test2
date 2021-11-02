import React from 'react';
import Item from "./Components/Item";
import Classes from "./SomePages.module.css";
import Order from "../../StyledComponents/FullComponents/Order";

const SomePages = () => {
    return (
        <div className={Classes.page}>
            <Order/>
            <Order/>
            <Order/>
            <Order/>
        </div>
    );
};

export default SomePages;