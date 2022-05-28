import { useEffect, useReducer, useState } from 'react'

export function useSetState(initialState) {
    const [state, setState] = useReducer(
        (state, newState) => ({
            ...state,
            ...newState
        }),
        initialState
    )
    return [state, setState]
}

export function useDebounce(value, delay) {
    const [debouncedValue, setDebouncedValue] = useState(value);
    useEffect(
        () => {
            const handler = setTimeout(() => {
                setDebouncedValue(value);
            }, delay);

            return () => {
                clearTimeout(handler);
            };
        },
        [value, delay]
    );
    return debouncedValue;
}