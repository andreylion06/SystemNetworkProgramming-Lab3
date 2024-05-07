
// Ім'я файлу: Menu.cs
// Ремарка: Menu відображає консольне меню опцій, обробляє вибір користувача та виконує відповідні дії.
// Автор: Андрій Сахно

namespace ConsoleAppLab3.Logic
{
    class Menu
    {
        private Dictionary<string, Action> menuItems;

        public Menu(Dictionary<string, Action> items)
        {
            menuItems = items;
        }

        public void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("\n\n================ Menu ================\n");
            int i = 1;
            foreach (var item in menuItems)
            {
                Console.WriteLine($"    Option {i}: {item.Key}");
                i++;
            }
            Console.WriteLine("\n=======================================");
        }

        public string? ChooseOption()
        {
            Console.Write("\nYour choice ==> ");
            string? userInput = Console.ReadLine();
            Console.WriteLine();
            return userInput;
        }

        public void HandleInput(string? userInput)
        {
            try
            {
                int operationNumber = int.Parse(userInput!);
                menuItems.ElementAt(operationNumber - 1).Value.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown operation. Please, try again.");
            }
        }

        public void WaitNextIteration()
        {
            Console.Write("\nPress any key to continue.");
            Console.ReadLine();
        }
    }
}

// Кінець файлу