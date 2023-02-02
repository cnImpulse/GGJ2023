using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public class ObjectPoolSystem
    {
        //µ¥ÀýÄ£Ê½
        private static ObjectPoolSystem instance = new ObjectPoolSystem();
        public static ObjectPoolSystem Instance
        {
            get { return instance; }
        }

        static Dictionary<int, Queue<GameObject>> GameObjectPool = new Dictionary<int, Queue<GameObject>>();//¶ÔÏó³Ø×Öµä

        static Dictionary<int, Queue<UIForm>> UIFormPool = new Dictionary<int, Queue<UIForm>>();//UIFORM³Ø×Öµä

        static Dictionary<int, Queue<UIItem>> UIItemPool = new Dictionary<int, Queue<UIItem>>();//UIItem³Ø×Öµä

        static Dictionary<int, Queue<AudioClip>> AudioClipPool = new Dictionary<int, Queue<AudioClip>>();//AudioClip³Ø×Öµä

        static Dictionary<string, Queue<Texture>> TexturePool = new Dictionary<string, Queue<Texture>>();//ÎÆÀí³Ø
        public bool ReBackGameObjectPool(int id, GameObject obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!GameObjectPool.ContainsKey(id))
            {
                GameObjectPool.Add(id, new Queue<GameObject>());
            }
            obj.SetActive(false);
            GameObjectPool[id].Enqueue(obj);

            return true;
        }

        public bool ReBackUIFormPool(int id, UIForm uIForm)
        {
            if (uIForm == null)
            {
                return false;
            }

            if (!UIFormPool.ContainsKey(id))
            {
                UIFormPool.Add(id, new Queue<UIForm>());
            }
            uIForm.gameObject.SetActive(false);
            UIFormPool[id].Enqueue(uIForm);
            return true;
        }

        public bool ReBackUIItemPool(int id, UIItem uiItem)
        {
            if (uiItem == null)
            {
                return false;
            }

            if (!UIItemPool.ContainsKey(id))
            {
                UIItemPool.Add(id, new Queue<UIItem>());
            }
            uiItem.gameObject.SetActive(false);
            UIItemPool[id].Enqueue(uiItem);
            return true;
        }

        public bool ReBackAudioClipPool(int id, AudioClip audioClip)
        {
            if (audioClip == null)
            {
                return false;
            }

            if (!AudioClipPool.ContainsKey(id))
            {
                AudioClipPool.Add(id, new Queue<AudioClip>());
            }
            AudioClipPool[id].Enqueue(audioClip);
            return true;
        }

        public bool ReBackTexturePool(string path, Texture texture)
        {
            if (texture == null)
            {
                return false;
            }

            if (!TexturePool.ContainsKey(path))
            {
                TexturePool.Add(path, new Queue<Texture>());
            }
            TexturePool[path].Enqueue(texture);
            return true;
        }

        public GameObject GetGameObjectFormPool(int id)
        {
            if (GameObjectPool.ContainsKey(id) && GameObjectPool[id].Count != 0)//È¡³Ø
            {
                GameObject temp = GameObjectPool[id].Dequeue();
                return temp;
            }
            return null;
        }

        public UIForm GetUIFormFormPool(int id)
        {
            if (UIFormPool.ContainsKey(id) && UIFormPool[id].Count != 0)//È¡³Ø
            {
                UIForm temp = UIFormPool[id].Dequeue();
                temp.gameObject.SetActive(true);
                return temp;
            }
            return null;
        }

        public UIItem GetUIItemFormPool(int id)
        {
            if (UIItemPool.ContainsKey(id) && UIItemPool[id].Count != 0)//È¡³Ø
            {
                UIItem temp = UIItemPool[id].Dequeue();
                temp.gameObject.SetActive(true);
                return temp;
            }
            return null;
        }

        public AudioClip GetAudioClipFormPool(int id)
        {
            if (AudioClipPool.ContainsKey(id) && AudioClipPool[id].Count != 0)//È¡³Ø
            {
                AudioClip temp = AudioClipPool[id].Dequeue();
                return temp;
            }
            return null;
        }

        public Texture GetTextureFormPool(string path)
        {
            if (TexturePool.ContainsKey(path) && TexturePool[path].Count != 0)//È¡³Ø
            {
                Texture temp = TexturePool[path].Dequeue();
                return temp;
            }
            return null;
        }



        public bool TestGameObjectPool(int id)
        {
            if (GameObjectPool.ContainsKey(id) && GameObjectPool[id].Count != 0)//È¡³Ø
            {
                return true;
            }
            return false;
        }

        public bool TestUIFormPool(int id)
        {
            if (UIFormPool.ContainsKey(id) && UIFormPool[id].Count != 0)//È¡³Ø
            {
                return true;
            }
            return false;
        }

        public bool TestUIItemPool(int id)
        {
            if (UIItemPool.ContainsKey(id) && UIItemPool[id].Count != 0)//È¡³Ø
            {
                return true;
            }
            return false;
        }

        public bool TestAudioClipPool(int id)
        {
            if (AudioClipPool.ContainsKey(id) && AudioClipPool[id].Count != 0)//È¡³Ø
            {
                return true;
            }
            return false;
        }

        public bool TestTexturePool(string path)
        {
            if (TexturePool.ContainsKey(path) && TexturePool[path].Count != 0)//È¡³Ø
            {
                return true;
            }
            return false;
        }
    }
}

