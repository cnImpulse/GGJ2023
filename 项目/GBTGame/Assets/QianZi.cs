using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class QianZi : MonoBehaviour
    {
        public Player Parent = default;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Parent.OnHookTool(collision.gameObject);
        }
    }
}
