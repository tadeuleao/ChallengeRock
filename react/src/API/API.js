import Axios from 'axios'

const readForJson = respostaHttp => {
    return respostaHttp.json();
}

const interpretAnswer = json => {
    if (json.success) {
        return json.data;
    }

    return Promise.reject(json.errors);
}

class API {

    //POST
    static post(resource, data) {

        const config = {
            headers: {
                "Content-Type": "application/json-patch+json"
            }
        }
        return Axios.post(process.env.REACT_APP_POSTS + resource, data, config);
    }

    //PUT
    static put(resource, data) {
        console.log(data)
        return fetch(process.env.REACT_APP_POSTS + resource, {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json-patch+json'
                },
                method: "PUT",
                body: JSON.stringify(data)
            })
            .then(readForJson)
            .then(interpretAnswer);
    }

    //DELETE
    static delete(resource) {
        return fetch(process.env.REACT_APP_POSTS + resource, {
                method: "DELETE"
            })
            .then(readForJson)
            .then(interpretAnswer)
    }

    //GET
    static get(resource) {

        const config = {
            headers: {
                "Content-Type": "application/json-patch+json"
            }
        }

        return Axios.get(process.env.REACT_APP_POSTS + resource, config);
    }
}

export default API;