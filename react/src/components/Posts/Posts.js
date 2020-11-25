import React , {useState, useEffect} from 'react'
import {Card , Button , Badge} from 'react-bootstrap/'
import API from '../../API/API'
import {useContextPosts} from '../../Context/PostsContext'

export default function Posts(props){
    const [text , setText] = useState("Like")
    const [statusButton , setStatusButton] = useState("light")
    const [countLike , serCountLike] = useState(props.like)
    const [statusLike,setStatusLike] = useState(props.statusLike)
    const {isAuthenticate , setIsAuthenticate} = useContextPosts();

    const addLike = (handle) => {
        debugger;
        console.log(isAuthenticate)
        if(statusLike === false){
            const data = {"IdPost":handle , "IdUser": 1};
            alterStatus(); 
            API.put("LikePost",data);                       
        }       
    }

    const alterStatus = () =>{
        console.log("adas")
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
            <Card style={{ width: '18rem' }}>
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

