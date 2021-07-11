using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class BeaconController : MonoBehaviour
{
    private TeleportationAnchor[] arr_TeleAnchors;


    // Start is called before the first frame update
    void Start()
    {
        arr_TeleAnchors = GetComponentsInChildren<TeleportationAnchor>();

    }

    public void OnActivated()
    {
        

        string name_Selected = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name_Selected);
        
        /*
        string[] name_Splited = name_Selected.Split('_');
        int sector_selected = int.Parse(name_Splited[3]);
        PhotoController.instance.ChangeSpace(sector_selected);
        MiniMapController.instance.ChangeColor(sector_selected);
        */

    }





}
