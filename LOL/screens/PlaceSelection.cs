namespace LOL
{
    class PlaceSelection : Screen, IKeyController
    {
        public Element[] elements =
        {
            new AirplaneWiget()
        };

        private int selectedElemIndex = 0;
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
        }
    }
}