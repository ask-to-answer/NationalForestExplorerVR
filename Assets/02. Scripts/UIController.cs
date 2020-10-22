using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter(Collider other)
    {     
        Debug.Log("Enter");
        panel.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        panel.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
