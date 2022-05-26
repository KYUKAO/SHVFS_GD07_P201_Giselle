using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Linq : MonoBehaviour
{
    //Language
    //Integrated
    //Query
    public void OnEnable()
    {
        var names = new[] { "Gary", "Chloe", "Claire", "Rebecca",
            "EZ", "Ben", "Kevin", "Giselle" };
        //Query syntax
        var namesWithAQuery = from name in names
                              where name.Contains("C")
                              select name;
        //Method syntax
        //Where is a filtering extension method
        var namesWithAMethod = names.Where(name => name.Contains("C"));

        foreach(var name in namesWithAQuery)
        {
            Debug.Log($"QUERY:{name}");
        }
        foreach(var name in namesWithAMethod)
        {
            Debug.Log($"METHOD:{name}");
        }
        //Lambda...=>"goes to"
    }
    public class LinqExample : MonoBehaviour
    {
        // Language
        // INtegrated
        // Query

        private void OnEnable()
        {
            var names = new[] { "Gary", "Chloe", "Claire", "Rebecca", "EZ", "Ben", "Kevin", "Giselle" };

            // Query syntax
            var namesWithAQuery = from name in names
                                  where name.Contains("C")
                                  select name;

            // Method syntax
            var namesWithAMethod = names.Where(name => name.Contains("C"));

            foreach (var name in namesWithAQuery)
            {
                //Debug.Log($"QUERY: {name}");
            }

            foreach (var name in namesWithAMethod)
            {
                //Debug.Log($"METHOD: {name}");
            }

            // Method syntax has MORE operators and methods, the compiler converts query syntax to method syntax.. It doesn't really matter which one you use

            var enemies = new List<Enemy>()
            {
                new Enemy() {Name = "Gary", HP = 9000},
                new Enemy() {Name = "Ben", HP = 99},
                new Enemy() {Name = "Chris", HP = 0},
                new Enemy() {Name = "Claire", HP = 0},
                new Enemy() {Name = "Chloe", HP = 2},
                new Enemy() {Name = "Rebecca", HP = 10},
                new Enemy() {Name = "Giselle", HP = 34},
                new Enemy() {Name = "Kevin", HP = 45},
                new Enemy() {Name = "EZ", HP = 50},
            };

            // Filtering operators: filter a sequence based on some argument or criteria
            // var deadEnemies = enemies.Where(enemy => enemy.HP <= 0);
            //
            // foreach (var enemy in deadEnemies)
            // {
            //     Debug.Log($"Dead Enemy: {enemy.Name}");
            // }

            // Sorting operators: arrange elements in a collection(OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse)
            // var strongestEnemyFirst = enemies.OrderByDescending(enemy => enemy.HP).ToList();
            //
            // strongestEnemyFirst.ForEach(enemy => Debug.Log($"{enemy.Name}|{enemy.HP}"));

            // Grouping Operators:
            // var groupedEnemiesByHP = enemies.GroupBy(enemy => enemy.HP);
            //
            // foreach (var group in groupedEnemiesByHP)
            // {
            //     foreach (var enemy in group)
            //     {
            //         Debug.Log($"{enemy.Name} || {enemy.HP}");
            //     }
            // }

            // Projection Operators:
            // var HPs = enemies.Select(enemy => enemy.HP); // Change data we got. Now it's not enemies, it's HPs.
            // Debug.Log("Total HPs" + HPs.Sum());

            // Quantifier Operators:
            // var isEveryoneNearlyDead = enemies.All(enemy => enemy.HP <= 0);
            // Debug.Log(isEveryoneNearlyDead);

            // Element Operators: 
            // var mostHealthyEnemy = enemies.OrderByDescending(enemy => enemy.HP).FirstOrDefault();
            // if (mostHealthyEnemy != null) Debug.Log(mostHealthyEnemy.Name);

            // var HPs = enemies.Select(enemy => enemy.HP).Skip(1); // Skip count Numbers...

            // var hps = enemies.SkipWhile(enemy => enemy.HP >= 0);

            // var distinctHP = HPs.Distinct(); // Only Distinct number.


            // Grouping Operators: creates groups of elements, where each group has a key and inner collection (GroupBy, ToLookup)
            // Joining Operators: joins sequences (Join, GroupJoin)
            // Projection Operators: projects and returns collections/sequences based on a transformation (Select, SelectMany) Flattens collections that contain lists of lists.
            // Quantifier Operators: evaluates elements and returns a bool (All, Any, Contains)
            // Aggregation Operators: math operations (Aggregate, Average, Count)
            // Element Operators: returns a particular element in the sequence (ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault)
            // Equality Operators: checks number, type, value and order are equal (SequenceEqual)
            // Concatenation Operators: appends two sequences (Concat)
            // Generation Operators: returns a new collection with a default value if empty (DefaultIfEmpty, Empty, Range, Repeat)
            // Set Operators: returns new sequences, depending on the operator (Distinct, Except, Intersect, Union)
            // Partitioning Operators: split sequences and return one of the parts (Skip, SkipWhile, Take, TakeWhile)
            // Conversion Operators: convert the type of elements in a sequence (AsEnumerable, AsQueryable, Cast, OfType, ToArray, ToDictionary, ToList, ToLookup)
        }

        public class Enemy
        {
            public string Name;
            public int HP;
        }
    }
}
//Grouping Operator:creates groups of elements,where each group has a key and inner collection(Group By,ToLookUp)
