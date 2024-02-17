using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogManager.Instance.NPCDialog = gameObject.GetComponentInParent<Interaction>();
            DialogManager.Instance.OpenPanelDialog();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogManager.Instance.NPCDialog = null;
            DialogManager.Instance.ClosePanelDialog();
            DialogManager.Instance.ClosePanelDialog();
        }
    }
}
