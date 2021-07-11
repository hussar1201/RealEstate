using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    private ColorChanger[] arr_ColorChangers;
    private bool flag_actived = false;

    public static MiniMapController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<MiniMapController>();
            }
            return m_instance;
        }
    }

    private static MiniMapController m_instance;

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
        arr_ColorChangers = GetComponentsInChildren<ColorChanger>();
        for(int i=0;i<arr_ColorChangers.Length-1;i++)
        {
            arr_ColorChangers[i].UnSelected();
        }
        arr_ColorChangers[0].Selected();
        gameObject.SetActive(flag_actived);
    }

    public void ChangeColor(int num)
    {
        for (int i = 0; i < arr_ColorChangers.Length - 1; i++)
        {
            if (i == num)
            {
                arr_ColorChangers[num].Selected();
                continue;
            }
            arr_ColorChangers[i].UnSelected();
        }
        
    }


    public void ActiveMenu()
    {
        gameObject.SetActive(flag_actived = !flag_actived);
    }


}
