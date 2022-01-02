using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGameProject.Class;

namespace GuessingGameProject
{
    internal class Game
    {
        private bool _game = true;
        private Random rdn = new Random();
        private Menu menu = new Menu();
        private readonly int[] _attempts = { 15, 10, 5 };
        private int _attempt;
        private int _userProp;

        public int Start()
        {
            do
            {
                //Iniciamo o menu;
                Console.WriteLine(menu.Close + menu.ScreenMenu);

                //Mostrando as opções na tela;
                foreach (string option in menu.Options)
                {
                    Console.WriteLine(option);
                }

                //Escolhendo a dificuldade;
                Console.Write("\n\tEscolha sua dificuldade [1, 2, 3]: ");

                try
                {
                    menu.Option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    this.OptionInvalid();
                    return 0;
                }
                //Verificando a opção dada pelo usuário;
                
                if(!menu.VerifyOption())    //Caso a opção não esteja listada, perguntar se o usuário quer sair do app;
                {
                    Console.WriteLine(menu.Close);
                    Console.Write("\tSair do jogo? [Y/N]");

                    string closeGame = Console.ReadLine();
                    string closeGameToUpper = closeGame.ToUpper();

                    if (
                        closeGameToUpper == "Y" ||
                        closeGameToUpper == "YES" ||
                        closeGameToUpper == "SIM" ||
                        closeGameToUpper == "S"
                    )
                    {
                        this.Set_Game(false);
                        return 1;
                    }

                    return 0;
                }
                //Exibe a opção escolhida;
                string[] stringSplit = menu.Options[menu.Option].Split(' ');
                this.ShowDificult(stringSplit);

                //Gera o número aleatório;
                this.Attempt = this.ReturnNumAttempt();

                //Começando o jogo;

                return 1;

            } while (this._game);
        }

        private void OptionInvalid()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\tOpção inválida!\n\n \tAperte enter para voltar");
            Console.ResetColor();
            Console.ReadLine();
        }

        private void ShowDificult(string[] dificuld)
        {
            Console.Clear();
            int len = dificuld.Length;
            Console.Write("\tDificuldade escolhida: ");
            Console.WriteLine(dificuld[1]);
            Console.WriteLine("\n\n\t" + dificuld[len - 2] + " " + dificuld[len - 1]);
            Console.WriteLine("\tTemos um número desconhecido entre 0 e 100.");
            Console.WriteLine("\tVocê tem " + this._attempts[menu.Option] + " chances! Boa sorte!");
        }

        private int ReturnNumAttempt()
        {
            int i = this.rdn.Next(101);
            return i;
        }

        public void Set_Game(bool value)
        {
            _game = value;
        }

        public int Attempt
        {
            get => this._attempt;
            set
            {
                if (value < 0 || value > 100) this._attempt = this.rdn.Next(50);
                else this._attempt = value;
            }
        }

        public int UserProp
        {
            get => this._userProp;
            set => this._userProp = value;
        }
    }
}
