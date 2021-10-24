import React from 'react';
import Classes from './Header.module.css'
import Logo from "./HeaderComponents/Logo";

const Header = () => {
    return (
        <header className={Classes.head}>
            <div  >
                <Logo/>
                <h1>headser</h1>
            </div>
        </header>
    );
};

export default Header;