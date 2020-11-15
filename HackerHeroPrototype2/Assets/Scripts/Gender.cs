using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender : MonoBehaviour
{
    private string genders;

    public Gender(string gender)
    {
        this.Genders = gender;
    }

    public global::System.String Genders { get => genders; set => genders = value; }
}
