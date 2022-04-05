using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*This class displays a win message to the player once they hit the platform at the end of the level*/
public class WinPoint : MonoBehaviour
{
    [SerializeField] GameObject PUBox;
    [SerializeField] TMP_Text winText;
    

    private void OnTriggerEnter(Collider other) //turns on the canvas as soon as the player is on it
    {
        if (other.tag == "Player")
        {
            PUBox.SetActive(true);
            winText.enabled = true;
        }
    }
}
