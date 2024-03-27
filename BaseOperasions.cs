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
        public readonly static List<String> BaseCharacteristic = new List<String>
        {
           "Siła",
           "Budowa Ciała",
           "Kondycja ",
           "Moc ",
           "Zręczność ",
           "Wygląd ",
           "Inteligencja ",
           "Wykształcenie ",
           "Ruch"
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



        public static bool MakeBase(int CharacterId, List<String> BaseList)
        {
            using (var dbContext = new BoardsContext())
            {
                var user = dbContext.Characters.FirstOrDefault(c => c.Id == CharacterId);
                if (user == null)
                {
                    return false;
                }
                var ListOfcharacterStats = user.Stats.ToList();
                


            }

            return true;
        }
    }
}
