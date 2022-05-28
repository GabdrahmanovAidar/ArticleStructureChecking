import jwt_decode from "jwt-decode";
import {
    Home,
    DollarSign,
    Users,
    Flag,
    UserCheck,
    BookOpen,
    AtSign,
    Book
} from 'react-feather';

export const MENUITEMS = () => {
    return MAINMENUITEMS;
}

const MAINMENUITEMS = [
    {
        title: 'Профиль', icon: Users, type: 'link', path: '/profile', active: false
    },
    {
        title: 'Документы', icon: Book, type: 'link', path: '/articles', active: false
    },
]