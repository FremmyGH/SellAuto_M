import React, { Component } from 'react';
import {Col} from 'reactstrap';
import './css/main.css';


export class Footer extends Component {
    render() {
        return (
            <Col sm={12} className="no-padding">
                <hr />
                <div className="col-sm-8 margin-bottom-60 padding-40">
                    <h6 className="color-gray">© 2019 SellAuto.ru
                        Разработка дизайна Fremmy, Реклама на сайте, Оферта (правила и условия), Техподдержка, Авто
                        авто.дром.ру: всё об автомобилях. Продажа автомобилей – частные объявления, автосалоны
                        авторынки.
                    </h6>
                </div>
            </Col>
        );
    }
}
