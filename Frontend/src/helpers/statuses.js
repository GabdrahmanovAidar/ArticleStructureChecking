export const getArticleStatusText = (statusNum) => {
    switch (statusNum) {
        case 0:
            return "В ожидании"
        case 1:
            return "Ошибка"
        case 2:
            return "Успешно"
    }
}
export const getArticleStatusColor = (statusNum) => {
    switch (statusNum) {
        case 0:
            return "primary"
        case 2:
            return "success"
        case 1:
            return "danger"
    }
};