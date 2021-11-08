import React from 'react';
import styled from "styled-components";

const StyledImg = styled.img`
  width: ${props => props.width || "3vw"};
  height: ${props => props.height || "6vh"};
  margin-top: 0.5vh;
`


const Img = (props) => {
    return <StyledImg {...props} children={props.children}/>
};

export default Img;