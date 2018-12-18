import React, { Component } from 'react';

export class ProductionChainUpdate extends Component {
    displayName = ProductionChainUpdate.name

    constructor(props) {
        super(props);

        this.state = {
            targetUrl: 'http://localhost:64156/api/productionChain/',
            redirectUrl: 'https://localhost:44335/productionchain/',
            currentProductionChain: [{
                id: '',
                name: ''
            }],
            value: ''
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    
    componentDidMount() {
        this.setState({ currentProductionChain: this.props.location.state.currentItem });
        this.setState({ value: this.props.location.state.currentItem.name });
    }

    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        this.updateProductionChain(this.state.value, this.state.currentProductionChain.id);
        event.preventDefault();
    }

    updateProductionChain = (productionChainName, productionChainId) => {
        fetch(this.state.targetUrl + productionChainId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: productionChainName,
            })
        });
        window.location.href = this.state.redirectUrl;
    }

    render() {
        return (
            <div>
                <h1>Modification de la chaine de production</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de modification de la chaine de production.</p>
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
                                value="Modifier la chaine de production"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
