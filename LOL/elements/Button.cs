namespace LOL
{
    class Button : Element
    {
        public string title;

        public const int width = 20;
        public const int height = 5;

        private int maxTitleLength {
            get { return width - 5; }
        }

        public Button(string title, bool isActive = false)
        {
            if (title.Length > maxTitleLength)
                throw new ArgumentException("Длинна текста в кнопке больше разрешенной");
            this.title = title;
            this.isActive = isActive;
        }

        override public void draw(int fromX = 0)
        {
            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                drawMargin(fromX);
                drawButton(currentHeight);
                Console.WriteLine();
            }
        }

        private void drawMargin(int until = 0)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;
            for (int j = 0; j < until; j++) { Console.Write(' '); }
        }

        private void drawButton(int currentHeight)
        {
            if (isActive)
            {
                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.White;
                System.Console.BackgroundColor = ConsoleColor.Black;
            }


            if (currentHeight == 0)
            {
                Console.Write("┌");
                for (int j = 0; j < width - 2; j++) { Console.Write("─"); }
                Console.Write("┐");
            }
            else if (currentHeight == height - 1)
            {
                Console.Write("└");
                for (int j = 0; j < width - 2; j++) { Console.Write("─"); }
                Console.Write("┘");
            }
            else if (currentHeight == height / 2)
            {
                int textStartIndex = (width - 2 - title.Length) / 2;
                Console.Write("│");
                for (int j = 0; j < width - 1 - title.Length; j++)
                {
                    if (j != textStartIndex)
                        Console.Write(" ");
                    else
                        Console.Write(title);

                }
                Console.Write("│");
            }
            else
            {
                Console.Write("│");
                for (int j = 0; j < width - 2; j++) { Console.Write(" "); }
                Console.Write("│");
            }

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}