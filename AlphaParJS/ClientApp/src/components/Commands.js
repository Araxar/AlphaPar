import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Pages.css';
import { ApiUrl } from './../App';

export class Commands extends Component {
    displayName = Commands.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: ApiUrl + 'commands/',
            idCustomer: '',
            idPlan: '',
            planAmount: 0,
            deliveryDate: '',
            data: [{
                customer: {
                    name: String,
                    siret: String,
                    phone: String,
                    email: String
                },
                plan: {
                    name: String,
                    time: String,
                    piece: {
                        name: String,
                        stock: Int32Array,
                        productionChain: {
                            name: String
                        }
                    }
                },
                planAmount: Int32Array,
                deliveryDate: String
            }]
        };
    }

    handleClick = idCommand => {
        const requestOptions = {
            method: 'DELETE'
        };

        fetch(this.state.targetUrl + idCommand, requestOptions);

        window.location.reload();
    }

    componentDidMount() {
        fetch(this.state.targetUrl)
            .then(response => response.json())
            .then(data => {
                this.setState({ data });
            });
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
        this.addCommand();
        event.preventDefault();
    }

    addCommand() {
        fetch(this.state.targetUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                idCustomer: this.state.idCustomer,
                idPlan: this.state.idPlan,
                planAmount: this.state.planAmount,
                deliveryDate: this.state.deliveryDate,
            })
        });
        window.location.reload();
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <h1>Commandes</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de gestion des commandes. D'ici vous pouvez ajouter, supprimer ou modifier des commandes et accéder à la liste complête de celles-ci.</p>
                <br />
                <table>
                    <tr>
                        <th>
                            Nom du client
                        </th>
                        <th>
                            Plan commandé
                        </th>
                        <th>
                            Co&#251;t du plan
                        </th>
                        <th>
                            Date de livraison
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
                            <td>{item.customer.name}</td>
                            <td>{item.plan.name}</td>
                            <td>{item.planAmount}</td>
                            <td>{item.deliveryDate}</td>
                            <td><Link to={{ pathname: '/update/command', state: { currentItem: item } }}><button>Modifier</button></Link></td>
                            <td><button onClick={() => { this.handleClick(item.id) }}>Supprimer</button></td>
                        </tr>
                    }
                    )}
                </table>
                <br />

                <form className="form" onSubmit={this.handleSubmit}>
                    <div className="field">
                        <label>Id du client</label>
                        <div className="control">
                            <input
                                className="input"
                                type="text"
                                name="idCustomer"
                                value={this.state.idCustomer}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>Id du plan commandé</label>
                        <div className="control">
                            <input
                                className="input"
                                type="text"
                                name="idPlan"
                                value={this.state.idPlan}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>Co&#251;t du plan</label>
                        <div className="control">
                            <input
                                className="input"
                                type="number"
                                name="planAmount"
                                value={this.state.planAmount}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>Date de livraison</label>
                        <div className="control">
                            <input
                                className="input"
                                type="date"
                                name="deliveryDate"
                                value={this.state.deliveryDate}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <div className="control">
                            <input
                                type="submit"
                                value="Ajouter une commande"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
