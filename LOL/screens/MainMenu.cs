namespace LOL
{
    class MainMenu : Screen, IKeyController
    {
        public Element[] buttonsList =
        {
            new Button("Регистрация", true),
            new Button("Вход")
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
                    if ((buttonsList[selectedButtonIndex] as Button).title == "Регистрация") {
                        App.openRegisterScreen();
                    }
                    else if((buttonsList[selectedButtonIndex] as Button).title == "Вход") {
                        App.openLoginScreen();
                    }
                    break;
            }
        }
    }
}