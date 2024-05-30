using memento_poc;

List<History> histories = new();

Menu menu = new Menu(
    "Criar novo editor",
    "Ver editores",
    "Sair"
);

menu.SetTitle("EDITOR");
menu.ClearConsoleBeforeDisplaying(true);

void createEditor()
{
    Console.Write("Informe o nome do editor: ");
    histories.Add(new History(new Editor(Console.ReadLine())));
}

void displayEditorOptions(int selectedEditorIndex)
{
    Editor selectedEditor = histories[selectedEditorIndex].CurrentEditor();

    Menu menu = new("Ver conteúdo", "Alterar conteúdo", "Desfazer última alteração", "Voltar");
    menu.SetTitle(selectedEditor.Name());
    menu.ClearConsoleBeforeDisplaying(true);

    while (true)
    {
        switch (menu.Ask())
        {
            case 1:
                Console.Clear();
                selectedEditor.Display();
                Console.ReadKey();
                break;
            case 2:
                histories[selectedEditorIndex].Save();

                Console.Write("Informe o conteúdo para alterar: ");
                selectedEditor.SetText(Console.ReadLine());
                break;
            case 3:
                histories[selectedEditorIndex].Restore();
                break;
            default:
                return;
        }
    }
}

void displayEditors()
{
    if (histories.Count <= 0)
        return;

    Menu menu = new();
    menu.SetTitle("EDITORES");
    menu.ClearConsoleBeforeDisplaying(true);

    histories.ForEach(history => menu.AddOption(history.CurrentEditor().Name()));

    menu.AddOption("Voltar");

    while (true)
    {
        int option = menu.Ask();

        if (option - 1 == histories.Count)
            return;

        displayEditorOptions(option - 1);
    }
}

while (true)
{
    switch (menu.Ask())
    {
        case 1:
            createEditor();
            break;
        case 2:
            displayEditors();
            break;
        default:
            Environment.Exit(0);
            break;
    }
}