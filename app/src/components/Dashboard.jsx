import * as React from 'react';
import '../index.css';
import httpClient from '../httpClient';
import Spinner from './Spinner';
const config = require('../config.json');


class Dashboard extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isLoading: false,
            projects: [],
            current: null,
            month: { date: '01.2020', name: 'January' },
            errors: false
        }

        this.ensureDataFetched = this.ensureDataFetched.bind(this);
        this.update = this.update.bind(this);
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
                        return { state: state.projects = response.data.projects };
                    });
                }
            })
            .catch((err) => {
                //TO:DO display error message here
                this.setLoading(false);
            });
    }


    update(project) {
        this.setLoading(true);
        const client = new httpClient();
        return client.post(`${config.aws.api.url}${config.aws.api.projects}`, project, { 'x-api-key': config.aws.api.key })
            .then(response => {
                this.setLoading(false);
                if (response && response.status === 200) {
                  return this.ensureDataFetched();
                }
            })
            .catch((err) => { this.setLoading(false); });
    }



    validate(value, target) {
        if (value && value.length > 20 || !value) {
            target.style.borderColor = "red";
            this.setState({ errors: true });
            return false;
        }
        else {
            this.setState({ errors: false });
            target.style.borderColor = "";
            return true;
        }
    }

    updateClient(target, projName, elId) {
        this.setState({ current: elId });
        let value = target.value;
        if (!this.validate(value, target)) return;
        const project = this.state.projects.find(p => p.Name === projName);
        project.ClientName = value;
        this.update(project);
    }

    updateStatus(target, projName, elId) {
        this.setState({ current: elId });
        let value = target.value;
        if (!this.validate(value, target)) return;
        const project = this.state.projects.find(p => p.Name === projName);
        project.Status = value;
        this.update(project);
    }


    updateJobNo(target, projName, elId) {
        this.setState({ current: elId });
        let value = target.value;
        if (!this.validate(value, target)) return;
        const project = this.state.projects.find(p => p.Name === projName);
        project.JobNo = value;
        this.update(project);
    }

    updateRevenue(target, projName, elId) {
        this.setState({ current: elId });
        let value = target.value;
        if (!this.validate(value, target)) return;
        const project = this.state.projects.find(p => p.Name === projName);
        project.Revenue = value;
        this.update(project);
    }

    render() {
        return (
            <React.Fragment>

                <div className="main lower">
                    <React.Fragment>

                       <div className="row row-header">
                            <div className="col-2">Project</div>
                            <div className="col-2 d-none d-sm-block">Client</div>
                            <div className="col-2 d-none d-sm-block">Status</div>
                            <div className="col-2 d-none d-sm-block">Job No</div>
                            <div className="col-4">Revenue({this.state.month.date})</div>
                        </div>

                        {this.state.projects && this.state.projects.map((proj, i) =>
                            <div key={i} className="row align-items-center">

                                <div key={`${i}${'a'}`} className="col-2">
                                    {this.state.isLoading ? <Spinner isLoading={this.state.isLoading} /> :
                                        proj.Name
                                    }
                                </div>

                                <div key={`${i}${'b'}`} className="col-2 d-none d-sm-block">
                                    <input key={`${i}${i}${'b'}`} disabled={this.state.errors && this.state.current !== `${i}${i}${'b'}`}
                                        onChange={(e) => this.updateClient(e.target, proj.Name, `${i}${i}${'b'}`)} defaultValue={proj.ClientName} />
                                </div>

                                <div key={`${i}${'c'}`} className="col-2 d-none d-sm-block">
                                    <input key={`${i}${i}${'c'}`} disabled={this.state.errors && this.state.current !== `${i}${i}${'c'}`}
                                        onChange={(e) => this.updateStatus(e.target, proj.Name, `${i}${i}${'c'}`)} defaultValue={proj.Status} />
                                </div>

                                <div key={`${i}${'d'}`} className="col-2 d-none d-sm-block">
                                    <input key={`${i}${i}${'d'}`} disabled={this.state.errors && this.state.current !== `${i}${i}${'d'}`}
                                        onChange={(e) => this.updateJobNo(e.target, proj.Name, `${i}${i}${'d'}`)} defaultValue={proj.JobNo} />
                                </div>

                                <div key={`${i}${'e'}`} className="col-4">
                                    <input key={`${i}${i}${'e'}`} disabled={this.state.errors && this.state.current !== `${i}${i}${'e'}`}
                                        onChange={(e) => this.updateRevenue(e.target, proj.Name, `${i}${i}${'e'}`)} defaultValue={proj.Revenue} />
                                </div>


                            </div>
                        )}
                    </React.Fragment>
                </div>
            </React.Fragment>
        )
    };
};
export default Dashboard;