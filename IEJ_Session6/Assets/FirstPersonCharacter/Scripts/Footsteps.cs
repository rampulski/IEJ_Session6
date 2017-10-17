using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AK.Wwise.Event FootStepEvent = null;

    float footstepTimer = 0.0f;

    Vector3 lastPos = new Vector3(0, 0, 0);

    private void Awake()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        bool isMoving = (lastPos.x != transform.position.x || lastPos.z != transform.position.z);
        lastPos = transform.position;

        if (isMoving)
        {
            if (footstepTimer > 0.30f)
            {
                FootStepEvent.Post(gameObject);
                footstepTimer = 0.0f;
            }

            footstepTimer += Time.deltaTime;
        }
    }
}
