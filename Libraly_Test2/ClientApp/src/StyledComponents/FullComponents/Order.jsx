import React from 'react';
import Div from "../LittleComponents/Div";
import Button from "../LittleComponents/Button";
import Img from "../LittleComponents/Img";


const Order = (props) => {
    return (
        <Div {...props} gridArea="auto" width="18vw" margin="0.5vw" display="inline" border="solid 0.2vh black">

            <Img width="10vw" height="30vh"
                 src="https://s1.1zoom.ru/big3/799/Game_of_Thrones_Men_Closeup_Eyes_Jon_Snow_Face_529978_4950x6900.jpg"/>

            <Div display="grid" gridTemplateColumns="1fr 1fr 1fr">
                <Div gridArea="auto" display="flex">
                    <p>Жанр</p>
                </Div>

                <Div gridArea="auto" display="flex">
                    <p>названия</p>
                </Div>

                <Div gridArea="auto" display="inline">
                    <p>количество:</p>
                </Div>

            </Div>

            <Div display="flex">
                <Button borderRadius='0' width='4.8vw' height='4vh'>1</Button>
                <Button borderRadius='0' width='4.8vw' height='4vh'>2</Button>
                <Button borderRadius='0' width='4.8vw' height='4vh'>3</Button>
            </Div>
        </Div>
    );
};

export default Order;