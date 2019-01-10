import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Pages.css';
import { ApiUrl } from './../App';

export class Pieces extends Component {
    displayName = Pieces.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: ApiUrl + 'pieces/',
            name: '',
            stock: 0,
            idProductionChain: '',
            data: [{
                name: String,
                stock: Int32Array,
                idProductionChain: String,
                productionChain: {
                    name: String
                }
            }]
        };
    }

    componentDidMount() {
        fetch(this.state.targetUrl)
            .then(response => response.json())
            .then(data => {
                this.setState({ data });
            });
    }

    handleClick = idPiece => {
        const requestOptions = {
            method: 'DELETE'
        };

        fetch(this.state.targetUrl + idPiece, requestOptions);

        window.location.reload();
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
        this.addPiece();
        event.preventDefault();
    }

    addPiece() {
        fetch(this.state.targetUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: this.state.name,
                stock: this.state.stock,
                idProductionChain: this.state.idProductionChain,
            })
        });
        window.location.reload();
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <h1>Pi&#232;ces</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de gestion des pi&#232;ces. D'ici vous pouvez ajouter, supprimer ou modifier des pi&#232;ces et acc&#233;der à la liste complête de celles-ci.</p>
                <br />
                <table>
                    <tr>
                        <th>
                            Nom de la pièce
                        </th>
                        <th>
                            Nombre en stock
                        </th>
                        <th>
                            Numéro de la chaine de production associée
                        </th>
                        <th>
                            Nom de la chaine de production associée
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
                            <td>{item.stock}</td>
                            <td>{item.idProductionChain}</td>
                            <td>{item.productionChain.name}</td>
                            <td><Link to={{ pathname: '/update/piece', state: { currentItem: item } }}><button>Modifier</button></Link></td>
                            <td><button onClick={() => { this.handleClick(item.id) }}>Supprimer</button></td>
                        </tr>
                    }
                    )}
                </table>
                <br />

                <form className="form" onSubmit={this.handleSubmit}>
                    <div className="field">
                        <label>Nom de la pi&#232;ce</label>
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
                        <label>Nombre en stock</label>
                        <div className="control">
                            <input
                                className="input"
                                type="number"
                                name="stock"
                                value={this.state.stock}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <label>N° de la chaine associ&#233;e</label>
                        <div className="control">
                            <input
                                className="input"
                                type="text"
                                name="idProductionChain"
                                value={this.state.idProductionChain}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <div className="control">
                            <input
                                type="submit"
                                value="Ajouter une pi&#232;ce"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
