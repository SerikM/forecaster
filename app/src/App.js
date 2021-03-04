import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Dashboard from './components/Dashboard';
import Reports from './components/Reports';

import './index.css';

function App() {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route exact path='/dashboard' component={Dashboard} />
      <Route exact path='/reports' component={Reports} />
    </Layout>
  );
}

export default App;

