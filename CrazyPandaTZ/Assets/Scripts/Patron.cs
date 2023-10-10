using UnityEngine;

public class Patron : MonoBehaviour, ICanBeSlowedItem
{
    [SerializeField] private Rigidbody2D patronRigidBody;
    public Rigidbody2D RigidbodyItem { get => patronRigidBody; }
    [SerializeField] private bool isSlowed = false;
    public bool IsSlowed { get => isSlowed; set => isSlowed = value; }

    public void OnEnterIntoSlowedArea(float slowfactor)
    {
        if (isSlowed || slowfactor == 0)
            return;

        isSlowed = true;

        patronRigidBody.velocity = Vector2.ClampMagnitude(patronRigidBody.velocity, patronRigidBody.velocity.magnitude / slowfactor);
    }
}
