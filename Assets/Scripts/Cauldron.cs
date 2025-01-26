using UnityEngine;

public class Cauldron : MonoBehaviour
{
    ParticleSystem particles;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //TODO: is player
        {
            particles.maxParticles = other.GetComponent<Character>().ingredientAmount;
            particles.Play();
        }
    }
}
