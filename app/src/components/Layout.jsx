import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import '../index.css';

export default (props ) => (
    <React.Fragment>
        <NavMenu />
        <Container>
            {props.children}
        </Container>
    </React.Fragment>
);