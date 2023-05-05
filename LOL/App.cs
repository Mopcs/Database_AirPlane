namespace LOL
{
    internal class App
    {
        private static Screen activeScreen = new MainMenu();

        static void Main()
        {
            Console.CursorVisible = false;

            while (true)
            {
                activeScreen.draw();

                if (activeScreen is IKeyController)
                    (activeScreen as IKeyController).onKeyPressed(Console.ReadKey());
                    
                Console.Clear();
            }

        }

        public static void openMainMenu() {
            activeScreen = new MainMenu();
        }

        public static void openRegisterScreen() {
            activeScreen = new Registration();
        }

        public static void openLoginScreen() {
            activeScreen = new Login();
        }
        public static void openDateSelectionScreen() {
            activeScreen = new DateSelection();
        }
        public static void openPlaceSelectionScreen()
        {
            activeScreen = new PlaceSelection();
        }
    }
}