using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGameFrameWork
{
	public class LoginUserInfo : LocalFile
	{
		public string Username; //账号

		public string Password; //密码

		public int Remeber; //是否记住密码

		public int AutoLogin; //是否自动登录

	}
}

