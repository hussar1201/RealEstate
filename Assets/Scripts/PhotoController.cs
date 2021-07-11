using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController : MonoBehaviour
{
    public Material material_SkyBox;
    public Texture[] arr_Texture;
    
    private int cnt = 0;

    public static PhotoController instance {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<PhotoController>();
            }
            return m_instance;
        }
    }

    private static PhotoController m_instance;

    private void Awake()
    {
       if(instance != this)
        {
            Destroy(gameObject);
            return;
        }
        material_SkyBox.mainTexture = arr_Texture[0];

    }



    public void ChangeSpace(int num)
    {
     
        material_SkyBox.mainTexture = arr_Texture[num];
    }

}
