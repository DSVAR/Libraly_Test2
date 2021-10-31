import React from 'react';
import styled,{css} from "styled-components"


const StyledDiv=styled.div`
  grid-area: ${props=>props.gridArea ||"none"};
  display:${props=>props.display ||'flex'};
  border: ${props=>props.border || 'none'};
  vertical-align: top;
  align-items: center;
  flex-direction: ${props=>props.flexDirection || "row"};
  margin:${props=> props.margin || "none" };
  max-width: ${props=> props.maxWidth || "none"};
  background: ${props=>props.background || "none" };
  justify-content: space-between;
`


const Div = (props) => {
    return <StyledDiv {...props} children={props.children}/>
};

export default Div;