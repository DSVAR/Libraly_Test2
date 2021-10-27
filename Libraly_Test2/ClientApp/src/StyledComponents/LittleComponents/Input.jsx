import React from 'react';
import styled,{css} from 'styled-components'

const StyledInput=styled.input`
  background: ${props=> props.color || 'aqua'};
  text-align:center;
  border:green solid 0.5vh ;
  border-radius:2rem;
  margin:1vh auto;
  height: 30%;
  
  outline:0;
  outline-offset:0;
  :active{
    background: red;
    border: none;
    outline:none;

  }
  :focus{
    height: 50%z;
    background: orange; 
    border: 0;
    outline:none;
    
  }
  :hover{
    
    border-color: red;
    outline:none;
    
  }
`;



const Input = (props) => {
    return ( <StyledInput {...props} children={props.children}   />

    );
};

export default Input;