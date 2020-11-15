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
    private string[] pronouns; // Subjective, Objective, Possesive, Possesive Pronoun
    private string genderID;
    private string ethnicity;
    private int gradeLvl;
    private string hasDisability;
    //public Account2 account;
    


    public GameObject[] panels = new GameObject[9];
    public GameObject AccountPage1;
    public GameObject AccountPage2;
    public GameObject AccountPage3;
    public GameObject AccountPage4;
    public GameObject AccountPage5;
    public GameObject AccountPage6;
    public GameObject AccountPage7;
    public GameObject AccountPage8;
    public GameObject AvatarPage;
    public RectTransform progressMask;
    private const float PROGRESS_RATE = 0.14f;

    [Header("Page 1")]
    public TMP_InputField nameField;

    [Header("Page 2")]
    public GameObject pronounFieldObj; // used to show/hide
    public TMP_InputField pronounField;

    public struct Account
    {
        string name;
        string[] pronouns; // Subjective, Objective, Possesive, Possesive Pronoun
        string genderID;
        string ethnicity;
        string hasDisability;
        int gradeLvl;

        public Account(string _name, string[] _pronouns, string _genderID, string _ethnicity, string _hasDisability, int _gradeLvl)
        {
            name = _name;
            pronouns = _pronouns;
            genderID = _genderID;
            ethnicity = _ethnicity;
            hasDisability = _hasDisability;
            gradeLvl = _gradeLvl;
        }
    }

    public void Start()
    {
        currentPage = 0;
        //Account2 account = new Account2();
        ChangePanelHelper(0);

        currentProgress = 0.02f; // Temp!!! TODO check progress
        acntName = null; // Temp!
        pronouns = new string[4];
    }

    public void ChangePage(int direction)
    {
        currentPage += direction;
       
        


        Debug.Log(AccountToString()); // Temp!



        switch (currentPage)
        {
            case 0:
                ChangePanelHelper(currentPage);
                break;
            case 1: // Name Page
                //progressMask.localScale = new Vector3(0.1f, 1f, 1f);
                ChangePanelHelper(currentPage);
                break;
            case 2: // Pronoun Page
                ChangePanelHelper(currentPage);
                UpdateName();
               
                break;
            case 3: // Gender Page
                
                progressMask.localScale = new Vector3(PROGRESS_RATE * 2 + currentProgress, 1f, 1f);
                if (acntName != null)
                {
                    progressMask.localScale = new Vector3(PROGRESS_RATE + currentProgress, 1f, 1f);
                    ChangePanelHelper(currentPage);

                    if (pronouns[0] == null)
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
            case 4:
                progressMask.localScale = new Vector3(PROGRESS_RATE * 3 + currentProgress, 1f, 1f);
                ChangePanelHelper(currentPage);
                if (genderID == null)
                {
                    UpdateGender(0);
                }
               

            
                break;
            case 5:
                progressMask.localScale = new Vector3(PROGRESS_RATE * 4 + currentProgress, 1f, 1f);
                ChangePanelHelper(currentPage);
                if (ethnicity == null)
                {
                    UpdateEthnicity(0);
                }
               
              
                break;
            case 6:
                progressMask.localScale = new Vector3(PROGRESS_RATE * 5 + currentProgress, 1f, 1f);
                ChangePanelHelper(currentPage);
                if (hasDisability == null)
                {
                    UpdateDisability(0);
                }
                
             
                break;
            case 7:
                progressMask.localScale = new Vector3(PROGRESS_RATE * 6 + currentProgress, 1f, 1f);
                ChangePanelHelper(currentPage);
                if (gradeLvl == 0)
                {
                    UpdateGrade(3);
                }
                break;
            case 8:
                ChangePanelHelper(currentPage);

                break;

            case 9:
                ChangePanelHelper(currentPage);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
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
            /*if (acntName == null)
            {
                currentProgress += PROGRESS_RATE;
                progressMask.localScale = new Vector3(currentProgress, 1f, 1f);
            }*/

            acntName = nameField.text;
            //account.setName(nameField.text);

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
                pronounFieldObj.SetActive(false);
                pronouns[0] = "she";
                pronouns[1] = "her";
                pronouns[2] = "her";
                pronouns[3] = "hers";
                break;
            case 1:
                pronounFieldObj.SetActive(false);
                pronouns[0] = "he";
                pronouns[1] = "him";
                pronouns[2] = "his";
                pronouns[3] = "his";
                break;
            case 2:
                pronounFieldObj.SetActive(false);
                pronouns[0] = "they";
                pronouns[1] = "them";
                pronouns[2] = "their";
                pronouns[3] = "theirs";
                break;
            default:
                pronounFieldObj.SetActive(true);
                // TEMP !!! TODO: Add string parser, validator, and update currentProgress
                pronouns[0] = "Xe"; // temp
                pronouns[1] = "Xem"; // temp
                pronouns[2] = "Xyr"; // temp
                pronouns[3] = "Xyrs"; // temp
                break;
        }
        
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
                genderID = "girl";
                break;
            case 1:
                genderID = "boy";
                break;
            case 2:
                genderID = "non-binary";
                break;
            default:
                genderID = "unknown";
                break;
        }
    }

    public void UpdateEthnicity(int _selection)
    {

        
        switch (_selection)
        {
            case 0:
                ethnicity = "Black/African-American";
                break;
            case 1:
                ethnicity = "Indigenous/Native-American";
                break;
            case 2:
                ethnicity = "white";
                break;
            case 3:
                ethnicity = "unknown";
                break;
            case 4:
                ethnicity = "latinx";
                break;
            case 5:
                ethnicity = "middle eastern";
                break;
            case 6:
                ethnicity = "asian";
                break;
            default:
                ethnicity = "other";
                break;
        }
    }

    public void UpdateDisability(int _selection)
    {
        switch (_selection)
        {
            case 0:
                
                hasDisability = "yes";
                break;
            case 1:
                hasDisability = "no";
                break;
            case 2:
                hasDisability = "unsure";
                break;
            default:
                hasDisability = "unknown";
                break;
        }
    }

    public void UpdateGrade(int _selection)
    {

        gradeLvl = _selection;
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
    private string AccountToString()
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
    }
}
