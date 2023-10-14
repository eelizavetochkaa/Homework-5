using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5
{
    internal class Program
    {
        static void AddNewStudent(List<Student> students)
        {
            Console.WriteLine("Введите фамилию:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите имя:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите год рождения:");
            int birthYear;
            while (!int.TryParse(Console.ReadLine(), out birthYear))
            {
                Console.WriteLine("Неверный формат. Введите год рождения еще раз:");
            }

            Console.WriteLine("Введите экзамен, по которому поступил:");
            string examName = Console.ReadLine();

            Console.WriteLine("Введите баллы:");
            int score;
            while (!int.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("Неверный формат. Введите баллы еще раз:");
            }

            Student newStudent = new Student(lastName, firstName, birthYear, examName, score);
            students.Add(newStudent);
            Console.WriteLine("Новый студент добавлен.");
        }
        static void DeleteStudent(List<Student> students)
        {
            Console.WriteLine("Введите фамилию студента, которого хотите удалить:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите имя студента:");
            string firstName = Console.ReadLine();

            Student studentToDelete = students.FirstOrDefault(s => s.LastName == lastName && s.FirstName == firstName);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
                Console.WriteLine("Студент удален.");
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }
        static void SortStudentsByScore(List<Student> students)
        {
            students = students.OrderBy(s => s.Score).ToList();
            Console.WriteLine("Студенты отсортированы по баллам (по возрастанию).");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.LastName} {student.FirstName} - Баллы: {student.Score}");
            }
        }
        static List<Student> LoadStudentsFromFile(string filename)
        {
            List<Student> students = new List<Student>();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        string lastName = parts[0].Trim();
                        string firstName = parts[1].Trim();
                        int birthYear = int.Parse(parts[2].Trim());
                        string examName = parts[3].Trim();
                        int score = int.Parse(parts[4].Trim());
                        students.Add(new Student(lastName, firstName, birthYear, examName, score));
                    }
                }
                return students;
            }
        }
        static void SaveStudentsToFile(List<Student> students, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.LastName}, {student.FirstName}, {student.BirthYear}, {student.ExamName}, {student.Score}");
                }
            }
        }
        static void DistributePatientsToHospitals(List<Babushka> patients, Stack<Hospital> hospitals)
        {
            foreach (var patient in patients)
            {
                bool placed = false;
                foreach (var hospital in hospitals)
                {
                    if (hospital.CanTreat(patient) && hospital.HasCapacity())
                    {
                        hospital.AddPatient(patient);
                        placed = true;
                        break;
                    }
                }
                if (!placed)
                {
                    Console.WriteLine($"{patient.Name} остается на улице и плачет.");
                }
            }
        }


        /*
        static void ShuffleList<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        */
        static void Main(string[] args)
        {
            /*Console.WriteLine("Номер 1. Изображения");
            // Создаем список URL-адресов изображений. 
             List<string> imageUrls = new List<string>
             {
                 '''1.jpg
                '''2.jpg
                '''3.jpg
                '''4.jpg
                '''5.jpg
                '''6.jpg
                '''7.jpg
                '''8.jpg
                '''9.jpg
                '''10.jpg
                '''11.jpg
                '''12.jpg
                '''13.jpg
                '''14.jpg
                '''15.jpg
                '''16.jpg
                '''17.jpg
                '''18.jpg
                '''19.jpg
                '''20.jpg
                '''21.jpg
                '''22.jpg
                '''23.jpg
                '''24.jpg
                '''25.jpg
                '''26.jpg
                '''27.jpg
                '''28.jpg
                '''299.jpg
                '''30.jpg
                '''31.jpg
                '''32.jpg
             }
             List<byte[]> images = new List<byte[]>();
             using (WebClient webClient = new WebClient())
             {
                 foreach (string imageUrl in imageUrls)
                 {
                     byte[] imageBytes = webClient.DownloadData(imageUrl);
                     images.Add(imageBytes);
                 }
             }


            
            // Дублируем элементы (по 2 одинаковых картинки). 
            List<byte[]> duplicatedList = images.Concat(images).ToList();

            // Перемешиваем List. 
            ShuffleList(duplicatedList);

            // Выводим изначальный и перемешанный List в консоль. 
            Console.WriteLine("Изначальный List:");
            PrintList(images);

            Console.WriteLine("\nПеремешанный List:");
            PrintList(duplicatedList);*/

            Console.WriteLine("Номер 2. Программа создаёт бабулю");
            List<Babushka> babushkas = new List<Babushka>();
            Stack<Hospital> hospitals = new Stack<Hospital>();

            // Create hospitals
            Hospital hospital1 = new Hospital("Hospital 1", new List<string> { "Грипп", "Простуда" }, 100);
            Hospital hospital2 = new Hospital("Hospital 2", new List<string> { "Разрыв сердца", "Артрит" }, 80);
            hospitals.Push(hospital1);
            hospitals.Push(hospital2);

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить бабулю");
                Console.WriteLine("2. Распределить бабуль по больницам");
                Console.WriteLine("3. Вывести информацию");
                Console.WriteLine("4. Выйти");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите имя бабули: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите возраст бабули: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Сколько болезней у бабули: ");
                        int numDiseases = int.Parse(Console.ReadLine());

                        List<string> diseases = new List<string>();
                        for (int i = 0; i < numDiseases; i++)
                        {
                            Console.Write($"Введите болезнь {i + 1}: ");
                            diseases.Add(Console.ReadLine());
                        }

                        Babushka babushka = new Babushka(name, age, diseases);
                        babushkas.Add(babushka);
                        break;
                    case 2:
                        DistributePatientsToHospitals(babushkas, hospitals);
                        break;
                    case 3:
                        Console.WriteLine("Список бабуль:");
                        foreach (var babushka1 in babushkas)
                        {
                            Console.WriteLine(babushka1);
                        }

                        Console.WriteLine("Список больниц:");
                        foreach (var hospital in hospitals)
                        {
                            Console.WriteLine(hospital);
                        }
                        break;
                    case 4:
                        return;
                }

            }
            Console.WriteLine("Номер 3. Программа создаёт студента");
            // Создание списка студентов из вашей группы (предварительно загруженных из файла). 
            List<Student> students = LoadStudentsFromFile("students.txt");

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("a. Новый студент");
                Console.WriteLine("b. Удалить студента");
                Console.WriteLine("c. Сортировать по баллам");
                Console.WriteLine("q. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":
                        AddNewStudent(students);
                        break;
                    case "b":
                        DeleteStudent(students);
                        break;
                    case "c":
                        SortStudentsByScore(students);
                        break;
                    case "q":
                        SaveStudentsToFile(students, "students.txt");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("Номер 4. Программа находит кратчайший путь графа");
            Graph graph = new Graph(7);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);

            Console.WriteLine("Обход графа в ширину и кратчайший путь:");
            graph.BFS(0, 6);
            Console.ReadKey();
        }

    }
}
