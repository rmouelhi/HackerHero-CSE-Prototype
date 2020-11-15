using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pronouns : MonoBehaviour
{
    private string subject;
    private string objectPronoun;
    private string possessive;
    private string reflexive;


    public Pronouns(string subject, string objectPronoun, string possessive, string reflexive)
    {
        this.Subject = subject;
        this.ObjectPronoun = objectPronoun;
        this.Possessive = possessive;
        this.Reflexive = reflexive;
    }

    public global::System.String Subject { get => subject; set => subject = value; }
    public global::System.String ObjectPronoun { get => objectPronoun; set => objectPronoun = value; }
    public global::System.String Possessive { get => Possessive; set => Possessive = value; }
    public global::System.String Reflexive { get => reflexive; set => reflexive = value; }
}
