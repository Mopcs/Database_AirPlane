using System.Globalization;

namespace LOL
{
    class FoodScreen : Screen, IKeyController
    {
        public Element[] buttonsList =
        {
            new Button("Суп", true),
            new Button("Банан"),
            new Button("Энергетик"),
            new Button("Собака в тз"),
        };

        private int selectedButtonIndex = 0;
        private const int marginLeft = 50;

        override public void draw()
        {
            foreach (var button in buttonsList)
            {
                button.draw(marginLeft);
            }
        }

        public void onKeyPressed(ConsoleKeyInfo charKey)
        {
            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    buttonsList[selectedButtonIndex].isActive = false;
                    selectedButtonIndex = (selectedButtonIndex + buttonsList.Length - 1) % buttonsList.Length;
                    buttonsList[selectedButtonIndex].isActive = true;
                    break;
                case ConsoleKey.DownArrow:
                    buttonsList[selectedButtonIndex].isActive = false;
                    selectedButtonIndex = (selectedButtonIndex + 1) % buttonsList.Length;
                    buttonsList[selectedButtonIndex].isActive = true;
                    break;
                case ConsoleKey.Enter:
                    App.openConfirmScreen();
                    break;
            }
        }
    }
}