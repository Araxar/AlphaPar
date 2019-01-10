import React, { Component } from 'react';
import './Pages.css';
import { ApiUrl } from './../App';

export class Employees extends Component {
    displayName = Employees.name

    constructor(props) {
        super(props);

        this.state = {
            data: [{
                name: String,
                surname: String,
                dateOfBirth: String,
                phone: String,
                email: String
            }]
        };
    }

    componentDidMount() {
        var targetUrl = ApiUrl + 'employees';
        fetch(targetUrl)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ data });
            });
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <h1>Employ&#233;s</h1>
                <br />
                <br />
                <p>Bienvenue sur la page de gestion des employés. D'ici vous pouvez ajouter, supprimer ou modifier des employés et accéder à la liste complête de ceux-ci.</p>
                <br />
                <table>
                    <tr>
                        <th>
                            Pr&#233;nom
                        </th>
                        <th>
                            Nom
                        </th>
                        <th>
                            Date de naissance
                        </th>
                        <th>
                            Téléphone
                        </th>
                        <th>
                            Email
                        </th>
                    </tr>
                        {data.map(item => {
                        return <tr key={item.id}>
                            <td>{item.name}</td>
                            <td>{item.surname}</td>
                            <td>{item.dateOfBirth}</td>
                            <td>{item.phone}</td>
                            <td>{item.email}</td>
                        </tr>
                        }
                        )}
                </table>
            </div>
        );
    }
}
