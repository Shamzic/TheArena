namespace TheArena.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TheArenaContext : DbContext
    {
        public TheArenaContext()
            : base("name=TheArenaContext")
        {
        }

        public virtual DbSet<Ban> Ban { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<FollowGame> FollowGame { get; set; }
        public virtual DbSet<FollowPlayer> FollowPlayer { get; set; }
        public virtual DbSet<FollowTeam> FollowTeam { get; set; }
        public virtual DbSet<FollowTournament> FollowTournament { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameType> GameType { get; set; }
        public virtual DbSet<Geek> Geek { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<Ranking> Ranking { get; set; }
        public virtual DbSet<Reason> Reason { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesGeek> RolesGeek { get; set; }
        public virtual DbSet<Round> Round { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<ScoreType> ScoreType { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SettingValues> SettingValues { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamGeek> TeamGeek { get; set; }
        public virtual DbSet<TeamTag> TeamTag { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentLog> TournamentLog { get; set; }
        public virtual DbSet<TournamentTag> TournamentTag { get; set; }
        public virtual DbSet<Versus> Versus { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .Property(e => e.Commentary)
                .IsUnicode(false);

            modelBuilder.Entity<Division>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Division)
                .WithRequired(e => e.Game1)
                .HasForeignKey(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.FollowGame)
                .WithRequired(e => e.Game1)
                .HasForeignKey(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Ranking)
                .WithRequired(e => e.Game1)
                .HasForeignKey(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Stats)
                .WithRequired(e => e.Game1)
                .HasForeignKey(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                .HasMany(e => e.Tournament)
                .WithRequired(e => e.Game1)
                .HasForeignKey(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameType>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<GameType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GameType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<GameType>()
                .HasMany(e => e.Game)
                .WithRequired(e => e.GameType1)
                .HasForeignKey(e => e.GameType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Geek>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Geek>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Geek>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Geek>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Geek>()
                .Property(e => e.Birthdate)
                .IsUnicode(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Ban)
                .WithRequired(e => e.Geek)
                .HasForeignKey(e => e.BannedGeek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.FollowGame)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Geek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.FollowPlayer)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.FollowPlayer1)
                .WithRequired(e => e.Geek2)
                .HasForeignKey(e => e.Geek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.FollowTeam)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Geek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.FollowTournament)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Geek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.Geek)
                .HasForeignKey(e => e.Sender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Message1)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Receiver)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.RolesGeek)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Geek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Settings)
                .WithRequired(e => e.Geek1)
                .HasForeignKey(e => e.Geek)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Stats)
                .WithRequired(e => e.Geek)
                .HasForeignKey(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Team)
                .WithRequired(e => e.Geek)
                .HasForeignKey(e => e.Captain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.TeamGeek)
                .WithRequired(e => e.Geek)
                .HasForeignKey(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Geek>()
                .HasMany(e => e.Tournament)
                .WithRequired(e => e.Geek)
                .HasForeignKey(e => e.Organiser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Period>()
                .HasMany(e => e.Ban)
                .WithRequired(e => e.Period)
                .HasForeignKey(e => e.BanPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Period>()
                .HasMany(e => e.Tournament)
                .WithRequired(e => e.PeriodRegistration)
                .HasForeignKey(e => e.RegisteringPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Period>()
                .HasMany(e => e.Tournament1)
                .WithRequired(e => e.PeriodPlay)
                .HasForeignKey(e => e.PlayingPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Period>()
                .HasMany(e => e.Versus)
                .WithRequired(e => e.Period)
                .HasForeignKey(e => e.VersusPeriod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reason>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Reason>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Reason>()
                .HasMany(e => e.Ban)
                .WithRequired(e => e.Reason)
                .HasForeignKey(e => e.BanReason)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .HasMany(e => e.Round)
                .WithOptional(e => e.Result1)
                .HasForeignKey(e => e.Result);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.RolesGeek)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScoreType>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreType>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.ScoreType1)
                .HasForeignKey(e => e.ScoreType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Setting>()
                .HasMany(e => e.SettingValues)
                .WithRequired(e => e.Setting1)
                .HasForeignKey(e => e.Setting)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SettingValues>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<SettingValues>()
                .HasMany(e => e.Settings)
                .WithRequired(e => e.SettingValues)
                .HasForeignKey(e => e.SettingValue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.FollowTeam)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Participation)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Ranking)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Result)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.Loser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Result1)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Winner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Stats)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.TeamTag)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.TeamGeek)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Versus)
                .WithOptional(e => e.Team)
                .HasForeignKey(e => e.Team1);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Versus1)
                .WithOptional(e => e.Team3)
                .HasForeignKey(e => e.Team2);

            modelBuilder.Entity<TeamTag>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Tournament>()
                .Property(e => e.Initials)
                .IsUnicode(false);

            modelBuilder.Entity<Tournament>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tournament>()
                .Property(e => e.Rules)
                .IsUnicode(false);

            modelBuilder.Entity<Tournament>()
                .Property(e => e.Tags)
                .IsUnicode(false);

            modelBuilder.Entity<Tournament>()
                .HasMany(e => e.FollowTournament)
                .WithRequired(e => e.Tournament1)
                .HasForeignKey(e => e.Tournament)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tournament>()
                .HasMany(e => e.Participation)
                .WithRequired(e => e.Tournament1)
                .HasForeignKey(e => e.Tournament)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tournament>()
                .HasMany(e => e.TournamentLog)
                .WithRequired(e => e.Tournament1)
                .HasForeignKey(e => e.Tournament)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tournament>()
                .HasMany(e => e.TournamentTag)
                .WithRequired(e => e.Tournament1)
                .HasForeignKey(e => e.Tournament)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tournament>()
                .HasMany(e => e.Versus)
                .WithRequired(e => e.Tournament1)
                .HasForeignKey(e => e.Tournament)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TournamentLog>()
                .Property(e => e.Entry)
                .IsUnicode(false);

            modelBuilder.Entity<TournamentTag>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Versus>()
                .HasMany(e => e.Round)
                .WithRequired(e => e.Versus1)
                .HasForeignKey(e => e.Versus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Ip)
                .IsUnicode(false);
        }
    }
}
