using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    [SerializeField]
    float speed = 10, jumpForce = 10, suckForce = 10;
    Vector3 movement = Vector3.zero;

    [SerializeField]
    Transform mesh;

    [SerializeField]
    ProxyCollider proxy;
    [SerializeField]
    Animator _anim;

    float moveRaw;
    float jumpRaw;
    CharacterController controller;
    
    float gravity = 9.81f;

    CachingService<bool> groundedCache = new CachingService<bool>(0.2f, (t, _) => t);

    bool sucking, blowing = false;

     public int ingredientAmount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveRaw < 0)
        {
            mesh.localScale =  new Vector3(-1, 1, 1) * 0.8f;
        }
        if (moveRaw > 0)
        {
            mesh.localScale =  new Vector3(1, 1, 1) * 0.8f;
        }

        
    }

    private void FixedUpdate()
    {
        if (groundedCache.Check(controller.isGrounded) && movement.y <= 0)
        {

            if (jumpRaw != 0)
            {
                movement.y += jumpRaw * jumpForce;
            }
            else
            {
                movement.y = 0;
            }
            jumpRaw = 0;
        }
        else
        {
            movement.y += -gravity * Time.deltaTime;
        }

        movement.x = moveRaw * speed;
        controller.Move(movement * Time.deltaTime);


        if (sucking)
        {
            foreach (var item in proxy.rigidbodies)
            {
                item.Key.AddForce((transform.position - item.Key.position).normalized * suckForce * Time.deltaTime);
            }
        }

        if (blowing)
        {
            foreach (var item in proxy.rigidbodies)
            {
                item.Key.AddForceAtPosition((  item.Key.position - transform.position).normalized * suckForce * Time.deltaTime,item.Value);
            }
        }

        


    }

    public void OnAttack(InputValue value)
    {
        blowing = value.Get<float>() > 0;
        _anim.SetBool("Blowing", blowing);
    }

    public void OnCrouch(InputValue value)
    {

    }

    public void OnInteract(InputValue value)
    {

        sucking = value.Get<float>() > 0;
            _anim.SetBool("Sucking", sucking);
        
        
    }

    public void OnJump(InputValue value)
    {
        jumpRaw = value.Get<float>();
    }

    public void OnLook(InputValue value)
    {
        //turn = value.Get<Vector2>().x;
    }

    public void OnMove(InputValue value)
    {

        var temp = value.Get<Vector2>();

        if (temp.y >= 0)
        {
            jumpRaw = temp.y;
        }

        moveRaw = temp.x;

        Debug.LogWarning(value.Get<Vector2>());
    }

    public void OnNext(InputValue value)
    {

    }

    public void OnPrevious(InputValue value)
    {

    }

    public void OnSprint(InputValue value)
    {

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (proxy.rigidbodies.Remove( collision.rigidbody))
        {
            Destroy(collision.gameObject);
            ingredientAmount++;
        }
    }

}
