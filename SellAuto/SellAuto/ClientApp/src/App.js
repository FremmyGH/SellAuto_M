import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import {Home} from './components/Home';
import {Login} from './components/Login';
import {Logout} from './components/Logout';
import {Profile} from './components/Profile';
import {OptionsProfile} from './components/OptionsProfile';
import { AddAd } from './components/AddAd';
import { MyAds } from './components/MyAds';
import { CurrentAd } from './components/CurrentAd';
import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home}/>
                <Route path='/login' component={Login}/>
                <Route path='/logout' component={Logout}/>
                <Route path='/profile' component={Profile}/>
                <Route path='/options' component={OptionsProfile}/>
                <Route path='/addAd' component={AddAd} />
                <Route path='/currentAd/:idAd' component={CurrentAd} />
                <Route path='/myAds' component={MyAds} />
            </Layout>
        );
    }
}
