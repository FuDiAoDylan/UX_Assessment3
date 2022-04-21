using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController_William : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    Vector3 off;     //���Ŀ���λ����Ϣ
    public float speed;   //����ƶ��ٶ�
    Vector3 ve;     //ƽ������ķ���ֵ
    Quaternion angel;   //�������Ŀ�����תֵ
    public float hight;   //����ĸ߶�
    public float foward;  //����ڽ�ɫ��ľ���

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
        //��������ָ��ķ���
        angel = Quaternion.LookRotation(player.transform.position - off);
        transform.rotation = Quaternion.Slerp(transform.rotation, angel, Time.deltaTime * speed);
    }
}
