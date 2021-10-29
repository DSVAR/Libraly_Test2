import React from 'react';
import styled, {css, keyframes} from 'styled-components'

const Animation=keyframes`
  //from{
  //
  //}
  //to{
  //  
  //}
  0%,100%{
    border-style: solid;
    border-color: red darkred aquamarine aqua;
    box-shadow: 0.3em -0.1em 1em red;
  }
  50%{
    border-style: solid;
    border-color: aqua aquamarine darkred red;
    box-shadow: -0.3em 0.1em 1em red;    
  }
`

const StyledInput = styled.input`
  background: ${props => props.background || 'lightgray'};
  text-align: center;
  border: solid 0.4vh ${props => props.borderColor || 'green'};
  border-radius: 2rem;
  margin: 1vh auto;
  outline: 0;
  outline-offset: 0;
  position: relative;
  width: 90%;  
  :active {
    outline: none;    
  }

  :focus {
    //box-shadow: -0.8em 0.3em  1em lightgray;
    background: lightgray;
    //border: solid 0.3vh;
    outline: none;
    animation: ${Animation} linear infinite 2s;
  }

  :hover {
  
    border-color: red;
    outline: none;

  }
`;


const Input = (props) => {
    return (<StyledInput {...props} children={props.children}/>

    );
};

export default Input;