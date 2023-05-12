namespace LOL
{
    class AirplaneWiget : Element, IKeyController
    {
        public int activeIndex = 0;

        private bool enableControls = true;

        public string nameOfPlace { 
            get
            {
                string toReturn = "";
                int height = activeIndex / width;
                int number = activeIndex % width + 1;
                if (height == 0) toReturn = "F";
                else if (height == 1) toReturn = "D";
                else if (height == 2) toReturn = "C";
                else if (height == 3) toReturn = "A";
                return toReturn + number.ToString();
            }
        }

        private const int width = 20;
        private const int height = 9;

        private const ConsoleColor businessPlaceColor = ConsoleColor.Cyan;
        private const ConsoleColor extendedPlaceColor = ConsoleColor.Green;
        private const ConsoleColor commonPlaceColor = ConsoleColor.Magenta;

        public AirplaneWiget(bool enableControls = true) { 
            this.enableControls = enableControls;
            activeIndex = App.placeIdx;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey)
        {
            
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        activeIndex = (activeIndex + width * 3) % 80;
                        break;
                    case ConsoleKey.DownArrow:
                        activeIndex = (activeIndex + width) % 80;
                        break;
                    case ConsoleKey.LeftArrow:
                        activeIndex = (activeIndex / width) * width + (activeIndex + width - 1) % width;
                        break;
                    case ConsoleKey.RightArrow:
                        activeIndex = (activeIndex / width) * width + (activeIndex + 1) % (width);
                        break;
                }
            
        }

        override public void draw(int fromX = 0)
        {
            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                drawMargin(fromX);
                drawPlane(currentHeight);
                Console.WriteLine();
            }
        }

        private void drawMargin(int until = 0)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;
            for (int j = 0; j < until; j++) { Console.Write(' '); }
        }

        private void drawPlane(int currentHeight)
        {
            if (currentHeight == 0)
                Console.Write("                             /             |");
            else if (currentHeight == 8)
                Console.Write("                             \\             |");
            else if (currentHeight == 1 || currentHeight == 7) 
                Console.Write("      ────────────────────────────────────────────────────────────");
            else if (currentHeight == 4)
                Console.Write("  (     01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20");
            else
            {
                if (currentHeight == 2)
                    Console.Write("    / F ");
                else if (currentHeight == 3)
                    Console.Write("   /  D ");
                else if (currentHeight == 5)
                    Console.Write("   \\  C ");
                else if (currentHeight == 6)
                    Console.Write("    \\ A ");
                for (int i = 0; i < width; ++i)
                {
                    ConsoleColor placeColor;
                    if (i < 2)
                        placeColor = businessPlaceColor;
                    else if (i == 2)
                        placeColor = extendedPlaceColor;
                    else
                        placeColor = commonPlaceColor;

                    int currentIndex;
                    if (currentHeight <= 3)
                        currentIndex = (currentHeight - 2) * width + i;
                    else
                        currentIndex = (currentHeight - 3) * width + i;


                    if (currentIndex == activeIndex)
                    {
                        System.Console.ForegroundColor = placeColor;
                        System.Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        System.Console.ForegroundColor = placeColor;
                        System.Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.Write("■");

                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                }
            }
        }
    }
}