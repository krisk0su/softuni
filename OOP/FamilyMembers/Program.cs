

using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }


        int n = int.Parse(Console.ReadLine());
        var family = new Family();
        for (int i = 0; i < n; i++)
        {
            var args = Console.ReadLine().Split();
            var person = new Person();

            person.name = args[0];
            person.age = int.Parse(args[1]);

            family.AddMember(person);
        }

        var oldest = family.GetOldestMember();

        Console.WriteLine($"{oldest.name} {oldest.age}");

    }
}