using UnityEngine;

public class BubbleAnimationTest : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    private bool isOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            isOn = !isOn;
            _anim.SetBool("Blowing", isOn);


        }
    }
}
