using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {

    [SerializeField]
    private GameObject Image;

    private Animator Fade;

    private void Awake()
    {
        Fade = Image.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider Other)
    {
        Fade.enabled = true;
        Fade.Play("FadeOut");
    }

}
