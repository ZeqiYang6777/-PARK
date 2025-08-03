using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCamera;
    public float InteractionRange = 3.0f;

    public GameObject Ui_Interaction;
    public TMP_Text Ui_InteractionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IntercationRay();

    }
    private void IntercationRay()
    {

        Ray ray = mainCamera.ViewportPointToRay(Vector3.one / 2);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, InteractionRange))
        {
            iinteractable iinteractable = hitInfo.collider.GetComponent<iinteractable>();
            if (iinteractable != null)
            {
                Ui_InteractionText.text = iinteractable.GetDescription();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    iinteractable.Intercat();
                }
            }

        }
        Ui_Interaction.SetActive(false);


    }
}
