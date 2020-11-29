import React , { useState , createContext, useContext} from 'react'

const PostsContext = createContext();

export default function PostsProvider({children}){
    const [isAuthenticate , setIsAuthenticate] = useState(false);
    const [teste , setTeste] = useState("Tadeu");

    return(
        <PostsContext.Provider 
            value={{isAuthenticate , setIsAuthenticate}}>
            {children}
        </PostsContext.Provider>
    );
}

export function useContextPosts(){
    const context = useContext(PostsContext);
    const {isAuthenticate , setIsAuthenticate} = context;
    return {isAuthenticate , setIsAuthenticate};
}