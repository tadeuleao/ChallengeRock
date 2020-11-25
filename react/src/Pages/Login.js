import React , {useState, useEffect} from 'react'
import Header from '../components/Header/Header'
import API from '../API/API'
import {Form, Button , Row , Col} from 'react-bootstrap'
import './Login.css'
import {useContextPosts} from '../Context/PostsContext'

export default function LoginPage(){

    const [alert , setAlert] = useState("");
    const {isAuthenticate , setIsAuthenticate} = useContextPosts();

    //FUNCTIONS
    const Auth = () => {
        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;
        
        if(Validate(username , password)){
            const data = JSON.stringify({"Login": username, "Password":password})
            
            API.post("Auth" , data).then(rs => {
                if(rs.data.success){
                    setIsAuthenticate(true);
                    window.location.href = window.location + "listPosts";
                }else {
                    setIsAuthenticate(false);
                }
            });
        }    
        debugger;
        console.log(isAuthenticate)   
    };

    const Validate = (username , password) => {
        if(username === "" || password === ""){
            setAlert("User Invalid")
            return false;
        }
        return true;
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
                            <Form.Label>Username</Form.Label>
                            <Form.Control type="text" placeholder="Enter username" id="username" />
                            <Form.Text className="text-muted">
                                We'll never share your <b>Username</b> with anyone else.
                            </Form.Text>
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Password" id="password" />
                            <Form.Text className="text-muted">
                                We'll never share your <b>Password</b> with anyone else.
                            </Form.Text>
                        </Form.Group>
                        <Button variant="primary" onClick={Auth}>
                            Log in
                        </Button>
                        
                    </Form>
                </Col>
            </Row>
        </React.Fragment>
        
    );
}