using System;
using System.Text;
using GuessingGameProject.Class;

namespace GuessingGameProject
{
    internal class Game
    {
        private bool _game = true;                          //Controlador do game global;
        private Random rdn = new Random();                  //Atributo de aleatoriedade;
        private Menu menu = new Menu();                     //Atribuição do Menu;
        private readonly int[] _attempts = { 15, 10, 5 };   //Possíveis chaces que o usuário pode ter;
        private int _attempt;                               //Número que deve ser adivinhado estará aqui;
        private int _userAttempt;                           //As chances do usuário estarão aqui;
        private int _userProp;                              //Proposta de resposta do usuário;
        private int _score = 3000;                           //Pontuação que vai diminuindo;

        public int Start()
        {
            Console.OutputEncoding = Encoding.UTF8;

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
                        this.Set_Game = false;
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
                Console.WriteLine("\n\tADIVINHE O NÚMERO!!");
                Console.WriteLine("\n\n\t___________________\n\n");

                do
                {
                    Console.Write("\tEscolha um número: ");

                    try
                    {
                        this.UserProp = Convert.ToInt32(Console.ReadLine());

                        if (this.UserProp == this.Attempt)
                        {
                            Console.Clear();
                            Console.WriteLine($"\n\n\tPERFEITO!! O número era {this.Attempt}, você acertou. Parábens!!\n");

                            if(this.Score == 3000)
                            {
                                Console.Write("\t===================\n");
                                Console.Write("\t  DE PRIMEIRA!!!!\n");
                                Console.Write("\t===================\n");
                                Console.Write("\t_/﹋\\_\n");
                                Console.Write("\t(҂`_´) 3000 PONTOS!\n");
                                Console.Write("\t<;︻╦╤─ ҉   -- \n");
                                Console.WriteLine("\t===================\n");
                            }

                            if (this.Score < 10) this.Score = 10;
                            Console.WriteLine($"\t{this.Score} Pontos! Parabéns.");
                            bool aux = true;
                            while (aux)
                            {
                                Console.Write("\n\n\tE agora?\n\n\t[1] - Novo jogo [2] - Sair");
                                try
                                {
                                    int op = Convert.ToInt32(Console.ReadLine());
                                    if (op == 1)
                                    {
                                        Console.Clear();
                                        Console.ResetColor();
                                        aux = false;
                                        this.Set_Game = true;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        aux = false;
                                        this.Set_Game = false;
                                    }
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\tOpção inválida");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                            }
                        }
                        else
                        {
                            string mOrM = this.UserProp > this.Attempt ? "maior" : "menor";
                            this.Score -= 200;
                            this.UserAttempt -= 1;
                            Console.WriteLine($"\tO número {this.UserProp} é {mOrM}.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\tOpção inválida!");
                    }
                } while (this.UserProp != this.Attempt && this.UserAttempt > 0);

                if(this.UserAttempt <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"\tAcabaram suas chances! o número era: {this.Attempt}\n");
                    Console.ResetColor();
                }

            } while (this._game);
            return 1;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            int len = dificuld.Length;
            Console.Write("\tDificuldade escolhida: ");
            Console.WriteLine(dificuld[1]);
            Console.WriteLine("\n\n\t" + dificuld[len - 2] + " " + dificuld[len - 1]);
            Console.WriteLine("\tTemos um número desconhecido entre 0 e 100.");
            Console.WriteLine("\tVocê tem " + this._attempts[menu.Option] + " chances! Boa sorte!");
            this.UserAttempt = this._attempts[menu.Option];
        }

        private int ReturnNumAttempt()
        {
            int i = this.rdn.Next(101);
            return i;
        }

        public bool Set_Game
        {
            set => this._game = value;
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

        public int UserAttempt
        {
            get => this._userAttempt;
            set => this._userAttempt = value;
        }

        public int Score
        {
            get => this._score;
            set => this._score = value;
        }

        public int UserProp
        {
            get => this._userProp;
            set => this._userProp = value;
        }
    }
}
