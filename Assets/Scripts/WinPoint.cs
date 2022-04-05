using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinPoint : MonoBehaviour
{
    [SerializeField] GameObject PUBox;
    [SerializeField] TMP_Text winText;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PUBox.SetActive(true);
            winText.enabled = true;
        }
    }
}
