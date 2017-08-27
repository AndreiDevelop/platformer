using UnityEngine;
using System.Collections;

public class PopUpAnimation : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    public void HideStartPopUp()
    {
        anim.SetBool("HideStart", true);
    }

    public void ShowGameOverPopUp()
    {
        anim.SetBool("ShowGameOver", true);
    }

    public void HideGameOverPopUp()
    {
        anim.SetBool("ShowGameOver", false);
    }
}
