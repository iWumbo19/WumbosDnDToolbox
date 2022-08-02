using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using WumbosDnDToolbox.Model;
using WumbosDnDToolbox.Model.Monster;

namespace WumbosDnDToolbox.Data
{
    public static class MonsterDb
    {
        public static MonsterModel[] _monsters;

        public static bool InitializeMonsterDb()
        {
            try
            {
                string collectionJSON = new WebClient().DownloadString("https://www.dnd5eapi.co/api/monsters/");
                CategoryReferenceModel monsterReference = JsonConvert.DeserializeObject<CategoryReferenceModel>(collectionJSON);
                List<string> monsterNameList = new List<string>();
                List<MonsterModel> monsters = new List<MonsterModel>();
                foreach (APIReferenceModel item in monsterReference.results)
                {
                    monsterNameList.Add(item.name);
                    string monsterJSON = new WebClient().DownloadString("https://www.dnd5eapi.co" + item.url);
                    monsters.Add(JsonConvert.DeserializeObject<MonsterModel>(monsterJSON));
                }
                monsterNameList.Sort();
                _monsters = monsters.ToArray();
            }
            catch (System.Exception)
            {
                return false;
            }
            if (_monsters.Length == 0) return false;
            return true;
        }

        public static bool InitializeMonsterDbSmall()
        {
            try
            {
                string collectionJSON = new WebClient().DownloadString("https://www.dnd5eapi.co/api/monsters/");
                CategoryReferenceModel monsterReference = JsonConvert.DeserializeObject<CategoryReferenceModel>(collectionJSON);
                List<string> monsterNameList = new List<string>();
                List<MonsterModel> monsters = new List<MonsterModel>();
                for (int i = 0; i < 25; i++)
                {
                    monsterNameList.Add(monsterReference.results[i].name);
                    string monsterJSON = new WebClient().DownloadString("https://www.dnd5eapi.co" + monsterReference.results[i].url);
                    monsters.Add(JsonConvert.DeserializeObject<MonsterModel>(monsterJSON));
                }
                monsterNameList.Sort();
                _monsters = monsters.ToArray();
            }
            catch (System.Exception)
            {
                return false;
            }
            if (_monsters.Length == 0) return false;
            return true;
        }

        public static MonsterModel GetMonster(string name)
        {
            foreach (MonsterModel monster in _monsters)
            {
                if (monster.name == name) return monster;
            }
            return null;
        }
    }
}
