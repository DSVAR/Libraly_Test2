import './App.css';
import HeaderContainer from "./Components/Header/HeaderContainer";
import NavbarContainer from "./Components/Navbar/NavbarContainer";
import SomePagesContainer from "./Components/Content/SomePagesContainer";
import FooterContainer from "./Components/Footer/FooterContainer";

function App() {
    return (
        <div className="App">
            {/*<div  className="item hed">*/}
                 <HeaderContainer/>
            {/*</div>*/}

            {/*<div  className="item nav">*/}
                <NavbarContainer/>
            {/*</div>*/}

            {/*<div  className="item page">*/}
                <SomePagesContainer/>
            {/*</div>*/}

            {/*<div className="item fot">*/}
            {/*    <FooterContainer/>*/}
            {/*</div>*/}
        </div>
    );
}

export default App;
