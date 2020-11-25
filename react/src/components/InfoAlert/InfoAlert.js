import React from 'react'
import {Alert} from 'react-bootstrap'

export default function InfoAlert(props){

    return(
        <React.Fragment>
            <Alert variant="info">
                {props.text}
            </Alert>
        </React.Fragment>
    );
}