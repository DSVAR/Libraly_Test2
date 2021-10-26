import React from 'react';
import styled, {css} from "styled-components";

const StyledButton=styled.button`
  margin: ${props=>props.margin || 0};
  color: ${props=>props.color || 'blue'};
  background: ${props=>props.background ||'black'};
  width: 4rem;
  height: 4rem;
  justify-content: center;
  
  &:hover{
  background: ${({hoverBack})=>hoverBack || 'blue'};
  }
`;


const Button = (props) => {
    return  <StyledButton {...props} children={props.children}/>
};

export default Button;