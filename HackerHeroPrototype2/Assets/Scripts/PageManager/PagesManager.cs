using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PagesManager : MonoBehaviour
{
    private int numberOfPages;
    public int GetNumOfPages() { return numberOfPages; }

    private int currentPage;
    public int GetCurrentPage() { return currentPage; }

    // list of items with the "Day/Night" Tag
    private GameObject[] dnTagged;

    private bool dnToggle;
    // To edit background color
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        numberOfPages = transform.childCount - 1;
        currentPage = 0;

        CollectTag("ToggleText");

        for (int i = 1; i < numberOfPages; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePage(int _selection)
    {
        transform.GetChild(currentPage).gameObject.SetActive(false);
        currentPage += _selection;
        transform.GetChild(currentPage).gameObject.SetActive(true);
    }

    public void JumpToPage(int _selection)
    {
        transform.GetChild(currentPage).gameObject.SetActive(false);
        currentPage = _selection;
        transform.GetChild(currentPage).gameObject.SetActive(true);
    }

    private void CollectTag(string _tagName)
    {
        for (int i = 0; i < numberOfPages; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        dnTagged = GameObject.FindGameObjectsWithTag(_tagName);
    }

    public void ToggleDayNight()
    {
        dnToggle = !dnToggle;
        
        Text textComponent;
        TMP_Text tmpComponent;
        if (dnToggle)
        {
            mainCamera.GetComponent<Camera>().backgroundColor = Color.white;
            foreach (GameObject text in dnTagged)
            {
                textComponent = text.GetComponent<Text>();
                if (textComponent != null)
                {
                    textComponent.color = Color.black;
                }
                else
                {
                    tmpComponent = text.GetComponent<TMP_Text>();
                    if (tmpComponent != null)
                    {
                        tmpComponent.color = Color.black;
                    }
                }

            }
        }
        else
        {
            mainCamera.GetComponent<Camera>().backgroundColor = Color.black;
            foreach (GameObject text in dnTagged)
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
}
