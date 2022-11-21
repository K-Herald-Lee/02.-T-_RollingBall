using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sPlayer : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audio;
    public ManagerLogic manager;
    public float jumpPower;
    public int itemcnt;
    bool isJump = false;
    private void Awake() 
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        itemcnt = 0;
    }
    
    private void Update() {
        if(Input.GetButtonDown("Jump") && !isJump){
            isJump = true;
            rigid.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);
        } 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h,0,v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Floor") {
            isJump = false;  
        }        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Item"){
            itemcnt++;
            audio.Play();
        }
        else if(other.tag == "Finish"){
            if(itemcnt >= manager.totalItemCnt){
                manager.stage++;
            }
            SceneManager.LoadScene("Stage"+manager.stage.ToString());
        }        
        else if (other.tag == "Respawn"){
            SceneManager.LoadScene("Stage"+manager.stage.ToString());
        }
    }
}
