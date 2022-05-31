import React, {useState, Fragment, useEffect} from 'react';
// import logo from '../assets/images/endless-logo.png';
// import Language from './language';
// import UserMenu from './userMenu';
// import Notification from './notification';
// import SearchHeader from './searchHeader';
import {Link, useHistory} from 'react-router-dom';
import {
    AlignLeft, Bell, LogOut, Maximize, MessageCircle, MoreHorizontal
    // Maximize, Bell, MessageCircle, MoreHorizontal
} from 'react-feather';
// import {EN} from '../constant'
import logo from "../../assets/images/logo/logo.png";
import UserMenu from "./userMenu";

const Header = () => {
    const [sidebar, setSidebar] = useState(true);
    const history = useHistory();
    // const [rightSidebar, setRightSidebar] = useState(true);
    const [headerbar, setHeaderbar] = useState(true);
    const Logout = () => {
        localStorage.removeItem('token');
        history.push(`${process.env.PUBLIC_URL}/login`)
    }
    const openCloseSidebar = () => {
        setSidebar(!sidebar)

        // if (sidebar) {
        //     setSidebar(!sidebar)
        //     // document.querySelector(".page-main-header").classList.remove('open');
        //     // document.querySelector(".page-sidebar").classList.remove('open');
        //
        // } else {
        //     setSidebar(!sidebar)
        //     // document.querySelector(".page-main-header").classList.add('open');
        //     // document.querySelector(".page-sidebar").classList.add('open');
        // }
    }
    const mql = window.matchMedia("(min-width: 600px)");

    useEffect(()=> {
        if (!mql.matches) {
            setSidebar(false)
        }
    },[])

    useEffect(()=> {
        if (sidebar) {
            document.querySelector(".page-main-header").classList.remove('open');
            document.querySelector(".page-sidebar").classList.remove('open');
        } else {
            document.querySelector(".page-main-header").classList.add('open');
            document.querySelector(".page-sidebar").classList.add('open');
        }
    },[sidebar])




    // function showRightSidebar() {
    //   if (rightSidebar) {
    //     setRightSidebar(!rightSidebar)
    //     document.querySelector(".right-sidebar").classList.add('show');
    //   } else {
    //     setRightSidebar(!rightSidebar)
    //     document.querySelector(".right-sidebar").classList.remove('show');
    //   }
    // }

    //full screen function
    // function goFull() {
    //   if ((document.fullScreenElement && document.fullScreenElement !== null) ||
    //     (!document.mozFullScreen && !document.webkitIsFullScreen)) {
    //     if (document.documentElement.requestFullScreen) {
    //       document.documentElement.requestFullScreen();
    //     } else if (document.documentElement.mozRequestFullScreen) {
    //       document.documentElement.mozRequestFullScreen();
    //     } else if (document.documentElement.webkitRequestFullScreen) {
    //       document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);
    //     }
    //   } else {
    //     if (document.cancelFullScreen) {
    //       document.cancelFullScreen();
    //     } else if (document.mozCancelFullScreen) {
    //       document.mozCancelFullScreen();
    //     } else if (document.webkitCancelFullScreen) {
    //       document.webkitCancelFullScreen();
    //     }
    //   }
    // }

    return (
        <Fragment>
            <div className="page-main-header open">
                <div className="main-header-right row">
                    <div className="mobile-sidebar d-block">
                        <div className="media-body text-right switch-sm">
                            <label className="switch">
                                <a onClick={() => openCloseSidebar()}>
                                    <AlignLeft/>
                                </a>
                            </label>
                        </div>
                    </div>
                    <div className="main-header-left d-lg-none">
                        <div className="logo-wrapper">
                            <Link to={`${process.env.PUBLIC_URL}/`}>
                                {<img className="img-fluid" style={{width: 150}} src={logo} alt="" />}
                            </Link>
                        </div>
                    </div>
                    <div className="nav-right col p-0">
                        {/*<ul className={`nav-menus ${headerbar ? '' : 'open'}`}>*/}
                        {/*    /!*<li/>*!/*/}
                        {/*    /!*<li/>*!/*/}
                        {/*    /!*<li/>*!/*/}
                        {/*    /!*<li/>*!/*/}
                        {/*    /!*<UserMenu />*!/*/}
                        {/*</ul>*/}
                        <label>
                            <a className="flex-end" onClick={Logout}><LogOut /> {"Выйти"}</a>
                        </label>
                        {/*<div className="d-lg-none mobile-toggle pull-right" onClick={() => setHeaderbar(!headerbar)}><MoreHorizontal/></div>*/}
                    </div>
                </div>
            </div>
        </Fragment>
    )
};
export default Header;
