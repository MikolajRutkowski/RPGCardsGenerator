using Microsoft.EntityFrameworkCore;
using RPGCardsGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCardsGenerator
{
    public static class AddSkils
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
       
        public static List<Statistic> BaseSkils = new List<Statistic> 
        {
            new Statistic("Antropologia", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Archeologia", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Broń palna", TypeOfCariables.skill, "(Pistolet, Karabin, Strzelba)", rollDice(20), 1),
            new Statistic("Historia", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Jazda (samochodem)", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Jazda konno", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Język (Inny)", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Korzystanie z biblioteki", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Medycyna", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Mitologia Cthulhu", TypeOfCariables.skill, "", 0),
            new Statistic("Naprawa elektryczna", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Naprawa mechaniczna", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Nauka", TypeOfCariables.skill, "(różne kategorie)", rollDice(20), 1),
            new Statistic("Nawigacja", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Obsługa ciężkiego sprzętu", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Ocenianie/Wycena", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Ocena wiarygodności kredytowej", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Okultyzm", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Pierwsza pomoc", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Przekonywanie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Przebranie/Maskowanie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Przetrwanie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Psychoanaliza", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Psychologia", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Prawo", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Pływanie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Rachunkowość", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Rzut", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Skok", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Skradanie się", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Słuchanie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Szybkie rozmawianie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Sztuka/Rzemiosło", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Urok/Oczarowanie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Unik", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Widzenie ukrytych rzeczy", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Wspinaczka", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Zastraszenie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Zręczność manualna", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Śledzenie", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Ślusarstwo", TypeOfCariables.skill, "", rollDice(20), 1),
            new Statistic("Świat naturalny", TypeOfCariables.skill, "", rollDice(20), 1)
        };
    

        public readonly static List<String> BaseSkilsName = new List<String>
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
