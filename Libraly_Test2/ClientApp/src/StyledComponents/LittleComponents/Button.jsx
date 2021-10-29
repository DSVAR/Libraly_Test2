import React from 'react';
import styled, {css} from "styled-components";

const StyledButton=styled.button`
  margin: ${props=>props.margin || 0};
  color: ${props=>props.color || 'blue'};
  background: ${props=>props.background ||'black'};
  width: 6rem;
  height: 4rem;
  justify-content: center;
  border:solid ${props=>props.borderColor || 'black'};
  border-radius: 0.7em ;
  margin: 1vh;
  font-family: ;
  &:hover{
  background: ${({hoverBack})=>hoverBack || 'blue'};
  }
`;


const Button = (props) => {
    return  <StyledButton {...props} children={props.children}/>
};

export default Button;