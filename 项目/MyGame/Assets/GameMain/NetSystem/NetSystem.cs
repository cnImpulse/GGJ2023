using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using System.Threading.Tasks; //关键的包

using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;


namespace MyGameFrameWork
{
    public class NetSystem : MonoBehaviour
    {
        private NetSystem()
        {
            instance = this;
        }
        //单例模式
        private static NetSystem instance;
        public static NetSystem Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// 无参访问接口
        /// </summary>
        /// <typeparam name="T">必须实现NetObj接口</typeparam>
        /// <param name="url">接口地址</param>
        /// <returns>一个T类型的结果，或者null</returns>
        public async Task<NetObj> LoadDataSimple<T>(string url) where T : NetObj
        {
            var Request = UnityWebRequest.Post(url, "");
            await Request.SendWebRequest();
            var text = Request.downloadHandler.text;
            try
            {
                return JsonMapper.ToObject<T>(text);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }

        }

        /// <summary>
        /// 有参访问接口
        /// </summary>
        /// <typeparam name="T">必须实现NetObj接口</typeparam>
        /// <param name="url">接口地址</param>
        /// <param name="form">参数表单</param>
        /// <param name="succeed">成功访问函数</param>
        /// <param name="fail">失败访问函数</param>
        /// <returns>一个T类型的结果，或者null</returns>
        public async Task<NetObj> LoadData<T>(string url, WWWForm form = null, Action<System.Object> succeed = null, Action fail = null) where T : NetObj
        {
            UnityWebRequest Request = null;
            if (form != null)
            {
                Request = UnityWebRequest.Post(url, form);
            }
            else
            {
                Request = UnityWebRequest.Post(url, "");
            }

            await Request.SendWebRequest();
            var text = Request.downloadHandler.text;

            if (Request.result == UnityWebRequest.Result.ProtocolError ||
                Request.result == UnityWebRequest.Result.ConnectionError ||
                Request.result == UnityWebRequest.Result.DataProcessingError)
            {
                if (fail != null)
                {
                    fail();
                }
                Debug.LogError("Net Error!");
                return null;
            }
            else
            {

                try
                {
                    T obj = JsonMapper.ToObject<T>(text);
                    if (succeed != null)
                    {
                        succeed(obj);
                    }
                    return obj;
                }
                catch (Exception ex)
                {
                    if (fail != null)
                    {
                        fail();
                    }
                    Debug.LogError(ex.Message);
                    return null;
                }
            }
        }

        public async Task<Texture> LoadImg(string url, Action<Texture> succeed = null)
        {
            if (ObjectPoolSystem.Instance.TestTexturePool(url))
            {
                return ObjectPoolSystem.Instance.GetTextureFormPool(url);
            }

            UnityWebRequest Request = null;
            Request = UnityWebRequestTexture.GetTexture(url);
            await Request.SendWebRequest();


            if (Request.result == UnityWebRequest.Result.ProtocolError ||
                Request.result == UnityWebRequest.Result.ConnectionError ||
                Request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Net Error!");
                return null;
            }
            else
            {

                try
                {
                    Texture2D download = ((DownloadHandlerTexture)Request.downloadHandler).texture;
                    ObjectPoolSystem.Instance.ReBackTexturePool(url, download);
                    if (succeed != null)
                    {
                        succeed(download);
                    }
                    return download;
                }
                catch (Exception ex)
                {
                    Debug.LogError(ex.Message);
                    return null;
                }
            }
        }
    }

    public static class ExtensionMethods
    {
        public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<object>();
            asyncOp.completed += obj => { tcs.SetResult(null); };
            return ((Task)tcs.Task).GetAwaiter();
        }
    }
}

