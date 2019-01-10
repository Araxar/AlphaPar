import React, { Component } from 'react';
import { ApiUrl, RedirectUrl } from './../../App';

export class CommandUpdate extends Component {
    displayName = CommandUpdate.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: ApiUrl + 'customers/',
            redirectUrl: RedirectUrl + 'customers/',
            currentCommand: [{
                id: '',
                idCustomer: '',
                idPlan: '',
                planAmount: '',
                deliveryDate: ''
            }],
            idCustomer: '',
            idPlan: '',
            planAmount: '',
            deliveryDate: ''
        };
    }

    componentDidMount() {
        this.setState({ currentCommand: this.props.location.state.currentItem });
        this.setState({ idCustomer: this.props.location.state.currentItem.idCustomer });
        this.setState({ idPlan: this.props.location.state.currentItem.idPlan });
        this.setState({ planAmount: this.props.location.state.currentItem.planAmount });
        this.setState({ deliveryDate: this.props.location.state.currentItem.deliveryDate });
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
        this.updateCommand(this.state.idCustomer, this.state.idPlan, this.state.planAmount, this.state.deliveryDate, this.state.currentCommand.id);
        event.preventDefault();
    }

    updateCommand = (idCustomer, idPlan, planAmount, deliveryDate, commandId) => {
        console.log(commandId);
        fetch(this.state.targetUrl + commandId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                idCustomer: idCustomer,
                idPlan: idPlan,
                planAmount: planAmount,
                deliveryDate: deliveryDate
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
                <p>Bienvenue sur la page de modification des commandes.</p>
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
                        <label>Id du plan</label>
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
                                value="Modifier la commande"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
