using MyGameFrameWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public Transform SubObj;

    float speed;
    Vector3 direct;
    Transform ts;
    Vector3 temp;
    Vector2[] directs;

    float distance;

    float curr_time;
    int layermask;
    bool isDead;

    PlayerMove pm;

    Vector3 Ok;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        curr_time = 0f;

        speed = 10f;
        ts = GetComponent<Transform>();
        directs = new Vector2[4]
        {
            new Vector2(0,1),
            new Vector2(0,-1),
            new Vector2(1,0),
            new Vector2(-1,0),
        };
        distance = 0.05f;
        layermask = (1 << 7) | (1 << 8) | (1 << 10);

        Ok = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        curr_time += Time.deltaTime;
        if (curr_time >= 3f)
        {
            Back();
        }
        RaycastHit2D hit;
        ts.localPosition += direct * speed * Time.deltaTime;
        for(int i = 0; i < 4; i++)
        {
            hit = Physics2D.Raycast(this.transform.localPosition, directs[i], distance, layermask);
            if (hit.collider)
            {
                if(hit.collider.tag == "Enemy" && !isDead)
                {
                    isDead = true;

                    EnemyMove em = hit.collider.gameObject.GetComponent<EnemyMove>();
                    if (em != null)
                    {
                        float DPS = TOOLS.GetPlayerDps(pm.playerState, 1, em.CurrHp, em.CurrDenfense);
                        em.Injure(DPS);
                        //SoundSystem.Instance.PlayEffect(Data_AudioID.key_FireHit);
                    }
                    else
                    {
                        EnemyMove2 em2 = hit.collider.gameObject.GetComponent<EnemyMove2>();
                        if (em2 != null)
                        {
                            
                            float DPS2 = TOOLS.GetPlayerDps(pm.playerState, 2, em2.CurrHp, em2.CurrDenfense);
                            em2.Injure(DPS2);
                            //SoundSystem.Instance.PlayEffect(Data_AudioID.key_FireHit);
                        }
                        else
                        {
                            EnemyMove3 em3 = hit.collider.gameObject.GetComponent<EnemyMove3>();
                            if (em3 != null)
                            {

                                float DPS3 = TOOLS.GetPlayerDps(pm.playerState, 3, em3.CurrHp, em3.CurrDenfense);
                                em3.Injure(DPS3);
                                
                            }
                        }
                    }

                    //hit.collider.gameObject.GetComponent<EnemyMove>()?.Injure();
                    //hit.collider.gameObject.GetComponent<EnemyMove2>()?.Injure();
                    //hit.collider.gameObject.GetComponent<EnemyMove>()?.Injure();
                }
                Back();
            }
            break;
        }
    }

    public void SetDirect(Vector3 Direct,PlayerMove pm,float speed)
    {
        direct = Direct;
        direct.z = 0;
        direct = Vector3.Normalize(direct);
        if (direct == Vector3.zero)
        {
            direct.x = 1;
            direct.y = -1;
        }
        curr_time = 0f;
        this.pm = pm;
        this.speed = speed;
        
        //Vector3 endv = transform.localEulerAngles + new Vector3(0, 0, -90);
        //transform.localRotation = Quaternion.Euler()
        float angle = Vector3.Angle(Ok, direct);
        if (direct.x < 0)
        {
            this.SubObj.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -angle));
        }
        else
        {
            this.SubObj.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

    void Back()
    {
        ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_FireBullet].ID, this.gameObject);
        isDead = false;
    }
}
