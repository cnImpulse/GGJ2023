using DataCs;
using MyGameFrameWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Security.Cryptography;
using System.Net;

public class EnemyMove2 : MonoBehaviour
{

    // Start is called before the first frame update
    public float speed = 20f;
    Transform ts;
    public Tower Tower1;
    public Tower BigTower2;
    public Transform Player;
    Vector2[] directs;

    float distance;
    float attack_distance;
    float attack_tower_distance;
    float attack_big_tower_distance;
    float follow_distance;

    int layermask;
    private Camera cam;
    private TowerHpBar HpBar;

    public GameObject Canva;

    public float MaxHp;
    public float CurrHp;
    public float CurrDenfense;

    bool isDead;
    bool isAttack;
    bool isGameOver;

    Vector2 rv2;

    int attack_mode;

    Vector3 follow_location;

    Animator an;
    //string WalkString;
    //string AtttackString;
    Vector3 XAV3;//用于反转
    Vector3 XBV3;

    //SpriteRenderer OBJASp;
    //Animator OBJAnimator;
    //GameObject SubObj;
    bool isBoom;

    float isDead_curr_time;
    float isDead_time;

    float injure_currtime;
    float injure_time;

    void Start()
    {

         injure_currtime = 1f;
         injure_time = 0.5f;

        an = GetComponent<Animator>();
        //OBJAnimator = transform.Find("GameObject").gameObject.GetComponent<Animator>();
        //OBJASp = transform.Find("GameObject").gameObject.GetComponent<SpriteRenderer>();
        //SubObj = OBJAnimator.gameObject;
        //WalkString = "EnemyAWalk";
        //AtttackString = "EnemyAAtack";

        isDead_curr_time = 0f;
        isDead_time = 1.2f;
        float rx = Random.Range(0, 1);
        float ry = Random.Range(0, 1);
        rv2.x = rx;
        rv2.y = ry;
        isDead = false;
        isAttack = false;
        isBoom = false;
        an.SetBool("isAttack", isAttack);
        //OBJAnimator.enabled = isAttack;
        //OBJASp.enabled = isAttack;
        attack_mode = 1;//mode 1 = small 2 = big 3 = player;
        GetComponent<CircleCollider2D>().enabled = true;

        MaxHp = TOOLS.GetMonsterDataById(2).MaxHp;
        CurrHp = MaxHp;
        CurrDenfense = TOOLS.GetMonsterDataById(2).InitialDefense;

        cam = Camera.main;

        distance = 0.5f;
        attack_distance = 1f;
        follow_distance = 3f;
        attack_tower_distance = 4.5f;
        attack_big_tower_distance = 5f;
        ts = GetComponent<Transform>();
        directs = new Vector2[8]
        {
            new Vector2(0,1),
            new Vector2(0,-1),
            new Vector2(1,0),
            new Vector2(-1,0),

            new Vector2(1,1),
            new Vector2(-1,-1),
            new Vector2(1,-1),
            new Vector2(-1,1)
        };
        layermask = (1 << 7) | (1 << 10);
        //CreateHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        injure_currtime +=Time.deltaTime;

        if (isDead)
        {
            isDead_curr_time += Time.deltaTime;
            if (isDead_curr_time >= isDead_time)
            {
                isDead_curr_time = 0f;

                if (!isGameOver)
                {
                    EventManagerSystem.Instance.Invoke2(Data_EventName.KillMonster_str, KillMonsterEventArgs.Create(2));
                    Destroy(HpBar.gameObject);
                    Destroy(this.gameObject);
                    //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID, HpBar.gameObject);
                    //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyA].ID, this.gameObject);
                    //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyAObj].ID, SubObj);

                }
            }
        }
        Select();
        Anim();
        if (attack_mode == 1)
        {
            follow_location = Tower1.transform.localPosition;
        }
        else if (attack_mode == 2)
        {
            follow_location = BigTower2.transform.localPosition;
        }
        else
        {
            follow_location = Player.localPosition;
        }
        Attack(follow_location);
        Move(follow_location);
        HpBarMove();

    }

    public void init(Tower stower, Tower btower, Transform player, GameObject canva)
    {
        injure_currtime = 1f;
        injure_time = 0.5f;

        isDead_curr_time = 0f;
        isDead_time = 1.2f;
        transform.localEulerAngles = Vector3.zero;
        Tower1 = stower;
        BigTower2 = btower;
        Player = player;
        Canva = canva;
        isDead = false;
        isAttack = false;
        isBoom = false;
        attack_mode = 1;
        XAV3 = new Vector3(-0.5f, 0.5f);
        XBV3 = new Vector3(0.5f, 0.5f);
        an = GetComponent<Animator>();

        int id = Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyAObj].ID;

        
        an.SetBool("isAttack", isAttack);
        
        isGameOver = false;
        GetComponent<CircleCollider2D>().enabled = true;
        
        MaxHp = TOOLS.GetMonsterDataById(2).MaxHp;
        CurrHp = MaxHp;
        CurrDenfense = TOOLS.GetMonsterDataById(2).InitialDefense;

        CreateHPBar();

        EventManagerSystem.Instance.Add2(Data_EventName.GameOver_str, GameOver);
    }

    void Anim()
    {
        //if()

    }


    void Select()
    {
        if (attack_mode == 3)
        {
            return;
        }
        Vector3 direct = Player.localPosition - this.transform.position;
        if (follow_distance * follow_distance > direct.z * direct.z + direct.y * direct.y + direct.x * direct.x)
        {
            attack_mode = 3;
        }
        else if (attack_mode == 1)//当前攻击塔
        {
            if (Tower1.isDead)//小塔死了
            {
                attack_mode = 2;//攻击主塔
            }
        }
    }

    void Attack(Vector3 pos)
    {
        if (isDead || isAttack)
        {
            return;
        }
        Vector3 direct = pos - this.transform.position;
        //Debug.Log(direct.z * direct.z + direct.y * direct.y + direct.x * direct.x);
        if (attack_big_tower_distance * attack_big_tower_distance > direct.z * direct.z + direct.y * direct.y + direct.x * direct.x && attack_mode == 2)
        {
            //SubObj.transform.localPosition = pos;// BigTower2.transform.localPosition+this.transform.localPosition;
            UseObject(pos);
            // AttackTower(BigTower2);
        }
        if (attack_tower_distance * attack_tower_distance > direct.z * direct.z + direct.y * direct.y + direct.x * direct.x && attack_mode == 1)
        {
            UseObject(pos);
            //AttackTower(Tower1);
        }
        else if (attack_distance * attack_distance > direct.z * direct.z + direct.y * direct.y + direct.x * direct.x && attack_mode == 3)
        {
            UseObject(pos);
            //Attack(Player.gameObject);
        }
    }

    void Move(Vector3 pos)
    {
        if (isDead || isAttack)
        {
            return;
        }
        Vector3 direct = pos - this.transform.position;
        direct.z = 0;
        direct.x += rv2.x;
        direct.y += rv2.y;
        direct = Vector3.Normalize(direct);

        RaycastHit2D hit;
        for (int i = 0; i < 8; i++)
        {
            hit = Physics2D.Raycast(this.transform.localPosition, directs[i], distance, layermask);
            if (hit.collider)
            {
                if (directs[i].x * direct.x > 0f)
                {
                    direct.y += direct.x;
                    direct.x = 0;
                }
                else if (directs[i].y * direct.y > 0f)
                {
                    direct.x += direct.y;
                    direct.y = 0;
                }
                break;
            }
        }
        direct = Vector3.Normalize(direct);
        if (direct.x > 0f)
            transform.localScale = XAV3;
        else
            transform.localScale = XBV3;
        this.transform.localPosition += direct * speed * Time.deltaTime;
    }

    void HpBarMove()
    {
        Vector3 playerScreenPos = Vector3.zero;
        if (cam != null)
            playerScreenPos = cam.WorldToScreenPoint(this.transform.position);
        //再把人物坐标Y加一个高度给到人物
        if (HpBar != null)
            HpBar.gameObject.GetComponent<RectTransform>().position = new Vector3(playerScreenPos.x, playerScreenPos.y + 70f, playerScreenPos.z);

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
        HpBar.SetMaxHp(MaxHp, CurrHp);
        HpBar.SetHp(1f);
    }

    public void Injure(float DPS)
    {
        if (injure_currtime >= injure_time)
        {
            injure_currtime = 0f;
            SoundSystem.Instance.PlayEffect(Data_AudioID.key_FireHit);
        }
        CurrHp -= DPS;
        if (CurrHp <= 0)
        {
            HpBar.SetHp(0f);
            CurrHp = 0;
            Dead();
        }
        else
        {
            //HpBar.size = CurrHp / MaxHp;
            HpBar.SetHp(CurrHp / MaxHp);
        }
    }

    void Dead()
    {
        if (isDead)
        {
            return;
        }
        Vector3 endv = transform.localEulerAngles + new Vector3(0, 0, -90);
        transform.DOLocalRotate(endv, 0.5f);
        //an.SetBool("isAttack", false);
        //EventManagerSystem.Instance.Delete2(Data_EventName.GameOver_str, GameOver);
        isDead = true;
        //GetComponent<CircleCollider2D>().enabled = false;
        /*Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            if (!isGameOver)
            {
                EventManagerSystem.Instance.Invoke2(Data_EventName.KillMonster_str, KillMonsterEventArgs.Create(2));
                Destroy(HpBar.gameObject);
                Destroy(this.gameObject);
                //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID, HpBar.gameObject);
                //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyA].ID, this.gameObject);
                //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyAObj].ID, SubObj);
                
            }
        })
        .SetDelay(1f);*/
    }

    void DeadSelf()
    {
        //an.SetBool("isAttack", false);
        EventManagerSystem.Instance.Delete2(Data_EventName.GameOver_str, GameOver);
        isDead = true;
        //GetComponent<CircleCollider2D>().enabled = false;
       /* Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            if (!isGameOver)
            {
                EventManagerSystem.Instance.Invoke2(Data_EventName.KillMonster_str, KillMonsterEventArgs.Create(2));
                Destroy(HpBar.gameObject);
                Destroy(this.gameObject);
                //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID, HpBar.gameObject);
                //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyA].ID, this.gameObject);
                //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyAObj].ID, SubObj);
                
            }
        })
        .SetDelay(1f);*/
    }

    void Attack(GameObject Player)
    {
        float DPS = TOOLS.GetMonsterToPlayerDps(2, Player.GetComponent<PlayerMove>().CurrPlayerHp);
        
        Player.GetComponent<PlayerMove>().Injure(DPS);// -= DPS;
        EventManagerSystem.Instance.Invoke2(Data_EventName.PlayerInjure_str, PlayerInjureEventArgs.Create(DPS));
        Sequence seq = DOTween.Sequence();

        
    }

    void AttackTower(Tower tower)
    {
        //Debug.Log("AttackTower");
        //isAttack = true;

        
        tower.Injure(2);// -= DPS;
                        //isAttack = false;

        
    }

    void GameOver(IEventArgs eventArgs)
    {
        isGameOver = true;
        //GameOverEventArgs gameOverEventArgs = (GameOverEventArgs)eventArgs;
        Destroy(HpBar.gameObject);
        Destroy(this.gameObject);
        //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_HPBar].ID, HpBar.gameObject);
        //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyA].ID, this.gameObject);
        //ObjectPoolSystem.Instance.ReBackGameObjectPool(Data_GameObjectID.Dic[DataCs.Data_GameObjectID.key_EnemyAObj].ID, SubObj);
    }

    void UseObject(Vector3 pos)
    {
        isAttack = true;
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1.5f);
        seq.AppendCallback(() =>
        {
            if (!isGameOver && !isDead)
            {   

                if (attack_mode == 1)
                {
                    pos = Tower1.transform.localPosition;
                }
                else if (attack_mode == 2)
                {
                    pos = BigTower2.transform.localPosition;
                }
                else
                {
                    pos = Player.localPosition;
                }
                Vector3 directTower1 = Tower1.transform.localPosition - this.transform.position;
                Vector3 directTower2 = BigTower2.transform.localPosition - this.transform.position;
                Vector3 directPlayer = Player.localPosition - this.transform.position;
                //Debug.Log(direct.z * direct.z + direct.y * direct.y + direct.x * direct.x);
                if (attack_big_tower_distance * attack_big_tower_distance > directTower1.z * directTower1.z + directTower1.y * directTower1.y + directTower1.x * directTower1.x)
                {
                    isBoom = true;
                    an.SetBool("isAttack", isAttack);
                    AttackTower(Tower1);
                    
                }
                if (attack_tower_distance * attack_tower_distance > directTower2.z * directTower2.z + directTower2.y * directTower2.y + directTower2.x * directTower2.x)
                {
                    //UseObject(pos);
                    isBoom = true;
                    an.SetBool("isAttack", isAttack);
                    AttackTower(BigTower2);
                }
                if (attack_tower_distance * attack_tower_distance > directPlayer.z * directPlayer.z + directPlayer.y * directPlayer.y + directPlayer.x * directPlayer.x)
                {
                    //UseObject(pos);
                    isBoom = true;
                    an.SetBool("isAttack", isAttack);
                    Attack(Player.gameObject);
                }
            }
        });
        seq.AppendInterval(0.2f);
        seq.AppendCallback(() => {
            if(isBoom)
            {
                SoundSystem.Instance.PlayEffect(Data_AudioID.key_Monster2Bomb);
                DeadSelf();
            }
            else
            {
                isAttack = false;
            }
        });
    }
    private void OnDestroy()
    {
        EventManagerSystem.Instance.Delete2(Data_EventName.GameOver_str, GameOver);
    }
}
