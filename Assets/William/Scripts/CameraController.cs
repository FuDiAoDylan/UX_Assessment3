// Reference https://python.iitter.com/other/315447.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    Vector3 off;     //相机目标点位置信息
    public float speed;   //相机移动速度
    Vector3 ve;     //平滑阻尼的返回值
    Quaternion angel;   //相机看向目标的旋转值
    public float hight;   //相机的高度
    public float foward;  //相机在角色后的距离

    // Start is called before the first frame update
    void Start()
    {
        // offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = player.transform.position + offset;

        off = player.transform.position + hight * player.transform.up - foward * player.transform.forward;
        // off = new Vector3(0,1.9f,0.15f);
        // transform.position = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, off, ref ve, 0);
        //看向向量指向的方向
        angel = Quaternion.LookRotation(player.transform.position - off);
        transform.rotation = Quaternion.Slerp(transform.rotation, angel, Time.deltaTime * speed);
    }
}