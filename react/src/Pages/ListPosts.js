import React from 'react'
import {Row,Col} from 'react-bootstrap/'
import Header from '../components/Header/Header'
import Posts from '../components/Posts/Posts'
import './ListPost.css'
import API from '../API/API'

class ListPosts extends React.Component {

    constructor(props) {
        super(props);
        this.state = {data: []};
      }

    componentDidMount() {

        let user = localStorage.getItem("codUser");

        API.get("Posts?IdUser="+user+"&PageCurrent=0&QuantityItems=0")
            .then(rs => {
                this.setState({data:rs.data});
            });
    }

    render(){
        return ( 
            <React.Fragment>
                <Header> </Header> 
                <Row className = "rowLinePost" >
                    {
                    this.state.data.map(posts => 
                        <Col md = {3} key={posts.handle}>
                            <Posts like = {posts.like}
                                tittle = {posts.tittle}
                                content = {posts.text}
                                statusLike = {posts.isLiked}
                                handle = {posts.handle} >
                            </Posts> 
                        </Col> 
                        )
                    }
                   
                </Row> 
            </React.Fragment>
        )
    }   
}

export default ListPosts;