using System;
using System.Collections.Generic;
using System.Text;


public class FamilyTree
{
    public Person person;

    public List<Parent> parents;

    public List<Child> children;

    public FamilyTree(Person person)
    {
        this.person = person;

        parents = new List<Parent>();

        children = new List<Child>();
    }
}

