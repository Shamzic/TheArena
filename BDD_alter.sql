ALTER TABLE Division ADD CONSTRAINT FK_Division FOREIGN KEY (Game) REFERENCES Game (GameId);

ALTER TABLE Message ADD CONSTRAINT FK_Message1 FOREIGN KEY (Sender) REFERENCES Geek (GeekId);
ALTER TABLE Message ADD CONSTRAINT FK_Message2 FOREIGN KEY (Receiver) REFERENCES Geek (GeekId);

ALTER TABLE Ban ADD CONSTRAINT FK_Ban1 FOREIGN KEY (BannedGeek) REFERENCES Geek (GeekId);
ALTER TABLE Ban ADD CONSTRAINT FK_Ban2 FOREIGN KEY (BanReason) REFERENCES Reason (ReasonId);
ALTER TABLE Ban ADD CONSTRAINT FK_Ban3 FOREIGN KEY (BanPeriod) REFERENCES Period (PeriodId);

ALTER TABLE Ranking ADD CONSTRAINT FK_Ranking1 FOREIGN KEY (Game) REFERENCES Game (GameId);
ALTER TABLE Ranking ADD CONSTRAINT FK_Ranking2 FOREIGN KEY (Team) REFERENCES Team (TeamId);

ALTER TABLE Tournament ADD CONSTRAINT FK_Tournament1 FOREIGN KEY (Organiser) REFERENCES Geek (GeekId);
ALTER TABLE Tournament ADD CONSTRAINT FK_Tournament2 FOREIGN KEY (Game) REFERENCES Game (GameId);
ALTER TABLE Tournament ADD CONSTRAINT FK_Tournament3 FOREIGN KEY (RegisteringPeriod) REFERENCES Period (PeriodId);
ALTER TABLE Tournament ADD CONSTRAINT FK_Tournament4 FOREIGN KEY (PlayingPeriod) REFERENCES Period (PeriodId);

ALTER TABLE Game ADD CONSTRAINT FK_Game FOREIGN KEY (GameType) REFERENCES GameType (GameTypeId);
ALTER TABLE Team ADD CONSTRAINT FK_Team FOREIGN KEY (Captain) REFERENCES Geek (GeekId);

ALTER TABLE Participation ADD CONSTRAINT FK_Participation1 FOREIGN KEY (Team) REFERENCES Team (TeamId);
ALTER TABLE Participation ADD CONSTRAINT FK_Participation2 FOREIGN KEY (Tournament) REFERENCES Tournament (TournamentId);

ALTER TABLE Versus ADD CONSTRAINT FK_Versus1 FOREIGN KEY (Team1) REFERENCES Team (TeamId);
ALTER TABLE Versus ADD CONSTRAINT FK_Versus2 FOREIGN KEY (Team2) REFERENCES Team (TeamId);
ALTER TABLE Versus ADD CONSTRAINT FK_Versus3 FOREIGN KEY (Tournament) REFERENCES Tournament (TournamentId);
ALTER TABLE Versus ADD CONSTRAINT FK_Versus4 FOREIGN KEY (VersusPeriod) REFERENCES Period (PeriodId);

ALTER TABLE Stats ADD CONSTRAINT FK_Statistics1 FOREIGN KEY (Game) REFERENCES Game (GameId);
ALTER TABLE Stats ADD CONSTRAINT FK_Statistics2 FOREIGN KEY (Team) REFERENCES Team (TeamId);
ALTER TABLE Stats ADD CONSTRAINT FK_Statistics3 FOREIGN KEY (Player) REFERENCES Geek (GeekId);

ALTER TABLE Round ADD CONSTRAINT FK_Round1 FOREIGN KEY (Versus) REFERENCES Versus (VersusId);
ALTER TABLE Round ADD CONSTRAINT FK_Round2 FOREIGN KEY (Result) REFERENCES Result (ResultId);

ALTER TABLE Score ADD CONSTRAINT FK_Score FOREIGN KEY (ScoreType) REFERENCES ScoreType (ScoreTypeId);

ALTER TABLE Result ADD CONSTRAINT FK_Result1 FOREIGN KEY (Loser) REFERENCES Team (TeamId);
ALTER TABLE Result ADD CONSTRAINT FK_Result2 FOREIGN KEY (Winner) REFERENCES Team (TeamId);

ALTER TABLE Setting ADD CONSTRAINT FK_Setting1 FOREIGN KEY (Geek) REFERENCES Geek (GeekId);
ALTER TABLE Setting ADD CONSTRAINT FK_Setting2 FOREIGN KEY (Parameter) REFERENCES Parameter (ParameterId);

ALTER TABLE RolesGeek ADD CONSTRAINT FK_RG1 FOREIGN KEY (Role) REFERENCES Roles (RoleId);
ALTER TABLE RolesGeek ADD CONSTRAINT FK_RG2 FOREIGN KEY (Geek) REFERENCES Geek (GeekId);

ALTER TABLE TeamGeek ADD CONSTRAINT FK_TG1 FOREIGN KEY (Team) REFERENCES Team (TeamId);
ALTER TABLE TeamGeek ADD CONSTRAINT FK_TG2 FOREIGN KEY (Player) REFERENCES Geek (GeekId);

ALTER TABLE FollowGame ADD CONSTRAINT FK_FG1 FOREIGN KEY (Game) REFERENCES Game (GameId);
ALTER TABLE FollowGame ADD CONSTRAINT FK_FG2 FOREIGN KEY (Geek) REFERENCES Geek (GeekId);

ALTER TABLE FollowPlayer ADD CONSTRAINT FK_FP1 FOREIGN KEY (Player) REFERENCES Geek (GeekId);
ALTER TABLE FollowPlayer ADD CONSTRAINT FK_FP2 FOREIGN KEY (Geek) REFERENCES Geek (GeekId);

ALTER TABLE FollowTeam ADD CONSTRAINT FK_FTe1 FOREIGN KEY (Team) REFERENCES Team (TeamId);
ALTER TABLE FollowTeam ADD CONSTRAINT FK_FTe2 FOREIGN KEY (Geek) REFERENCES Geek (GeekId);

ALTER TABLE FollowTournament ADD CONSTRAINT FK_FTo1 FOREIGN KEY (Tournament) REFERENCES Tournament (TournamentId);
ALTER TABLE FollowTournament ADD CONSTRAINT FK_FTo2 FOREIGN KEY (Geek) REFERENCES Geek (GeekId);