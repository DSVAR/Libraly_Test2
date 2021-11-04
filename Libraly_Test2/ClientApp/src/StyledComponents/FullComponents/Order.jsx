import React from 'react';
import Div from "../LittleComponents/Div";
import Button from "../LittleComponents/Button";



const Order = (props) => {
    return (
        <Div {...props} gridArea="auto"  width="18vw" margin="0.5vw" display="inline"  border="solid 0.5vh black">
            <Button>swer</Button>
              <p>order</p>
            <Div  display="inline">
                <Button borderRadius='0' width='5em' height='3em'>1</Button>
                <Button borderRadius='0' width='5em' height='3em'>2</Button>
                <Button borderRadius='0' width='5em' height='3em'>3</Button>
            </Div>
        </Div>
    );
};

export default Order;