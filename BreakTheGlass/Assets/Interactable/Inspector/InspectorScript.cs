using UnityEngine;

public class InspectorScript : MonoBehaviour
{
    public bool inspecting;
    
    private GameObject instiatedObject;
    private Vector3 objectSize;
    private const float maxSize = 0.5f;

    [Range(1,10)]
    public float RotationSpeed;
    [Range(1, 10)]
    public float scrollSpeed;

    public Vector2 MinMaxScroll;
    public cameraManager cm;

    [SerializeField]
    private GameObject aim;

    public void Start()
    {
        inspecting = false;
    }

    public void InspectObject(GameObject objectInsp)
    {
        if (objectInsp == null) return; if (instiatedObject != null)  Destroy(instiatedObject);
        aim.SetActive(false);
        instiatedObject = Instantiate(objectInsp, this.transform);
        
        instiatedObject.transform.localPosition = Vector3.zero;
        MeshFilter mf = instiatedObject.GetComponent<MeshFilter>();
        if (mf != null)
        {
            objectSize = Vector3.Scale(mf.mesh.bounds.extents, instiatedObject.transform.localScale);
            instiatedObject.transform.localScale *= maxSize / OtherFunctions.getMaxElement(objectSize);
        }



    }

    [SerializeField]
    private Transform camPos;
    private float Zpos;


    private void Update()
    {
        if (!inspecting) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inspecting = false;
            aim.SetActive(true);
            cm.changeCamera(0);
        }

        if (instiatedObject == null) return;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            Zpos -= scrollSpeed * 10 * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Zpos += scrollSpeed * 10 * Time.deltaTime;
        }
        Zpos = Mathf.Clamp(Zpos, MinMaxScroll.x, MinMaxScroll.y);
      
        camPos.localPosition = new Vector3(camPos.localPosition.x, camPos.localPosition.y, Zpos);

        if (Input.GetKey(KeyCode.Mouse0))
        instiatedObject.transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * 1000 * Time.deltaTime), (-Input.GetAxis("Mouse X") * RotationSpeed * 1000 * Time.deltaTime), 0, Space.World);
    }

}



