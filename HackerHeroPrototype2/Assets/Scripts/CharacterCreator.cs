using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    private GameObject[] tops;
    private GameObject[] hairs;
    private GameObject[] skins;
    private GameObject[] bottoms;
    private GameObject[] shoes;

    public GameObject parent;
    public GameObject top;
    public GameObject hair;
    public GameObject skin;
    public GameObject bottom;
    public GameObject shoe;

    private int topIndex = 1;
    private int hairIndex = 5;
    private int skinIndex = 1;
    private int bottomIndex = 4;
    private int shoesIndex = 6;
    
    // Start is called before the first frame update
    void Start()
    {
        Object[] topTemps = Resources.LoadAll("Prefabs/Top", typeof(GameObject));
        tops = new GameObject[topTemps.Length];

        for(int i = 0; i < topTemps.Length; i++)
        {
            tops[i] = Instantiate((GameObject)topTemps[i], top.transform.position, top.transform.rotation ,parent.transform);
            tops[i].SetActive(false);
        }

        Object[] hairTemps = Resources.LoadAll("Prefabs/Hair", typeof(GameObject));
        hairs = new GameObject[hairTemps.Length];
        for (int i = 0; i < hairTemps.Length; i++)
        {
            hairs[i] = Instantiate((GameObject)hairTemps[i], hair.transform.position, hair.transform.rotation, parent.transform);
            hairs[i].SetActive(false);
        }
        Object[] skinTemps = Resources.LoadAll("Prefabs/Skin", typeof(GameObject));
        skins = new GameObject[skinTemps.Length];
        for (int i = 0; i < skinTemps.Length; i++)
        {
            skins[i] = Instantiate((GameObject)skinTemps[i], skin.transform.position, skin.transform.rotation, parent.transform);
            skins[i].SetActive(false);
        }
        Object[] bottomTemps = Resources.LoadAll("Prefabs/Bottom", typeof(GameObject));
        bottoms = new GameObject[bottomTemps.Length];
        for (int i = 0; i < bottomTemps.Length; i++)
        {
            bottoms[i] = Instantiate((GameObject)bottomTemps[i], bottom.transform.position, bottom.transform.rotation, parent.transform);
            bottoms[i].SetActive(false);
        }
        Object[] shoeTemps = Resources.LoadAll("Prefabs/Shoe", typeof(GameObject));
        shoes = new GameObject[shoeTemps.Length];
        for (int i = 0; i < shoeTemps.Length; i++)
        {
            shoes[i] = Instantiate((GameObject)shoeTemps[i], shoe.transform.position, shoe.transform.rotation, parent.transform);
            shoes[i].SetActive(false);
        }

        Debug.Log(hairs.Length);
        Debug.Log(skins.Length);
        Debug.Log(tops.Length);
        Debug.Log(bottoms.Length);
        Debug.Log(shoes.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHair(int _selection)
    {
        hairIndex += _selection;
        hairIndex = hairIndex > hairs.Length-1 ? 0 : hairIndex;
        hairIndex = hairIndex < 0 ? hairs.Length-1 : hairIndex;

        GameObject currentHair = hairs[hairIndex];
        currentHair.SetActive(true);
        hair.SetActive(false);
        hair = currentHair;
    }
    public void ChangeTop(int _selection)
    {
        topIndex += _selection;
        topIndex = topIndex > tops.Length-1 ? 0 : topIndex;
        topIndex = topIndex < 0 ? tops.Length-1 : topIndex;
        
        GameObject currentTop = tops[topIndex];
        currentTop.SetActive(true);
        top.SetActive(false);
        top = currentTop;
    }
    public void ChangeBottom(int _selection)
    {
        bottomIndex += _selection;
        bottomIndex = bottomIndex > bottoms.Length-1 ? 0 : bottomIndex;
        bottomIndex = bottomIndex < 0 ? bottoms.Length-1 : bottomIndex;

        GameObject currentBottom = bottoms[bottomIndex];
        currentBottom.SetActive(true);
        bottom.SetActive(false);
        bottom = currentBottom;
    }
    public void ChangeSkin(int _selection)
    {
        skinIndex += _selection;
        skinIndex = skinIndex > skins.Length-1 ? 0 : skinIndex;
        skinIndex = skinIndex < 0 ? skins.Length-1 : skinIndex;

        GameObject currentSkin = skins[skinIndex];
        currentSkin.SetActive(true);
        skin.SetActive(false);
        skin = currentSkin;
    }
    public void ChangeShoes(int _selection) {
        shoesIndex += _selection;
        shoesIndex = shoesIndex > shoes.Length-1 ? 0 : shoesIndex;
        shoesIndex = shoesIndex < 0 ? shoes.Length-1 : shoesIndex;

        GameObject currentShoes = shoes[shoesIndex];
        currentShoes.SetActive(true);
        shoe.SetActive(false);
        shoe = currentShoes;
    }
}
