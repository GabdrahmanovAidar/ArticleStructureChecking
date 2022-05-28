import { apiUrl } from "../connectionStrings";
import { handlers } from "../helpers/hadlers"

export const articleService = {
    getList,
    create
};

export function getList(pageNumber, pageSize) {
    const requestOptions = {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('token'),
            'Content-Type': 'application/json'
        }
    };
    return fetch(apiUrl + `api/article/getList`, requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}

export function create(message) {
    const requestOptions = {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('token'),
            'Content-Type': 'application/json'
        },
        body: message
    };
    return fetch(apiUrl + "api/article/create", requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}