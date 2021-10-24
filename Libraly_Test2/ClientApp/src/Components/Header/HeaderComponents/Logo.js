import React from 'react';
import Classes from "./HComopents.module.css"
import logo from '../../../Images/logo1.png'

const Logo = (props) => {
    return (
        <div className={Classes.logo}>
            <img alt="logo" src={logo} />
        </div>
    );
};

export default Logo;