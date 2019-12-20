import React, {Component} from 'react';
import './fonts/font-awesome-4.7.0/css/font-awesome.min.css';
import './vendor/animate/animate.css';
import './vendor/css-hamburgers/hamburgers.min.css';
import './vendor/animsition/css/animsition.min.css';
import './vendor/select2/select2.min.css';
import './vendor/daterangepicker/daterangepicker.css';
import './css/util.css';
import './css/main.css';
import './NavMenu.css';
import {Alert} from 'reactstrap';

export class Login extends Component {
    displayName = Login.name;

    constructor(props) {
        super(props);

        this.state = {
            login: "",
            password: "",
            tokenKey: "",
            danger: "",
            check: ""
        };
        console.log(sessionStorage.getItem('token'));
        this.onSubmit = this.onSubmit.bind(this);
        this.onLoginChange = this.onLoginChange.bind(this);
        this.onPasswordChange = this.onPasswordChange.bind(this);
    }

    onLoginChange(e) {
        this.setState({login: e.target.value});
    }

    onPasswordChange(e) {
        this.setState({password: e.target.value});
    }

    onSubmit = (e) => {
        e.preventDefault();
        let data = JSON.stringify({
            "login": this.state.login,
            "password": this.state.password,
        });
            fetch('api/Account/Token', {
                method: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: data,
            })
                .then(response => response.json())
                .then(data => {
                    sessionStorage.setItem('Token', data.access_token);
                    sessionStorage.setItem('Username', data.username);
                    this.state.check = data.access_token;
                    if (sessionStorage.getItem('Token')) {
                        this.state.check = "Ok";
                        return window.location.href = "/";
                    }


                    // this.setState({ danger: "Введен неверный Логин/пароль"});
                });
            //if(this.state.check === undefined){
        console.log(this.state.check);
            //}
    };

    render() {
        return (
            <div className="limiter">
                <div className="container-login100">
                    <div className="wrap-login100">
                        <form className="login100-form validate-form p-l-55 p-r-55 p-t-178"
                              onSubmit={(e) => this.onSubmit(e)}>
                            <span className="login100-form-title"> Sign In </span>
                            <div className="wrap-input100 validate-input m-b-16"
                                 data-validate="Please enter username">
                                <input className="input100" type="text" name="login" value={this.state.login}
                                       onChange={this.onLoginChange}
                                       placeholder="Логин"/>
                                <span className="focus-input100"></span>
                            </div>
                            <div className="wrap-input100 validate-input" data-validate="Please enter password">
                                <input className="input100" type="password" name="password"
                                       value={this.state.password}
                                       onChange={this.onPasswordChange} placeholder="Пароль"/>
                                <span className="focus-input100"></span>
                            </div>
                            <div className="text-right p-t-13 p-b-23">
                            </div>
                            <div className="container-login100-form-btn">
                                <input type="submit" className="login100-form-btn" value="Войти"/>
                            </div>
                            <div className="text-right p-t-13 p-b-23"></div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}