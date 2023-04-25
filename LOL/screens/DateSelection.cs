namespace LOL
{
    class DateSelection : Screen, IKeyController
    {
        public Element[] elements =
        {
            new Button("Беги!")
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
                default:
                    var elem = elements[selectedElemIndex];
                    if (elem is IKeyController)
                        (elem as IKeyController).onKeyPressed(charKey);
                    break;
            }
        }
    }
}