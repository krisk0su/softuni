using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    public string name;

    public Company company;

    public Car car;

    public List<Pokemon> pokemons;

    public List<Parent> parents;

    public List<Child> children;



    public Person(string name)
    {
        this.name = name;

        pokemons = new List<Pokemon>();
        
        parents = new List<Parent>();

        children = new List<Child>();

        this.company = new Company("", "", 0);

        this.car = new Car("", 0);

    }

    public void PokeString()
    {
        if (pokemons.Count==0)
        {
            
        }
        else
        {
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"{pokemon.name} {pokemon.type}");
            }
        }

    }
    public void ParentString()
    {
        if (parents.Count == 0)
        {
            
        }
        else
        {
            foreach (var parent in parents)
            {
                Console.WriteLine($"{parent.name} {parent.dateBirth}");
            }
        }

    }
    public void ChildString()
    {
        if (children.Count == 0)
        {
            
        }
        else
        {
            foreach (var child in children)
            {
                Console.WriteLine($"{child.name} {child.dateBirth}");
            }
        }

    }
}

