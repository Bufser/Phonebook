using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Contacts
    {
        public string surname;
        public string name;
        public string patronymic;
        public string number;
        public string country;
        public string birthday;
        public string organization;
        public string post;
        public string other;

        public Contacts(string surname, string name, string patronymic, string number, string country, string birthday, string organization, string post, string other)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.number = number;
            this.country = country;
            this.birthday = birthday;
            this.organization = organization;
            this.post = post;
            this.other = other;
        }
    }
    class NoteBook
    {
        List<Contacts> contacts = new List<Contacts>();


        public void add(string surname, string name, string patronymic, string number, string country, string birthday, string organization, string post, string other)
        {
            Contacts date = new Contacts(surname, name, patronymic, number, country, birthday, organization, post, other);
            contacts.Add(date);
        }

        public void list(Action<Contacts> action)
        {
            contacts.ForEach(action);
        }



        public bool remove(string name)
        {
            Contacts date = find(name);

            if (date != null)
            {
                contacts.Remove(date);
                return true;
            }
            else
            {
                return false;
            }
        }


        public Contacts find(string name)
        {
            Contacts date = contacts.Find(
              delegate (Contacts a)
              {
                  return a.name == name;
              }
            );
            return date;
        }
    }

    class Program
    {
        NoteBook phone = new NoteBook();

        static void Main(string[] args)
        {
            int variable;
            Program bas = new Program();

            bas.Menu();
            do
            {
                Console.WriteLine("Выберите: ");
                variable = int.Parse(Console.ReadLine());
                bas.WorkSpace(variable);
            }
            while (variable != 0);
        }

        void Menu()
        {
            Console.WriteLine("1. Создание записей\n2. Редактирование записей\n3. Удаление созданных зприсей\n4. Просмотр созданных записей\n5. Просмотр всех созданных записей с краткой информацией\n0. Выход\n------ОДИНАКОВЫЕ ИМЕНА ИСПОЛЬЗОВАТЬ НЕ РЕКОМЕНДУЕТСЯ------");
        }

        void WorkSpace(int variable)
        {
            string surname = "";
            string name = "";
            string patronymic = "";
            string number = "";
            string country = "";
            string birthday = "";
            string organization = "";
            string post = "";
            string other = "";

            switch (variable)
            {
                case 1:
                    Console.WriteLine("Введите фамилию: ");
                    surname = Console.ReadLine();
                    Console.WriteLine("Введите имя: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите отчество: ");
                    patronymic = Console.ReadLine();
                    Console.WriteLine("Введите номер: ");
                    number = Console.ReadLine();
                    Console.WriteLine("Введите страну: ");
                    country = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения: ");
                    birthday = Console.ReadLine();
                    Console.WriteLine("Введите организацию: ");
                    organization = Console.ReadLine();
                    Console.WriteLine("Введите должность: ");
                    post = Console.ReadLine();
                    Console.WriteLine("Введите прочее: ");
                    other = Console.ReadLine();
                    phone.add(surname, name, patronymic, number, country, birthday, organization, post, other);
                    Console.WriteLine("Контакт добавлен");
                    break;
                case 2:
                    Console.WriteLine("Введите имя для редактирования: ");
                    name = Console.ReadLine();
                    Contacts date;
                    date = phone.find(name);
                    if (date == null)
                    {
                        Console.WriteLine("контакт {0} не найден.", name);
                        Console.ReadKey();
                    }
                    else
                    {
                        int t = 0;
                        string redact = "";
                        while (t != 1)
                        {
                            Console.WriteLine("Введите параметр редактирования: ");
                            redact = Console.ReadLine();
                            switch (redact.ToLower())
                            {
                                case "фамилия":
                                    Console.WriteLine("Введите новую фамилию: ");
                                    date.surname = Console.ReadLine();
                                    break;
                                case "имя":
                                    Console.WriteLine("Введите новое имя: ");
                                    date.name = Console.ReadLine();
                                    break;
                                case "отчество":
                                    Console.WriteLine("введите новое отчество: ");
                                    date.patronymic = Console.ReadLine();
                                    break;
                                case "номер":
                                    Console.WriteLine("введите новый номер: ");
                                    date.number = Console.ReadLine();
                                    break;
                                case "страна":
                                    Console.WriteLine("Введите новую стрпану: ");
                                    date.country = Console.ReadLine();
                                    break;
                                case "дата рождения":
                                    Console.WriteLine("Введите новую дату рождения: ");
                                    date.birthday = Console.ReadLine();
                                    break;
                                case "организация":
                                    Console.WriteLine("Введите новое название организации: ");
                                    date.organization = Console.ReadLine();
                                    break;
                                case "должность":
                                    Console.WriteLine("Введите новую должность: ");
                                    date.post = Console.ReadLine();
                                    break;
                                case "прочее":
                                    Console.WriteLine("Измените прочую информацию: ");
                                    date.other = Console.ReadLine();
                                    break;
                            }
                            Console.WriteLine("Изменить что-то еще?(да/нет)");
                            string val = Console.ReadLine();
                            if (val == "да")
                            {
                                t = 0;
                            }
                            else
                            {
                                t++;
                                redact = null;
                            }
                        }

                    }
                    break;
                case 3:
                    Console.WriteLine("Введите имя для удаления: ");
                    name = Console.ReadLine();
                    if (phone.remove(name))
                    {
                        Console.WriteLine("Контакт удален");
                    }
                    else
                    {
                        Console.WriteLine("Контакт {0} не найден", name);
                    }
                    break;
               
                case 4:
                    Console.WriteLine("Введите имя для поиска: ");
                    name = Console.ReadLine();
                    Contacts human;
                    human = phone.find(name);
                  
                    if (human == null)
                    {
                        Console.WriteLine("контакт {0} не найден", name);
                    }
                    else
                    {
                        Console.WriteLine("Контакт:");
                        Console.WriteLine(" Фамилия:{0}\n Имя:{1}\n Отчество:{2}\n Номер:{3}\n Страна:{4}\n Дата рождения:{5}\n Организация:{6}\n Должность:{7}\n Прочее:{8}"
                            , human.surname, human.name, human.patronymic, human.number, human.country, human.birthday, human.organization, human.post, human.other);
                    }
                    break;
                case 5:
                    Console.WriteLine("Список:");
                    phone.list(
                      delegate (Contacts p)
                      {
                          Console.WriteLine("{0} - {1} - {2}", p.surname, p.name, p.number);
                      }
                    );
                    break;
            }
        }
    }
}
