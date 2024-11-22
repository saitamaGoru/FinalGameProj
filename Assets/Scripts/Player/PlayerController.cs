using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

   [Header("Movement Properties")]
   [SerializeField] float _moveSpeed = 5f;
   [SerializeField] float minxPos = -5f;
   [SerializeField] float maxxPos = 5f;
   [SerializeField] float minzPos = -2f;
   [SerializeField] float maxzPos = 2f;
    Vector2 _movement;
   

    Rigidbody rigidBody;
   private void Awake()
   {
     rigidBody = GetComponent<Rigidbody>();
   }


    private void FixedUpdate()
    {
        HandleMovement();
    }


   public void Move(InputAction.CallbackContext ctx)
   {
        _movement = ctx.ReadValue<Vector2>();
   }

   private void HandleMovement()
    {
        Vector3 currentPos = rigidBody.position;

        float clampedPosX = ClampX(currentPos);
        float clampedPosZ = ClampZ(currentPos);

        Vector3 moveDir = new Vector3(_movement.x, 0f, _movement.y);
        Vector3 newPos = new Vector3(clampedPosX, currentPos.y, clampedPosZ) + moveDir * (_moveSpeed * Time.fixedDeltaTime);

       

        rigidBody.MovePosition(newPos);
    }

    private float ClampX(Vector3 currentPos)
    {
        return Mathf.Clamp(currentPos.x, minxPos, maxxPos);
    }

    private float ClampZ(Vector3 currentPos)
    {
        return Mathf.Clamp(currentPos.z, minzPos, maxzPos);
    }
}
