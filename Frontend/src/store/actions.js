export const GET_TOKEN = 'GET_TOKEN';
export const GET_TOKEN_ERROR = 'GET_TOKEN_ERROR';


export const getToken = (payload) => {
    return {
        type: GET_TOKEN,
        payload
    }
};

export const getTokenError = (payload) => {
    return {
        type: GET_TOKEN_ERROR,
        payload
    }
};
