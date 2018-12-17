import React, { Component } from 'react';

export class Pieces extends Component {
    displayName = Pieces.name

    render() {
        return (
            <div>
                <h1>Pi&#232;ces</h1>
                <br />
                <br />
                <p>Bienvenue sur la page d'accueil de votre ERP. D'ici vous pouvez avoir acc&#232;s aux diff&#233;rentes pages de gestion.</p>
                <br />
                <p>Voici toutes les pages que vous pouvez g&#233;rer :</p>
                <ul>
                    <li><strong>Employ&#233;s</strong>. Pour g&#233;rer les diff&#233;rents employ&#233;s.</li>
                    <li><strong>Clients</strong>. Pour g&#233;rer vos clients.</li>
                    <li><strong>Chaine de production</strong>. Pour g&#233;rer la chaine de production.</li>
                    <li><strong>Plans</strong>. Pour g&#233;rer les plans.</li>
                    <li><strong>Pi&#232;ces</strong>. Pour g&#233;rer les diff&#233;rentes pi&#232;ces.</li>
                    <li><strong>Commandes</strong>. Pour g&#233;rer les commandes des clients.</li>
                </ul>
            </div>
        );
    }
}
