using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ProgramManager : MonoBehaviour
{
    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject PlaneMarkerPrefab;
    private ARRaycastManager ARRaycastManagerScript;

    private Vector2 TouchPosition;

    public GameObject Pet;

    private Button button;
    private bool ObjectAdded;

    public CatScript catScript;

    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
        PlaneMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjectAdded)
        {
            ShowMarker();
        }
    }

    public void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(Pet, hits[0].pose.position, Pet.transform.rotation);
            ObjectAdded = true;
        }
    }
}
