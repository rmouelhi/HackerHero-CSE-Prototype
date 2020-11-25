using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender 
{
    private string genders;


    public Gender()
    {
        this.genders = "";
    }
    public Gender(string gender)
    {
        this.genders = gender;
    }

    public global::System.String Genders { get => genders; set => genders = value; }


    public string toString()
    {
        return "Gender: " + this.genders + "\n";
    }
}
