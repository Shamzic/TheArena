INSERT INTO GameType VALUES ('FPS', 'First-Person Shooter', 'Pan-pan cul-cul', 0);
INSERT INTO GameType VALUES ('MOBA', 'Multiplayer Online Battle Arena', 'La map ressemble à un tangram pour enfant de 3 ans', 0);
INSERT INTO GameType VALUES ('MMORPG', 'Massively Multiplayer Online Role-Playing Game', 'Qui a pensé que ce serait une bonne idée pour une appli pareille ?', 1);

INSERT INTO Game VALUES ('Counter-Strike', 12, 1, 0);
INSERT INTO Game VALUES ('Dota 2', 0, 2, 0);
INSERT INTO Game VALUES ('League of Legends', 0, 2, 1);

INSERT INTO Division VALUES ('Herald', 2, 0);
INSERT INTO Division VALUES ('Guardian', 2, 0);
INSERT INTO Division VALUES ('Crusader', 2, 0);
INSERT INTO Division VALUES ('Archon', 2, 0);
INSERT INTO Division VALUES ('Legend', 2, 0);
INSERT INTO Division VALUES ('Ancient', 2, 0);
INSERT INTO Division VALUES ('Divine', 2, 0);
INSERT INTO Division VALUES ('Immortal', 2, 0);
INSERT INTO Division VALUES ('Pro', 1, 0);
INSERT INTO Division VALUES ('Casual', 1, 0);

INSERT INTO ScoreType VALUES ('WIN', 'Victoire', 0);
INSERT INTO ScoreType VALUES ('CS', 'Nombre de creeps tués', 0);
INSERT INTO ScoreType VALUES ('KDA', '(Kills + Assists)/Deaths', 0);
INSERT INTO ScoreType VALUES ('OBJ', 'Nombre d''objectifs détruits', 1);

INSERT INTO Roles VALUES ('Player', 0);
INSERT INTO Roles VALUES ('Captain', 0);
INSERT INTO Roles VALUES ('Admin', 0);
INSERT INTO Roles VALUES ('Mod', 0);
INSERT INTO Roles VALUES ('Organiser', 0);
INSERT INTO Roles VALUES ('Weeaboo', 1);

INSERT INTO Reason VALUES ('Cheating', 'Déroger aux règles du jeu ou du tournoi', 0);
INSERT INTO Reason VALUES ('Betting', 'Parier sur un tournoi auquel l''utilisateur prend part', 1);
INSERT INTO Reason VALUES ('Swearing', 'Employer un langage un peu trop fleuri', 0);

INSERT INTO Geek VALUES ('Catwaman', 'meaow666', 'Jeanne', 'Chaudanson', 'catsrule@bastet.com', '20101995', 0);
INSERT INTO Geek VALUES ('Blyatman', 'p1zd1et', 'Igor', 'Dosgor', 'moskaumoskau@vodka.com', '26111995', 0);
INSERT INTO Geek VALUES ('Admin', 'admin', 'Admin', 'Admin', 'admin@admin.com', '05051905', 0);
INSERT INTO Geek VALUES ('ElModerator', 'iloveunicorns', 'Jean-Marie', 'Michel', 'pfudonr@gogole.com', '01021993', 0);
INSERT INTO Geek VALUES ('Deleted', 'deleted', 'Deleted', 'Deleted', 'deleted@deleted.com', '20022002', 1);
INSERT INTO Geek VALUES ('Dendi', 'squirrel321', 'Danil', 'Ishutin', 'danil@ishutin.com', '30121992', 0);

INSERT INTO RolesGeek VALUES (3, 3, 0);
INSERT INTO RolesGeek VALUES (4, 4, 0);
INSERT INTO RolesGeek VALUES (5, 4, 0);
INSERT INTO RolesGeek VALUES (2, 1, 0);
INSERT INTO RolesGeek VALUES (1, 1, 0);
INSERT INTO RolesGeek VALUES (1, 6, 0);

INSERT INTO Message VALUES ('ez', 1509493171, 6, 1, 0);
INSERT INTO Message VALUES ('New phone who dis?', 1514203932, 2, 1, 1);
INSERT INTO Message VALUES ('Dernier avertissement !', 1539474055, 4, 2, 0);

INSERT INTO Period VALUES (1539514800, 1544785200, 0);
INSERT INTO Period VALUES (1538380800, 1556697600, 0);
INSERT INTO Period VALUES (1565028000, 1566774000, 0);

INSERT INTO Ban VALUES ('Avertissement ignoré', 2, 1, 3, 0);

INSERT INTO Team VALUES ('PWRRGR', 'Power Rangers', '', 1, 0);

INSERT INTO TeamGeek VALUES (1, 1, 0);
INSERT INTO TeamGeek VALUES (6, 1, 0);
INSERT INTO TeamGeek VALUES (2, 1, 1);

INSERT INTO Ranking VALUES (1, 2, 1, 1, 0);

INSERT INTO Tournament VALUES ('TI42', 'The International 42', 'Que le meilleur gagne !', 16, 2, '', 2, 3, 2, 0, 4);

INSERT INTO Participation VALUES (NULL, 1, 1, 1, 0);

INSERT INTO Parameter VALUES ('Langue', 'en', 0);
INSERT INTO Parameter VALUES ('Messages', 'on', 0);

INSERT INTO Setting VALUES (1, 1, 'fr', 0);
INSERT INTO Setting VALUES (1, 2, 'on', 0);
INSERT INTO Setting VALUES (2, 1, 'en', 0);
INSERT INTO Setting VALUES (2, 2, 'on', 0);
INSERT INTO Setting VALUES (6, 1, 'en', 0);
INSERT INTO Setting VALUES (6, 2, 'off', 0);
INSERT INTO Setting VALUES (3, 1, 'fr', 0);
INSERT INTO Setting VALUES (3, 2, 'off', 0);
INSERT INTO Setting VALUES (4, 1, 'fr', 0);
INSERT INTO Setting VALUES (4, 2, 'on', 0);
INSERT INTO Setting VALUES (5, 1, 'fr', 1);
INSERT INTO Setting VALUES (5, 2, 'on', 1);

INSERT INTO FollowTeam VALUES (4, 1, 0);

INSERT INTO FollowPlayer VALUES (1, 6, 0);

INSERT INTO FollowGame VALUES (2, 2, 0);

INSERT INTO FollowTournament VALUES (4, 1, 0);