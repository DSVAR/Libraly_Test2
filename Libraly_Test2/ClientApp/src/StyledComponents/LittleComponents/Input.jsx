import React from 'react';
import styled, {css, keyframes} from 'styled-components'
import Button from "./Button";

const Animation = keyframes`
  //from{
  //
  //}
  //to{
  //  
  //}
  0%, 100% {
    border-style: solid;
    border-color: red darkred aquamarine aqua;
    box-shadow: 0.3em -0.1em 1em red;
  }
  50% {
    border-style: solid;
    border-color: aqua aquamarine darkred red;
    box-shadow: -0.3em 0.1em 1em red;
  }
`

const StyledInput = styled.input`
  background: ${props => props.background || 'lightgray'};
  text-align: center;
  border: ${props => props.borderColor || 'green solid 0.4vh'};
  border-radius: 0rem;

  outline: 0;
  outline-offset: 0;
  position: relative;
  width: ${props => props.width || '4'};
  height: ${props => props.height || '3.5vh'};

  :active {
    outline: none;
  }

  :focus {
    //box-shadow: -0.8em 0.3em  1em lightgray;
    background: lightgray;
    //border: solid 0.3vh;
    outline: none;
   // animation: ${Animation} linear infinite 2s;
  }

  :hover {

    border-color: red;
    outline: none;

  }
`;

const StyledButton=styled.button`
  
  margin: ${props=>props.margin || 0};
  color: ${props=>props.color || 'blue'};
  background: ${props=>props.background ||'black'};
  width: 4vw;
  height: 4.8vh;
  justify-content: center;
  border:${props => props.borderColor || 'green solid 0.4vh'};
  //border: none;
  
  &:hover{
    background: ${({hoverBack})=>hoverBack || 'blue'};    
  }

  :focus{
    animation: ${Animation} linear infinite 2s;
  }

`;



export const Searcher = (props) => {

    return (
        <>
            <StyledInput {...props} children={props.children}/>
            <StyledButton {...props} children={props.children}/>
        </>
    );
};


const Input = (props) => {
    return (<StyledInput {...props} children={props.children}/>

    );
};

export default Input;
