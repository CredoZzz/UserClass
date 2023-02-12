using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UserRepository
{
    class User
    {

        public User() { }
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class UserRepository
    {
        private List<User> _users = new List<User>();
        private int clickCounter = 0;

        public void AddUser(User user)
        {
            _users.Add(user);
            clickCounter++;
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
            clickCounter++;
        }

        public void UpdateUser(User oldUser, User newUser)
        {
            int index = _users.IndexOf(oldUser);
            _users[index] = newUser;
            clickCounter++;
        }

        public void ShowUsers()
        {
            Console.WriteLine("Список пользователей: ");
            foreach (var user in _users)
            {
                Console.WriteLine($"Имя: " + user.Name + ", Возраст: " + user.Age);
            }
            clickCounter++;
        }

        public void ShowClickCounter()
        {
            Console.WriteLine("Количество кликов: " + clickCounter);
        }

        public void IncrementClickCounter()
        {
            clickCounter++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            UserRepository repository = new UserRepository();
            int choice;
            User user = new User();

            Console.WriteLine("Программа репозиторий пользователя");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Удалить пользователя");
            Console.WriteLine("3. Обновить пользователя");
            Console.WriteLine("4. Показать список пользователей");
            Console.WriteLine("5. Показать список кликов");
            Console.WriteLine("6. Добавить клик");
            Console.WriteLine("7. Выход");

            while (true)
            {

                Console.Write("Выберите действие: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        user.Name = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        user.Age = int.Parse(Console.ReadLine());
                        repository.AddUser(user);
                        break;

                    case 2:
                        Console.Write("Введите имя: ");
                        user.Name = Console.ReadLine();
                        Console.Write("Введите возраст: ");
                        user.Age = int.Parse(Console.ReadLine());
                        repository.DeleteUser(user);
                        break;

                    case 3:
                        Console.Write("Введите предыдущее имя пользователя: ");
                        User oldUser = new User();
                        oldUser.Name = Console.ReadLine();
                        Console.Write("Введите предыдущий возраст пользователя: ");
                        oldUser.Age = int.Parse(Console.ReadLine());
                        Console.Write("Введите новое имя пользователя: ");
                        User newUser = new User();
                        newUser.Name = Console.ReadLine();
                        Console.Write("Введите новый возраст пользователя: ");
                        newUser.Age = int.Parse(Console.ReadLine());
                        repository.UpdateUser(oldUser, newUser);
                        break;

                    case 4:
                        repository.ShowUsers();
                        break;

                    case 5:
                        repository.ShowClickCounter();
                        break;
                    case 6:
                        repository.IncrementClickCounter();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Неправильный выбор.");
                        break;

                }
            }
        }
    }
}

