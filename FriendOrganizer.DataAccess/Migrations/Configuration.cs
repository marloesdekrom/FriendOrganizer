namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Friends.AddOrUpdate(
                f => f.FirstName,
              new Friend { FirstName = "Klaas", LastName = "Karel" },
                new Friend { FirstName = "Piet", LastName = "de Jong" },
                new Friend { FirstName = "Mien", LastName = "Dobbelsteen" },
                new Friend { FirstName = "Truus", LastName = "Jansen" }

                );

            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "TypeScript" },
                new ProgrammingLanguage { Name = "JavaScript" },
                new ProgrammingLanguage { Name = "Java" }
                );

            context.FriendPhoneNumbers.AddOrUpdate(
                p => p.Number,
                new FriendPhoneNumber { Number = "+31 263718298", FriendID = context.Friends.First().Id }
                );

            context.Meetings.AddOrUpdate(
                m => m.Title,
                new Meeting
                {
                    Title = "Going to the movies",
                    DateFrom = new DateTime(2018, 8, 20),
                    DateTo = new DateTime(2018, 8, 20),
                    Friends = new List<Friend>
                    {
                        context.Friends.Single(f=>f.FirstName == "Mien" && f.LastName == "Dobbelsteen"),
                        context.Friends.Single(f=>f.FirstName == "Truus" && f.LastName == "Jansen")
                    }
                });
                
        }
    }
}
