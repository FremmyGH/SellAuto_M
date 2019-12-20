import React, { Component } from 'react';
import { Link, Redirect } from 'react-router-dom';
export class Logout extends Component {


    constructor(props) {
        super(props);
        sessionStorage.removeItem('Token');
        sessionStorage.removeItem('Username');
    }
    render() {
        return <Redirect to='/login' />
    }
}