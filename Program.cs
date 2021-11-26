using System;

namespace lab2_shlegel
{
    class Program
    {
        static void Main(string[] args)
        {
            Klient Sargo = new Klient("Шлегель", 51234, 2000);
            Klient Dasha = new Klient("Чернышева", 42135, 2003);

            Kredit biz = new Kredit(Sargo.Fio, Sargo.Passport, Sargo.Birth, "Погашен", 15000, "4 года", "Покупка бизнеса");
            Kredit zhiguli = new Kredit(Sargo.Fio, Sargo.Passport, Sargo.Birth, "Погашен", 20000, "1 год", "Покупка авто");

            Bank vtb3 = new Bank("Тиньков", biz.summa, biz.uslovie, biz.naznachenie, Sargo.Fio, Sargo.Passport, Sargo.Birth, biz.status);
            Bank vtb4 = new Bank("Тиньков", zhiguli.summa, zhiguli.uslovie, zhiguli.naznachenie, Sargo.Fio, Sargo.Passport, Sargo.Birth, zhiguli.status);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("ПОГАШЕННЫЕ КРЕДИТЫ:");
            if (biz.StatusKredita() == "Погашен" && zhiguli.StatusKredita() == "Погашен")
            {
                
                Console.WriteLine("Клиент: " + Sargo.Fio + ", Паспорт: " + Sargo.Passport + "| Общая сумма погашенных кредитов: " + (biz.summa + zhiguli.summa));
            }
            else
            { Console.WriteLine("У клиента" + Sargo.Fio + " нет погашенных кредитов"); }

            Console.WriteLine("______________________________");

            Kredit ipoteka = new Kredit(Dasha.Fio, Dasha.Passport, Dasha.Birth, "Не погашен", 2000000, "23 года", "Ипотека");
            Kredit avtobuy = new Kredit(Dasha.Fio, Dasha.Passport, Dasha.Birth, "Не погашен", 500000, "2 года", "Покупка авто");

            Bank vtb = new Bank("Тиньков", ipoteka.summa, ipoteka.uslovie, ipoteka.naznachenie, Dasha.Fio, Dasha.Passport, Dasha.Birth, ipoteka.status);
            Bank vtb2 = new Bank("Тиньков", avtobuy.summa, avtobuy.uslovie, avtobuy.naznachenie, Dasha.Fio, Dasha.Passport, Dasha.Birth, ipoteka.status);

            if (ipoteka.Target() == avtobuy.Target())
            {
                Console.WriteLine("У клиента: " + Dasha.Fio + " уже есть открытый договор с таким же назначением назначением : " + ipoteka.naznachenie);
            }
            else
            {
                Console.WriteLine("ЗАКЛЮЧЕННЫЕ ДОГОВОРЫ:");
                Console.WriteLine(vtb.Info_Klient());
                Console.WriteLine(vtb2.Info_Klient());
            }

            Console.ReadKey();
        }
    }
    class Klient
    {
        public string Fio;
        public int Passport;
        public int Birth;

        public Klient(string Fio, int Passport, int Birth)
        {
            this.Fio = Fio;
            this.Passport = Passport;
            this.Birth = Birth;
        }

    }

    class Kredit
    {
        
        public Klient Klient;
        public int summa;
        public string uslovie;
        public string naznachenie;
        public string status;

        public Kredit(string Fio, int Passport, int Birth, string status, int summa, string uslovie, string naznachenie)
        {
            this.summa = summa;
            this.uslovie = uslovie;
            this.naznachenie = naznachenie;
            this.Klient = new Klient(Fio, Passport, Birth);
            this.status = status;
        }

        public string Target()
        {
            return this.naznachenie;
        }
        public string StatusKredita()
        {
            return this.status;
        }


        public string Info_Kredit()
        {
            return $"Номер комнаты: {summa} | Этаж: {uslovie} | Статус: {naznachenie}";
        }




    }

    class Bank
    {
        public string boss;
        public Kredit spisok;

        public Bank(string boss,int summa, string uslovie, string naznachenie, string Fio, int Passport, int Birth, string status)
        {
            this.boss = boss;
            this.spisok = new Kredit(Fio, Passport, Birth, status, summa, uslovie, naznachenie);
        }

        public string GetInfoBank()
        {
            return $" Начальник отдела: {boss} | \n Список кредитых договоров: {spisok.Klient.Fio} {spisok.Klient.Passport} {spisok.Klient.Birth}  {spisok.status} {spisok.summa} {spisok.uslovie} {spisok.naznachenie}  ";
        }

        


        public string Info_Klient()
        {
            return $" Клиент: {spisok.Klient.Fio} (Год рождения: {spisok.Klient.Birth} | Паспорт: {spisok.Klient.Passport})| Сумма кредита : {spisok.summa} | Условие: {spisok.uslovie}| Назначение: {spisok.naznachenie}| Статус: {spisok.status}";
        }
    }
}

