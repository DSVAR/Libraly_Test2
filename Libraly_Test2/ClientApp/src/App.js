import './App.css';
import HeaderContainer from "./Components/Header/HeaderContainer";
import NavbarContainer from "./Components/Navbar/NavbarContainer";
import SomePagesContainer from "./Components/Content/SomePagesContainer";
import FooterContainer from "./Components/Footer/FooterContainer";
import {BrowserRouter} from  "react-router-dom";
import {Provider} from "react-redux";
import {createStore} from "redux";
import Store from "./Redux/Store";
import store from "./Redux/Reducers";





function App() {
    return (
        <div className="App">

            <HeaderContainer/>
            <NavbarContainer/>
            <SomePagesContainer/>
        </div>
    );
}



const MainApp=(props)=>{
    return <BrowserRouter>
        <Provider store={store}>
            <App/>
        </Provider>
    </BrowserRouter>
}

export default MainApp;
