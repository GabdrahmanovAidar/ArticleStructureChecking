export const getDateFull = (date) => {
    const newDate = new Date(date);
    return (newDate.getDate() < 10 ? "0" + newDate.getDate() : newDate.getDate()) + "." +
        (newDate.getMonth() + 1) + "." + newDate.getFullYear() + " " +
        (newDate.getHours() < 10 ? "0" + newDate.getHours() : newDate.getHours()) + ":" +
        (newDate.getMinutes() < 10 ? "0" + newDate.getMinutes() : newDate.getMinutes())
};

export const getDateOnly = (date) => {
    const newDate = new Date(date);
    if (date) {
        return (newDate.getDate() < 10 ? "0" + newDate.getDate() : newDate.getDate()) + "." +
            (newDate.getMonth() + 1) + "." + newDate.getFullYear() + " "
    }else {
        return "-"
    }
};

export const defaultDate = '0001-01-01T00:00:00';