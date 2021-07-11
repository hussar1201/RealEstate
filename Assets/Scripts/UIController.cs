using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public Button[] arr_Btns;
    private bool flag_actived = false;

    public static UIController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIController>();
            }
            return m_instance;
        }
    }

    private static UIController m_instance;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        arr_Btns = GetComponentsInChildren<Button>();
        gameObject.SetActive(flag_actived);

    }

    public void OnClickBtn()
    {
        string name_Selected = EventSystem.current.currentSelectedGameObject.name;
        string[] name_Splited = name_Selected.Split('_');
        int sector_selected = int.Parse(name_Splited[3]);
        PhotoController.instance.ChangeSpace(sector_selected);
        MiniMapController.instance.ChangeColor(sector_selected);

    }

    public void ActiveMenu()
    {
        gameObject.SetActive(flag_actived = !flag_actived);
    }




 
}
