import React from 'react';
import Item from "./Components/Item";
import Classes from "./SomePages.module.css";

const SomePages = () => {
    return (
        <div className={Classes.page}>
            <Item/>
        </div>
    );
};

export default SomePages;