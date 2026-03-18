using UnityEngine;

// MODEL: Strictly holds raw data (Text, Audio, etc). 
[System.Serializable]
public class ArtifactData
{
    [Header("Text Information")]
    [Tooltip("Type the history/story of the artifact here.")]
    [TextArea(3, 10)] // Creates a large box for typing long text
    public string description;

}