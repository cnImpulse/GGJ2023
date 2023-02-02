using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public class TestObj : NetObj
    {
        public int id;
        public string name;

        public override string ToString()
        {
            return id.ToString() + " " + name;
        }
    }

    public class TestObj2 : NetObj
    {
        public string username;
        public string password;

        public override string ToString()
        {
            return string.Format("username:{0},password{1}", username, password);
        }
    }

    public class Login_Scuec : NetObj
    {
        public int login;//0表示登录未通过,1表示登录通过

        public override string ToString()
        {
            return string.Format("login:{0}", login);
        }
    }

    public class Get_User_Game : NetObj
    {
        public List<Get_User_Game_Item> get_User_Game_Items = new List<Get_User_Game_Item>();
    }

    public class Get_User_Game_Item
    {
        public int gameid;
        public string gamename;
        public string gameicon;
        public string localpath;

        public override string ToString()
        {
            return string.Format("gameid:{0},gamename:{1},gameicon:{2},localpath:{3}", gameid, gamename, gameicon, localpath);
        }
    }

    public class Get_Game_Content : NetObj
    {
        public List<Get_Game_Content_Item> get_Game_Content_Items = new List<Get_Game_Content_Item>();
    }

    public class Get_Game_Content_Item
    {
        public int contentid;
        public string contenttype;
        public string contentdes;
        public string contentpath;
        public string contentimgpath;
        public int contentparentid;

        public override string ToString()
        {
            return string.Format("contentid:{0},contenttype:{1},contentdes:{2},contentpath:{3},contentimgpath:{4},contentparentid{5}"
                , contentid, contenttype, contentdes, contentpath, contentimgpath, contentparentid);
        }
    }
}

