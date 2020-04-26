using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    public float CD;
    public float Dist;

    public enum AbilityMode
    {
        ObjectA,
        ObjectB,
    }

    GameController gameController;
    public GameObject SwapperA;
    public GameObject SwapperB;
    private GameObject tempObj;
    private string tempNameA, tempNameB;
    private string tempName;
    public AbilityMode abilityMode;
    bool inSetting;
    bool inCD;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        abilityMode = AbilityMode.ObjectA;
        inSetting = false;
        inCD = false;

 //       SetMode();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Setting.Keys.KEY_CHANGEMODE))
        {
            switch (abilityMode)
            {
                case AbilityMode.ObjectA:
                    abilityMode = AbilityMode.ObjectB;
                    break;
                case AbilityMode.ObjectB:
                    abilityMode = AbilityMode.ObjectA;
                    break;
                default:
                    break;
            }
            SetMode();
        }
    }
    private void FixedUpdate()
    {
        if (SwapperA != null)
        {
            if (Vector2.Distance(SwapperA.transform.position, transform.position) > Dist)
            {
                SwapperA = null;
                tempNameA = "";
                gameController.DeleteObj();
            }
        }

        if (SwapperB != null)
        {
            if (Vector2.Distance(SwapperB.transform.position, transform.position) > Dist)
            {
                SwapperB = null;
                tempNameB = "";
                gameController.DeleteObj();
            }
        }

        if (inSetting)
        {
            if(tempObj != null && Input.GetKey(Setting.Keys.KEY_ABILITY))
            {
                if (abilityMode == AbilityMode.ObjectA)
                {
                    if(SwapperB == tempObj)
                    {
                        SwapperB = SwapperA;
                        tempNameB = tempNameA;
                    }
                    SwapperA = tempObj;
                    tempNameA = tempName;
                    gameController.SetObj(tempNameA);
                }
                else
                {
                    if(SwapperA == tempObj)
                    {
                        SwapperA = SwapperB;
                        tempNameA = tempNameB;
                    }
                    SwapperB = tempObj;
                    tempNameB = tempName;
                    gameController.SetObj(tempNameB);
                }
            }
        }
        else
        {
            if(Input.GetKey(Setting.Keys.KEY_ABILITY) && !inCD)
            {
                Swap();
                StartCoroutine(CDTimer());
            }
        }
    }

    void SetMode()
    {
        gameController.SetMode(abilityMode.ToString());
        if (abilityMode == AbilityMode.ObjectA && SwapperA != null)
        {
            gameController.SetObj(tempNameA);
        }
        else if(abilityMode == AbilityMode.ObjectB  && SwapperB != null)
        {
            gameController.SetObj(tempNameB);
        }
        else
        {
            gameController.DeleteObj();
        }
    }

    void Swap()
    {
        Vector3 playerPos = transform.position;
        if(abilityMode == AbilityMode.ObjectA)
        {
            Vector3 swapperPos = SwapperA.transform.position;

            SwapperA.transform.position = playerPos;
            transform.position = swapperPos;
        }
        else
        {
            Vector3 swapperPos = SwapperB.transform.position;

            SwapperB.transform.position = playerPos;
            transform.position = swapperPos;
        }
    }

    IEnumerator CDTimer()
    {
        inCD = true;
        yield return new WaitForSeconds(CD);
        inCD = false;
    }

    public void SettingState(GameObject Obj, string ObjName)
    {
        inSetting = true;
        tempObj = Obj;
        gameController.ShowTips(transform.position + Vector3.up * 0.8f);

        tempName = ObjName;
    }

    public void SwappingState()
    {
        inSetting = false;
        tempObj = null;
        gameController.HideTips();
    }

    public void ClearObj()
    {
        tempObj = null;
        SwapperA = null;
        SwapperB = null;
        tempNameA = null;
        tempNameB = null;
        gameController.DeleteObj();
    }
}
