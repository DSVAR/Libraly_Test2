import React from 'react';
import Classes from './Header.module.css'
import Logo from "./HeaderComponents/Logo";
import styled from "styled-components";


const Header = () => {
    return (
        <header className={Classes.head}>
            <Logo/>
            <div  >
                {/*<Button/>*/}
                <h1>headser</h1>
            </div>
        </header>
    );
};

export default Header;