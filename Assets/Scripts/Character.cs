using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    
    [SerializeField]
    float speed = 10, jumpForce = 10;
    Vector3 movement = Vector3.zero;
    Vector2 moveRaw;
    float jumpRaw;
    CharacterController controller;
    float gravity = 9.81f;

    CacheService<bool> groundedCache = new CacheService<bool>(0.5f, t => t);
    CacheService<float> jumpRawCache = new CacheService<float>(0.5f, t => t > 0);

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
    void Update()
    {
        
        


        if (groundedCache.Check(controller.isGrounded))
        {
            
            if (jumpRawCache.Check(jumpRaw) != 0)
            {
                movement.y += jumpRawCache.Check(jumpRaw) + jumpForce;
            }
            else
            {
                movement.y = 0;
            }
            jumpRaw = 0;
        }
        else
        {
            movement.y = -gravity;
        }



        movement.x = moveRaw.x * speed;
        movement.z = moveRaw.y * speed;

        controller.Move(movement * Time.deltaTime );
    }

    /// <summary>
    /// only call in update;
    /// </summary>
    /// <returns></returns>
    
}
