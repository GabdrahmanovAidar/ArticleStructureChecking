import React from 'react';
import CircularProgress from '@mui/material/CircularProgress';
import LinearProgress from '@mui/material/LinearProgress';
const CustomLoader = (props) => {

    return (<React.Fragment >
        <div className="text-center">
        <LinearProgress />
        </div>

    </React.Fragment >)
};

export default CustomLoader;
