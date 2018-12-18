import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Pages.css';

export class Customers extends Component {
    displayName = Customers.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: 'http://localhost:64156/api/customers/',
            name: '',
            siret: '',
            phone: '',
            email: '',
            data: [{
                name: String,
                surname: String,
                dateOfBirth: String,
                phone: String,
                email: String
            }]
        };
    }

    handleChange(event) {
        const target = event.target;
        const value = target.type === "checkbox" ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    handleSubmit(event) {
        this.addCustomer();
        event.preventDefault();
    }

    handleClick = idCustomer => {
        const requestOptions = {
            method: 'DELETE'
        };

        fetch(this.state.targetUrl + idCustomer, requestOptions);

        window.location.reload();
    }

    componentDidMount() {
        fetch(this.state.targetUrl)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ data });
            });
    }

    addCustomer() {
        fetch(this.state.targetUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: this.state.name,
                siret: this.state.siret,
                phone: this.state.phone,
                email: this.state.email,
            })
        });
        window.location.reload();
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <h1>Clients</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de gestion des clients. D'ici vous pouvez ajouter, supprimer ou modifier des clients et accéder à la liste complête de ceux-ci.</p>
                <br />
                <table>
                    <tr>
                        <th>
                            Nom du client
                            </th>
                        <th>
                            Siret
                            </th>
                        <th>
                            Téléphone
                            </th>
                        <th>
                            Email
                            </th>
                        <th>
                            Modification
                            </th>
                        <th>
                            Suppression
                            </th>
                    </tr>
                    {data.map(item => {
                        return <tr key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.siret}</td>
                            <td>{item.phone}</td>
                            <td>{item.email}</td>
                            <td><Link to={{ pathname: '/update/customer', state: { currentItem: item } }}><button>Modifier</button></Link></td>
                            <td><button onClick={() => { this.handleClick(item.id) }}>Supprimer</button></td>
                        </tr>
                    }
                    )}
                </table>
                <br />

                <form className="form" onSubmit={this.handleSubmit}>
                    <div className="field">
                        <label>Nom de l'entreprise</label>
                        <div className="control">
                            <input
                                className="input"
                                type="text"
                                name="name"
                                value={this.state.name}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>Siret</label>
                        <div className="control">
                            <input
                                className="input"
                                type="number"
                                name="siret"
                                value={this.state.siret}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>Téléphone</label>
                        <div className="control">
                            <input
                                className="input"
                                type="tel"
                                name="phone"
                                value={this.state.phone}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>Email</label>
                        <div className="control">
                            <input
                                className="input"
                                type="email"
                                name="email"
                                value={this.state.email}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <div className="control">
                            <input
                                type="submit"
                                value="Ajouter un client"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
