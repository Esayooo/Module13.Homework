using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.Homework
{
    // Класс для представления клиента
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; }

        public Client(int id, string name, string serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
        }
    }

    class BankQueue
    {
        private Queue<Client> clientQueue = new Queue<Client>();

        // Функция добавления клиента в очередь
        public void EnqueueClient(Client client)
        {
            clientQueue.Enqueue(client);
            Console.WriteLine($"Клиент {client.Name} добавлен в очередь на обслуживание по услуге {client.ServiceType}.");
            DisplayQueue();
        }

        // Функция обслуживания клиентов
        public void ServeNextClient()
        {
            if (clientQueue.Count > 0)
            {
                Client servedClient = clientQueue.Dequeue();
                Console.WriteLine($"Клиент {servedClient.Name} обслужен. Ушел по услуге {servedClient.ServiceType}.");
                DisplayQueue();
            }
            else
            {
                Console.WriteLine("Очередь пуста. Нет клиентов для обслуживания.");
            }
        }

        // Функция отображения текущего состояния очереди
        private void DisplayQueue()
        {
            Console.WriteLine("Текущее состояние очереди:");
            foreach (var client in clientQueue)
            {
                Console.WriteLine($"Клиент {client.Name} - {client.ServiceType}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            BankQueue bankQueue = new BankQueue();

            // Простой интерфейс для взаимодействия с пользователем
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Встать в очередь");
                Console.WriteLine("2. Обслужить следующего клиента");
                Console.WriteLine("3. Выйти из программы");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите ваше имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите ваш ИИН: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Выберите тип обслуживания (кредитование, открытие вклада, консультация): ");
                        string serviceType = Console.ReadLine();

                        Client newClient = new Client(id, name, serviceType);
                        bankQueue.EnqueueClient(newClient);
                        break;

                    case "2":
                        bankQueue.ServeNextClient();
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите действие из списка.");
                        break;
                }
            }
        }
    }

}
