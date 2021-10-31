import React from 'react';
import Links from "./Components/Links";
import Classes from "./Navbar.module.css";
import Input from "../../StyledComponents/LittleComponents/Input";
import Button from "../../StyledComponents/LittleComponents/Button";
import Div from "../../StyledComponents/LittleComponents/Div";

const Navbar = () => {
    return (
        <Div display={'block'} gridArea={"n"} border={'solid red'} maxWidth="20vw">
            <Div display={'block'}>
                <Input/>

            </Div>
        </Div>
    );
};

export default Navbar;