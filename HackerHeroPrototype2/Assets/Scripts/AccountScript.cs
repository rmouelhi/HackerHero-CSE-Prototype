using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccountScript : MonoBehaviour
{
    //public Account account;
    private int currentPage;
    private float currentProgress;
    private string acntName;
    //private string[] pronouns; // Subjective, Objective, Possesive, Possesive Pronoun
    private string genderID;
    private string ethnicity;
    private int gradeLvl;
    private string hasDisability;
    private Pronouns pronouns;
    private MissionFocus missions;
    private Gender gender;
    public Account account;
    private bool helpingCivilians, hacking, climbingRanks, solvingCrime, pronounHelp, genderHelp,dayNight;
    
    [Header("Settings")]
    public GameObject[] panels = new GameObject[10];
    public GameObject mainCamera;
    private GameObject[] toggleList;
    [Header("Progress Bar")]
    public GameObject progressBar;
    public GameObject nextButton;
    public GameObject previousButton;
    public RectTransform progressMask;
    private const float PROGRESS_RATE = 0.14f;

    [Header("Name")]
    public TMP_InputField nameField;

    [Header("Pronouns")]
    public GameObject subjectFieldObj; // used to show/hide
    public TMP_InputField subjectField;
    public GameObject objectFieldObj;
    public TMP_InputField objectField;
    public GameObject possessiveFieldObj;
    public TMP_InputField possessiveField;
    public GameObject reflexiveFieldObj;
    public TMP_InputField reflexiveField;

    public GameObject pronounDefinition;

    [Header("Gender")]
    public GameObject genderFieldObj;
    public TMP_InputField genderField;
    public GameObject genderDefinition;
    [Header("Superpower")]
    public TMP_InputField superPowerField;
    
    public void Start()
    {
        account = new Account(); //temp
        missions = new MissionFocus();
        genderDefinition.SetActive(false);
        pronounDefinition.SetActive(false);
        currentPage = 0;
        
        

        currentProgress = 0.02f; // Temp!!! TODO check progress
        acntName = null; // Temp!
        helpingCivilians = false;
        solvingCrime = false;
        hacking = false;
        climbingRanks = false; //temp!
        progressBar.SetActive(false);
        previousButton.SetActive(false);
        dayNight = false;


        SetAllPanelsActive();
        toggleList = GameObject.FindGameObjectsWithTag("ToggleText");
        Debug.Log("toggleList length: " + toggleList.Length);
        ChangePanelHelper(0);
    }
    /*
    public void ChangePage(int direction)
    {
        currentPage += direction;

        Debug.Log(account.toString());



        switch (currentPage)
        {
            case 0: //intro page 1
                progressBar.SetActive(false);
                previousButton.SetActive(false);
                ChangePanelHelper(currentPage);
                break;
            case 1: //intro page 2
                progressBar.SetActive(false);
                previousButton.SetActive(false);
                nextButton.SetActive(true);
                
                ChangePanelHelper(currentPage);
                break;
            case 2: //name
                progressBar.SetActive(true);
                progressMask.localScale = new Vector3(0.16f, 1f, 1f);
                ChangePanelHelper(currentPage);
                UpdateName();
               
                break;
            case 3: //pronouns
                
                
                if (acntName != null)
                {
                    progressBar.SetActive(true);
                    previousButton.SetActive(true);
                    progressMask.localScale = new Vector3(0.16f*2f , 1f, 1f);
                    ChangePanelHelper(currentPage);
                    if(pronouns == null)
                    {
                        UpdatePronouns(0);
                    }
                    
                }
                else
                {
                    Debug.Log("Name is missing!");
                    // Undo page change
                    currentPage -= direction;
                }
                ChangePanelHelper(currentPage);

                
                break;
            case 4: //gender
                progressBar.SetActive(true);
                previousButton.SetActive(true);
                progressMask.localScale = new Vector3(0.16f * 3f , 1f, 1f);
                ChangePanelHelper(currentPage);
                if (gender == null)
                {
                    UpdateGender(0);
                }
               

            
                break;
            case 5: //grade
                progressBar.SetActive(true);
                previousButton.SetActive(true);
                progressMask.localScale = new Vector3(0.16f * 4f , 1f, 1f);
                ChangePanelHelper(currentPage);
                
               
              
                break;
            case 6: //missions
                progressBar.SetActive(true);
                previousButton.SetActive(true);
                progressMask.localScale = new Vector3(0.16f * 5f , 1f, 1f);
                ChangePanelHelper(currentPage);
                
               
                
             
                break;
            case 7: //superpower
                progressBar.SetActive(true);
                previousButton.SetActive(true);
                progressMask.localScale = new Vector3(1f , 1f, 1f);
                ChangePanelHelper(currentPage);
                if (gradeLvl == 0)
                {
                    UpdateGrade(3);
                }
                break;
            case 8: //"Grea job agent, Now it is time to create your avatar"
                progressBar.SetActive(false);
                previousButton.SetActive(false);
                ChangePanelHelper(currentPage);

                break;

            case 9: //character creator
                progressBar.SetActive(false);
                nextButton.SetActive(false);
                previousButton.SetActive(false);
                ChangePanelHelper(currentPage);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }
    */
    public void SetAllPanelsActive()
    {
        foreach(GameObject panel in panels)
        {
            panel.SetActive(true);
        }
    }
    public void ChangePanelHelper(int pageNumber)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if(i == pageNumber)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }
    public void UpdateName()
    {
        if (nameField.text != "")
        {
            if (acntName == null)
            {
                currentProgress += PROGRESS_RATE;
                progressMask.localScale = new Vector3(currentProgress, 1f, 1f);
            }

            acntName = nameField.text;
            account.setName(nameField.text);

        }
        else
        {
            Debug.Log("Name field is empty");
        }
    }

    public void UpdatePronouns(int _selection)
    {
         
        /*if (pronouns[0] == null)
        {
            currentProgress += PROGRESS_RATE;
            progressMask.localScale = new Vector3(currentProgress, 1f, 1f);
        }*/
        
        switch (_selection)
        {
            case 0:
                subjectFieldObj.SetActive(false);
                objectFieldObj.SetActive(false);
                possessiveFieldObj.SetActive(false);
                reflexiveFieldObj.SetActive(false);
                pronouns = new Pronouns("they", "them", "their", "themselves");
                account.Pronouns = pronouns;
                break;
            case 1:
                subjectFieldObj.SetActive(false);
                objectFieldObj.SetActive(false);
                possessiveFieldObj.SetActive(false);
                reflexiveFieldObj.SetActive(false);
                pronouns = new Pronouns("she", "her", "hers", "herself");
                account.Pronouns = pronouns;
                break;
            case 2:
                subjectFieldObj.SetActive(false);
                objectFieldObj.SetActive(false);
                possessiveFieldObj.SetActive(false);
                reflexiveFieldObj.SetActive(false);
                pronouns = new Pronouns("he", "him", "his", "himself");
                account.Pronouns = pronouns;
                
               
                break;
            default:
                subjectFieldObj.SetActive(true);
                objectFieldObj.SetActive(true);
                possessiveFieldObj.SetActive(true);
                reflexiveFieldObj.SetActive(true);
                pronouns = new Pronouns();
                account.Pronouns = pronouns;
                // TEMP !!! TODO: Add string parser, validator, and update currentProgress

                break;
        }
        
    }

    public void UpdateSubject()
    {
        
        if(subjectField.text != "") pronouns.Subject = subjectField.text;
        account.Pronouns = pronouns;
    }
    public void UpdateObjectPronoun()
    {
        if (objectField.text != "") pronouns.ObjectPronoun = objectField.text;
        account.Pronouns = pronouns;
    }
    public void UpdatePossessive()
    {
        if (possessiveField.text != "") pronouns.Possessive = possessiveField.text;
        
        account.Pronouns = pronouns;
    }
    public void UpdateReflexive()
    {
        if (reflexiveField.text != "") pronouns.Reflexive = reflexiveField.text;
        account.Pronouns = pronouns;
    }
    
    public void UpdateGender(int _selection)
    {
        /*if (genderID == null)
        {
            currentProgress += PROGRESS_RATE;
            progressMask.localScale = new Vector3(currentProgress, 1f, 1f);
        }*/

        switch (_selection)
        {
            case 0:
                genderFieldObj.SetActive(false);
                gender = new Gender("non-binary");
                account.Gender = gender;
                break;
            case 1:
                genderFieldObj.SetActive(false);
                gender = new Gender("boy");
                account.Gender = gender;
                break;
            case 2:
                genderFieldObj.SetActive(false);
                gender = new Gender("girl");
                account.Gender = gender;
                break;
            default:
                genderFieldObj.SetActive(true);
                gender = new Gender();
                account.Gender = gender;
                break;
        }
    }

    public void CustomGender()
    {
        if (genderField.text != "") gender.Genders = genderField.text;
        account.Gender = gender; 
    }

    public void UpdateGrade(int _selection)
    {

        account.GradeLvl = _selection;
    }

    public void HelpingCivilians()
    {
        helpingCivilians = !helpingCivilians;
        missions.HelpingCivilians = helpingCivilians;
        account.Missions = missions;
    }
    public void HackingSystem()
    {
        hacking = !hacking;
        missions.Hacking = hacking;
        account.Missions = missions;
    }
    public void SolvingCrime()
    {
        solvingCrime = !solvingCrime;
        missions.SolvingCrime = solvingCrime;
        account.Missions = missions;


    }
    public void ClimbingRanks()
    {
        climbingRanks = !climbingRanks;
        missions.ClimbingRanks = climbingRanks;
        account.Missions = missions;

    }
    public void UpdateSuperPower()
    {
        if (superPowerField.text != "")
        {
            string input = superPowerField.text;
            Superpower superpower = new Superpower(input);
            account.SuperPower = superpower;
            

        }
        else
        {
            Debug.Log("Name field is empty");
        }
    }
    public void togglePronounPanel()
    {
        pronounHelp = !pronounHelp;
        pronounDefinition.SetActive(pronounHelp);
    }
    public void toggleGenderPanel()
    {
        genderHelp = !genderHelp;
        genderDefinition.SetActive(genderHelp);
    }

    public void toggleDayNightMode()
    {
        Text textComponent;
        TMP_Text tmpComponent;
        dayNight = !dayNight;
        if (dayNight)
        {
            mainCamera.GetComponent<Camera>().backgroundColor = Color.white;
            foreach(GameObject text in toggleList)
            {
                textComponent = text.GetComponent<Text>();
                if(textComponent != null)
                {
                    textComponent.color = Color.black;
                }
                else
                {
                    tmpComponent = text.GetComponent<TMP_Text>();
                    if(tmpComponent != null)
                    {
                        tmpComponent.color = Color.black;
                    }
                }
                
            }
        }
        else
        {
            mainCamera.GetComponent<Camera>().backgroundColor = Color.black;
            foreach (GameObject text in toggleList)
            {
                textComponent = text.GetComponent<Text>();
                if (textComponent != null)
                {
                    textComponent.color = Color.white;
                }
                else
                {
                    tmpComponent = text.GetComponent<TMP_Text>();
                    if (tmpComponent != null)
                    {
                        tmpComponent.color = Color.white;
                    }
                }
            }
        }
        
    }
    


    //#################### SAVE AND LOAD ACCOUNT FOR SERVER AND CLIENT ####################//

    /*
    public void CreateAccount()
    {
        account = new Account(acntName, pronouns, genderID, ethnicity, hasDisability, gradeLvl);
    }
    
    //create txt file to store account values on the client
    public void SaveAccountClient()
    {

    }

    //fetch account values from txt file stored on the client
    public void LoadAccountClient()
    {
        Account m_Account = new Account();
        account = m_Account;
    }

    //create txt file to store account values on the server
    public void SaveAccountServer()
    {

    }

    //fetch account values from txt file stored on the server
    public void LoadAccountServer()
    {
        Account m_Account = new Account();
        account = m_Account;
    }
    */

    //#####################################################################################//

    // Will migrated into Account struct
    /*private string AccountToString()
    {
        string accnt = "";
        accnt = currentPage != -1 ? accnt + "currentPage: " + currentPage + "\n" : accnt;  // temp
        accnt = currentProgress != -1 ? accnt + "currentProgress: " + currentProgress + "\n" : accnt;  // temp
        accnt = acntName != null ? accnt + "acntName: " + acntName + "\n" : accnt;
        accnt = pronouns[0] != null ? accnt + "pronouns: " + pronouns[0] + "/" + pronouns[1] + "/" + pronouns[2] + "/" + pronouns[3] + "\n" : accnt;
        accnt = genderID != null ? accnt + "genderID: " + genderID + "\n" : accnt;
        accnt = ethnicity != null ? accnt + "ethnicity: " + ethnicity + "\n" : accnt;
        accnt = hasDisability != null ? accnt + "hasDisability: " + hasDisability + "\n" : accnt;
        accnt = gradeLvl != 0 ? accnt + "gradeLvl: " + gradeLvl + "\n" : accnt;
        return accnt;
    }*/
}
