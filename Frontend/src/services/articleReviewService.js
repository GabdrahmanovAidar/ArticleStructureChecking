import { apiUrl } from "../connectionStrings";
import { handlers } from "../helpers/hadlers";
import { axios } from "axios";

export const articleReviewService = {
    get,
    getByArticleId,
    create,
    check
};

export function get(id) {
    const requestOptions = {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('token'),
            'Content-Type': 'application/json'
        }
    };
    return fetch(apiUrl + `api/articleReview/get/` + id, requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}

export function getByArticleId(articleId) {
    const requestOptions = {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('token'),
            'Content-Type': 'application/json'
        }
    };
    return fetch(apiUrl + `api/articleReview/getByArticleId?articleId=${articleId}`, requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}

export function create(message) {
    const requestOptions = {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('token')
        },
        body: message
    };
    return fetch(apiUrl + "api/articleReview/create", requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}

export function check(message) {
    const requestOptions = {
        method: 'POST',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('token'),
            'Content-Type': 'application/json'
        },
        body: message
    };
    return fetch(apiUrl + "api/articleReview/check", requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}