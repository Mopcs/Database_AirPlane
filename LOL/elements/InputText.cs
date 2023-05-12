namespace LOL
{
    internal class InputText : Element, IKeyController
    {
        string hint;

        public string value = "";

        public InputText(string hint, bool isActive = false) {
            this.hint = hint;
            this.isActive = isActive;
        }

        public void onKeyPressed(ConsoleKeyInfo charKey) {
            if (charKey.Key == ConsoleKey.Backspace && value.Length > 0) {
                value = value.Remove(value.Length - 1);
            }
            // else if (Char.IsLetter(charKey.KeyChar)) {
            //     value += charKey.KeyChar;
            // }
            else {
                value += charKey.KeyChar;
            }
        }

        override public void draw(int fromX = 0) {
            drawMargin(fromX);

            if (isActive) {
                Console.Write("> ");
            }

            Console.Write(string.Format("{0}: {1}", hint, value));
            
            Console.WriteLine();
        }

        private void drawMargin(int until = 0)
        {
            for (int j = 0; j < until; j++) { Console.Write(' '); }
        }
    }
}