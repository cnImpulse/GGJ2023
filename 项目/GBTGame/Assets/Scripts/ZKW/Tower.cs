using DataCs;
using MyGameFrameWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    ETurrutType turrutType;
    public bool isDead;
    bool isGameOver;

    public float MaxHP;
    public float CurrHp;

    private Camera cam;
    private TowerHpBar HpBar;

    public GameObject Canva;
    int curr_level;

    float curr_time;
    float shot_time;

    public PlayerMove pm;

    float fire_distance;
    float fire_distance_big;
    // Start is called before the first frame update
    void Start()
    {
        
        isDead = false;
        isGameOver = false;
        curr_time = 0f;
        shot_time = 1f;
        fire_distance = 3.5f;
        fire_distance_big = 5.5f;
    }

    public void init(ETurrutType eTurrutType,int level)
    {
        curr_time = 0f;
        shot_time = 1f;
        fire_distance = 3.5f;
        fire_distance_big = 5.5f;
        gameObject.SetActive(true);
        EventManagerSystem.Instance.Add2(Data_EventName.GameOver_str, GameOver2);
        EventManagerSystem.Instance.Add2(Data_EventName.GameOK_str, GameOver2);
        turrutType = eTurrutType;
        cam = Camera.main;
        isGameOver = false;
        isDead = false;
        TOOLS.GetTurrutHps(eTurrutType, (uint)level, out MaxHP, out CurrHp);//��ȡѪ��



        if (turrutType != ETurrutType.Center)
        {
            CreateHPBar();
            HpBarMove();
        }
        else
        {
            //SoundSystem.Instance.PlayMusic(Data_AudioID.key_FireBurning);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(turrutType != ETurrutType.Center)
        {
            if (HpBar != null)
            {
                //HpBar.SetHp(1f);// = 1f;
                HpBarMove();
            }
        }
        
        curr_time += Time.deltaTime;
        if (curr_time >= shot_time &&!isGameOver)
        {
            AutoInjure();
            FireWork();
            curr_time = 0;
        }   
    }

    void CreateHPBar()
    {
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int id = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID;
        GameObject temp;
        if (ObjectPoolSystem.Instance.TestGameObjectPool(id))
        {
            temp = ObjectPoolSystem.Instance.GetGameObjectFormPool(id);
        }
        else
        {
            string path = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].path;
            temp = GameObject.Instantiate((GameObject)Resources.Load(path));
        }
        temp.SetActive(true);
        temp.transform.SetParent(Canva.transform);
        HpBar = temp.GetComponent<TowerHpBar>();
        HpBar.SetMaxHp(MaxHP, CurrHp);
        HpBar.SetHp(1f);
    }

    void HpBarMove()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        var playerScreenPos = cam.WorldToScreenPoint(this.transform.position);
        //�ٰ���������Y��һ���߶ȸ�������
        if(turrutType==ETurrutType.Normal)
            HpBar.gameObject.GetComponent<RectTransform>().position = new Vector3(playerScreenPos.x, playerScreenPos.y + 90f, playerScreenPos.z);
        else
            HpBar.gameObject.GetComponent<RectTransform>().position = new Vector3(playerScreenPos.x, playerScreenPos.y + 90f, playerScreenPos.z);
    }

    public void Injure(int monsterID)
    {
        float DPS = TOOLS.GetMonsterToTurrutDps((uint)monsterID, CurrHp);

        CurrHp-= DPS;

        if(turrutType == ETurrutType.Center)
        {
            EventManagerSystem.Instance.Invoke2(Data_EventName.MainTowerInjure_str, MainTowerInjureEventArgs.Create(DPS));
        }
        else
        {
            //HpBar.size = CurrHp / (float)MaxHP;
            HpBar.SetHp(CurrHp / MaxHP);
        }
        if (CurrHp <= 0)
        {
            Dead();
        }
    }

    public void Injure(float DPS)
    {
        CurrHp -= DPS;

        if (CurrHp <= 0)
        {
            CurrHp = 0;
        }
        if(CurrHp >= MaxHP)
        {
            CurrHp = MaxHP;
        }

        if (turrutType == ETurrutType.Center)
        {
            //Debug.Log("Func1");
            EventManagerSystem.Instance.Invoke2(Data_EventName.MainTowerInjure_str, MainTowerInjureEventArgs.Create(DPS));
        }
        else
        {
            
            HpBar.SetHp(CurrHp / MaxHP);
        }
        if (CurrHp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        if (!isGameOver && !isDead)
        {
            //Debug.Log("Destory");
            isDead = true;
            SoundSystem.Instance.PlayEffect(Data_AudioID.key_TurrDestroyed);
            
            this.gameObject.SetActive(false);
            //EventManagerSystem.Instance.Delete2(Data_EventName.GameOver_str, GameOver2);
            //EventManagerSystem.Instance.Delete2(Data_EventName.GameOK_str, GameOver2);
            if (turrutType != ETurrutType.Center)
                Destroy(HpBar.gameObject);
            //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID, HpBar.gameObject);
            if(turrutType == ETurrutType.Center)
            {
                Debug.Log("GameOver");
                SoundSystem.Instance.StopMusic(Data_AudioID.key_FireBurning);
                EventManagerSystem.Instance.Invoke2(Data_EventName.GameOver_str, GameOverEventArgs.Create());
            }
        }
    }

    void GameOver2(IEventArgs eventArgs)
    {
        if (isDead)
        {
            return;
        }

        SoundSystem.Instance.StopMusic(Data_AudioID.key_FireBurning);
        isGameOver = true;
        //GameOverEventArgs gameOverEventArgs = (GameOverEventArgs)eventArgs;
        if (turrutType != ETurrutType.Center)
            Destroy(HpBar.gameObject);
        //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID, HpBar.gameObject);
        //EventManagerSystem.Instance.Delete2(Data_EventName.GameOver_str, GameOver2);
        //EventManagerSystem.Instance.Delete2(Data_EventName.GameOK_str, GameOver2);
    }

    void AutoInjure()
    {
        float DPS = TOOLS.GetTurrutConsumeSpeed(turrutType, (uint)curr_level);
        CurrHp -= DPS;

        if (turrutType == ETurrutType.Center)
        {
            EventManagerSystem.Instance.Invoke2(Data_EventName.MainTowerInjure_str, MainTowerInjureEventArgs.Create(DPS));
        }
        else
        {
            HpBar.SetHp(CurrHp / MaxHP);
        }
        if (CurrHp <= 0)
        {
            Dead();
        }
    }

    void FireWork()
    {
        Vector3 d = pm.gameObject.transform.position-this.transform.position;
        float distance = (d.x * d.x)+(d.y+d.y)+(d.z*d.z);
        float DPS = TOOLS.GetTurrutConduceSpeed(turrutType, (uint)curr_level);
        
        if (turrutType == ETurrutType.Center)
        {
            if(distance< fire_distance_big* fire_distance_big)
            {
                
                float currPer = CurrHp / MaxHP;
                float PlayerHpPer = pm.CurrPlayerHp / pm.PlayerHp;
                if(currPer< PlayerHpPer&& pm.CurrPlayerHp-DPS>0f)
                {
                    //CurrHp = Mathf.Min(MaxHP, CurrHp + DPS);
                    pm.InjureByTower(DPS);
                    Injure(-DPS);
                    EventManagerSystem.Instance.Invoke2(Data_EventName.PlayerInjure_str, PlayerInjureEventArgs.Create(DPS));
                }
                else if(CurrHp-DPS > 0f)
                {
                    //pm.CurrPlayerHp = Mathf.Min(pm.PlayerHp, pm.CurrPlayerHp+DPS);
                    pm.InjureByTower(-DPS);
                    EventManagerSystem.Instance.Invoke2(Data_EventName.PlayerInjure_str, PlayerInjureEventArgs.Create(-DPS));
                    Injure(DPS);/*
                    
                    CurrHp -= DPS;

                    HpBar.size = CurrHp / (float)MaxHP;
                    if (CurrHp <= 0)
                    {
                        Dead();
                    }*/
                }
            }
        }
        else
        {
            if (distance < fire_distance * fire_distance)
            {
                float currPer = CurrHp / MaxHP;
                float PlayerHpPer = pm.CurrPlayerHp / pm.PlayerHp;
                if (currPer < PlayerHpPer && pm.CurrPlayerHp - DPS > 0f)
                {
                    //CurrHp = Mathf.Min(MaxHP, CurrHp + DPS);
                    pm.InjureByTower(DPS);
                    Injure(-DPS);
                    EventManagerSystem.Instance.Invoke2(Data_EventName.PlayerInjure_str, PlayerInjureEventArgs.Create(DPS));
                }
                else if (CurrHp - DPS > 0f)
                {
                    //pm.CurrPlayerHp = Mathf.Min(pm.PlayerHp, pm.CurrPlayerHp+DPS);
                    pm.InjureByTower(-DPS);
                    EventManagerSystem.Instance.Invoke2(Data_EventName.PlayerInjure_str, PlayerInjureEventArgs.Create(-DPS));
                    Injure(DPS);/*
                    
                    CurrHp -= DPS;

                    HpBar.size = CurrHp / (float)MaxHP;
                    if (CurrHp <= 0)
                    {
                        Dead();
                    }*/
                }
            }
        }
    }
}
