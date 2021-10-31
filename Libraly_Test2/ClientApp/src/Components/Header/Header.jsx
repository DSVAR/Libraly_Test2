import React from 'react';
import Classes from './Header.module.css'
import Logo from "./HeaderComponents/Logo";
import styled from "styled-components";
import Div from "../../StyledComponents/LittleComponents/Div";
import Input, {Searcher} from "../../StyledComponents/LittleComponents/Input";
import Button from "../../StyledComponents/LittleComponents/Button";


const Header = () => {
    return (
        <header className={Classes.head}>
            <Div>
                <Div>
                    <Logo/>
                </Div>

                <Div margin="1vh auto"  >
                    {/*<button onAnimationStart={}*/}
                    <Searcher width='29vw'/>
                </Div>

                <Div>
                    <Button/>
                </Div>
            </Div>
        </header>
    );
};

export default Header;