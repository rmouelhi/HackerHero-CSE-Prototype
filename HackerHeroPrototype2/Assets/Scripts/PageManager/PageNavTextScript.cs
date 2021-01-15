using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PageNavTextScript : MonoBehaviour
{
    public GameObject pagesManager;
    private PagesManager pagesManagerScript;

    private int numberOfPages;
    private int currentPage;
    
    private TMP_Text maxPageText;
    private TMP_Text currentPageTempText;
    private TMP_Text currentPageText;
    private TMP_InputField currentPageField;

    // Start is called before the first frame update
    void Start()
    {
        pagesManagerScript = pagesManager.GetComponent<PagesManager>();
        numberOfPages = pagesManagerScript.GetNumOfPages();
        currentPage = pagesManagerScript.GetCurrentPage();

        maxPageText = transform.GetChild(0).GetComponent<TMP_Text>();
        currentPageTempText = transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        //currentPageText = transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TMP_Text>();\
        currentPageField = transform.GetChild(1).GetComponent<TMP_InputField>();

        UpdateMaxPage();
    }

    // Update the text to show max number of pages
    void UpdateMaxPage()
    {
        numberOfPages = pagesManagerScript.GetNumOfPages();
        maxPageText.text = "/ " + numberOfPages;
    }

    // Called by buttons to update current page on placeholder text
    public void UpdateCurrentPage()
    {
        currentPage = pagesManagerScript.GetCurrentPage();
        currentPageTempText.text = (currentPage + 1).ToString();
    }

    // Calls Pages JumpTo function and shifts index value (starts at 1, moves to 0)
    public void JumpToPage()
    {
        Debug.Log(currentPageField.text);
        //To Do: add try catch exception for parse attempt
        int destination = int.Parse(currentPageField.text) - 1;

        // Clear Input Field (to display temp text)
        currentPageField.text = "";

        pagesManagerScript.JumpToPage(destination);
        UpdateCurrentPage();
    }
}
