import React from 'react';
import Links from "./Components/Links";
import Classes from "./Navbar.module.css";

const Navbar = () => {
    return (
        <nav className={Classes.navbar}>
            <Links/>
        </nav>
    );
};

export default Navbar;