import React, { Component } from 'react';
import { ApiUrl, RedirectUrl } from './../../App';

export class PieceUpdate extends Component {
    displayName = PieceUpdate.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: ApiUrl + 'pieces/',
            redirectUrl: RedirectUrl + 'pieces/',
            currentPiece: [{
                name: '',
                stock: 0,
                idProductionChain: ''
            }],
            name: '',
            stock: '',
            idProductionChain: ''
        };
    }

    componentDidMount() {
        this.setState({ currentPiece: this.props.location.state.currentItem });
        this.setState({ name: this.props.location.state.currentItem.name });
        this.setState({ stock: this.props.location.state.currentItem.stock });
        this.setState({ idProductionChain: this.props.location.state.currentItem.idProductionChain });
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
        this.updatePiece(this.state.name, this.state.stock, this.state.idProductionChain, this.state.currentPiece.id);
        event.preventDefault();
    }

    updatePiece = (name, stock, idProductionChain, pieceId) => {
        console.log(pieceId);
        fetch(this.state.targetUrl + pieceId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: name,
                stock: stock,
                idProductionChain: idProductionChain
            })
        });
        window.location.href = this.state.redirectUrl;
    }

    render() {
        return (
            <div>
                <h1>Modification des pi&#232;ces</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de modification des pi&#232;ces.</p>
                <br />
                <form className="form" onSubmit={this.handleSubmit}>
                    <div className="field">
                        <label>Nom de la pi&#232;ces</label>
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
                        <label>Stock</label>
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
                        <label>N° de la chaine de production associée</label>
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
                                value="Modifier la pi&#232;ce"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
