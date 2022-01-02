namespace GuessingGameProject.Class
{
    internal class Menu
    {
        private int _option;
        private readonly string _close = "\t- crtl + c para sair\n\n";
        private readonly string[] _options = { 
            "\t1- Fácil (15 tentativas)",
            "\t2- Normal (10 tentativas)",
            "\t3- Difícil (5 tentativas)"
        };

        private readonly string _screenMenu = "\t*****************************\n\t*" +
            "    JOGO DA ADIVINHAÇÃO    *\n\t****" +
            "*************************\n";

        public bool VerifyOption()
        {
            return this.Option >= 0 && this.Option < 3;
        }

        public int Option
        {
            get => _option;
            set => _option = value - 1;
        }

        public string[] Options 
        {
            get => _options;
        }

        public string ScreenMenu
        {
            get => _screenMenu;
        }

        public string Close
        {
            get => _close;
        }
    }
}
