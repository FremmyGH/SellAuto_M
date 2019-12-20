import React, { Component } from 'react';
import './css/main.css';
import { Col, Alert} from 'reactstrap';
import { LinkContainer } from 'react-router-bootstrap';

export class OptionsProfile extends Component {
    constructor(props) {
        super(props);
        this.state = { currentProfile: [], loading: true, danger: ""};
        this.FuncSave = this.FuncSave.bind(this);
    }
    componentDidMount() {
        this.OptionsData();
    }
    renderOptions() {
        return (
            <Col sm={12} >
                <h2 className="col-sm-offset-1 margin-top-20">Настройки профиля</h2>
                <div className="col-sm-offset-1 border-yellow margin-bottom-60 width-header"></div>
                <Col sm={{size:6, offset:3}}  className="border border-r-form">
                    <form onSubmit={this.FuncSave} className="col-sm-12">
                        <h3 className="margin-top-10">Персональные данные</h3>
                        <div className="border-yellow margin-bottom-20  width-main"></div>
                        <p>ФИО</p>
                        <input className="text-indent bgc-gray width-input margin-bottom-20 border-r-inp" name="fio"
                            defaultValue={this.state.currentProfile.fio} />
                        <p>Введите старый пароль</p>
                        <input type="password" className="text-indent bgc-gray width-input margin-bottom-20 border-r-inp" name="oldPassword" />
                        <p>Введите новый пароль</p>
                        <input type="password" className="text-indent bgc-gray width-input margin-bottom-20 border-r-inp" name="password" />
                        <button type="submit" className="login100-form-btn margin-bottom-20">Сохранить</button>
                        <LinkContainer to={'/profile'} className="login100-form-btn margin-bottom-20 color-black">
                            <p className="color-white bold cursor-p">Назад к профилю</p>
                        </LinkContainer>
                    </form>

                </Col>
            </Col>
        )
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderOptions(this.state.currentProfile);
            if(this.state.danger !== ""){
                return (
                    <div className="col-sm-12">
                        <Alert color="danger">
                            {this.state.danger}
                        </Alert>
                        {contents}
                    </div>
                );
            }
            else{
                return (
                    <div className="col-sm-12">
                        {contents}
                    </div>
                );
            }




    }


    FuncSave(event) {
        event.preventDefault();
        var id = this.state.currentProfile.idUser
        if (event.target.elements.oldPassword.value === this.state.currentProfile.password) {

            fetch('api/Users/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    idUser: id,
                    login: this.state.currentProfile.login,
                    fio: event.target.elements.fio.value,
                    password: event.target.elements.password.value,
                    role: this.state.currentProfile.role,
                    userPhoto: this.state.currentProfile.userPhoto,
                })
            }).then(this.props.history.push("/profile"));
        }
        else if (event.target.elements.oldPassword.value !== this.state.currentProfile.password && event.target.elements.oldPassword.value === "") {
            fetch('api/Users/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    idUser: id,
                    login: this.state.currentProfile.login,
                    fio: event.target.elements.fio.value,
                    password: this.state.currentProfile.password,
                    role: this.state.currentProfile.role,
                    userPhoto: this.state.currentProfile.userPhoto,
                })
            }).then(this.props.history.push("/profile"));
        }
        else {
            this.setState({ danger: "Введен неверный старый пароль"});
            console.log(this.state.danger)
        }
    }
    async OptionsData() {
        //var Username = this.props.match.params["Username"];
        var login = sessionStorage.getItem('Username');
        const response = await fetch('api/Users/' + login);
        const data = await response.json();
        this.setState({ currentProfile: data, loading: false });
    }
}
