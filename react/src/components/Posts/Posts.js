import React , {useState, useEffect} from 'react'
import {Card , Button , Badge} from 'react-bootstrap/'
import API from '../../API/API'

export default function Posts(props){
    const [text , setText] = useState("Like")
    const [statusButton , setStatusButton] = useState("light")
    const [countLike , serCountLike] = useState(props.like)
    const [statusLike,setStatusLike] = useState(props.statusLike)
    const [user , setUser] = useState(localStorage.getItem("codUser"))
    
    const addLike = (handle) => {
        if(statusLike === false){
            console.log(user)
            const data = {"IdPost":handle , "IdUser": parseInt(user)};
            alterStatus(); 
            API.put("LikePost",data);                  
        }       
    }

    const alterStatus = () =>{
        setText("Liked");
        setStatusButton("primary");
        serCountLike(Number(countLike) +1);
        setStatusLike("true");
    }

    useEffect(() => {
        if(props.statusLike === true){
            setStatusButton("primary");
            setText("Liked");
            setStatusLike("true");
        }
    })
        

    return(
        <div>
            <Card style={{ width: '18rem' , margin: 'auto' , marginTop:'5px' }}>
                <Card.Body>
                    <Card.Title>{props.tittle}</Card.Title>
                    <Card.Text>
                    {props.content}
                    </Card.Text>
                    <Button variant={statusButton} onClick={() => addLike(props.handle)}> {text} <Badge variant="secondary">{countLike}</Badge></Button>
                </Card.Body>
            </Card>
        </div>
    )
} 

