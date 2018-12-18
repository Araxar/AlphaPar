import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/'}>AlphaParJS</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/'} exact>
              <NavItem>
                <Glyphicon glyph='home' /> Accueil
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/employees'}>
              <NavItem>
                <Glyphicon glyph='user' /> Employ&#233;s
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/customers'}>
              <NavItem>
                <Glyphicon glyph='briefcase' /> Clients
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/productionchain'}>
              <NavItem>
                <Glyphicon glyph='wrench' /> Chaine de production
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/plans'}>
              <NavItem>
                <Glyphicon glyph='list-alt' /> Plans
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/pieces'}>
              <NavItem>
                <Glyphicon glyph='tag' /> Pi&#232;ces
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/commands'}>
              <NavItem>
                <Glyphicon glyph='credit-card' /> Commandes
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
