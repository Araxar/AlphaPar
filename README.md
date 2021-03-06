# AlphaPar<!-- omit in toc -->
Projet CyberSecurité du [groupe 1](#l%C3%A9quipe-de-travail), promotion A5 de Exia CESI Arras. Plus d'informations détaillées sur le Wiki du projet : [Wiki](https://github.com/Araxar/AlphaPar/wiki)

## Builds<!-- omit in toc -->
|  | API | Linux Client | Windows Client |
|--|-----|--------------|----------------|
| Master | [![Build status](https://dev.azure.com/CyberSecu/AlphaPar/_apis/build/status/Build%20API)](https://dev.azure.com/CyberSecu/AlphaPar/_build/latest?definitionId=-1) | [![Build status](https://dev.azure.com/CyberSecu/AlphaPar/_apis/build/status/Build%20Linux%20Client)](https://dev.azure.com/CyberSecu/AlphaPar/_build/latest?definitionId=3) | [![Build status](https://dev.azure.com/CyberSecu/AlphaPar/_apis/build/status/Build%20Windows%20Client)](https://dev.azure.com/CyberSecu/AlphaPar/_build/latest?definitionId=5) 
| Dev | [![Build status](https://dev.azure.com/CyberSecu/AlphaPar/_apis/build/status/Build%20API-DEV)](https://dev.azure.com/CyberSecu/AlphaPar/_build/latest?definitionId=6) | [![Build status](https://dev.azure.com/CyberSecu/AlphaPar/_apis/build/status/Build%20Linux%20Client-DEV)](https://dev.azure.com/CyberSecu/AlphaPar/_build/latest?definitionId=7) |  |

# Table des matières<!-- omit in toc -->
- [Contexte du projet](#contexte-du-projet)
- [L'équipe de travail](#l%C3%A9quipe-de-travail)
- [Architecture Sytème](#architecture-syt%C3%A8me)
- [Architecture Logiciel](#architecture-logiciel)

## Contexte du projet 
L’entreprise **AlphaPar** conçoit des modules pour les centrales électriques. Elle est composée de 5 personnes. Un nouveau client majeur a passé il y a 2 mois un contrat pluriannuel. Ce contrat multiplie par 3 la charge de travail et par 2 la superficie nécessaire pour l’unité de production tests. Ce nouveau contrat couvre également des modules pour les cœurs de réacteurs nucléaires. Dans les 2 prochains mois, un déménagement est prévu, l’embauche de 8 salariés et des investissements massifs (notamment pour son SI).

AlphaPar fait appel à un groupe d’experts pour s’équiper informatiquement parlant. L’usage de tableau Excel en local sur les postes sur un accès internet « nu » n’est plus acceptable dans ce nouveau contexte.

L’entreprise travaillant sur des technologies de pointe, sur la réalisation de brevet, et maintenant pour des OIV, elle doit pouvoir se protéger de l’espionnage industriel.
L’implémentation d’une interconnexion avec le réseau industriel au travers d’un réseau SCADA est prévue à moyen terme. Ce réseau ne doit pas connaître d’intrusions, il faut donc que le réseau auquel il est rattaché soit hermétique.

L’entreprise mandate le groupe d’experts pour réaliser son infrastructure « from scratch ». <br/>
La maquette qui sera présentée, sera auditée par une autre entreprise spécialisée dans la cybersécurité.

Une fois l’audit effectué, les experts recevront le rapport d’audit afin de « durcifier » cette infrastructure.

Pour plus d'information : [Voir le Wiki du Projet](https://github.com/Araxar/AlphaPar/wiki)

## L'équipe de travail
- **Martin Wallet**, _Ingénieur réseau_
- **Mathieu Carlier**, _Ingénieur système_
- **Luigi Gandossi**, _Ingénieur logiciel_
- **Guillaume Deramoudt**, _Ingénieur logiciel_

## Architecture Sytème

Voir la page du [Wiki associé](https://github.com/Araxar/AlphaPar/wiki/Architecture-r%C3%A9seau)

## Architecture Logiciel

Voir la page du [Wiki associé](https://github.com/Araxar/AlphaPar/wiki/Architecture-logiciel).
