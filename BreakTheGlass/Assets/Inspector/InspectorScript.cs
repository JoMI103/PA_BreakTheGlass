using UnityEngine;

public class InspectorScript : MonoBehaviour
{
    public GameObject InspectorObject;
    private GameObject instiatedObject;
    private Vector3 objectSize;
    private const float maxSize = 0.5f;
    [Range(1,10)]
    public float RotationSpeed;
    [Range(1, 10)]
    public float scrollSpeed;



    public void changeObject()
    {
        if (InspectorObject == null) return; if (instiatedObject != null)  Destroy(instiatedObject);
        instiatedObject = Instantiate(InspectorObject,this.transform);
        
        instiatedObject.transform.localPosition = Vector3.zero;

        objectSize = Vector3.Scale(instiatedObject.GetComponent<MeshFilter>().mesh.bounds.extents
            , instiatedObject.transform.localScale);


   
        instiatedObject.transform.localScale *= maxSize / OtherFunctions.getMaxElement(objectSize);
    
    }

    [SerializeField]
    private Transform camPos;
    private float Zpos;


    private void Update()
    {
        if (instiatedObject == null) return;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            Zpos -= scrollSpeed * 100 * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Zpos += scrollSpeed * 100 * Time.deltaTime;
        }
        Zpos = Mathf.Clamp(Zpos, -3, 3f);
      
        camPos.localPosition = new Vector3(camPos.localPosition.x, camPos.localPosition.y, Zpos);

        if (Input.GetKey(KeyCode.Mouse0))
        instiatedObject.transform.Rotate((Input.GetAxis("Mouse Y") * RotationSpeed * 1000 * Time.deltaTime), (-Input.GetAxis("Mouse X") * RotationSpeed * 1000 * Time.deltaTime), 0, Space.World);
    }

}



