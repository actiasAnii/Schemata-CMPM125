using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBearer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] uint FlagNum;
    [SerializeField] string SceneTransitionName;
    void Start()
    {
        GameObject FlagShip = GameObject.Find("TheSingleton");
        uint FlagID = FlagShip.GetComponent<singlinton>().getFlag();
        //if((FlagNum&FlagID) == 1)
        //{
        //    this.enabled = false;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("hullo");
        SceneManager.LoadScene(SceneTransitionName);
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("hullo");
        SceneManager.LoadScene(SceneTransitionName);
    }
}
