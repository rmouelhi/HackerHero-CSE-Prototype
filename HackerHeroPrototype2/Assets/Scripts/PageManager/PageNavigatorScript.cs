using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageNavigatorScript : MonoBehaviour
{
    public GameObject pagesManager;
    private PagesManager pagesManagerScript;
    
    private int numberOfPages;
    private int currentPage;

    private Transform navigatorMask;
    private Transform currentPagePip;

    // Start is called before the first frame update
    void Start()
    {
        pagesManagerScript = pagesManager.GetComponent<PagesManager>();
        numberOfPages = pagesManagerScript.GetNumOfPages();
        currentPage = pagesManagerScript.GetCurrentPage();

        navigatorMask = transform.GetChild(0);
        currentPagePip = transform.GetChild(0).GetChild(0);

        // Set Pips for Page Navigator
        ResizeNavigator();
    }

    // Called by buttons to move pip
    public void UpdateCurrentPage()
    {
        currentPage = pagesManagerScript.GetCurrentPage();
        currentPagePip.GetComponent<RectTransform>().anchoredPosition = new Vector3(currentPage + 0.5f,0,0);
    }

    void ResizeNavigator()
    {
        numberOfPages = pagesManagerScript.GetNumOfPages();
        navigatorMask.GetComponent<RectTransform>().sizeDelta = new Vector2(numberOfPages, 1);
        /*
        if (numberOfPages != 0)
        {
            return;
        }
        ResizeNavigator();
        */
    }
}
