using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {

    [SerializeField]
    private GameObject Image;

    private Animation Fade;

    private void Awake()
    {
        Fade = Image.GetComponent<Animation>();
    }

    void OnTriggerEnter(Collider Other)
    {
        Fade.Play("FadeOut");
    }

}
