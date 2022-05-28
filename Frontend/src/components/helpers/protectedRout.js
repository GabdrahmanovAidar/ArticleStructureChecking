import { Redirect } from 'react-router';
import jwt_decode from "jwt-decode";

const ProtectedRoute = ({
    allowedRoles = [],
    children,
}) => {
    const token = localStorage.getItem("token");
    var decoded = jwt_decode(token);
    return children;
};

export default ProtectedRoute;