import React, {Fragment} from 'react';

import DataTable from 'react-data-table-component';

const DataTableComponent = ({columns, data}) => {

    return (
        <Fragment>
                <div className="card">
                    <div className="card-body" style={{textAlign:"left"}}>
                        <DataTable
                            columns={columns}
                            data={data}
                            striped={true}
                            center={true}
                            noHeader={true}
                            dense={true}
                            responsive={true}
                        />
                    </div>
                </div>
        </Fragment>
    );
}
export default DataTableComponent;