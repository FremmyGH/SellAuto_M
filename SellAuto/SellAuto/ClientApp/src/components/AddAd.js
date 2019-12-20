import React, {Component} from 'react';
import './css/main.css';
import {Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Row, Col} from 'reactstrap';
import {LinkContainer} from 'react-router-bootstrap';
import Select from 'react-dropdown-select';
//import ReactExport from '../../../../node_modules/react-data-export';

export class AddAd extends Component {
    constructor(props) {
        super(props);
        this.state = {
            carMarks: [],
            selectedMark: [],
            carModels: [],
            selectedModel: [],
            steeringWheels: [],
            selectedWheel: [],
            typeCarBodies: [],
            selectedTypeCarBody: [],
            drives: [],
            selectedDrive: [],
            kpps: [],
            selectedKpp: [],
            colors: [],
            selectedColor: [],
            cities: [],
            selectedCity: [],
            statuses: [],
            selectedStatus: [],
            currentUser:[],
            loading: true
        };
        this.FuncSave = this.FuncSave.bind(this);
    //     this.CarModelsData = this.CarModelsData.bind(this);
    }

    componentDidMount() {
        this.CarMarksData();
        this.CarModelsData();
        this.CitiesData();
        this.ColorsData();
        this.DrivesData();
        this.KppsData();
        this.TypeCarBodiesData();
        this.StatusData();
        this.SteeringWheelsData();
        this.UserData();
    }

    render() {
        return (
            <Col sm={12}>
                <h2 className="col-sm-offset-1 margin-top-20">Добавить объявление</h2>
                <div className="col-sm-offset-1 border-yellow margin-bottom-60 width-header"></div>
                <Col sm={{size: 8, offset: 2}} className="border border-r-form">
                    <form onSubmit={this.FuncSave} className="col-sm-12">
                        <h3 className="margin-top-10">Данные автомобиля</h3>
                        <div className="border-yellow margin-bottom-20  width-main"></div>
                        <p className="margin-top-20">VIN или номер кузова *</p>
                        <input className="text-indent bgc-gray width-input border-r-inp" name="vin"/>
                        <p className="margin-top-20">Номер СТС (СОР)</p>
                        <input className="text-indent bgc-gray width-input border-r-inp" name="sts"/>
                        <p className="margin-top-20">Марка *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idMark"}
                            options={this.state.carMarks}
                            onChange={value =>
                                this.state.selectedMark = value
                            }
                        />
                        {/*<input className="text-indent bgc-gray width-input margin-bottom-20 border-r-inp" name="carMark" />*/}
                        <p className="margin-top-20">Модель *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idModel"}
                            options={this.state.carModels}
                            onChange={value =>
                                this.state.selectedModel = value
                            }
                        />
                        <p className="margin-top-20">Руль *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idSteeringWheel"}
                            options={this.state.steeringWheels}
                            onChange={value =>
                                this.state.selectedWheel = value
                            }
                        />
                        <p className="margin-top-20">Год выпуска</p>
                        <input className="text-indent bgc-gray width-input border-r-inp" name="yearPublish"/>
                        <p className="margin-top-20">Тип кузова *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idTypeCarBody"}
                            options={this.state.typeCarBodies}
                            onChange={value =>
                                this.state.selectedTypeCarBody = value
                            }
                        />
                        <p className="margin-top-20">Привод *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idDrive"}
                            options={this.state.drives}
                            onChange={value =>
                                this.state.selectedDrive = value
                            }
                        />
                        <p className="margin-top-20">КПП *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idKpp"}
                            options={this.state.kpps}
                            onChange={value =>
                                this.state.selectedKpp = value
                            }
                        />
                        <p className="margin-top-20">Объем</p>
                        <input className="text-indent bgc-gray width-input border-r-inp" name="volume"/>
                        <p className="margin-top-20">Мощность</p>
                        <input className="text-indent bgc-gray width-input border-r-inp" name="power"/>
                        <p className="margin-top-20">Цвет *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idColor"}
                            options={this.state.colors}
                            onChange={value =>
                                this.state.selectedColor = value
                            }
                        />
                        <p className="margin-top-20">Статус*</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idStatus"}
                            options={this.state.statuses}
                            onChange={value =>
                                this.state.selectedStatus = value
                            }
                        />
                        <p className="margin-top-20">Описание</p>
                        <textarea className="text-indent bgc-gray width-input " name="description"/>
                        <p className="margin-top-20">Цена</p>
                        <input className="text-indent bgc-gray width-input border-r-inp" name="price"/>
                        <p className="margin-top-20">Город *</p>
                        {/*тут будет селект*/}
                        <Select
                            labelField="name"
                            valueField={"idCity"}
                            options={this.state.cities}
                            onChange={value =>
                                this.state.selectedCity = value
                            }
                        />
                        <p className="margin-top-20">Телефон</p>
                        <input className="text-indent bgc-gray width-input margin-bottom-20 border-r-inp" name="phone1"/>
                        <button type="submit" className="login100-form-btn margin-bottom-20">Добавить объявление
                        </button>
                        <LinkContainer to={'/profile'}
                                       className="login100-form-btn-second margin-bottom-20 color-black">
                            <p className="color-white bold cursor-p">К профилю</p>
                        </LinkContainer>
                        <LinkContainer to={'/'}
                                       className="login100-form-btn-second margin-bottom-20 color-black bgc-darkgray">
                            <p className="color-white bold cursor-p">На главную</p>
                        </LinkContainer>
                    </form>
                </Col>
            </Col>
        )
    }

    // render() {
    //     let contents = this.state.loading
    //         ? <p><em>Loading...</em></p>
    //         : this.renderOptions(this.state.addNewAd);
    //     return (
    //         <div className="col-sm-12">
    //             {contents}
    //         </div>
    //
    //     );
    // }

    // 0b7c9b2a-13a0-e5b4-2675-c02d0c9a286b
    FuncSave(event) {
        event.preventDefault();
        let data = JSON.stringify({
            vin: event.target.elements.vin.value,
            sts: event.target.elements.sts.value,
            carModelId:  this.state.selectedModel[0].idModel,
            statusId:  this.state.selectedStatus[0].idStatus,
            markId: this.state.selectedMark[0].idMark,
            steeringWheelId: this.state.selectedWheel[0].idSteeringWheel,
            yearPublish: event.target.elements.yearPublish.value,
            typeCarBodyId: this.state.selectedTypeCarBody[0].idTypeCarBody,
            driveId: this.state.selectedDrive[0].idDrive,
            kppId: this.state.selectedKpp[0].idKpp,
            volume: event.target.elements.volume.value,
            power: event.target.elements.power.value,
            colorID:this.state.selectedColor[0].idColor,
            description: event.target.description.value,
            price: event.target.price.value,
            cityId:  this.state.selectedCity[0].idCity,
            phone1: event.target.elements.phone1.value,
            userId:  this.state.currentUser.idUser
            });
        console.log(data);
        fetch('api/Ads', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: data
        }).then(this.props.history.push("/"));
    }

    async CarMarksData() {
        const response = await fetch('api/CarMarks');
        const data = await response.json();
        this.setState({carMarks: data});
        // const responseModel = await fetch('api/CarModels/' +  this.state.selectedMark);
        // const dataModel = await responseModel.json();
        // this.setState({carModels: dataModel});
    }

    async SteeringWheelsData() {
        const response = await fetch('api/SteeringWheels');
        const data = await response.json();
        this.setState({steeringWheels: data});
    }

    async CarModelsData() {
        const response = await fetch('api/CarModels');
        const data = await response.json();
        this.setState({ carModels: data});
    }
    // CarModelsData(event) {
    //     if (this.state.selectedMark !== null){
    //         const response = fetch('api/CarModels/' + this.state.selectedMark);
    //         const data = response.json();
    //         this.setState({ carModels: data});
    //     }
    // }
    async CitiesData() {
        const response = await fetch('api/Cities');
        const data = await response.json();
        this.setState({cities: data});
    }

    async ColorsData() {
        const response = await fetch('api/Colors');
        const data = await response.json();
        this.setState({colors: data});
    }

    async DrivesData() {
        const response = await fetch('api/Drives');
        const data = await response.json();
        this.setState({drives: data});
    }

    async KppsData() {
        const response = await fetch('api/Kpps');
        const data = await response.json();
        this.setState({kpps: data});
    }

    async StatusData() {
        const response = await fetch('api/Status');
        const data = await response.json();
        this.setState({statuses: data});
    }

    async TypeCarBodiesData() {
        const response = await fetch('api/TypeCarBodies');
        const data = await response.json();
        this.setState({typeCarBodies: data});
    }
    async UserData(){
        const response = await fetch('api/Users/'+sessionStorage.getItem('Username'));
        const data = await response.json();
        this.setState({currentUser: data});
    }


}