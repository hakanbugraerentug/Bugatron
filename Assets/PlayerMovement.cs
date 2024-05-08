using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]Vector2 rawInput;
    [SerializeField]float standartMoveSpeed = 5f;

    [SerializeField]Vector2 minBounds;
    [SerializeField]Vector2 maxBounds;

    Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {

        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }



    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        shooter.isFiring = value.isPressed;
    }
    

    void Move()
    {
        if (true)
        {
            Vector3 delta = rawInput * standartMoveSpeed * Time.deltaTime;
            Vector3 newPos = new Vector3();
            newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x, maxBounds.x);
            newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y, maxBounds.y);

            transform.position = newPos;

            if (rawInput.x == -1)
            {
                var targetRotation = Quaternion.Euler(0,-120,90);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);

            }
            else if (rawInput.x == 1)
            {
                var targetRotation = Quaternion.Euler(0,-60,90);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
            }
        }
    }


}
