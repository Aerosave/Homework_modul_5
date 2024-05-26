using System;

class MainClass
{   // Метод вызова методов?
    public static void Main(string[] args)
    {
        // Вызов метода для получения данных пользователя
        var userData = GetUserInput();
        // Вызов метода для отображения данных пользователя
        DisplayUserData(userData);
    }

    // Метод анкетирования
    public static (string Name, string Surname, int Age, string HasPet, string[] PetNames, string[] FavoriteColor) GetUserInput()
    {
        // Запрос имени пользователя
        string Name;
       // Можно было проверку в метод, но и так сойдет)
        do
        {
            Console.Write("Введите имя: ");
            Name = Console.ReadLine();

            // Проверка, что введены только буквы
            if (!Name.All(char.IsLetter))
            {
                Console.WriteLine("Имя должно содержать только буквы. Попробуйте снова.");
            }
        } while (!Name.All(char.IsLetter));

        // Запрос фамилии пользователя
        string Surname;
        do
        {
            Console.Write("Введите фамилию: ");
            Surname = Console.ReadLine();

            // Проверка, что введены только буквы
            if (!Surname.All(char.IsLetter))
            {
                Console.WriteLine("Фамилия должна содержать только буквы. Попробуйте снова.");
            }
        } while (!Surname.All(char.IsLetter));

        // Запрос и валидация возраста пользователя
        Console.Write("Введите Ваш возраст: ");
        int Age = ValidatedNumber();

        // Запрос наличия питомцев и их имен
        (string HasPet, string[] PetNames) = HasPetCheck();

        // Запрос любимого цвета
        Console.Write("Сколько у вас любимых цветов: ");
        int colorCount = ValidatedNumber();
        string[] favoriteColors = GetFavoriteColors(colorCount);

        return (Name, Surname, Age, HasPet, PetNames, favoriteColors);
    }

    // Метод отображения данных в консоли
    public static void DisplayUserData((string Name, string Surname, int Age, string HasPet, string[] PetNames, string[] FavoriteColor) userData)
    {



        Console.WriteLine("Итоговая анкета :");
        Console.WriteLine($"Ваше Имя: {userData.Name}");
        Console.WriteLine($"Ваша Фамилия: {userData.Surname}");
        Console.WriteLine($"Ваш возраст: {userData.Age}");
        Console.WriteLine(userData.HasPet);

        if (userData.PetNames.Length > 0)
        {
            Console.WriteLine("Имена ваших питомцев: " + string.Join(", ", userData.PetNames));
        }

        if (userData.FavoriteColor.Length > 1)
        {
            Console.WriteLine("Ваши любимые цвета: " + string.Join(", ", userData.FavoriteColor));
        }
        else 
        {
        Console.WriteLine("Ваш любимый цвет:" + string.Join(",", userData.FavoriteColor));
        }
        
       
        Console.ReadKey();
    }

    // Метод валидации числа
    public static int ValidatedNumber()
    {
        int number;
        while (true)
        {
            // Запрос ввода числа от пользователя
            string input = Console.ReadLine();

            // Проверка, является ли ввод числом и больше нуля
            if (int.TryParse(input, out number) & number > 0)
            {
                // Если ввод корректный, выход из цикла
                return number;
            }
            else
            {
                // Если ввод некорректный, вывод сообщения об ошибке
                Console.WriteLine("Пожалуйста, введите данные корректно.");
            }
        }
    }

    // Метод проверки питомца
    public static (string, string[]) HasPetCheck()
    {
        Console.Write("У вас есть питомец? Пожалуйста, ответьте только 'да' или 'нет': ");
        string answer = Console.ReadLine();

        switch (answer)
        {
            case "да":
                Console.Write("Круто! Сколько у Вас питомцев? ");
                int countPet = ValidatedNumber();
                string[] petNames = new string[0];
                if (countPet > 0)
                {
                    petNames = GetPetNames(countPet);
                }
                return ("У вас есть питомец", petNames);

            case "нет":
                return ("У вас нет питомцев", new string[0]);

            default:
                Console.WriteLine("Ответ не поддерживает формат программы! Попробуйте еще раз.");
                return HasPetCheck();
        }
    }

    // Метод для запроса имен питомцев
    public static string[] GetPetNames(int count)
    {
        string[] petNames = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите имя питомца {i + 1}: ");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    //Метод любимых цветов
    public static string[] GetFavoriteColors(int count)
    {
        string[] favoriteColors = new string[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введите любимый цвет {i + 1}: ");
            favoriteColors[i] = Console.ReadLine();
        }
        return favoriteColors;
    }

}



