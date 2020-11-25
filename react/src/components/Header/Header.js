import React from 'react'
import {Nav} from 'react-bootstrap'
import './Header.css'

export default function Headers(){

    return(
        <div>
            <Nav className="menu" defaultActiveKey="/home" as="ul">
                <Nav.Item as="li" className="menuItemLogo">
                    <Nav.Link href="/">POSTS APP</Nav.Link>
                </Nav.Item>
            </Nav>
        </div>
    );
}