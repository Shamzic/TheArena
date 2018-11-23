DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + ']'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME = rc1.CONSTRAINT_NAME

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor
GO

EXEC sp_MSforeachtable 'DROP TABLE ?'
GO

CREATE TABLE Division (DivisionId INT NOT NULL IDENTITY PRIMARY KEY, Name varchar(255), Game INT NOT NULL, Deleted BIT);
CREATE TABLE Message (MessageId INT NOT NULL IDENTITY PRIMARY KEY, Content varchar(255), Time INT NOT NULL, Sender INT NOT NULL, Receiver INT NOT NULL, Deleted BIT);
CREATE TABLE Ban (BanId INT NOT NULL IDENTITY PRIMARY KEY, Commentary varchar(255), BannedGeek INT NOT NULL, BanPeriod INT NOT NULL, BanReason INT NOT NULL, Deleted BIT);
CREATE TABLE Ranking (RankingId INT NOT NULL IDENTITY PRIMARY KEY, Standing INT, Game INT NOT NULL, Division INT, Team INT NOT NULL, Deleted BIT);
CREATE TABLE Tournament (TournamentId INT NOT NULL IDENTITY PRIMARY KEY, Initials varchar(255) NOT NULL, Name varchar(255), Rules varchar(255), Slots INT, PlayerNumber INT, Tags varchar(255), RegisteringPeriod INT NOT NULL, PlayingPeriod INT NOT NULL, Game INT NOT NULL, Deleted BIT, Organiser INT NOT NULL);
CREATE TABLE Game (GameId INT NOT NULL IDENTITY PRIMARY KEY, Name varchar(255), AgeLimit INT, GameType INT NOT NULL, Deleted BIT);
CREATE TABLE Team (TeamId INT NOT NULL IDENTITY PRIMARY KEY, Initials varchar(255), Name varchar(255), Tags varchar(255), Captain INT NOT NULL, Deleted BIT);
CREATE TABLE Period (PeriodId INT NOT NULL IDENTITY PRIMARY KEY, Start INT, Ending INT, Deleted BIT);
CREATE TABLE Participation (ParticipationId INT NOT NULL IDENTITY PRIMARY KEY, Place INT, Qualified BIT, Team INT NOT NULL, Tournament INT NOT NULL, Deleted BIT);
CREATE TABLE Versus (VersusId INT NOT NULL IDENTITY PRIMARY KEY, Team1 INT, Team2 INT, VersusPeriod INT NOT NULL, Result INT NOT NULL, Tournament INT NOT NULL, Deleted BIT);
CREATE TABLE Reason (ReasonId INT NOT NULL IDENTITY PRIMARY KEY, Name varchar(255), Description varchar(255), Deleted BIT);
CREATE TABLE Stats (StatisticsId INT NOT NULL IDENTITY PRIMARY KEY, Game INT NOT NULL, Team INT NOT NULL, Player INT NOT NULL, WinNumber INT, LoseNumber INT, LifetimeScore INT, Deleted BIT);
CREATE TABLE Round (RoundId INT NOT NULL IDENTITY PRIMARY KEY, Number INT, Versus INT NOT NULL, Result INT, Deleted BIT);
CREATE TABLE Score (ScoreId INT NOT NULL IDENTITY PRIMARY KEY, Result INT NOT NULL, ScoreType INT NOT NULL, Winner INT, Loser INT, Deleted BIT);
CREATE TABLE GameType (GameTypeId INT NOT NULL IDENTITY PRIMARY KEY, Initials varchar(255), Name varchar(255), Description varchar(255), Deleted BIT);
CREATE TABLE ScoreType (ScoreTypeId INT NOT NULL IDENTITY PRIMARY KEY, Initials varchar(255), Name varchar(255), Deleted BIT);
CREATE TABLE Visitor (Ip varchar(255) NOT NULL, Deleted BIT);
CREATE TABLE Geek (GeekId INT NOT NULL IDENTITY PRIMARY KEY, Username varchar(255) NOT NULL, Name varchar(255), Surname varchar(255), Password varchar(255), Mail varchar(255), Birthdate INT, Deleted BIT);
CREATE TABLE Result (ResultId INT NOT NULL IDENTITY PRIMARY KEY, Loser INT NOT NULL, Winner INT NOT NULL, Deleted BIT);
CREATE TABLE Roles (RoleId INT NOT NULL IDENTITY PRIMARY KEY, Name varchar(255), Deleted BIT);
CREATE TABLE Configuration (ConfigurationId INT NOT NULL IDENTITY PRIMARY KEY, Geek INT NOT NULL, Parameter INT NOT NULL, Value varchar(255), Deleted BIT);
CREATE TABLE Parameter (ParameterId INT NOT NULL IDENTITY PRIMARY KEY, Name varchar(255), Preselected varchar(255), Deleted BIT);
CREATE TABLE Roles_Geek (RolesGeekId INT NOT NULL IDENTITY PRIMARY KEY, Role INT NOT NULL, Geek INT NOT NULL, Deleted BIT);
CREATE TABLE Team_Geek (TeamGeekId INT NOT NULL IDENTITY PRIMARY KEY, Player INT NOT NULL, Team INT NOT NULL, Deleted BIT);
CREATE TABLE FollowTeam (FollowTeamId INT NOT NULL IDENTITY PRIMARY KEY, Geek INT NOT NULL, Team INT NOT NULL, Deleted BIT);
CREATE TABLE FollowPlayer (FollowPlayerId INT NOT NULL IDENTITY PRIMARY KEY, Geek INT NOT NULL, Player INT NOT NULL, Deleted BIT);
CREATE TABLE FollowGame (FollowGameId INT NOT NULL IDENTITY PRIMARY KEY, Geek INT NOT NULL, Game INT NOT NULL, Deleted BIT);
CREATE TABLE FollowTournament (FollowTournamentId INT NOT NULL IDENTITY PRIMARY KEY, Geek INT NOT NULL, Tournament INT NOT NULL, Deleted BIT);