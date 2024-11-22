using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ModelProperties : MonoBehaviour
{

    public string id;
    public GameManager manager;
    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log(id);
        screenPoint = manager._camera.WorldToScreenPoint(transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        offset = transform.position - manager._camera.ScreenToWorldPoint(mousePos);
        

    }
    private void OnMouseUp()
    {
        Debug.Log("B�rakt�n");
    }

    private void OnMouseDrag()
    {
        Debug.Log("S�r�kl�yorsun");
        Vector3 currentPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPos =  manager._camera.ScreenToWorldPoint(currentPoint)+offset;
        transform.position = currentPos;
      
        //nesnenin �zellikleri oldugu i�in 
    }



}
