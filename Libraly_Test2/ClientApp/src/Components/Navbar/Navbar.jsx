import React from 'react';
import Links from "./Components/Links";
import Classes from "./Navbar.module.css";
import Input from "../../StyledComponents/LittleComponents/Input";
import Button from "../../StyledComponents/LittleComponents/Button";
import Div from "../../StyledComponents/LittleComponents/Div";
import Filter from "../../StyledComponents/LittleComponents/Filter";

const Navbar = () => {
    return (
        <Div display={'block'} gridArea={"n"} border={'solid red'} maxWidth="20vw">


            <h4 className={Classes.Text}> Фильтрация</h4>

            <Filter>
                <li>
                    автору
                </li>
                <li>
                    количеству
                </li>
            </Filter>


            {/*</Div>*/}
        </Div>
    );
};

export default Navbar;