using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    // 房間名稱
    public string RoomName = "";

    // 房間位置
    public Vector2 RoomPos = Vector2.zero;

    // 房間大小
    public Vector2 RoomSize = Vector2.zero;

    // 房間背景組成
    public List<List<RoomBlock>> RoomBlocks = new List<List<RoomBlock>>();

    // 房間地板
    public List<Platform> Platforms = new List<Platform>();

    // 房間物體
    public List<Object> Objects = new List<Object>();

    public Room(string name, int pos_x,int pos_y,int size_x,int size_y)
    {
        SetRoomName(name);
        SetRoomPos(pos_x, pos_y);
        SetRoomSize(size_x, size_y);
    }

    public void SetRoomName(string name)
    {
        RoomName = name;
    }

    public void SetRoomPos(float x, float y)
    {
        RoomPos = new Vector2(x, y);
    }

    public void SetRoomSize(int x, int y)
    {
        RoomSize = new Vector2(x, y);
    }

    public void SetRoomBlocks(int[,] Blocks)
    {
        int x = Blocks.GetLength(1);
        int y = Blocks.GetLength(0);

        if (x != RoomSize.x || y != RoomSize.y)
        {
            Debug.Log("錯誤");
            return;
        }

        for(int i = y - 1; i >= 0 ; i--)
        {
            List<RoomBlock> temp = new List<RoomBlock>();
            for(int j = 0; j < x; j++)
            {
                temp.Add(new RoomBlock(Blocks[i,j]));
            }
            RoomBlocks.Add(temp);
        }
    }

    public void SetPlatform(Vector2 pos, string name)
    {
        Platforms.Add(new Platform(pos, name));
    }

    public void SetObject(Vector2 pos, string name)
    {
        Objects.Add(new Object(pos, name));
    }

    public void SetObject(Vector2 pos, string name,int type, int id)
    {
        Objects.Add(new Object(pos, name, type, id));
    }
}