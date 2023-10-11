using UnityEngine;

public class Patron : MonoBehaviour, ICanBeSlowedItem
{
    [SerializeField] private Rigidbody2D patronRigidBody;
    public Rigidbody2D RigidbodyItem { get => patronRigidBody; }
    [SerializeField] private bool isSlowed = false;
    public bool IsSlowed { get => isSlowed; set => isSlowed = value; }

    private float factorSlow = 0f;

    private Vector2 prevVelocity = Vector2.zero;

    private float prevAngularVel = 0f;
    private void FixedUpdate()
    {
        if (IsSlowed)
        {
            if(factorSlow != 0)
            {
                float angularDifference = (patronRigidBody.angularVelocity - prevAngularVel) / factorSlow;
                patronRigidBody.angularVelocity = prevAngularVel + angularDifference;

                Vector2 vectorDifference = (patronRigidBody.velocity - prevVelocity) / factorSlow;
                patronRigidBody.velocity = new Vector2(prevVelocity.x + vectorDifference.x, prevVelocity.y + vectorDifference.y + (9.8f * Time.fixedDeltaTime / factorSlow));
                prevVelocity = patronRigidBody.velocity;
                prevAngularVel = patronRigidBody.angularVelocity;

            }
        }
    }

    public void OnEnterIntoSlowedArea(float slowfactor)
    {
        if (isSlowed || slowfactor == 0)
            return;

        patronRigidBody.velocity /= slowfactor;
        prevAngularVel = patronRigidBody.angularVelocity;
        prevVelocity = patronRigidBody.velocity;
        factorSlow = slowfactor;
        isSlowed = true;
    }

    public void OnExitFromSlowedArea(float slowfactor)
    {
        if (!isSlowed)
            return;

        patronRigidBody.velocity *= slowfactor;
        factorSlow = 1;
        IsSlowed = false;
    }
}
