import React from 'react';
import Links from "./Components/Links";
import Classes from "./Navbar.module.css";
import Input from "../../StyledComponents/LittleComponents/Input";

const Navbar = () => {
    return (
        <nav className={Classes.navbar}>
            <Input />
        </nav>
    );
};

export default Navbar;