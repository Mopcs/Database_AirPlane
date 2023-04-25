namespace LOL
{
    class Registration : Screen, IKeyController
    {
        public Element[] elements =
        {
            new InputText("Имя", true),
            new InputText("Фамилия"),
            new InputText("Отчество"),
            new InputText("Дата рождения"),
            new InputText("Логин"),
            new InputText("Пароль"),
            new Button("Регистрация")
        };
        
        private int selectedElemIndex = 0;
        private const int marginLeft = 50;

        override public void draw()
        {
            foreach (var elem in elements)
            {
                elem.draw(marginLeft);
            }
        }

        public void onKeyPressed(ConsoleKeyInfo charKey)
        {
            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    elements[selectedElemIndex].isActive = false;
                        selectedElemIndex = (selectedElemIndex + elements.Length - 1) % elements.Length;
                    elements[selectedElemIndex].isActive = true;
                        break;
                case ConsoleKey.DownArrow:
                    elements[selectedElemIndex].isActive = false;
                        selectedElemIndex = (selectedElemIndex + 1) % elements.Length;
                    elements[selectedElemIndex].isActive = true;
                        break;
                case ConsoleKey.Escape:
                    App.openMainMenu();
                    break;
                case ConsoleKey.Enter:
                    if (elements[selectedElemIndex] is Button) {
                        App.openDateSelectionScreen();
                    }
                    break;
                default:
                    var elem = elements[selectedElemIndex];
                    if (elem is IKeyController)
                        (elem as IKeyController).onKeyPressed(charKey);
                    break;
            }
        }
    }
}