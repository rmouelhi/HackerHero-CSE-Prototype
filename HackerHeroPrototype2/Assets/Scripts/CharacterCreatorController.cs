using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreatorController : MonoBehaviour
{
    [Header("Temp")]
    public Sprite blankImage;

    [Header("Overlay")]
    public GameObject selectionPanel;
    public GameObject displayPanel;
    public GameObject displayAvatar;
    private GameObject[] onSamples;
    private GameObject[] offSamples;

    [Header("Skin")]
    public GameObject skinColorPanel;
    public GameObject skinImage;
    //private Sprite[] skins;

    [Header("Hair")]
    public GameObject hairImagePanel;
    public GameObject hairColorPanel;
    public GameObject hairImage;
    private Sprite[] hairs;

    [Header("Eyes")]
    public GameObject eyesImagePanel;
    public GameObject eyesImage;
    private Sprite[] eyes;

    [Header("Nose")]
    public GameObject noseImagePanel;
    public GameObject noseImage;
    private Sprite[] noses;

    [Header("Mouth")]
    public GameObject mouthImagePanel;
    public GameObject mouthImage;
    private Sprite[] mouths;

    [Header("Clothes")]
    public GameObject clothesImagePanel;
    public GameObject clothesImage;
    private Sprite[] clothes;

    private bool zoomDisplay;
    private bool enablePreview;
    private bool showSamples;

    void Start()
    {
        // Objects must be active for FindGameObjectsWithTag to function
        hairImagePanel.SetActive(true);
        eyesImagePanel.SetActive(true);
        noseImagePanel.SetActive(true);
        mouthImagePanel.SetActive(true);
        clothesImagePanel.SetActive(true);

        onSamples = GameObject.FindGameObjectsWithTag("Sample On");
        offSamples = GameObject.FindGameObjectsWithTag("Sample Off");

        //UpdatePrefabAttributes script;
        zoomDisplay = false;
        enablePreview = false;
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

        skinColorPanel.SetActive(false);
        hairImagePanel.SetActive(true);
        hairColorPanel.SetActive(true);
        eyesImagePanel.SetActive(false);
        noseImagePanel.SetActive(false);
        mouthImagePanel.SetActive(false);
        clothesImagePanel.SetActive(false);

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

    public void TogglePreview()
    {
        enablePreview = !enablePreview;

        if (!enablePreview)
        {
            displayPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0.67f);
            displayPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);

            selectionPanel.SetActive(true);
        }
        else
        {
            displayPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
            displayPanel.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);

            selectionPanel.SetActive(false);
        }

        displayPanel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        displayPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

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
                skinColorPanel.SetActive(false);
                hairImagePanel.SetActive(true);
                hairColorPanel.SetActive(true);
                eyesImagePanel.SetActive(false);
                noseImagePanel.SetActive(false);
                mouthImagePanel.SetActive(false);
                clothesImagePanel.SetActive(false);
                break;
            case 1:
                skinColorPanel.SetActive(true);
                hairImagePanel.SetActive(false);
                hairColorPanel.SetActive(false);
                eyesImagePanel.SetActive(true);
                noseImagePanel.SetActive(false);
                mouthImagePanel.SetActive(false);
                clothesImagePanel.SetActive(false);
                break;
            case 2:
                skinColorPanel.SetActive(true);
                hairImagePanel.SetActive(false);
                hairColorPanel.SetActive(false);
                eyesImagePanel.SetActive(false);
                noseImagePanel.SetActive(true);
                mouthImagePanel.SetActive(false);
                clothesImagePanel.SetActive(false);
                break;
            case 3:
                skinColorPanel.SetActive(true);
                hairImagePanel.SetActive(false);
                hairColorPanel.SetActive(false);
                eyesImagePanel.SetActive(false);
                noseImagePanel.SetActive(false);
                mouthImagePanel.SetActive(true);
                clothesImagePanel.SetActive(false);
                break;
            default:
                skinColorPanel.SetActive(true);
                hairImagePanel.SetActive(false);
                hairColorPanel.SetActive(false);
                eyesImagePanel.SetActive(false);
                noseImagePanel.SetActive(false);
                mouthImagePanel.SetActive(false);
                clothesImagePanel.SetActive(true);
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
            case 0:
                hairImage.GetComponent<Image>().color = new Color32(9, 8, 6, 255);
                break;
            case 1:
                hairImage.GetComponent<Image>().color = new Color32(59, 49, 38, 255);
                break;
            case 2:
                hairImage.GetComponent<Image>().color = new Color32(83, 61, 58, 255);
                break;
            case 3:
                hairImage.GetComponent<Image>().color = new Color32(106, 78, 66, 255);
                break;
            case 4:
                hairImage.GetComponent<Image>().color = new Color32(145, 85, 61, 255);
                break;
            case 5:
                hairImage.GetComponent<Image>().color = new Color32(181, 82, 57, 255);
                break;
            case 6:
                hairImage.GetComponent<Image>().color = new Color32(242, 218, 145, 255);
                break;
            case 7:
                hairImage.GetComponent<Image>().color = new Color32(238, 206, 168, 255);
                break;
            case 8:
                hairImage.GetComponent<Image>().color = new Color32(113, 99, 93, 255);
                break;
            case 9:
                hairImage.GetComponent<Image>().color = new Color32(255, 24, 225, 255);
                break;
            case 10:
                hairImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                break;
            case 11:
                hairImage.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
                break;
            case 12:
                hairImage.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
                break;
            case 13:
                hairImage.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;
            case 14:
                hairImage.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
                break;
            case 15:
                hairImage.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                break;
        }
        UpdateSampleColors("hair");
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
