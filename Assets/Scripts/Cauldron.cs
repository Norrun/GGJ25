using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField]
    Rigidbody Waffle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other) //TODO: is player
        {
            Waffle = Instantiate(Waffle,transform.position, Quaternion.identity);
            Waffle.AddForce(Vector3.up * 10);
        }
    }
}
