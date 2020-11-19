using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatorController : MonoBehaviour
{
    [Header("Temp")]
    public Sprite blankImage;

    [Header("Overlay")]
    public GameObject displayAvatar;
    public GameObject hairPanel;
    public GameObject eyesPanel;
    public GameObject nosePanel;
    public GameObject mouthPanel;
    public GameObject clothesPanel;
    private GameObject[] onSamples;
    private GameObject[] offSamples;

    [Header("Skin")]
    public GameObject skinImage;
    //private Sprite[] skins;

    [Header("Hair")]
    public GameObject hairImage;
    private Sprite[] hairs;

    [Header("Eyes")]
    public GameObject eyesImage;
    private Sprite[] eyes;

    [Header("Nose")]
    public GameObject noseImage;
    private Sprite[] noses;

    [Header("Mouth")]
    public GameObject mouthImage;
    private Sprite[] mouths;

    [Header("Clothes")]
    public GameObject clothesImage;
    private Sprite[] clothes;

    private bool zoomDisplay;
    private bool showSamples;

    void Start()
    {
        // Objects must be active for FindGameObjectsWithTag to function
        hairPanel.SetActive(true);
        eyesPanel.SetActive(true);
        nosePanel.SetActive(true);
        mouthPanel.SetActive(true);
        clothesPanel.SetActive(true);

        onSamples = GameObject.FindGameObjectsWithTag("Sample On");
        offSamples = GameObject.FindGameObjectsWithTag("Sample Off");

        //UpdatePrefabAttributes script;
        zoomDisplay = false;
        showSamples = false;

        foreach (GameObject sample in onSamples)
        {
            //UpdateSampleImages("all");
            //UpdateSampleColors("all");
            //script = displayAvatar.GetComponent<UpdatePrefabAttributes>();
            //if (script != null)
            //    script.SetAvatar(sample);
            sample.SetActive(showSamples);
        }
        foreach (GameObject sample in offSamples)
        {
            sample.SetActive(!showSamples);
        }

        hairPanel.SetActive(true);
        eyesPanel.SetActive(false);
        nosePanel.SetActive(false);
        mouthPanel.SetActive(false);
        clothesPanel.SetActive(false);

        //hairs = Resources.LoadAll<Sprite>("VarissaArt/Skin");
        hairs = Resources.LoadAll<Sprite>("VarissaArt/Hair");
        eyes = Resources.LoadAll<Sprite>("VarissaArt/Eyes");
        noses = Resources.LoadAll<Sprite>("VarissaArt/Nose");
        mouths = Resources.LoadAll<Sprite>("VarissaArt/Mouth");
        clothes = Resources.LoadAll<Sprite>("VarissaArt/Clothes");
    }

    public void ZoomDisplay()
    {
        zoomDisplay = !zoomDisplay;
        displayAvatar.GetComponent<RectTransform>().anchorMin = zoomDisplay ?
                new Vector2(0, -1.555f) : new Vector2(0, 0);
        displayAvatar.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
    }

    public void ToggleSamples()
    {
        showSamples = !showSamples;
        foreach (GameObject sample in onSamples)
        {
            sample.SetActive(showSamples);
        }
        foreach (GameObject sample in offSamples)
        {
            sample.SetActive(!showSamples);
        }
    }

    private void UpdateSampleImages(string _selection)
    {
        UpdatePrefabAttributes script;

        script = displayAvatar.GetComponent<UpdatePrefabAttributes>();
        if (script != null)
            script.UpdateImage(_selection);

        foreach (GameObject sample in onSamples)
        {
            script = sample.GetComponent<UpdatePrefabAttributes>();
            if (script != null)
                script.UpdateImage(_selection);
        }
    }

    private void UpdateSampleColors(string _selection)
    {
        UpdatePrefabAttributes script;

        script = displayAvatar.GetComponent<UpdatePrefabAttributes>();
        if (script != null)
            script.UpdateColor(_selection);

        foreach (GameObject sample in onSamples)
        {
            script = sample.GetComponent<UpdatePrefabAttributes>();
            if (script != null)
                script.UpdateColor(_selection);
        }
    }

    public void UpdateCatagories(int _selection)
    {
        switch (_selection)
        {
            case 0:
                hairPanel.SetActive(true);
                eyesPanel.SetActive(false);
                nosePanel.SetActive(false);
                mouthPanel.SetActive(false);
                clothesPanel.SetActive(false);
                break;
            case 1:
                hairPanel.SetActive(false);
                eyesPanel.SetActive(true);
                nosePanel.SetActive(false);
                mouthPanel.SetActive(false);
                clothesPanel.SetActive(false);
                break;
            case 2:
                hairPanel.SetActive(false);
                eyesPanel.SetActive(false);
                nosePanel.SetActive(true);
                mouthPanel.SetActive(false);
                clothesPanel.SetActive(false);
                break;
            case 3:
                hairPanel.SetActive(false);
                eyesPanel.SetActive(false);
                nosePanel.SetActive(false);
                mouthPanel.SetActive(true);
                clothesPanel.SetActive(false);
                break;
            default:
                hairPanel.SetActive(false);
                eyesPanel.SetActive(false);
                nosePanel.SetActive(false);
                mouthPanel.SetActive(false);
                clothesPanel.SetActive(true);
                break;
        }
    }

    public void UpdateSkinColor(int _selection)
    {
        switch (_selection)
        {
            case 0:
                skinImage.GetComponent<Image>().color = new Color32(182, 110, 69, 255);
                break;
            case 1:
                skinImage.GetComponent<Image>().color = new Color32(203, 146, 117, 255);
                break;
            case 2:
                skinImage.GetComponent<Image>().color = new Color32(79, 49, 57, 255);
                break;
            case 3:
                skinImage.GetComponent<Image>().color = new Color32(129, 93, 74, 255);
                break;
            case 4:
                skinImage.GetComponent<Image>().color = new Color32(254, 233, 206, 255);
                break;
            case 5:
                skinImage.GetComponent<Image>().color = new Color32(204, 151, 104, 255);
                break;
            case 6:
                skinImage.GetComponent<Image>().color = new Color32(236, 181, 132, 255);
                break;
            default:
                skinImage.GetComponent<Image>().color = new Color32(244, 203, 159, 255);
                break;
        }
        UpdateSampleColors("skin");
    }

    public void UpdateHair(int _selection)
    {
        if(_selection < 0)
        {
            hairImage.GetComponent<Image>().sprite = blankImage;
            //hairImage.SetActive(false);
            //return;
        }
        else
        {
            hairImage.GetComponent<Image>().sprite = hairs[_selection];
            //hairImage.SetActive(true);
        }
        //hairImage.GetComponent<Image>().sprite = hairs[_selection];
        UpdateSampleImages("hair");
    }

    public void UpdateHairColor(int _selection)
    {
        switch (_selection)
        {
            case 1:

                break;
        }
    }

    public void UpdateEyes(int _selection)
    {
        eyesImage.GetComponent<Image>().sprite = eyes[_selection];
        UpdateSampleImages("eyes");
    }

    public void UpdateNose(int _selection)
    {
        noseImage.GetComponent<Image>().sprite = noses[_selection];
        UpdateSampleImages("nose");
    }

    public void UpdateMouth(int _selection)
    {
        mouthImage.GetComponent<Image>().sprite = mouths[_selection];
        UpdateSampleImages("mouth");
    }

    public void UpdateClothes(int _selection)
    {
        clothesImage.GetComponent<Image>().sprite = clothes[_selection];
        UpdateSampleImages("clothes");
    }
}
