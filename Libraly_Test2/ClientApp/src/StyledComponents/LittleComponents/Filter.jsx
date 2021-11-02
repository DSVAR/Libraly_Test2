import React from 'react';
import styled,{css} from "styled-components";


const StyledOl=styled.ol`
    display: block;
  align-content: center;
  text-align: center;
  position: center;
  list-style-type: none;
  margin: 0;
  padding: 1vh 0;
  li{
    margin: 0.5vh auto;
    background: red;
    display:block;
  }
`


const Filter = (props) => {
    return (<StyledOl {...props} children={props.children} />

    );
};

export default Filter;