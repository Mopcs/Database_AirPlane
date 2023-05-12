namespace LOL
{
    class ConfirmScreen : Screen, IKeyController
    {
        public Element[] elements =
        {
            new Button("Забронировать", true),
            new Button("Меню")
        };

        private int selectedElemIndex = 0;
        private const int marginLeft = 50;

        override public void draw()
        {
            for (int j = 0; j < marginLeft; j++) { Console.Write(' '); }
            Console.WriteLine("Владивосток-Москва");
            for (int j = 0; j < marginLeft; j++) { Console.Write(' '); }
            Console.WriteLine("Дата: " + App.date);
            for (int j = 0; j < marginLeft; j++) { Console.Write(' '); }
            Console.WriteLine("Место: " + App.place);

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
                    if ((elements[selectedElemIndex] as Button).title == "Забронировать")
                        App.openEndScreen();
                    else if ((elements[selectedElemIndex] as Button).title == "Меню")
                        App.openFoodScreen();
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