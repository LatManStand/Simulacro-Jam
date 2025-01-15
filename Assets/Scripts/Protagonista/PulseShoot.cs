using UnityEngine;

public class PulseShoot : MonoBehaviour
{
    public GameObject pulsePrefab;
    public float pulseTimer = 3.0f;
    public float pulseVelocity = 2.0f;
    public float pulseLifeTime = 2.0f;

    private float _timer = 3.0f;
    private bool _canDoPulse = true;
    
    void Update(){
        if (Input.GetKeyDown("l") && _canDoPulse)
        {
            DoPulseShoot();
        }
        
        if (!_canDoPulse)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0.0f)
            {
                TimerEnded();
            } 
        }
    }

    private void TimerEnded()
    {
        _canDoPulse = true;
    }

    private void DoPulseShoot()
    {
        _timer = pulseTimer;
        _canDoPulse = false;
        GameObject go = Instantiate(pulsePrefab, transform.position, Quaternion.identity);
        go.GetComponent<PulseArea>().lifeTime = pulseLifeTime;
        go.GetComponent<PulseArea>().pulseVelocity = pulseVelocity;
        UISystemManager.instance.DoWave(pulseTimer);
    }
}
