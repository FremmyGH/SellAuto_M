import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Footer } from './Footer';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <NavMenu />
        <Container>
            <Row>
                <Col sm={12}>
                    {this.props.children}
                </Col>
                <Col sm={12}>
                    <Footer />
                </Col>
            </Row>
        </Container>
      </div>
    );
  }
}
