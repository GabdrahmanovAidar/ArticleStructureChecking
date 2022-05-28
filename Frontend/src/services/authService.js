import { apiUrl } from "../connectionStrings";
import { handlers } from "../helpers/hadlers";

export const authService = {
    refreshToken
};

export function refreshToken() {
    const formData = new URLSearchParams();
    formData.append('client_id', 'swagger_ui_client_id');
    formData.append('client_secret', 'swagger_ui_client_secret');
    formData.append('scope', 'zamme offline_access');
    formData.append('grant_type', 'refresh_token');
    formData.append('refresh_token', localStorage.getItem('refresh_token'));

    const requestOptions = {
        method: 'post',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: formData.toString()
    };
    return fetch(apiUrl + 'identity/Token', requestOptions)
        .then(handlers.handleResponse)
        .then(_ => {
            return _;
        });
}