using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account2 : MonoBehaviour
{
	private Pronouns pronouns;
	private Gender gender;
	
	private Superpower superPower;
	private MissionFocus missions;
	private string name;
	private int gradeLvl;

	public Account2()
	{

		Debug.Log("Account created");
		this.name = null;
		this.pronouns = null;
		this.gender = null;
		this.superPower = null;
		this.missions = null;

		this.gradeLvl = 0;
	}

    public Pronouns Pronouns { get => pronouns; set => pronouns = value; }
    public Gender Gender { get => gender; set => gender = value; }
    public Superpower SuperPower { get => superPower; set => superPower = value; }
    public MissionFocus Missions { get => missions; set => missions = value; }
    
    public global::System.Int32 GradeLvl { get => gradeLvl; set => gradeLvl = value; }

	public void setName(string name)
    {
		this.name = name;
    }
	public string getName()
    {
		return this.name;
    }


	public string toString()
    {
		string output = "Name: " + this.name + "\n";
		if(pronouns != null)
        {
			output += "Pronouns: \n" + pronouns.toString() + "\n";
		}
		if(gender != null)
        {
			output += gender.toString() + "\n";
        }
		if(this.gradeLvl != 0)
        {
			output += "Grade Level: " + this.gradeLvl + "\n";
        }
		if(missions != null)
        {
			output += missions.toString();
			Debug.Log("Mission is not null"); // missions is null find out why
        } 
		if(superPower != null)
        {
			output += superPower.toString();
        }
		return output; 
    }
}
