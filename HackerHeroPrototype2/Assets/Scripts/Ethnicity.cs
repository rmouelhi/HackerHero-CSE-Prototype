using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ethnicity : MonoBehaviour
{
   private string name;
   public Ethnicity(string input)
    {
        this.Name = input;
    }

    public global::System.String Name { get => name; set => name = value; }

    public string toString()
    {
        return name;
    }
}
