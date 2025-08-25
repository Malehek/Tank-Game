using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float m_Speed = 20f; // how fast the tank moves forward and backward
    public float m_RotationSpeed = 180f; // how fast the tank rotates in degrees per second

    private Rigidbody m_Rigidbody;

    private float m_ForwardInputValue; // the current value of the movement input
    private float m_TurnInputValue; // the current value of the turn input

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_ForwardInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void Update()
    {
        // Store the value of both input axes.
        m_ForwardInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 wantedVelocity = transform.forward * m_ForwardInputValue * m_Speed;
        m_Rigidbody.AddForce(wantedVelocity - m_Rigidbody.linearVelocity, ForceMode.VelocityChange);
    }

    private void Turn()
    {
        float turnValue = m_TurnInputValue * m_RotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnValue, 0f);
        m_Rigidbody.MoveRotation(transform.rotation * turnRotation);
    }
}