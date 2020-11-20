using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePrefabAttributes : MonoBehaviour
{
    [Header("Override")]
    public bool overrideSkin;
    public bool overrideHair;
    public bool overrideEyes;
    public bool overrideNose;
    public bool overrideMouth;
    //public bool overrideShoes;
    public bool overrideClothes;

    private GameObject avatar;
    private GameObject skin;
    private GameObject hair;
    private GameObject eyes;
    private GameObject nose;
    private GameObject mouth;
    //private Transform shoes;
    private GameObject clothes;

    private Transform skinChild;
    private Transform hairChild;
    private Transform eyesChild;
    private Transform noseChild;
    private Transform mouthChild;
    //private Transform shoesChild;
    private Transform clothesChild;

    //public void SetAvatar(GameObject _avatar) { avatar = _avatar; StartInstance(); }

    void Start()
    {
        /*
        skin = avatar.transform.GetChild(0);
        hair = avatar.transform.GetChild(1);
        eyes = avatar.transform.GetChild(2);
        nose = avatar.transform.GetChild(3);
        mouth = avatar.transform.GetChild(4);
        //shoes = avatar.transform.GetChild(5);
        clothes = avatar.transform.GetChild(6);
        */

        //*
        avatar = Resources.Load<GameObject>("Prefabs/Character/AvatarImage");
        skin = Resources.Load<GameObject>("Prefabs/Character/SkinImage");
        hair = Resources.Load<GameObject>("Prefabs/Character/HairImage");
        eyes = Resources.Load<GameObject>("Prefabs/Character/EyesImage");
        nose = Resources.Load<GameObject>("Prefabs/Character/NoseImage");
        mouth = Resources.Load<GameObject>("Prefabs/Character/MouthImage");
        //shoes = Resources.Load<GameObject>("Prefabs/Character/ShoesImage");
        clothes = Resources.Load<GameObject>("Prefabs/Character/ClothesImage");
        //*/

        skinChild = gameObject.transform.GetChild(0);
        //shoesChild = gameObject.transform.GetChild(1);
        clothesChild = gameObject.transform.GetChild(2);
        eyesChild = gameObject.transform.GetChild(3);
        noseChild = gameObject.transform.GetChild(4);
        mouthChild = gameObject.transform.GetChild(5);
        hairChild = gameObject.transform.GetChild(6);
    }

    public void UpdateImage(string _selection)
    {
        //gameObject.transform.GetChild(0);
        skinChild.GetComponent<Image>().color = skin.GetComponent<Image>().color;
        
        switch (_selection.ToLower())
        {
            case "skin":
                if (!overrideSkin)
                    skinChild.GetComponent<Image>().sprite = skin.GetComponent<Image>().sprite;
                break;
            case "hair":
                if (!overrideHair)
                    hairChild.GetComponent<Image>().sprite = hair.GetComponent<Image>().sprite;
                break;
            case "eyes":
                if (!overrideEyes)
                    eyesChild.GetComponent<Image>().sprite = eyes.GetComponent<Image>().sprite;
                break;
            case "nose":
                if (!overrideNose)
                    noseChild.GetComponent<Image>().sprite = nose.GetComponent<Image>().sprite;
                break;
            case "mouth":
                if (!overrideMouth)
                    mouthChild.GetComponent<Image>().sprite = mouth.GetComponent<Image>().sprite;
                break;
            case "clothes":
                if (!overrideClothes)
                    clothesChild.GetComponent<Image>().sprite = clothes.GetComponent<Image>().sprite;
                break;
            case "all":
                UpdateImage("skin"); UpdateImage("hair"); UpdateImage("eyes"); UpdateImage("nose"); UpdateImage("mouth"); UpdateImage("clothes");
                break;
        }
    }

    public void UpdateColor(string _selection)
    {
        switch (_selection.ToLower())
        {
            case "skin":
                skinChild.GetComponent<Image>().color = skin.GetComponent<Image>().color;
                break;
            case "hair":
                hairChild.GetComponent<Image>().color = hair.GetComponent<Image>().color;
                break;
            case "all":
                UpdateImage("skin");
                break;
        }
    }
}
