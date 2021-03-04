import * as React from 'react';
import '../index.css';
import httpClient from '../httpClient';
import Spinner from './Spinner';
const config = require('../config.json');


class Reports extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            revenues: [],
            isLoading: false,
            total: 0,
            errors: false
        }

        this.ensureDataFetched = this.ensureDataFetched.bind(this);
        this.setLoading = this.setLoading.bind(this);
    }


    setLoading(isLoading) {
        this.setState({ isLoading });
    }

    componentDidMount() {
        this.ensureDataFetched()
            .then((revenues) => {
                this.setState({ revenues });
            });
    }

    ensureDataFetched() {
        this.setLoading(true);
        const client = new httpClient();
        return client.get(`${config.aws.api.url}${config.aws.api.path}`, { 'x-api-key': config.aws.api.key })
            .then(response => {
                this.setLoading(false);
                if (response && response.data && response.status === 200) {
                    return response.data;
                }
                else return null;
            })
            .catch((err) => {
                //TO:DO display error message here
                this.setLoading(false);
            });
    }





    render() {
        return (
            <React.Fragment>

                <div className="row">
                    <div onClick={() => window.location.reload()} className="col-3 refresh-cont">
                        <a className="refresh d-inline d-md-none d-lg-none" href="#" > Refresh</a>
                    </div>
                    <div className="total col-9">
                        {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                            this.state.total > 0 && <span>total monthly revenue <h2>{this.state.total}</h2></span>
                        }
                    </div>
                </div>


                <div className="main lower">
                    <React.Fragment>

                        {this.state.revenues && this.state.revenues.map((br, i) =>
                            <div key={i} className="col-3 col-sm-4 col-md-4">
                              
                                {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                   <span>single month revenue stats to be displayed here</span>
                                }
                                

                            </div>
                        )}
                    </React.Fragment>
                </div>


            </React.Fragment>
        )
    };
};
export default Reports;