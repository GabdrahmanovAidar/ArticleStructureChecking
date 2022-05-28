import React from 'react';
import { ReactComponent as LogoBig } from "../../assets/images/logo/logo-zamzam-big.svg";
import { withRouter } from "react-router";
import { Login, LOGIN, YourName, Password, RememberMe } from '../../constant';
import { getToken, getTokenError } from "../../store/actions";
import { useDispatch, useSelector } from "react-redux";
import axios from "axios";
import { apiUrl } from "../../connectionStrings"
import { authService } from '../../services/authService';
import { toast } from 'react-toastify';
import jwt_decode from "jwt-decode";

const Logins = ({ history }) => {
    const dispatch = useDispatch();
    const errorMessage = useSelector((state) => state.data.tokenErrorMessage);

    async function getDatasUser() {
        return await axios({
            method: 'get',
            url: apiUrl + "api/user/advertisingPartner/get",
            headers: {
                'Authorization': `Bearer ${localStorage.getItem("token")}`
            }
        })
            .then(async (res) => {
                // @ts-ignore
                await localStorage.setItem("getUser", JSON.stringify(res.data));
                // history.push(`${process.env.PUBLIC_URL}/dashboard`);
            })
    }

    const loginAuth = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: `grant_type=password&username=${formData.get("username")}&password=${formData.get("password")}&` +
                'client_secret=swagger_ui_client_secret&client_id=swagger_ui_client_id&scope=zamme offline_access'
        };

        return fetch(apiUrl + "identity/Token", requestOptions)
            .then(async (res) => {
                let result = await res.json()
                if (result.error) {
                    toast.error(<p>{result.error_description}</p>);
                    return;
                }
                await dispatch(getToken(result.access_token));
                await localStorage.setItem("token", result.access_token);
                await localStorage.setItem("refresh_token", result.refresh_token);
                window.location.href = `/articles`;
            })
            .catch((error) => {
                console.error(error);
            });
    }

    return (
        <div>
            <div className="page-wrapper">
                <div className="container-fluid p-0">
                    {/* <!-- login page start--> */}
                    <div className="authentication-main">
                        <div className="row">
                            <div className="col-md-12">
                                <div className="auth-innerright">
                                    <div className="authentication-box">
                                        <div className="text-center"><LogoBig /></div>
                                        <div className="card mt-4">
                                            <div className="card-body">
                                                <div className="text-center">
                                                    <h4>Вход</h4>
                                                </div>
                                                <div className="text-danger py-2">{errorMessage}</div>
                                                <form className="theme-form" onSubmit={(e) => loginAuth(e)}>
                                                    <div className="form-group">
                                                        <label className="col-form-label pt-0">Логин</label>
                                                        <input className="form-control" name="username" type="text"
                                                            required="" />
                                                    </div>
                                                    <div className="form-group">
                                                        <label className="col-form-label">Пароль</label>
                                                        <input className="form-control" name="password" type="password"
                                                            required="" />
                                                    </div>
                                                    <div className="checkbox p-0">
                                                        <input id="checkbox1" type="checkbox" />
                                                        <label htmlFor="checkbox1">Запомнить меня</label>
                                                    </div>
                                                    <div className="form-group form-row mt-3 mb-0">
                                                        <button className="btn btn-primary btn-block"
                                                            type="submit">Войти</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    {/* <!-- login page end--> */}
                </div>
            </div>
        </div>
    );
};

export default withRouter(Logins);
