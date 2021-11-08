import {BooksApi} from "../Api/api";

const SET_BOOKS = 'SET_BOOKS';


const initialState = {
    books: []
}

const bookReducer = (state = initialState, action) => {
    switch (action.type) {
        case SET_BOOKS: {
            return {
                ...state,
                books: action.books
            }
        }


        default:
            return state;
    }
}

export const getBooker=() => async (dispatch) => {
    let response = BooksApi.getBooks();
    dispatch(setBooks(response))
}

export const setBooks = (books) => ({type: SET_BOOKS, books})

export default bookReducer;