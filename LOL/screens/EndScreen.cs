namespace LOL
{
    class EndScreen : Screen, IKeyController
    {
        public Element[] elements =
        {
            new AirplaneWiget()
        };


        private const int marginLeft = 20;

        override public void draw()
        {

            foreach (var elem in elements)
            {
                elem.draw(marginLeft);
            }
        }

        public void onKeyPressed(ConsoleKeyInfo charKey)
        {
            (elements[0] as IKeyController).onKeyPressed(charKey);
            switch (charKey.Key)
            {
                case ConsoleKey.Escape:
                    App.openMainMenu();
                    break;
            }
        }
    }
}