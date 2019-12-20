import React, {Component} from 'react';
import {Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink} from 'reactstrap';
import {Link} from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        if (sessionStorage.getItem('Token')) {
            return (
                <header className="bgc-lightgray">
                    <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
                            light>
                        <Container>
                            <NavbarBrand tag={Link} to="/">SellAuto</NavbarBrand>
                            <NavbarToggler onClick={this.toggleNavbar} className="mr-2"/>
                            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed}
                                      navbar>
                                <ul className="navbar-nav flex-grow">
                                    <NavItem className="float-left">
                                        <NavLink tag={Link} className="text-or" to="/AddAd">Добавить объявление</NavLink>
                                    </NavItem>
                                    <NavItem className="float-right">
                                        <NavLink tag={Link} className="text-or" to="/profile">Профиль</NavLink>
                                    </NavItem>
                                    <NavItem className="float-right">
                                        <NavLink tag={Link} className="text-or" to="/logout">Выйти</NavLink>
                                    </NavItem>
                                </ul>
                            </Collapse>
                        </Container>
                    </Navbar>
                </header>
            );
        }
        else{
            return (
                <header className="bgc-lightgray">
                    <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
                            light>
                        <Container>
                            <NavbarBrand tag={Link} to="/">SellAuto</NavbarBrand>
                            <NavbarToggler onClick={this.toggleNavbar} className="mr-2"/>
                            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed}
                                      navbar>
                                <ul className="navbar-nav flex-grow">
                                    <NavItem className="float-right">
                                        <NavLink tag={Link} className="text-or" to="/login">Войти</NavLink>
                                    </NavItem>
                                </ul>
                            </Collapse>
                        </Container>
                    </Navbar>
                </header>
            );
        }
    }
}
