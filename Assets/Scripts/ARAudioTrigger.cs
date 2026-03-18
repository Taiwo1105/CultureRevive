using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARAudioTrigger : MonoBehaviour
{
    private ARTrackedImageManager _trackedImageManager;

    void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.updated)
        {
            // Get the AudioSource attached to the 3D model prefab
            AudioSource audio = trackedImage.GetComponentInChildren<AudioSource>();

            if (audio != null)
            {
                if (trackedImage.trackingState == TrackingState.Tracking)
                {
                    if (!audio.isPlaying) audio.Play();
                }
                else
                {
                    audio.Stop();
                }
            }
        }
    }
}