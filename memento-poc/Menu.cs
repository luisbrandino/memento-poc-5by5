namespace memento_poc
{
    public class Menu
    {
        private string? _title;
        private List<string> _options;
        private bool _clear = false;

        public Menu(params string[] options)
        {
            _options = new List<string>(options);
        }

        public void ClearConsoleBeforeDisplaying(bool clear)
        {
            _clear = clear;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        public void AddOption(string description)
        {
            _options.Add(description);
        }

        private void Display()
        {
            if (_clear)
                Console.Clear();

            if (_title != null)
                Console.WriteLine(_title);

            for (int i = 0; i < _options.Count; i++)
                Console.WriteLine($"{i + 1} - {_options[i]}");
        }

        public int Ask()
        {
            Display();
            Console.Write("Sua opção: ");

            int option;

            while (true)
            {
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Valor inválido, digite apenas números. Tente novamente: ");
                    continue;
                }

                bool correctOption = option >= 1 && option <= _options.Count;

                if (correctOption)
                    break;

                Console.Write($"Valor inválido, digite apenas valores entre {1} e {_options.Count}. Tente novamente: ");
            }

            return option;
        }
    }
}
