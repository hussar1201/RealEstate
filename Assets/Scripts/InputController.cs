using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class InputController : MonoBehaviour
{

    InputDevice Controller_L;
    InputDevice Controller_R;
    bool triggerValue_L = false;
    bool triggerValue_R = false;

    float time_input_interval = 0.2f;//0.1f -> 0.2f 수정
    float time_checked = 0f;

    public GameObject explainXbtn; //추가
    private bool firstXtouch = false; //추가

    public static InputController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<InputController>();
            }
            return m_instance;
        }
    }

    private static InputController m_instance;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }


    void Start()
    {

        List<InputDevice> leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        List<InputDevice> rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if (leftHandDevices.Count == 1)
        {
            Controller_L = leftHandDevices[0];
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        if (rightHandDevices.Count == 1)
        {
            Controller_R = rightHandDevices[0];
        }
        else if (rightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one right hand!");
        }
    }

    void Update()
    {
        time_checked += Time.deltaTime;


        if (time_input_interval <= time_checked)
        {
            time_checked = 0f;

            if (Controller_L.TryGetFeatureValue(CommonUsages.primaryButton, out triggerValue_L) && triggerValue_L)
            {
                //여기부터
                if (firstXtouch == false)
                {
                    explainXbtn.SetActive(false);
                }
                firstXtouch = true;
                //여기까지 추가 

                UIController.instance.ActiveMenu();
                MiniMapController.instance.ActiveMenu();
                Debug.Log("pressed");
            }

            if (Controller_L.TryGetFeatureValue(CommonUsages.secondaryButton, out triggerValue_L) && triggerValue_L)
            {
                Debug.Log("Left Y Button is pressed.");
            }


            if (Controller_R.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue_R) && triggerValue_R)
            {
                Debug.Log("Right Button is pressed.");
            }
        }



    }
}
