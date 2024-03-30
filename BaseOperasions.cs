using Microsoft.EntityFrameworkCore;
using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator
{
    public static class BaseOperasions
    {
        public static int rollDice(int k = 6)
        {
            int results = new Random().Next(1,k+1);
            return results;
        }

        public readonly static List<String> BaseCharacteristicName = new List<String>
        {
           "Siła", // 3k6     
           "Kondycja ", // 3k6
           "Moc ", // 3k6
           "Zręczność ", // 3k6
           "Wygląd ", // 3k6
           "Inteligencja ", //2k6 + 6
           "Wykształcenie ", //2k6 + 6
           "Budowa Ciała",  //2k6 + 6
           "Ruch" 
        };

        public static List<Statistic> BaseCharacteristic = new List<Statistic>
        {
           new Statistic("Siła",TypeOfCariables.characteristic,"",rollDice(),rollDice(),rollDice()),
           new Statistic("Kondycja", TypeOfCariables.characteristic, "",rollDice(),rollDice(),rollDice()),
           new Statistic("Moc", TypeOfCariables.characteristic, "",rollDice(),rollDice(),rollDice()),
           new Statistic("Zręczność", TypeOfCariables.characteristic, "", rollDice(),rollDice(),rollDice()),
           new Statistic("Wygląd", TypeOfCariables.characteristic, "", rollDice(),rollDice(),rollDice()),
           new Statistic("Inteligencja", TypeOfCariables.characteristic, "", 6,rollDice(),rollDice()),
           new Statistic("Wykształcenie", TypeOfCariables.characteristic, "", 6,rollDice(),rollDice()),
           new Statistic("Budowa Ciała", TypeOfCariables.characteristic, "", 6,rollDice(),rollDice()),
           new Statistic("Ruch", TypeOfCariables.characteristic, "", 7)

        };

        public readonly static List<String> BaseSkils = new List<String>
        {
           "Antropologia",
            "Archeologia",
            "Broń palna (Pistolet, Karabin, Strzelba)",
            "Historia",
            "Jazda (samochodem)",
            "Jazda konno",
            "Język (Inny)",
            "Korzystanie z biblioteki",
            "Medycyna",
            "Mitologia Cthulhu",
            "Naprawa elektryczna",
            "Naprawa mechaniczna",
            "Nauka (różne kategorie)",
            "Nawigacja",
            "Obsługa ciężkiego sprzętu",
            "Ocenianie/Wycena",
            "Ocena wiarygodności kredytowej",
            "Okultyzm",
            "Pierwsza pomoc",
            "Przekonywanie",
            "Przebranie/Maskowanie",
            "Przetrwanie",
            "Psychoanaliza",
            "Psychologia",
            "Prawo",
            "Pływanie",
            "Rachunkowość",
            "Rzut",
            "Skok",
            "Skradanie się",
            "Słuchanie",
            "Szybkie rozmawianie",
            "Sztuka/Rzemiosło" ,
            "Urok/Oczarowanie",
            "Unik",
            "Widzenie ukrytych rzeczy",
            "Wspinaczka",
            "Zastraszenie",
            "Zręczność manualna",
            "Śledzenie",
            "Ślusarstwo",
            "Świat naturalny"
        };

        public static List<string> MakeLitOfstring(List<Statistic> baseList)
        {
            List<string> result = new List<string>();
            for (int i = 0; i <  baseList.Count; i++)
            {
                result.Add(baseList[i].Name);
            }

            return result;
        }

        public static bool MakeBase(int SuspectId, List<Statistic> BaseList)
        {
            using (var dbContext = new BoardsContext())
            {
                var user = dbContext.Characters.Include(u => u.Stats).FirstOrDefault(c => c.Id == SuspectId);
                if (user == null)
                {
                    return false;
                }
                var ListOfcharacterStats = MakeLitOfstring(user.Stats.ToList());
                
                for(int i = 0; i < BaseList.Count; i++)
                {
                    if (!ListOfcharacterStats.Contains(BaseList[i].Name))
                    {
                        dbContext.Add(new Statistic()
                        {
                            Name = BaseList[i].Name,
                            Value = BaseList[i].Value,
                            CharaterId = SuspectId,
                            Description = BaseList[i].Description,
                            Type = BaseList[i].Type


                        }) ;
                    }
                }
                dbContext.SaveChanges();

            }

            return true;
        }
    }
}
