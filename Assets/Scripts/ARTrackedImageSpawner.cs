using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackedImageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject charizardPrefab;
    private GameObject charizard;

    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackablesChanged.AddListener(OnImageChanged);
    }

    private void OnImageChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            charizard = Instantiate(charizardPrefab, newImage.transform);
        }
    }
}