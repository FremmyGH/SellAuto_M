import React, { Component } from 'react';
import './css/main.css';
import { Link } from 'react-router-dom';
import { Container, Row, Col } from 'reactstrap';
//import {Glyphicon, Nav, Navbar, NavItem} from 'react-bootstrap';
// import {LinkContainer} from 'react-router-bootstrap';


export class MyAds extends Component {
    constructor(props) {
        super(props);
        this.state = { adList: [], loading: true };
        //var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //console.log(userId)
        //
        //fetch('api/Ads/GetAd', {
        //    headers: {
        //        'Content-Type': 'application/json',
        //        "Authorization": "Bearer " + sessionStorage.getItem('Token')
        //    },
        //})
        //    .then(response => response.json())
        //    .then(data => {
        //        this.setState({ adList: data, loading: false });
        //    });
        fetch('api/Ads')
            .then(response => response.json())
            .then(data => {
                this.setState({ adList: data, loading: false });
            });
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderAdTable(this.state.adList);
        return (
            <Col sm={12} className="no-padding">
                <Col sm={6} className="no-padding"><h3> Главная</h3></Col>
                <Col sm={1} className="border-yellow margin-bottom-60 width-header"></Col>
                {contents}
                <a href="#" title="Вернуться к началу" className="top-button">Наверх</a>
                {/*<Col sm={12}>*/}
                {/*<Footer />*/}
                {/*</Col>*/}
            </Col>
        )
    }


    renderAdTable(adList) {
        return <Col sm={12} className="no-padding">
            {adList.map((ad) => {
                return <Link to={"/currentAd/" + ad.idAd} key={ad.IdAd}>
                    <Row>
                        <Col sm={4}>
                            <img width="350" src={ad.photoFile} />
                        </Col>
                        <Col sm={3} >
                            <h4>{ad.mark.name} {ad.carModel.name}, {ad.yearPublish} г.</h4>
                        </Col>
                        <Col sm={3}>
                            <p>{ad.volume} л. , ({ad.power} л.с.)</p>
                            <p>{ad.kpp.name}</p>
                            <p>{ad.drive.name}</p>
                        </Col>
                        <Col sm={2}>
                            <h3>{ad.price} Р</h3>
                            <p className="margin-top-20">{ad.city.name}</p>
                        </Col>
                        <Col sm={12} className="no-padding">
                            <hr />
                        </Col>
                    </Row>
                </Link>

            })}
        </Col>
        // return <Container>
        //     <Row>
        //         <div className="col-sm-12">
        //             {adList.map((ad) => {
        //                 return <Link to={"/currentAd/" + ad.idAd}>
        //                     <div key={ad.IdAd} className="col-sm-12 no-padding cursor-p">
        //                         <div className="col-sm-4">
        //                             <img width="350" src={ad.photoFile}/>
        //                         </div>
        //                         <div className="col-sm-3">
        //                             <h4>{ad.mark.name} {ad.carModel.name}, {ad.yearPublish} г.</h4>
        //                         </div>
        //                         <div className="col-sm-3">
        //                             <p>{ad.volume} л. , ({ad.power} л.с.)</p>
        //                             <p>{ad.kpp.name}</p>
        //                             <p>{ad.drive.name}</p>
        //                         </div>
        //                         <div className="col-sm-2">
        //                             <h3>{ad.price} Р</h3>
        //
        //                             <p className="margin-top-20">{ad.city.name}</p>
        //                         </div>
        //                         <div className="col-sm-12 no-padding">
        //                             <hr/>
        //                         </div>
        //                     </div>
        //                 </Link>
        //             })}
        //         </div>
        //     </Row>
        // </Container>
    }

    //
    // FuncGet(id) {
    //     this.props.history.push("/currentAd/" + id);
    // }
}
