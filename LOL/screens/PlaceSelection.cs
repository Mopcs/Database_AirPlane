namespace LOL
{
    class PlaceSelection : Screen, IKeyController
    {
        public Element[] elements =
        {
            new AirplaneWiget()
        };
        
        private const int marginLeft = 20;
        private string date;

        public PlaceSelection(string date)
        {
            this.date = date;
        }

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
                    App.openDateSelectionScreen();
                    break;
                case ConsoleKey.Enter:
                    App.place = (elements[0] as AirplaneWiget).nameOfPlace;
                    App.date = date;
                    App.placeIdx = (elements[0] as AirplaneWiget).activeIndex;
                    App.openConfirmScreen();
                    break;
            }
        }
    }
}