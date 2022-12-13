using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class DistanceCalculate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currTarget;
    [SerializeField] GameObject arrow;
    [SerializeField] TMP_Text distance;
    [SerializeField] Axis axis;
    PhotonView pv;
    void Start()
    {
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
        axis = GameObject.Find("XAxis").GetComponent<Axis>();
            axis.myPlayer = this.gameObject;
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;
        if (currTarget != null)
        {
            arrow.SetActive(true);
            Vector3 targetPos = currTarget.transform.position;
            targetPos.y = arrow.transform.position.y;
            arrow.transform.LookAt(targetPos);

            if (Vector3.Distance(arrow.transform.position, targetPos) < 10f)
            {
                arrow.SetActive(false);
                currTarget = null;
            }
           
        }
    }

}
