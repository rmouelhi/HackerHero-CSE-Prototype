using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFocus 
{
    private bool helpingCivilians;
    private bool solvingCrime;
    private bool hacking;
    private bool climbingRanks;

    public MissionFocus()
    {
        
        this.helpingCivilians = false;
        this.solvingCrime = false;
        this.hacking = false;
        this.climbingRanks = false; 
    }
    public MissionFocus(bool helpingCivilians, bool solvingCrime, bool hacking, bool climbingRanks)
    {
        this.helpingCivilians = helpingCivilians;
        this.solvingCrime = solvingCrime;
        this.hacking = hacking;
        this.climbingRanks = climbingRanks;

    }

    public bool HelpingCivilians { get => helpingCivilians; set => helpingCivilians = value; }
    public bool SolvingCrime { get => solvingCrime; set => solvingCrime = value; }
    public bool Hacking { get => hacking; set => hacking = value; }
    public bool ClimbingRanks { get => climbingRanks; set => climbingRanks = value; }

    public string toString()
    {
        Debug.Log("Mission toString()");
        string output = "";
        output += "Helping civilians: " + this.HelpingCivilians + "\n";
        output += "Solving Crime: " + this.solvingCrime + "\n";
        output += "Hacking: " + this.hacking + "\n";
        output += "Climbing Ranks: " + this.climbingRanks + "\n";
        return output; 
    }
}
