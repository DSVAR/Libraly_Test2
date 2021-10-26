import './App.css';
import HeaderContainer from "./Components/Header/HeaderContainer";
import NavbarContainer from "./Components/Navbar/NavbarContainer";
import SomePagesContainer from "./Components/Content/SomePagesContainer";
import FooterContainer from "./Components/Footer/FooterContainer";

function App() {
    return (
        <div className="App">

            <HeaderContainer/>
            <NavbarContainer/>
            <SomePagesContainer/>
        </div>
    );
}

export default App;
