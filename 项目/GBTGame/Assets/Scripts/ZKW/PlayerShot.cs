using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;
using MyGameFrameWork;
using DG.Tweening;

public class PlayerShot : MonoBehaviour
{
    Sequence seq;
    public GameObject AllBullet;
    float curr_shot_time;
    public float shot_time;

    PlayerMove pm;

    bool isAttack;

    Vector3 temp3;

    Vector3 XAV3;//用于反转
    Vector3 XBV3;
    // Start is called before the first frame update
    void Start()
    {
        //shot_time = 1f;
        isAttack = false;
        curr_shot_time = 1f;
        pm = GetComponent<PlayerMove>();
        seq =  DOTween.Sequence();
        XAV3 = new Vector3(-0.5f, 0.5f);
        XBV3 = new Vector3(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        curr_shot_time += Time.deltaTime;
        if (curr_shot_time > shot_time)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SoundSystem.Instance.PlayEffect(Data_AudioID.key_FireShining);
                if (pm.playerState == EPlayerHpState.Freezing)
                {
                    Shot1();
                }
                else if(pm.playerState == EPlayerHpState.Normal)
                {
                    Shot2();
                }
                else if(pm.playerState == EPlayerHpState.Fever)
                {
                    Shot3();
                }
                else if(pm.playerState == EPlayerHpState.Overheating)
                {
                    Shot4();
                }
                else
                {
                    Shot1();
                }
                
            }
            else if(isAttack)
            {
                pm.animator.SetBool("isAttack", false);
                isAttack = false;
            }
        }
        temp3 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.localPosition;
        if (temp3.x > 0f)
            transform.localScale = XAV3;
        else
            transform.localScale = XBV3;
    }

    void Shot1()
    {
        if (!isAttack)
        {
            pm.animator.SetBool("isAttack", true);
        }
        isAttack = true;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int id = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].ID;
        GameObject temp;
        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp.SetActive(true);
        temp.transform.SetParent(AllBullet.transform);
        temp.transform.localPosition = this.transform.localPosition;
        temp.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition, pm,8);
        curr_shot_time = -0.2f;
    }

    void Shot2()
    {
        if (!isAttack)
        {
            pm.animator.SetBool("isAttack", true);
        }
        isAttack = true;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int id = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].ID;
        GameObject temp;
        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp.SetActive(true);
        temp.transform.SetParent(AllBullet.transform);
        temp.transform.localPosition = this.transform.localPosition;
        temp.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition, pm,12);
        curr_shot_time = 0f;
    }

    void Shot3()
    {
        if (!isAttack)
        {
            pm.animator.SetBool("isAttack", true);
        }
        isAttack = true;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int id = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].ID;
        GameObject temp1;
        GameObject temp2;
        GameObject temp3;
        Vector3 dir = pos - this.transform.localPosition;
        Vector3 radom;
        radom.x = Random.Range(0.1f, 0.5f);
        radom.y = Random.Range(0.1f, 0.5f);
        radom.z = Random.Range(0.1f, 0.5f);
        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp1 = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp1 = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp1.SetActive(true);
        temp1.transform.SetParent(AllBullet.transform);
        temp1.transform.localPosition = this.transform.localPosition;
        temp1.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition, pm,12);

        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp2 = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp2 = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp2.SetActive(true);
        temp2.transform.SetParent(AllBullet.transform);
        temp2.transform.localPosition = this.transform.localPosition;
        temp2.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition - radom, pm, 12);

        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp3 = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp3 = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp3.SetActive(true);
        temp3.transform.SetParent(AllBullet.transform);
        temp3.transform.localPosition = this.transform.localPosition;
        temp3.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition + radom, pm, 12);


        curr_shot_time = 0f;
    }

    void Shot4()
    {
        if (!isAttack)
        {
            pm.animator.SetBool("isAttack", true);
        }
        isAttack = true;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int id = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].ID;
        GameObject temp1;
        GameObject temp2;
        GameObject temp3;
        Vector3 dir = pos - this.transform.localPosition;
        Vector3 radom;
        radom.x = Random.Range(0.1f, 0.5f);
        radom.y = Random.Range(0.1f, 0.5f);
        radom.z = Random.Range(0.1f, 0.5f);
        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp1 = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp1 = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp1.SetActive(true);
        temp1.transform.SetParent(AllBullet.transform);
        temp1.transform.localPosition = this.transform.localPosition;
        temp1.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition, pm, 12);

        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp2 = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp2 = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp2.SetActive(true);
        temp2.transform.SetParent(AllBullet.transform);
        temp2.transform.localPosition = this.transform.localPosition;
        temp2.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition - radom, pm, 12);

        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp3 = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].path;
            temp3 = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp3.SetActive(true);
        temp3.transform.SetParent(AllBullet.transform);
        temp3.transform.localPosition = this.transform.localPosition;
        temp3.GetComponent<Bullet>().SetDirect(pos - this.transform.localPosition + radom, pm, 12);

        curr_shot_time = 0.1f;
    }
}
