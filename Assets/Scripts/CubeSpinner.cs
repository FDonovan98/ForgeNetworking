using UnityEngine;

using BeardedManStudios.Forge.Networking.Generated;

public class CubeSpinner : CubeSpinnerBehavior
{
    Rigidbody rigidbody;

    [Range(0.0f, 30.0f)]
    public float speed = 15.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (networkObject == null)
        {
            return;
        }

        if (!networkObject.IsOwner)
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
            return;
        }

        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * speed * Time.deltaTime;

        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;
    }
}
