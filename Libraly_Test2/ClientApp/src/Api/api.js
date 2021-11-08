import * as axios from 'axios';


let instance=axios.create({
    withCredentials: true,
    baseURL:'https://localhost:5001/'
})


export const BooksApi={
    getBooks(){
        return instance.get(`BookC/getBooks`).then(response=>{return response.data})
    }
}