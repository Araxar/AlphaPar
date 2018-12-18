import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './Pages.css';

export class ProductionChain extends Component {
    displayName = ProductionChain.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: 'http://localhost:64156/api/productionChain/',
            value: '',
            data: [{
                name: ''
            }]
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        fetch(this.state.targetUrl)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ data });
            });
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        this.addProductionChain(this.state.value);
        event.preventDefault();
    }

    handleClick = idProductionChain => {
        const requestOptions = {
            method: 'DELETE'
        };

        fetch(this.state.targetUrl + idProductionChain, requestOptions);

        window.location.reload();
    }

    addProductionChain = productionChainName => {
        fetch(this.state.targetUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: productionChainName,
            })
        });
        window.location.reload();
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <h1>Chaine de production</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de gestion de la chaine de production. D'ici vous pouvez ajouter, supprimer ou modifier des chaines de production et accéder à la liste complête de celles-ci.</p>
                <br />
                <table>
                    <tr>
                        <th>
                            Nom de la chaine de production
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
                            <td><Link to={{ pathname: '/update/productionChain', state: { currentItem: item } }}><button>Modifier</button></Link></td>
                            <td><button onClick={() => { this.handleClick(item.id) }}>Supprimer</button></td>
                        </tr>
                    }
                    )}
                </table>
                <br />
                <form onSubmit={this.handleSubmit}>
                    <div className="field">
                        <label>Name</label>
                        <div className="control">
                            <input
                                className="input"
                                type="text"
                                name="name"
                                value={this.state.value}
                                onChange={this.handleChange}
                            />
                        </div>
                    </div>
                    <br />
                    <div className="field">
                        <div className="control">
                            <input
                                type="submit"
                                value="Ajouter une chaine de production"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
