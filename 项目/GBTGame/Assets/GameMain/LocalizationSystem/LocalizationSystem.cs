using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    /// <summary>
    /// ���ػ�ϵͳ
    /// </summary>
    public class LocalizationSystem
    {
        private ELocalization CurrLanguage;
        private LocalizationSystem()
        {
            CurrLanguage = ELocalization.ChineseSimplified;
        }
        //����ģʽ
        private static LocalizationSystem instance = new LocalizationSystem();
        public static LocalizationSystem Instance
        {
            get { return instance; }
        }

        public void SetLanguage(ELocalization e)
        {
            CurrLanguage = e;
        }

        public string GetLocalizationString(string key)
        {
            switch (CurrLanguage)
            {
                case ELocalization.ChineseSimplified:
                    {
                        return Data_Localization.Dic[key].ChineseSimplified;
                    }
                case ELocalization.ChineseTraditional:
                    {
                        return Data_Localization.Dic[key].ChineseTraditional;
                    }
                case ELocalization.English:
                    {
                        return Data_Localization.Dic[key].English;
                    }
                default:
                    {
                        return Data_Localization.Dic[key].ChineseSimplified;
                    }
            }
        }

        public ELocalization GetLocalization()
        {
            return CurrLanguage;
        }

    }
}
