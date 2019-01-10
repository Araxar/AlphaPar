import React, { Component } from 'react';
import { ApiUrl, RedirectUrl } from './../../App';

export class PlanUpdate extends Component {
    displayName = PlanUpdate.name

    constructor(props) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);

        this.state = {
            targetUrl: ApiUrl + 'plans/',
            redirectUrl: RedirectUrl + 'plans/',
            currentPlan: [{
                name: '',
                id: '',
                time: '',
                idPiece: ''
            }],
            name: '',
            time: '',
            idPiece: ''
        };
    }

    componentDidMount() {
        this.setState({ currentPlan: this.props.location.state.currentItem });
        this.setState({ name: this.props.location.state.currentItem.name });
        this.setState({ time: this.props.location.state.currentItem.time });
        this.setState({ idPiece: this.props.location.state.currentItem.idPiece });
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
        this.updatePlan(this.state.name, this.state.time, this.state.idPiece, this.state.currentPlan.id);
        event.preventDefault();
    }

    updatePlan = (name, time, idPiece, planId) => {
        console.log(planId);
        fetch(this.state.targetUrl + planId, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                name: name,
                time: time,
                idPiece: idPiece
            })
        });
        window.location.href = this.state.redirectUrl;
    }

    render() {
        return (
            <div>
                <h1>Modification des plans</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de modification des plans.</p>
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
                        <label>N° de la pièce associée</label>
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
                                value="Modifier le plan"
                                className="button is-primary"
                            />
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
