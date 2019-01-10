import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Pages.css';
import { ApiUrl } from './../App';

export class Plans extends Component {
    displayName = Plans.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: ApiUrl + 'plans/',
            name: '',
            time: '',
            idPiece: '',
            data: [{
                name: String,
                time: String,
                idPiece: String,
                piece: {
                    name: String,
                    stock: Int32Array,
                    idProductionChain: String,
                    productionChain: {
                        name: String,
                    }
                }
            }]
        };
    }

    handleClick = idPlan => {
        const requestOptions = {
            method: 'DELETE'
        };

        fetch(this.state.targetUrl + idPlan, requestOptions);

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
        this.addPlan();
        event.preventDefault();
    }

    addPlan() {
        fetch(this.state.targetUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: this.state.name,
                time: this.state.time,
                idPiece: this.state.idPiece,
            })
        });
        window.location.reload();
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <h1>Plans</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de gestion des plans. D'ici vous pouvez ajouter, supprimer ou modifier des plans et accéder à la liste complête de ceux-ci.</p>
                <br />
                <table>
                    <tr>
                        <th>
                            Nom du plan
                        </th>
                        <th>
                            Temps de production
                        </th>
                        <th>
                            N° de la pièce associée
                        </th>
                        <th>
                            Nom de la pièce associée
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
                            <td>{item.time}</td>
                            <td>{item.idPiece}</td>
                            <td>{item.piece.name}</td>
                            <td><Link to={{ pathname: '/update/plan', state: { currentItem: item } }}><button>Modifier</button></Link></td>
                            <td><button onClick={() => { this.handleClick(item.id) }}>Supprimer</button></td>
                        </tr>
                    }
                    )}
                </table>
                <br />

                <form className="form" onSubmit={this.handleSubmit}>
                    <div className="field">
                        <label>Nom du plan</label>
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
                        <label>Temps de production</label>
                        <div className="control">
                            <input
                                className="input"
                                type="time"
                                name="time"
                                value={this.state.time}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>N° de la pi&#232;ce associ&#233;e</label>
                        <div className="control">
                            <input
                                className="input"
                                type="text"
                                name="idPiece"
                                value={this.state.idPiece}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <div className="control">
                            <input
                                type="submit"
                                value="Ajouter un plan"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
