import React, { Fragment } from 'react';
import { Home } from 'react-feather';
import { Link } from 'react-router-dom'

const Breadcrumb = props => {
    const breadcrumb = props;
    return (
        <Fragment>
            <div className="container-fluid">
                <div className="page-header">
                    <div className="row">
                        <div className="col">
                            <div className="page-header-left">
                                {/* <Link to={`${process.env.PUBLIC_URL}/`}>
                                    <Home />
                                </Link>
                                <h3>/</h3> */}
                                <h3>{breadcrumb.title}</h3>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Fragment>
    )
}

export default Breadcrumb
