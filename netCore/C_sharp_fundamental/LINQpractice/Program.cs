using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var contactList = new List<Dictionary<string, string>>();
            var newContact = new Dictionary<string, string>();
            newContact["name"] = "Tim";
            newContact["number"] = "382862672";
            newContact["age"] = "32";
            contactList.Add(newContact);
            var newContact1 = new Dictionary<string, string>();
            newContact1["name"] = "Kimi";
            newContact1["number"] = "097867657";
            newContact1["age"] = "27";
            contactList.Add(newContact1);
            var newContact2 = new Dictionary<string, string>();
            newContact2["name"] = "Ryan";
            newContact2["number"] = "677543434";
            newContact2["age"] = "71";
            contactList.Add(newContact2);
            var newContact3 = new Dictionary<string, string>();
            newContact3["name"] = "Sam";
            newContact3["number"] = "234234234";
            newContact3["age"] = "41";
            contactList.Add(newContact3);

            var firstLetterRNames = contactList.Where((contact) => contact["name"][0] == "R").ToList();
            var overForty = contactList.Where((contact) => {
                Console.WriteLine($"Parsing over {contact["name"]}!");
                return (Int64.Parse(contact["age"]) > 40);
                }).LastOrDefault();

            var sortedByNumber = contactList.OrderByDescending((contact) => Int64.Parse(contact["number"]))
                                            .Take(2)
                                            .ToList();
        }
    }
}
