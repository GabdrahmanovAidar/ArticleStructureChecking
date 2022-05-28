import { authService } from '../services/authService';

export const handlers = {
    userEditHandleResponse,
    handleResponse
};

const errorTitle = "invalid_grant";

const clearLocalStorage = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('refresh_token');
}

const initLocalStorage = (data) => {
    localStorage.setItem("token", data.access_token);
    localStorage.setItem("refresh_token", data.refresh_token);
}

const isError = (data) => {
    if (data === errorTitle) {
        return true;
    }
    return false;
}

export async function userEditHandleResponse(response) {
    return response.text().then(async text => {
        const data = text && JSON.parse(text);
        if ([401, 403].indexOf(response.status) !== -1) {
            await authService.refreshToken().then((data) => {
                if (isError(data.error)) {
                    clearLocalStorage();
                }
                else if (data) {
                    initLocalStorage(data);
                }
            }).catch(_ => {
                clearLocalStorage();
            });
            window.location.reload();
        }
        return data;
    });
}

export async function handleResponse(response) {
    return response.text().then(async text => {
        let isJson = IsJsonString(text);
        const data = (text && isJson) ? JSON.parse(text) : text;
        if (!response.ok) {
            if ([401, 403].indexOf(response.status) !== -1) {
                await authService.refreshToken().then((data) => {
                    if (isError(data.error)) {
                        clearLocalStorage();
                    }
                    else if (data) {
                        initLocalStorage(data);
                    }
                }).catch(_ => {
                    clearLocalStorage();
                });
                window.location.reload();
            }
        }
        return data;
    });
}

function IsJsonString(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}