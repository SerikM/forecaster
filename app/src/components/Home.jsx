import * as React from 'react';
import '../index.css';
import httpClient from '../httpClient';
import Spinner from './Spinner';
const config = require('../config.json');


class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoading: false,
            projects: [],
            total: 0,
            month: { date: '01.2020', name: 'January' },
            errors: false
        }

        this.ensureDataFetched = this.ensureDataFetched.bind(this);
        this.setLoading = this.setLoading.bind(this);
    }


    setLoading(isLoading) {
        this.setState({ isLoading });
    }

    componentDidMount() {
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        this.setLoading(true);
        const client = new httpClient();
        return client.get(`${config.aws.api.url}${config.aws.api.projects}?date=${this.state.month.date}`, { 'x-api-key': config.aws.api.key })
            .then(response => {
                this.setLoading(false);
                if (response && response.data && response.status === 200) {
                    this.setState((state) => {
                        return { state: state.projects = response.data.projects, total: response.data.total };
                    });
                }
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


                        <div className="row row-header">
                            <div className="col-2">Project</div>
                            <div className="col-2 d-none d-sm-block">Client</div>
                            <div className="col-2 d-none d-sm-block">Status</div>
                            {/* <div className="col-2">Month</div> */}
                            <div className="col-2 d-none d-sm-block">Job No</div>
                            <div className="col-4">Revenue({this.state.month.date})</div>
                        </div>

                        {this.state.projects && this.state.projects.map((proj, i) =>
                            <div key={i} className="row align-items-center">

                                <div key={i + 'a'} className="col-2">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.Name
                                    }
                                </div>

                                <div key={i + 'b'} className="col-2 d-none d-sm-block">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.ClientName
                                    }
                                </div>

                                <div key={i + 'c'} className="col-2 d-none d-sm-block">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.Status
                                    }
                                </div>

                                {/* <div key={i + 'd'} className="col-2">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.Month
                                    }
                                </div> */}

                                <div key={i + 'e'} className="col-2 d-none d-sm-block">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.JobNo
                                    }
                                </div>

                                <div key={i + 'f'} className="col-4">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.Revenue
                                    }
                                </div>

                            </div>
                        )}
                    </React.Fragment>
                </div>
            </React.Fragment>
        )
    };
};
export default Home;