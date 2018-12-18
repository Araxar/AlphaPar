import React, { Component } from 'react';


export class CustomerUpdate extends Component {
    displayName = CustomerUpdate.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: 'http://localhost:64156/api/customers/',
            redirectUrl: 'https://localhost:44335/customers/',
            currentCustomer: [{
                email: '',
                id: '',
                name: '',
                phone: '',
                siret: ''
            }],
            name: '',
            siret: '',
            phone: '',
            email: ''
        };
    }

    componentDidMount() {
        this.setState({ currentCustomer: this.props.location.state.currentItem });
        this.setState({ name: this.props.location.state.currentItem.name });
        this.setState({ siret: this.props.location.state.currentItem.siret });
        this.setState({ phone: this.props.location.state.currentItem.phone });
        this.setState({ email: this.props.location.state.currentItem.email });
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
        this.updateCustomer(this.state.name, this.state.siret, this.state.phone, this.state.email, this.state.currentCustomer.id);
        event.preventDefault();
    }

    updateCustomer = (name, siret, phone, email, customerId) => {
        console.log(customerId);
        fetch(this.state.targetUrl + customerId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: name,
                siret: siret,
                phone: phone,
                email: email
            })
        });
        window.location.href = this.state.redirectUrl;
    }

    render() {
        return (
            <div>
                <h1>Modification des clients</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de modification des clients.</p>
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
                                value="Modifier le client"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
