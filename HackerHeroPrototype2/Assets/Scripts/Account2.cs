using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account2 : MonoBehaviour
{
	private Pronouns pronouns;
	private Gender gender;
	private List<Ethnicity> ethnicities;
	private Superpower superPower;
	private MissionFocus focus;
	private string name;
	private int gradeLvl;

	public Account2()
	{
		this.pronouns = null;
		this.gender = null;
		this.ethnicities = null;
		this.superPower = null;
		this.focus = null;
		this.name = null;
		this.gradeLvl = 0;
	}

    public Pronouns Pronouns { get => pronouns; set => pronouns = value; }
    public Gender Gender { get => gender; set => gender = value; }
    public List<Ethnicity> Ethnicities { get => ethnicities; set => ethnicities = value; }
    public Superpower SuperPower { get => superPower; set => superPower = value; }
    public MissionFocus Focus { get => focus; set => focus = value; }
    
    public global::System.Int32 GradeLvl { get => gradeLvl; set => gradeLvl = value; }

	public void setName(string name)
    {
		this.name = name;
    }
	public string getName()
    {
		return this.name;
    }
}
