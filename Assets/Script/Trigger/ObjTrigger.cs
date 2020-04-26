using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTrigger : MonoBehaviour
{
    private string ObjName;

    private void Start()
    {
        ObjName = transform.parent.GetComponent<SpriteRenderer>().sprite.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAbility PA = collision.GetComponent<PlayerAbility>();
            PA.SettingState(this.transform.parent.gameObject, ObjName);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerAbility PA = collision.GetComponent<PlayerAbility>();
            PA.SwappingState();
        }
    }
}
