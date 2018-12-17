import React, { Component } from 'react';

export class Employees extends Component {
    displayName = Employees.name

    constructor(props) {
        super(props);

        this.state = {
            data: null,
        };
    }

    componentDidMount() {
        fetch('https://localhost:44347/api/employees')
            .then(response => response.json())
            .then(data => this.setState({ data }));
    }

    render() {
        return (
            <div>
                <h1>Employ&#233;s</h1>
                <br />
                <br />
                <p>Bienvenue sur la page d'accueil de votre ERP. D'ici vous pouvez avoir acc&#232;s aux diff&#233;rentes pages de gestion.</p>
                <br />
                <p>Voici toutes les pages que vous pouvez g&#233;rer :</p>
                {data.hits.map(hit =>
                    <li key={hit.objectID}>
                        <a href={hit.url}>{hit.title}</a>
                    </li>
                )}
            </div>
        );
    }
}
