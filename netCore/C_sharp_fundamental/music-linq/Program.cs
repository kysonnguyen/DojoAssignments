using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist A_MtV = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine("The artist's name is {0} and is {1} years old", A_MtV.ArtistName, A_MtV.Age);
            //Who is the youngest artist in our collection of artists?
            Artist youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"Artist {youngest.ArtistName} from {youngest.Hometown} is the youngest, at {youngest.Age} years old");
            //Display all artists with 'William' somewhere in their real name
            List<Artist> William = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            Console.WriteLine("The artists with William in their real name are: ");
            foreach(Artist artist in William)
            {
                Console.WriteLine($"- {artist.ArtistName} : {artist.RealName}");
            }
            //Display all groups with name less than 8 charactes in length.
            List<Group> groups = Groups.Where(group => group.GroupName.Length < 8).ToList();
            Console.WriteLine("These groups have names less than 8 characters in length:");
            foreach(Group group in groups)
            {
                Console.WriteLine($"- {group.GroupName}");
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> oldest = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3).ToList();
            Console.WriteLine("The 3 oldest artists from Atlanta are:");
            foreach (Artist artist in oldest)
            {
                Console.WriteLine($"- {artist.ArtistName} : {artist.Age}");
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> nonNYgroups = Artists.Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist;})
                                            .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                            .Select(artist => artist.Group.GroupName).Distinct().ToList();
            Console.WriteLine("These groups have members not from New York City:");
            foreach(string group in nonNYgroups)
            {
                Console.WriteLine($"- {group}");
            }
            
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<Artist> artists = Artists.Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => {artist.Group = group; return artist;})
                                        .Where(artist => artist.Group.GroupName == "Wu-Tang Clan").ToList();
            Console.WriteLine("These artists are in the 'Wu-Tang Clan' group:");
            foreach(Artist artist in artists)
            {
                Console.WriteLine($"- {artist.ArtistName}");
            }
        }
    }
}