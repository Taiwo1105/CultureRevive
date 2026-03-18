using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ArtifactImageSpawner : MonoBehaviour
{
    [Header("Manager")]
    public ARTrackedImageManager trackedImageManager;

    [Header("Artifact Prefabs")]
    public List<ArtifactEntry> artifacts;

    private Dictionary<string, GameObject> spawned = new Dictionary<string, GameObject>();

    void Awake()
    {
        foreach (var entry in artifacts)
        {
            GameObject obj = Instantiate(entry.prefab, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            spawned.Add(entry.imageName, obj);
        }
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var image in args.added)
            UpdateArtifact(image);

        foreach (var image in args.updated)
            UpdateArtifact(image);

        foreach (var image in args.removed)
            spawned[image.referenceImage.name].SetActive(false);
    }

    void UpdateArtifact(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        GameObject obj = spawned[name];

        if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
        {
            obj.SetActive(true);
            obj.transform.position = trackedImage.transform.position;
            // REMOVE rotation line completely

        }
        else
        {
            obj.SetActive(false);
        }
    }
}

[System.Serializable]
public class ArtifactEntry
{
    public string imageName;
    public GameObject prefab;
}
