using UnityEngine;
using System.Collections;
 
public class CameraSetting : MonoBehaviour {
     
    public float mainSpeed = 5.0f; //regular speed
    // float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    // float maxShift = 1000.0f; //Maximum speed when holdin gshift
    public Camera cam;
    public GameObject alert;
    public GameObject sayDialog;
    // public Animator dialogAnim;
    private bool say;
    private float xposi;
    private float yposi;
    private float zposi;
    public float xrange;
    public float zrange;
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    // private float totalRun= 1.0f;
    
    void Start (){
        // Debug.Log(sayDialog.name);
        fov = cam.fieldOfView;
        Vector3 defaultcamposition = cam.transform.position;
        Quaternion camRotation = cam.transform.rotation;
        cam.transform.rotation = camRotation;
        // Debug.Log(cam.transform.rotation);
        xposi = defaultcamposition.x;
        yposi = defaultcamposition.y;
        zposi = defaultcamposition.z;
        // Debug.Log(yposi);
    }

    #region Camera fov
 
    //fov 最大最小角度
    private int fovMinLimit = 25;
    private int fovMaxLimit = 100;
    //fov 变化速度
    // private float fovSpeed = 25.0f;
    //fov 角度
    private float fov = 0.0f;
 
    /// <summary>
    /// 滚轮控制相机视角缩放
    /// </summary>
    public void CameraFOV()
    {
        //获取鼠标滚轮的滑动量
        fov += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 2255;
 
        // fov 限制修正
        fov = ClampValue(fov,fovMinLimit, fovMaxLimit);
 
        //改变相机的 fov
        cam.fieldOfView = (fov);
    }
 
    #endregion

    void FixedUpdate () {
        if (sayDialog.name == "SayDialog"){
            if (sayDialog.activeSelf){
                Invoke( "SetCameraSayDialogFalse" , 0.05f );
            }
            else if (say){
                SetCam ( );
            }
        }
        else if (sayDialog.name == "Elf" || sayDialog.name == "Examiner") {
            if (sayDialog.activeSelf){
                SetCam ( );
            }
        }
        // Vector3 p = GetBaseInput();
        // p = p * mainSpeed * Time.deltaTime;
        // Vector3 newPosition = cam.transform.position;
        // cam.transform.Translate(p);
        // newPosition.x = cam.transform.position.x;
        // newPosition.z = cam.transform.position.z;
        // cam.transform.position = newPosition;
        // if (p.sqrMagnitude > 0){ // only move while a direction key is pressed
        //   if (Input.GetKey (KeyCode.LeftShift)){
        //       totalRun += Time.deltaTime;
        //       p  = p * totalRun * shiftAdd;
        //       p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
        //       p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
        //       p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        //   } else {
        //       totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        //       p = p * mainSpeed;
        //   }
         
        //   p = p * Time.deltaTime;
        //   Vector3 newPosition = transform.position;
        //   if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
        //       transform.Translate(p);
        //       newPosition.x = transform.position.x;
        //       newPosition.z = transform.position.z;
        //       transform.position = newPosition;
        //   } else {
        //       transform.Translate(p);
        //   }
        // }
    }

    void SetCam () {
        cam.GetComponent<Rigidbody>().velocity = Vector3.zero; // Vector3.zero=new Vector3(0, 0, 0)
        cam.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Vector3 camposition = cam.transform.position;
        // Debug.Log(camposition);
        lastMouse = Input.mousePosition - lastMouse ;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        lastMouse = new Vector3(cam.transform.eulerAngles.x + lastMouse.x , cam.transform.eulerAngles.y + lastMouse.y, 0);
        cam.transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;
        //Mouse  camera angle done.  

        //Keyboard commands
        if (camposition.x > -xrange && camposition.x < xrange && camposition.z > -zrange && camposition.z < zrange)
        {
            Vector3 p = GetBaseInput();
            p = p * mainSpeed * Time.deltaTime;
            cam.transform.Translate(p);
            // Vector3 newPosition = cam.transform.position;
            camposition.x = cam.transform.position.x;
            camposition.y = yposi;
            camposition.z = cam.transform.position.z;
            cam.transform.position = camposition;
        }
        else{
            cam.transform.position =new Vector3 (xposi,yposi,zposi);
            StartCoroutine(BeyondGameRange());
        }
    }

    void SetCameraSayDialogFalse () {
        if (sayDialog.activeSelf == false ){
            say = true;
        }
    }

    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        
        if (Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }

    #region tools ClampValue
    //值范围值限定
    float ClampValue(float value, float min, float max)//控制旋转的角度
    {
        if (value < -360)
            value += 360;
        if (value > 360)
            value -= 360;
        return Mathf.Clamp(value, min, max);//限制value的值在min和max之间， 如果value小于min，返回min。 如果value大于max，返回max，否则返回value
    }
 
    #endregion

    IEnumerator BeyondGameRange(){
        // alert.SetActive(true);
        alert.GetComponent<Animator>().Play("TriggerDialogFadeIn");
        yield return new WaitForSeconds(1);
        alert.GetComponent<Animator>().Play("TriggerDialogFadeOut");
        // yield return new WaitForSeconds(1);
        // alert.SetActive(false);
    }
}