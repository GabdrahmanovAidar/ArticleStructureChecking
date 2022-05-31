import React,{Fragment} from 'react';
// import RightSidebar from './common/right-sidebar';
// import ThemeCustomizer from './common/theme-customizer'
// import { ToastContainer } from 'react-toastify';
// import Loader from './common/loader';
import Sidebar from "./sidebar-component/sidebar";
import Footer from "./footer";
import {useHistory} from 'react-router-dom';
import Header from "./header/header";
import {AlignLeft, LogOut} from "react-feather";
import {Link} from "react-router-dom";
import {ReactComponent as Logo} from "../assets/images/logo/logo.svg";
import axios from "axios";

const AppProfile = (props: any) => {
    const history = useHistory();
    const Logout = () => {
        localStorage.removeItem('token');
        localStorage.removeItem('getUser');
        history.push(`${process.env.PUBLIC_URL}/login`)
    }
    let datas = []


    datas = JSON.parse(localStorage.getItem("getUser") as string)
  return (
      <Fragment>
        <div className="page-wrapper">
          <div className="page-body-wrapper">
              <div className="page-main-header open">
                <div className="main-header-right row">
                  <div className="mobile-sidebar d-block">
                      <div className="media-body text-right switch-sm">
                      </div>
                  </div>
                  <div className="main-header-left">
                      <div className="logo-wrapper">
                      </div>
                  </div>
                  <div className="nav-right col p-0">
                      <div className="flex-end">
                          <div onClick={Logout}>
                              <LogOut /> {"Выйти"}
                          </div>
                      </div>
                  </div>
              </div>
              </div>
            <div className="page-body">
              { props.children }
            </div>
            <Footer />
          </div>
        </div>
      </Fragment>
  );
}


export default AppProfile;
