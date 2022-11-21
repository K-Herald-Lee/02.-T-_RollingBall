using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinItem : MonoBehaviour
{
    public int speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 30) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player"){
            gameObject.SetActive(false);
        }
    }
}
