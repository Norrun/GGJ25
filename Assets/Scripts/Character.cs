using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    
    [SerializeField]
    float speed = 10, jumpForce = 10 , turnSpeed = 10;
    Vector3 movement = Vector3.zero;
    Vector2 moveRaw;
    float jumpRaw;
    CharacterController controller;
    float gravity = 9.81f;


    float turn;

    CacheService<bool> groundedCache = new CacheService<bool>(0.3f, (t,_) => t);
  

    public void OnAttack(InputValue value)
    {
         
    }

    public void OnCrouch(InputValue value)
    {
         
    }

    public void OnInteract(InputValue value)
    {
         
    }

    public void OnJump(InputValue value)
    {
        jumpRaw = value.Get<float>();
    }

    public void OnLook(InputValue value)
    {
        turn = value.Get<Vector2>().x;
    }

    public void OnMove(InputValue value)
    {

        moveRaw = value.Get<Vector2>();

       

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        


        if (groundedCache.Check(controller.isGrounded) && movement.y <=0)
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
            movement.y += -gravity  *Time.deltaTime;
        }



        movement.x = moveRaw.x * speed;
        movement.z = moveRaw.y * speed;

        controller.Move(transform.rotation * movement * Time.deltaTime);
        transform.eulerAngles += new Vector3(0, turn * Time.deltaTime * turnSpeed, 0);
        
    }

    /// <summary>
    /// only call in update;
    /// </summary>
    /// <returns></returns>
    
}
