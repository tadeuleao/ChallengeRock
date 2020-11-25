import React from 'react';
import { BrowserRouter , Route, Switch } from 'react-router-dom';
import NotFound from '../Pages/NotFound'
import ListPosts from '../Pages/ListPosts'
import Login from '../Pages/Login'
import Provider from '../Context/PostsContext'

export default function Routes() {
    return (
        <Provider>
            <BrowserRouter>
                <Switch>
                    <Route exact path="/listPosts" component={ListPosts}  />
                    <Route exact path="/" component={Login}   />
                    <Route component={NotFound} />
                </Switch>
            </BrowserRouter>
        </Provider>
    )
}