import React from 'react';
import Desription from "./Components/desrip";
import Classes from "./Footer.module.css";

const Footer = () => {
    return (
        <div className={Classes.footer} >
            <Desription/>
        </div>
    );
};

export default Footer;