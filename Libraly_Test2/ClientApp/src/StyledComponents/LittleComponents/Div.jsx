import React from 'react';
import styled,{css} from "styled-components"


const StyledDiv=styled.div`
  grid-area: ${props=>props.gridArea ||"none"};
  display:${props=>props.display ||'flex'};
  border: ${props=>props.border || 'none'};
  vertical-align: top;
  align-items: center;
`


const Div = (props) => {
    return <StyledDiv {...props} children={props.children}/>
};

export default Div;