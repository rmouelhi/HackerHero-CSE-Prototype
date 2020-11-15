using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFocus : MonoBehaviour
{
    private bool helpingCivilians;
    private bool solvingCrime;
    private bool hacking;
    private bool climbingRanks;

    public MissionFocus(bool helpingCivilians, bool solvingCrime, bool hacking, bool climbingRanks)
    {
        this.HelpingCivilians = helpingCivilians;
        this.SolvingCrime = solvingCrime;
        this.Hacking = hacking;
        this.ClimbingRanks = climbingRanks;

    }

    public bool HelpingCivilians { get => helpingCivilians; set => helpingCivilians = value; }
    public bool SolvingCrime { get => solvingCrime; set => solvingCrime = value; }
    public bool Hacking { get => hacking; set => hacking = value; }
    public bool ClimbingRanks { get => climbingRanks; set => climbingRanks = value; }
}
