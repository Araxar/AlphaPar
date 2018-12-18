import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Employees } from './components/Employees';
import { Customers } from './components/Customers';
import { ProductionChain } from './components/ProductionChain';
import { Plans } from './components/Plans';
import { Pieces } from './components/Pieces';
import { Commands } from './components/Commands';
import { ProductionChainUpdate } from './components/update/ProductionChainUpdate';
import { CustomerUpdate } from './components/update/CustomerUpdate';
import { PieceUpdate } from './components/update/PieceUpdate';
import { PlanUpdate } from './components/update/PlanUpdate';
import { CommandUpdate } from './components/update/CommandUpdatet';

export default class App extends Component {
    displayName = App.name

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/employees' component={Employees} />
                <Route path='/customers' component={Customers} />
                <Route path='/productionchain' component={ProductionChain} />
                <Route path='/plans' component={Plans} />
                <Route path='/pieces' component={Pieces} />
                <Route path='/commands' component={Commands} />
                <Route path='/update/productionChain' component={ProductionChainUpdate} />
                <Route path='/update/customer' component={CustomerUpdate} />
                <Route path='/update/piece' component={PieceUpdate} />
                <Route path='/update/plan' component={PlanUpdate} />
                <Route path='/update/command' component={CommandUpdate} />
            </Layout>
        );
    }
}
