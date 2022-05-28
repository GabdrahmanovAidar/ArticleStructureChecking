import React, { Fragment } from 'react';
// import RightSidebar from './common/right-sidebar';
// import ThemeCustomizer from './common/theme-customizer'
// import { ToastContainer } from 'react-toastify';
// import Loader from './common/loader';
import Sidebar from "./sidebar-component/sidebar";
import Footer from "./footer";
import Header from "./header/header";

const App = (props: any) => {
  return (
    <Fragment>
      <div className="page-wrapper">
        <div className="page-body-wrapper">
          <Header />
          <Sidebar />
          <div className="page-body">
            {props.children}
          </div>
          <div>
            <Footer />
          </div>
        </div>
      </div>
    </Fragment>
  );
}


export default App;
