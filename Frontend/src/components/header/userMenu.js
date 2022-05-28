import React, { Fragment, useState, useEffect } from 'react';
import man from '../../assets/images/dashboard/user.png';
import { User, Mail, Lock, Settings, LogOut } from 'react-feather';
import { Link } from 'react-router-dom';
import { withRouter } from 'react-router';
import {EditProfile,Inbox,LockScreen} from '../../constant'

const UserMenu = ({ history }) => {

    // const [profile, setProfile] = useState('');
    // auth0 profile
    // const {logout} = useAuth0()
    // const authenticated = JSON.parse(localStorage.getItem("authenticated"))
    // const auth0_profile = JSON.parse(localStorage.getItem("auth0_profile"))

    // useEffect(() => {
    //     setProfile(localStorage.getItem('profileURL') || man);
    // }, []);

    const Logout = () => {
        localStorage.removeItem('token');
        history.push(`${process.env.PUBLIC_URL}/login`)
    }


    return (
        <Fragment>
            <li className="onhover-dropdown">
                <div className="media align-items-center">
                    <img className="align-self-center pull-right img-50 rounded-circle blur-up lazyloaded" src={man} alt="header-user" />
                    <div className="dotted-animation">
                        {/*<span className="animate-circle"/>*/}
                        {/*<span className="main-circle"/>*/}
                    </div>
                </div>
                <ul className="profile-dropdown onhover-show-div p-20 profile-dropdown-hover">
                    <li><Link to={`${process.env.PUBLIC_URL}/users/userEdit`}><User />{EditProfile}</Link></li>
                    {/*<li><Link to={`${process.env.PUBLIC_URL}/email-app/emailDefault`}><Mail />{Inbox}</Link></li>*/}
                    {/*<li><a href="#javascript"><Lock />{LockScreen}</a></li>*/}
                    {/*<li><a href="#javascript"><Settings />{"Settings"}</a></li>*/}
                    <li><a onClick={Logout}><LogOut /> {"Выйти"}</a></li>
                </ul>
            </li>
        </Fragment>
    );
};


export default withRouter(UserMenu);