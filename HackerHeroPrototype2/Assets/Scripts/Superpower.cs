using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superpower : MonoBehaviour
{
    string superpowers;
    public  Superpower(string superpower)
    {
        this.superpowers = superpower;
    }

    public global::System.String Superpowers { get => superpowers; set => superpowers = value; }
}
