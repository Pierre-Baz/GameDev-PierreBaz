using UnityEngine;

public class LootFollow : MonoBehaviour
{
    #region Serialized Fields

    [Header("Movement Settings")]
    [SerializeField] private float smoothTime = 0.5f;
    [SerializeField] private float maxSpeedStart = 2.0f;
    [SerializeField] private float maxSpeedIncreaseRate = 0.1f;

    #endregion

    #region Private Variables
    private Transform playerTransform;
    private Vector3 velocity = Vector3.zero;
    private float currentMaxSpeed;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        currentMaxSpeed = maxSpeedStart;
    }

    private void Update()
    {
        if(playerTransform == null){
            return;
        }
        Vector3 targetPosition = playerTransform.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, currentMaxSpeed);
        
        // Increase the max speed over time
        currentMaxSpeed += maxSpeedIncreaseRate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnergyManager energyManager = collision.GetComponent<EnergyManager>();
            if (energyManager != null)
            {
                energyManager.LootSystemSorter(gameObject.name);
            }
            
            Destroy(gameObject);
        }
    }

    #endregion
}
