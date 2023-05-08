using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BI_TTT_MK3
{
    internal class Program
    {




        public bool Win = false;
        public string[] spotsD = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static void Main(string[] args)
        {

            Program program = new Program();
            program.playingfield();

            do
            {
                program.placement("X");
                program.judge("X");
            } while (program.Win == false);


        }





        public void playingfield()
        {
            Console.WriteLine("Press ENTER :)");
            Console.WriteLine($"{spotsD[0]} | {spotsD[1]} | {spotsD[2]}\n---------\n{spotsD[3]} | {spotsD[4]} | {spotsD[5]}\n---------\n{spotsD[6]} | {spotsD[7]} | {spotsD[8]}");
            Console.ReadLine();
        }





        public void placement(string Y)
        {
            //playingfield();
            Console.WriteLine($"player {Y} Enter a spot");
            string Uinput = Console.ReadLine();

            if (Uinput == "1" || Uinput == "2" || Uinput == "3" || Uinput == "4" || Uinput == "5" || Uinput == "6" || Uinput == "7" || Uinput == "8" || Uinput == "9")
            {
                int iUinput = Int32.Parse(Uinput);

                placecheck(Y, iUinput);
                playingfield();



            }


        }

        public void judge(string Y)
        {
            if (spotsD[0] == Y && spotsD[1] == Y && spotsD[2] == Y ||
                spotsD[3] == Y && spotsD[4] == Y && spotsD[5] == Y ||
                spotsD[6] == Y && spotsD[7] == Y && spotsD[8] == Y ||

                spotsD[0] == Y && spotsD[3] == Y && spotsD[6] == Y ||
                spotsD[1] == Y && spotsD[4] == Y && spotsD[7] == Y ||
                spotsD[2] == Y && spotsD[5] == Y && spotsD[8] == Y ||

                spotsD[0] == Y && spotsD[4] == Y && spotsD[8] == Y ||
                spotsD[2] == Y && spotsD[4] == Y && spotsD[6] == Y)
            {
                Win = true;

                Console.Clear();
                Console.WriteLine("3 in rad, press any key to restart");
                Console.ReadLine();


            }

            else if (spotsD[0] != "1" && spotsD[1] != "2" && spotsD[2] != "3" &&
            spotsD[3] != "4" && spotsD[4] != "5" && spotsD[5] != "6" &&
            spotsD[6] != "7" && spotsD[7] != "8" && spotsD[8] != "9")
            {
                Console.Clear();
                Console.WriteLine("Tie!, press any key to restart");
                Console.ReadLine();
            }
        }






        public void placecheck(string Y, int iUinput)
        {
            if (spotsD[iUinput - 1] == "1" || spotsD[iUinput - 1] == "2" || spotsD[iUinput - 1] == "3" || spotsD[iUinput - 1] == "4" || spotsD[iUinput - 1] == "5" || spotsD[iUinput - 1] == "6" || spotsD[iUinput - 1] == "7" || spotsD[iUinput - 1] == "8" || spotsD[iUinput - 1] == "9")
            {
                spotsD[iUinput - 1] = Y;
            }
            else
            {
                Console.WriteLine("Invalid! Spot taken!");

            }
        }
        public int value(char[,] playingfield)
        {





            /*
            This function evaluates the current state of the board.
            It returns 1 if the computer has won, -1 if the player has won, and 0 if the game is a tie or still in progress.
            */
            // Check rows for a win

            for (int i = 0; i < 3; i++)
            {
                if (playingfield[i, 0] == playingfield[i, 1] && playingfield[i, 1] == playingfield[i, 2])
                {
                    if (playingfield[i, 0] == 'X')
                    {
                        return -1;
                    }
                    else if (playingfield[i, 0] == 'O')
                    {
                        return 1;
                    }
                }




                // Check columns for a win
                for (int i = 0; i < 3; i++)
                {
                    if (playingfield[0, i] == playingfield[1, i] && playingfield[1, i] == playingfield[2, i])
                    {
                        if (playingfield[0, i] == 'X')
                        {
                            return -1;
                        
                        else if (playingfield[0, i] == 'O')
                        {
                            return 1;
                        }
                    }
                }



            }
        }


    }
}






          
