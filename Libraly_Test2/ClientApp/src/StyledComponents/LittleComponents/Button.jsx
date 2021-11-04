import React from 'react';
import styled, {css} from "styled-components";

const StyledButton=styled.button`
  margin: ${props=>props.margin || 0};
  color: ${props=>props.color || 'blue'};
  background: ${props=>props.background ||'black'};
  width: ${props=>props.width || '5rem'};
  height: ${props=>props.height || '5rem'};
  justify-content: center;
  border:solid ${props=>props.borderColor || 'black'};
  border-radius: ${props=>props.borderRadius|| '5em'} ;
  margin: 1vh;
  font-size: 2vh;
  font-family: Verdana;
  &:hover{
  background: ${({hoverBack})=>hoverBack || 'blue'};
  }
  
  :focus{
    animation: ${props=>props.animation ||'none'};
  }
  
`;


const Button = (props) => {
    return  <StyledButton {...props} children={props.children}/>
};

export default Button;