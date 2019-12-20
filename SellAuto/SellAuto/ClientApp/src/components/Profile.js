import React, {Component} from 'react';
import './css/main.css';
import {Link} from 'react-router-dom';
import {Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Row, Col} from 'reactstrap';
import {LinkContainer} from 'react-router-bootstrap';
import ReactExport from "react-data-export";

const ExcelFile = ReactExport.ExcelFile;
const ExcelSheet = ReactExport.ExcelFile.ExcelSheet;
const ExcelColumn = ReactExport.ExcelFile.ExcelColumn;

export class Profile extends Component {
    constructor(props) {
        super(props);
        this.state = {currentProfile: [], loading: true, Ads: [], CurrentAd:[]};
        //console.log(this.HttpContext.Current.User.Identity.GetUserId());
        //fetch('api/Ads/GetAd')
        //    .then(response => response.json())
        //    .then(data => {
        //        this.setState({ adList: data, loading: false });
        //    });
    }

    componentDidMount() {
        this.ProfileData();
    }



    // renderAd() {
    //     return (
    //         <div className="col-sm-12">
    //             <h2 >Продажа авто - Личный кабинет</h2>
    //             <div className="col-sm-8 col-sm-offset-2 border">
    //                 <img width="350" src={photo}/>
    //             </div>
    //             {/*<div className="col-sm-12">*/}
    //                 {/*<h1 className="margin-top-20">{this.state.currentAd.mark.name}  {this.state.currentAd.carModel.name},*/}
    //                     {/*{this.state.currentAd.yearPublish}</h1>*/}
    //             {/*</div>*/}
    //             {/*<div className="col-sm-7 margin-top-20">*/}
    //                 {/*<img width="600" src={this.state.currentAd.photoFile} />*/}
    //             {/*</div>*/}
    //             {/*<div className="col-sm-5">*/}
    //                 {/*<h2 className="margin-top-20 color-red">{this.state.currentAd.price} ₽</h2>*/}
    //
    //                 {/*<p className="margin-top-20">Двигатель: {this.state.currentAd.volume} л</p>*/}
    //                 {/*<p>Мощность: {this.state.currentAd.power} л.с.</p>*/}
    //                 {/*<p>Трансмиссия: {this.state.currentAd.kpp.name}</p>*/}
    //                 {/*<p>Привод: {this.state.currentAd.drive.name}</p>*/}
    //                 {/*<p>Тип кузова: {this.state.currentAd.typeCarBody.name}</p>*/}
    //                 {/*<p>Цвет: {this.state.currentAd.color.name}</p>*/}
    //                 {/*<p>VIN: {this.state.currentAd.vin}</p>*/}
    //                 {/*<p>Дополнительно: {this.state.currentAd.description}</p>*/}
    //
    //                 {/*<p className="margin-top-40">Город: {this.state.currentAd.city.name} </p>*/}
    //                 {/*<p>Телефон: {this.state.currentAd.phone1}</p>*/}
    //             {/*</div>*/}
    //         </div>
    //         //<div>
    //         //    <Main />
    //         //    <div>
    //         //        <form onSubmit={this.FuncSave}>
    //         //            <input name="idBook" type="hidden" value={this.state.book.idBook} />
    //         //            <p />
    //         //            <input name="publisherId" defaultValue={this.state.book.publisherId} />
    //         //            <p />
    //
    //
    //         //            <p />
    //         //            <input name="name" defaultValue={this.state.book.name} />
    //         //            <p />
    //         //            <input name="year" defaultValue={this.state.book.year} />
    //         //            <p />
    //         //            <input name="count" defaultValue={this.state.book.count} />
    //         //            <p />
    //         //            <button type="submit" >Сохранить</button>
    //         //            <button onClick={this.FuncCancel}>Отмена</button>
    //         //        </form>
    //         //    </div>
    //         //</div>
    //     )
    // }

    renderProfile() {
        const Export = () => {
            return (
                <ExcelFile filename={"ExportInExcel"} element={<button className="font text-or">Экспорт в Excel</button>}>
                    <ExcelSheet data={this.state.CurrentAd} name="Ads">
                        <ExcelColumn label="id объявления" value="idAd" />
                        <ExcelColumn label="Vin номер" value="vin" />
                        <ExcelColumn label="Марка" value="carMark" />
                        <ExcelColumn label="Модель" value="carModel" />
                        <ExcelColumn label="Положение руля" value="wheel" />
                        <ExcelColumn label="Год выпуска" value="yearP" />
                        <ExcelColumn label="Тип кузова" value="type_cb" />
                        <ExcelColumn label="Привод" value="drive" />
                        <ExcelColumn label="КПП" value="kpp" />
                        <ExcelColumn label="Объем (л)" value="volume" />
                        <ExcelColumn label="Мощность" value="power" />
                        <ExcelColumn label="Цвет" value="color" />
                        <ExcelColumn label="Описание" value="descript" />
                        <ExcelColumn label="Цена" value="price" />
                        <ExcelColumn label="Город" value="city" />
                        <ExcelColumn label="Телефон" value="phone" />
                        <ExcelColumn label="Пользователь" value="user" />
                    </ExcelSheet>
                </ExcelFile >
            );
        };
        return (<Col sm={12}>
                <Col sm={{size: 10, offset: 1}} className="margin-top-20 no-padding"><h2>Личный кабинет</h2></Col>
                <Col sm={{size: 2, offset: 1}} className="border-yellow margin-bottom-60 width-header"></Col>
                <Col sm={{size: 10, offset: 1}} className="border border-r-form">
                    <Row>
                        <Col sm={3}>
                            <img className="border-r" width="350" src={this.state.currentProfile.userPhoto}/>
                        </Col>
                        <Col sm={5} className="margin-top-20 no-padding">
                            <h2>{this.state.currentProfile.fio}</h2>
                            <div className="border-yellow margin-bottom-5 width-main"></div>
                            <NavItem>
                                <NavLink tag={Link} className="text-or no-padding" to="/options"><h6>Настроить профиль</h6></NavLink>
                            </NavItem>
                        </Col>
                        <Col sm={{size:3, offset:1}} className="margin-top-20">
                            <div className="margin-bottom-20">
                                <h4><Export/></h4>
                                {/*<a href="/profile" className="font text-or"><h4> Выгрузка в Excel</h4></a>*/}
                            </div>
                            <div><a href="/logout" className="font"><h4> Выйти</h4></a></div>
                        </Col>

                        <Col sm={12} className="margin-bottom-60">
                            <hr/>
                            <Row>
                                <Col sm={{size:4, offset:2}} className="margin-top-10">
                                    <a href="/myAds" className="font"><h4> Мои объявления</h4></a>
                                </Col>
                                <Col sm={4} className="margin-top-10">
                                    <a href="/addAd" className="font"><h4> Добавить объявление</h4></a>
                                </Col>
                            </Row>

                        </Col>
                    </Row>
                </Col>
            </Col>
        )
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderProfile(this.state.currentProfile);
        return (
            <Col sm={12} className="no-padding ">
                {contents}
            </Col>

        );
    }

    async ProfileData() {
        const responseAds = await fetch('api/Ads');
        const dataAds = await responseAds.json();
        this.setState({ Ads: dataAds, loading: false });

        this.state.Ads = this.state.Ads
            .forEach(Ad => this.state.CurrentAd
                .push({
                    idAd: Ad.idAd,
                    vin: Ad.vin,
                    sts: Ad.sts,
                    carMark: Ad.mark.name,
                    carModel: Ad.carModel.name,
                    wheel: Ad.steeringWheel.name,
                    yearP: Ad.yearPublish,
                    type_cb: Ad.typeCarBody.name,
                    drive: Ad.drive.name,
                    kpp: Ad.kpp.name,
                    volume: Ad.volume,
                    power: Ad.power,
                    color: Ad.color.name,
                    descript: Ad.description,
                    price: Ad.price,
                    city: Ad.city.name,
                    phone: Ad.phone1,
                    user: Ad.user.fio
                }));
        //var Username = this.props.match.params["Username"];
        // var idUser;
        // fetch('api/Ads/GetUserId')
        //     .then(response => response.json())
        //     .then(data => {
        //         data = idUser
        //     });
        // console.log(idUser);
        var Username = sessionStorage.getItem('Username');


        const response = await fetch('api/Users/' + Username);
        const data = await response.json();
        this.setState({currentProfile: data, loading: false});
    }
}
