using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camera;
    GameObject player;

    private GameObject StageObj;
    private Dictionary<string, GameObject> AllRooms = new Dictionary<string, GameObject>();
    private string currentRoomName = "";
    private float orthographicSize;

    private bool isFind;
    private bool isStart;
    struct Boundary
    {
        public float center_x, center_y;
        public float min_x, max_x, min_y, max_y;

        public Boundary(Vector2 center, Vector2 size)
        {
            center_x = center.x;
            center_y = center.y;

            min_x = center_x - size.x / 2;
            max_x = min_x + size.x;
            min_y = center_y - size.y / 2;
            max_y = min_y + size.y;
        }
    }

    Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        orthographicSize = camera.orthographicSize;

        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindAllRooms() && !isStart)
        {
            isStart = true;
        }
        else
        {
            if (ChangeRoom())
            {
                player.GetComponent<PlayerAbility>().ClearObj();
                MoveToNewRoom();
            }
            orthographicSize = camera.orthographicSize;
            float Offset_x = orthographicSize + Stage.StageUtils.Offset_Wall;
            float Offset_y = orthographicSize;
            Vector3 newPos = new Vector3(Mathf.Clamp(player.transform.position.x, boundary.min_x + Offset_x, boundary.max_x - Offset_x),
                                         Mathf.Clamp(player.transform.position.y, boundary.min_y + Offset_y, boundary.max_y - Offset_y),
                                       -10); ;
            transform.position = newPos;
        }    }

    bool FindAllRooms()
    {
        StageObj = GameObject.Find("Stage");

        if(StageObj == null)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < StageObj.transform.childCount; i++)
            {
                GameObject child = StageObj.transform.GetChild(i).gameObject;
                AllRooms[child.name] = child;
            }

            return true;
        }
    }

    bool ChangeRoom()
    {
        if (currentRoomName != Setting.Game.CURRENTROOM)
        {
            currentRoomName = Setting.Game.CURRENTROOM;
            return true;
        }
        return false;
    }

    void MoveToNewRoom()
    {
        GameObject room = AllRooms[currentRoomName];
        camera.orthographicSize = 4;

        if (room != null)
        {
            BoxCollider2D BC2D = room.GetComponent<BoxCollider2D>();

            Vector2 center = BC2D.offset + new Vector2(room.transform.position.x, room.transform.position.y);
            Vector2 size = BC2D.size;

            float min = size.x < size.y ? size.x : size.y / 2;
            if(min < camera.orthographicSize)
            {
                camera.orthographicSize = min;
            }
            boundary = new Boundary(center, size);
        }
    }
}
