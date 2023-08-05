using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public GameObject[] slices;
    public Canvas scoreCanvas;
    public int scoreValue = 1;
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Knife")
        {
            Slice();
            Destroy(this);
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            collider.gameObject.GetComponent<Knife>().Stop();
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().AddScore(scoreValue, transform.position);
            Canvas canva = Instantiate(scoreCanvas, transform.position, LookAtCamera());
            canva.GetComponentInChildren<Text>().text = "+"+scoreValue.ToString();
            Destroy(canva.gameObject, 1f);
        }
    }
    private Quaternion LookAtCamera()
    {
        return Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
    private void Slice()
    {
        slices[0].GetComponent<Rigidbody>().isKinematic = false;
        slices[0].GetComponent<Rigidbody>().AddForce(150, 20, 0);
        slices[1].GetComponent<Rigidbody>().isKinematic = false;
        slices[1].GetComponent<Rigidbody>().AddForce(-150, 20, 0);
    }
}