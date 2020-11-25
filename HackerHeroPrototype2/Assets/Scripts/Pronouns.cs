using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pronouns
{
    private string subject;
    private string objectPronoun;
    private string possessive;
    private string reflexive;

    public Pronouns()
    {
        this.subject = "";
        this.objectPronoun = "";
        this.possessive = "";
        this.reflexive = "";
    }


    public Pronouns(string subject, string objectPronoun, string possessive, string reflexive)
    {
        this.subject = subject;
        this.objectPronoun = objectPronoun;
        this.possessive = possessive;
        this.reflexive = reflexive;
    }

    public global::System.String Subject { get => subject; set => subject = value; }
    public global::System.String ObjectPronoun { get => objectPronoun; set => objectPronoun = value; }
    public global::System.String Possessive { get => possessive; set => possessive = value; }
    public global::System.String Reflexive { get => reflexive; set => reflexive = value; }



    public string toString()
    {
        string output = "";
        output += "Subject: " + this.subject + "\n";
        output += "Object: " + this.objectPronoun + "\n";
        output += "Possessive: " + this.possessive + "\n";
        output += "Reflexive: " + this.reflexive + "\n";
        return output; 
    }
}
