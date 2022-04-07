using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Linq : MonoBehaviour
{
    //Language
    //INTegrated
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
}
