import React, { Component } from 'react';
import './css/main.css';
import { Link } from 'react-router-dom';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Row, Col } from 'reactstrap';
import { LinkContainer } from 'react-router-bootstrap';

export class CurrentAd extends Component {
    constructor(props) {
        super(props);
        this.state = { currentAd: [], loading: true };
    }

    componentDidMount() {
        this.AdData();
    }

    renderAd() {
        return (
            <Col sm={12}>
                <Row>
                    <Col sm={12} className="col-sm-12">
                        <h1 className="margin-top-20">{this.state.currentAd.mark.name}  {this.state.currentAd.carModel.name},
                            {this.state.currentAd.yearPublish}</h1>
                    </Col>
                    <Col sm={7} className="margin-top-20">
                        <img width="500" src={this.state.currentAd.photoFile} />
                    </Col>
                    <Col sm={{size:3, offset:2}}>
                        <h2 className="margin-top-20 color-red">{this.state.currentAd.price} ₽</h2>
                        <p className="margin-top-20">Двигатель: {this.state.currentAd.volume} л</p>
                        <p>Мощность: {this.state.currentAd.power} л.с.</p>
                        <p>Трансмиссия: {this.state.currentAd.kpp.name}</p>
                        <p>Привод: {this.state.currentAd.drive.name}</p>
                        <p>Тип кузова: {this.state.currentAd.typeCarBody.name}</p>
                        <p>Цвет: {this.state.currentAd.color.name}</p>
                        <p>VIN: {this.state.currentAd.vin}</p>
                        <p>Дополнительно: {this.state.currentAd.description}</p>

                        <p className="margin-top-40">Город: {this.state.currentAd.city.name} </p>
                        <p>Телефон: {this.state.currentAd.phone1}</p>
                    </Col>
                </Row>
            </Col>
        )
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderAd(this.state.currentAd);
        return (
            <div className="col-sm-12">
                <div className="col-sm-12">
                    <LinkContainer to={'/'}>
                        <NavItem>
                            <h3> Назад </h3>
                        </NavItem>
                    </LinkContainer>
                </div>
                {contents}
            </div>
        );
    }
    async AdData() {
        var idAd = this.props.match.params["idAd"];
        console.log(idAd);
        const response = await fetch('api/Ads/' + idAd);
        const data = await response.json();
        this.setState({ currentAd: data, loading: false });
    }
}
