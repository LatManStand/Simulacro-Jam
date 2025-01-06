using UnityEngine;

public class RotatingShooterEnemy : ShooterEnemy
{
    public float rotationSpeed;
    public override void Look()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + rotationSpeed * Time.deltaTime);
    }
}
