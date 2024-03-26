using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace RPGCardsGenerator.Variables
{
    public abstract class Character
    {
        public List<String> BaseCharacteristic = new List<String>
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

        public List<String> BaseSkils = new List<String>
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


        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Statistic> Stats { get; set; } = new List<Statistic>();

        public bool MakeBase(int CharacterId)
        {
            using (var dbContext = new BoardsContext())
            {

            }

            return false;
        }


        public Character(string name)
        {
            this.Name = name;


        }

    }
}
