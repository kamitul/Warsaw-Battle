using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using UnityEditor;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private MouseData mouseData = default;

    [SerializeField]
    private Camera camera = default;

    [SerializeField]
    private List<CameraData> cameraDatas = default;

    private bool RightMouseClicked = false;
    [SerializeField]
    private bool IsFree = true;

    public float Speed = 10f;

    private float xMouse = 0f;
    private float yMouse = 0f;
    private void Start()
    {
        MoveToPoint(cameraDatas[1].Position, cameraDatas[1].Rotation, cameraDatas[1].Speed);
    }

    public void MoveToPoint(Vector3 pos, Vector3 rot, float time)
    {
        camera.transform.DOMove(pos, time).OnStart(() => IsFree = false).OnComplete(() => IsFree = true);
        camera.transform.DORotateQuaternion(Quaternion.Euler(rot), time).OnStart(() => IsFree = false).OnComplete(() => IsFree = true);
    }

    public void MoveToPoint(Position pos)
    {
        var toPoint = cameraDatas.Find(x => x.Type == pos);
        MoveToPoint(toPoint.Position, toPoint.Rotation, toPoint.Speed);
    }

    private void Update()
    {
        RightMouseClicked = Input.GetMouseButton(1);
        if(RightMouseClicked && IsFree)
        {
            Move();
            Rotate();
            Zoom();
        }
    }

    private void Zoom()
    {
        float zMouse = Input.GetAxis("Mouse Z") * mouseData.MouseSensZ;
        Vector3 move = camera.transform.forward * zMouse;
        camera.transform.position = Vector3.Lerp(camera.transform.position, camera.transform.position + move, Speed * Time.deltaTime);
    }

    private void Rotate()
    {
        xMouse += Input.GetAxis("Mouse X") * Time.deltaTime * mouseData.MouseSensX;
        yMouse -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseData.MouseSensY;
        camera.transform.eulerAngles = new Vector3(yMouse, xMouse, 0f);
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        Vector3 move = camera.transform.right * horizontal + camera.transform.forward * vertical;
        camera.transform.position = Vector3.Lerp(camera.transform.position, camera.transform.position + move, Speed * Time.deltaTime);
    }
}
