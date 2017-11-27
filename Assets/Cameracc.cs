using UnityEngine;

public class Cameracc : MonoBehaviour
{

    Transform target;
    public float horiz;
    public float verti;

    public float panSpeed = 0.03f;
    public float panBorderThickness = 0.1f;

    public float scrollSpeed = 0.1f;
    public float minY = 15f;
    public float maxY = 35f;

    private void Start()
    {
        Camera.main.aspect = 1.33f;
        //Quaternion rotation = Quaternion.Euler(-2.222f, 0, 0);
        //transform.SetPositionAndRotation(new Vector3(3.78f, 2.47f, -87.14f), rotation);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.forward *0.01f * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){

            transform.Translate(Vector3.back *0.01f* panSpeed * Time.deltaTime, Space.World);
        
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * 0.01f * panSpeed * Time.deltaTime, Space.World);
            //Debug.Log(transform.position);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * 0.01f * panSpeed * Time.deltaTime, Space.World);
            //Debug.Log(transform.position);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
            //Debug.Log(transform.position);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
            
           // Debug.Log(transform.position);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        //pos.x -= scroll * 0.1f * scrollSpeed * Time.deltaTime;
        //pos.x = Mathf.Clamp(pos.x, minY, maxY);



        transform.position  = pos;

    }
}
