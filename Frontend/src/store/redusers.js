import {
    GET_TOKEN,
    GET_TOKEN_ERROR

} from "./actions";

const initialState = {
    tokenData: null,
    tokenErrorMessage: "",
};


export const reducers = (state = initialState, action) => {
    switch (action.type) {
        case GET_TOKEN:
            return {
                ...state,
                tokenData: action.payload

            };
            case GET_TOKEN_ERROR:
            return {
                ...state,
                tokenErrorMessage: action.payload === 400 ? "Неверный логин или пароль" : ""

            };
        default:
            return state;
    }
};
