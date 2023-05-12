namespace LOL
{
    internal class Text : Element
    {
        string text;

        public Text(string text)
        {
            this.text = text;
        }

        override public void draw(int fromX = 0)
        {
            drawMargin(fromX);

            Console.WriteLine(text);
        }

        private void drawMargin(int until = 0)
        {
            for (int j = 0; j < until; j++) { Console.Write(' '); }
        }
    }
}