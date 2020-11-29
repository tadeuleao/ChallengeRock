import React , {useState, useEffect} from 'react'
import Header from '../components/Header/Header'
import API from '../API/API'
import {Form, Button , Row , Col} from 'react-bootstrap'
import './Login.css'

export default function LoginPage(){

    const [alert , setAlert] = useState("");
    
    //FUNCTIONS
    const Auth = () => {
        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;
        
        if(Validate(username , password)){
            const data = JSON.stringify({"Login": username, "Password":password})
            
            API.post("Auth" , data)
            .then(rs => {
                if(rs.data.success && rs.data.data.id > 0){
                    localStorage.setItem("codUser" , rs.data.data.id);
                    window.location.href = window.location + "listPosts";
                }else {
                    setIsAuthenticate(false);
                }
            });
        }    
    };

    const Validate = (username , password) => {
        if(username === "" || password === ""){
            setAlert("User Invalid")
            return false;
        }
        return true;
    }

    const ValidateAddNewUser = (username , password , name) => {
        if(username === "" || password === "" || name === ""){
            setAlert("User Invalid")
            return false;
        }
        return true;
    }

    const AddUser = () => {
        const name = document.getElementById("name").value;
        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;
        
        if(ValidateAddNewUser(username , password , name)){
            const data = {"Login": username, "Password":password , "Name": name};
            API.post("AddUser" , data)
            .then(rs => {
                console.log(rs)
                console.log(rs.data.data.id > 0)
                if(rs.data.success && rs.data.data.id > 0){
                    localStorage.setItem("codUser" , rs.data.data.id);
                    window.location.href = window.location + "listPosts";
                } else {
                    setAlert(rs.data.message);
                }
            });
        }
    }

    return(
        <React.Fragment>
            <Header></Header>
            <br />
            <br />
            <br />
            <Row className="justify-content-md-center" >
                <Col md={4}>
                    <Form className="formLogin">
                        <Form.Group>
                            <p style={{ color: 'red' }}>{alert}</p>
                            <Form.Label>Name</Form.Label>
                            <Form.Control type="text" placeholder="Name For new users!" id="name" />
                            <Form.Text className="text-muted">
                                For new users!
                            </Form.Text>
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Username *</Form.Label>
                            <Form.Control type="text" placeholder="Enter username" id="username" />
                            <Form.Text className="text-muted">
                                We'll never share your <b>Username</b> with anyone else.
                            </Form.Text>
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Password *</Form.Label>
                            <Form.Control type="password" placeholder="Password" id="password" />
                            <Form.Text className="text-muted">
                                We'll never share your <b>Password</b> with anyone else.
                            </Form.Text>
                        </Form.Group>
                        <Button variant="primary" onClick={Auth}>
                            Log in
                        </Button>
                        <Button style={{ marginLeft : 10 }} variant="success" onClick={AddUser}>
                           + New User
                        </Button>
                        
                    </Form>
                </Col>
            </Row>
        </React.Fragment>
        
    );
}