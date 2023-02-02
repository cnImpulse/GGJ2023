using DataCs;
using DG.Tweening;
using MyGameFrameWork;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public EPlayerHpState playerState;

    Transform Player;

    public float PlayerHp;
    public float CurrPlayerHp;

    float speed;
    Vector3 temp;
    Vector2 temp2;
    float distance;

    Vector2[] directs;
    int layermask;

    bool isMove;
    bool isDead;
    public Animator animator;

    float injure_currtime;
    float injure_time;

    float move_curr_time;
    float move_time;
    // Start is called before the first frame update
    void Start()
    {
        move_curr_time = 1f;
        move_time = 0.1f;
        injure_currtime = 1f;
        injure_time = 1f;
        transform.localEulerAngles = Vector3.zero;
        animator = GetComponent<Animator>();
        isDead = false;
        PlayerHp = TOOLS.GetPlayerMaxHp();
        CurrPlayerHp = PlayerData.GetDefaultObject().InitialHp;
        playerState = TOOLS.GetPlayerHpState(CurrPlayerHp);
        Player = GetComponent<Transform>();
        speed = 5f;
        distance = 0.5f;
        directs = new Vector2[8]
        {
            new Vector2(0, 1),
            new Vector2(0,-1),
            new Vector2(1, 0),
            new Vector2(-1,0),

            new Vector2(1,1),
            new Vector2(-1,-1),
            new Vector2(1,-1),
            new Vector2(-1,1)
        };
        layermask = (1 << 7) | (1 << 10);
    }

    public void PlayerInit()
    {
        move_curr_time = 1f;
        move_time = 0.1f;

        injure_currtime = 1f;
        injure_time = 1f;
        transform.localEulerAngles = Vector3.zero;
        isDead = false;
        transform.localPosition = new Vector3(2.22f, 0, 0);
        PlayerHp = TOOLS.GetPlayerMaxHp();
        CurrPlayerHp = PlayerData.GetDefaultObject().InitialHp;
        playerState = TOOLS.GetPlayerHpState(CurrPlayerHp);
    }

    // Update is called once per frame
    void Update()
    {
        move_curr_time += Time.deltaTime;

        injure_currtime+=Time.deltaTime;

        RaycastHit2D hit;
        temp = Vector3.zero;
        temp2.x = Player.localPosition.x;
        temp2.y = Player.localPosition.y;
        if (Input.GetKey(KeyCode.W))
        {
            isMove = true;
            move_curr_time = 0f;
            animator.SetBool("isMove", true);
            Debug.DrawRay(Player.localPosition, directs[0],Color.blue, distance);
            hit = Physics2D.Raycast(temp2 , directs[0], distance, layermask);
            if (!hit.collider)
            {
                
                temp.y += Time.deltaTime * speed;
            }
            else
            {
                //Debug.Log("CrushW");
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            isMove = true;
            move_curr_time = 0f;
            animator.SetBool("isMove", true);
            Debug.DrawRay(Player.localPosition, directs[3], Color.blue, distance);
            hit = Physics2D.Raycast(temp2 , directs[3], distance, layermask);
            if (!hit.collider)
            {
                temp.x -= Time.deltaTime * speed;
               
            }
            else
            {
                //Debug.Log("CrushA");
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            isMove = true;
            move_curr_time = 0f;
            animator.SetBool("isMove", true);
            Debug.DrawRay(Player.localPosition, directs[1], Color.blue, distance);
            hit = Physics2D.Raycast(temp2 , directs[1], distance, layermask);
            if (!hit.collider)
            {
                temp.y -= Time.deltaTime * speed;
               
            }
            else
            {
                //Debug.Log("CrushS");
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            isMove = true;
            move_curr_time = 0f;
            animator.SetBool("isMove", true);
            //Debug.Log("Move");
            Debug.DrawRay(Player.localPosition, directs[2], Color.blue, distance);
            hit = Physics2D.Raycast(temp2, directs[2], distance, layermask);
            if (!hit.collider)
            {
                temp.x += Time.deltaTime * speed;
            }
            else
            {
                //Debug.Log("CrushD");
            }
        }

        if(isMove && move_curr_time >= move_time)
        {
            //Debug.Log("No Move");
            isMove = false;
            animator.SetBool("isMove", false);
        }

        for (int i = 0; i < 8; i++)
        {
            hit = Physics2D.Raycast(this.transform.localPosition, directs[i], distance, layermask);
            if (hit.collider)
            {
                if (directs[i].x * temp.x > 0f)
                {
                    //temp.y += temp.x;
                    temp.x = 0;
                }
                else if (directs[i].y * temp.y > 0f)
                {
                    //temp.x += temp.y;
                    temp.y = 0;
                }
                break;
            }
        }


        Player.localPosition += temp;
    }

    public void Injure(float DPS)
    {
        if (injure_currtime >= injure_time && DPS>0)
        {
            SoundSystem.Instance.PlayEffect(Data_AudioID.key_PlayerInjured);
            injure_currtime = 0f;
        }
        CurrPlayerHp -= DPS;
        playerState = TOOLS.GetPlayerHpState(CurrPlayerHp);
        //Debug.Log(CurrPlayerHp);
        if (CurrPlayerHp <= 0 && !isDead)
        {
            SoundSystem.Instance.PlayEffect(Data_AudioID.key_PlayerDie);
            CurrPlayerHp = 0;
            playerState = TOOLS.GetPlayerHpState(CurrPlayerHp);
            isDead = true;
            Debug.Log("Dead");
            Vector3 endv = transform.localEulerAngles + new Vector3(0, 0, -90);
            transform.DOLocalRotate(endv, 0.5f).OnComplete(() =>
            {
                EventManagerSystem.Instance.Invoke2(DataCs.Data_EventName.GameOver_str, GameOverEventArgs.Create());
            });
            
        }
    }

    public void InjureByTower(float DPS)
    {
        CurrPlayerHp -= DPS;
        playerState = TOOLS.GetPlayerHpState(CurrPlayerHp);
        //Debug.Log(CurrPlayerHp);
        if (CurrPlayerHp <= 0 && !isDead)
        {
            SoundSystem.Instance.PlayEffect(Data_AudioID.key_PlayerDie);
            CurrPlayerHp = 0;
            playerState = TOOLS.GetPlayerHpState(CurrPlayerHp);
            isDead = true;
            Debug.Log("Dead");
            Vector3 endv = transform.localEulerAngles + new Vector3(0, 0, -90);
            transform.DOLocalRotate(endv, 0.5f).OnComplete(() =>
            {
                EventManagerSystem.Instance.Invoke2(DataCs.Data_EventName.GameOver_str, GameOverEventArgs.Create());
            });

        }
    }
}
