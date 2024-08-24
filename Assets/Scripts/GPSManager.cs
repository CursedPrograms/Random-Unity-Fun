using System.Diagnostics;
using UnityEngine;

public class GPSManager : MonoBehaviour
{
    private bool isLocationServiceEnabled = false;
    public float updateInterval = 1.0f;
    private float timeSinceLastUpdate = 0.0f;

    void Start()
    {
        StartLocationService();
    }

    void Update()
    {
        timeSinceLastUpdate += Time.deltaTime;
        if (timeSinceLastUpdate >= updateInterval)
        {
            timeSinceLastUpdate = 0.0f;
            UpdateLocation();
        }
    }

    private void StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogError("Location services are not enabled.");
            return;
        }

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location.");
            return;
        }

        isLocationServiceEnabled = true;
        Debug.Log("Location service started.");
    }

    private void UpdateLocation()
    {
        if (!isLocationServiceEnabled)
            return;

        LocationInfo location = Input.location.lastData;

        Debug.Log($"Latitude: {location.latitude}, Longitude: {location.longitude}, Altitude: {location.altitude}, Accuracy: {location.horizontalAccuracy}");
    }

    void OnDisable()
    {
        if (Input.location.isEnabledByUser)
        {
            Input.location.Stop();
        }
    }
}
