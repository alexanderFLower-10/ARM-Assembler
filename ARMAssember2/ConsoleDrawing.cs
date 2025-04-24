using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMAssember2
{
    internal class ConsoleDrawing
    {
        private int length;
        private int height;
        private int xstart;
        private int ystart;
        private string[] text;
        private string title;
        ConsoleColor titleColor;

        public ConsoleDrawing(string[] text, int cursorx, int cursory, string title = null, ConsoleColor titleColour = ConsoleColor.Gray)
        {

            if(title != null)
            {
                string[] temp = new string[text.Length + 1];
                temp[0] = title;
                for (int i = 1; i < text.Length + 1; i++)
                {
                    temp[i] = text[i-1];
                }
                this.text = temp;
            }
            else
            {
                this.text= text;
            }
            this.height = this.text.Length;
            int max = 0;
            foreach(string s in this.text)
            {
                if(s.Length > max) max = s.Length;
            }
            length = max + 2;
            xstart = cursorx;
            ystart = cursory;   
            this.titleColor = titleColour;
        }
        public void DrawAndHighlightLineNumber(int PC)
        {
            string[] result = new string[height + 2];
            result[0] = "╔";
            string temp = "";
            for (int i = 0; i < length; i++)
            {
                result[0] += "═";
            }
            result[0] += "╗";
            for (int i = 1; i < height + 1; i++)
            {
                temp = " ";
                result[i] += "║";
                temp += text[i - 1];
                for (int j = temp.Length; j < length; j++)
                {
                    temp += " ";
                }
                result[i] += temp;
                result[i] += "║";
            }
            result[result.Length - 1] += "╚";
            for (int i = 0; i < length; i++)
            {
                result[result.Length - 1] += "═";
            }
            result[result.Length - 1] += "╝";
            Console.SetCursorPosition(xstart, ystart);
            Console.Write(result[0]);

            Console.SetCursorPosition(xstart, ystart + 1);
            Console.Write(result[1][0]);
            Console.ForegroundColor = titleColor;
            for (int j = 1; j < result[1].Length - 1; j++)
            {
                Console.Write(result[1][j]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(result[1][result[1].Length - 1]);
            for (int i = 2; i < result.Length; i++)
            {
                Console.SetCursorPosition(xstart, ystart + i);
                if (i-2 == PC)
                {

                    Console.Write(result[i][0]);
                    Console.ForegroundColor = titleColor;
                    for (int j = 1; j < result[i].Length - 1; j++)
                    {
                        Console.Write(result[i][j]);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(result[i][result[i].Length - 1]);
                }
                else
                {
                    Console.Write(result[i]);
                }
            }



        }

        public void Draw()
        {
            string[] result = new string[height + 2];
            result[0] = "╔";
            string temp = "";
            for(int i = 0; i < length; i++)
            {
                result[0] += "═";
            }
            result[0] += "╗";
            for(int i = 1; i < height + 1; i++)
            {
                temp = " ";
                result[i] += "║";
                temp += text[i-1];
                for(int j = temp.Length; j <  length ; j++)
                {
                    temp += " ";
                }
                result[i] += temp;
                result[i] += "║";
            }
            result[result.Length-1] += "╚";
            for (int i = 0; i < length; i++)
            {
                result[result.Length-1] += "═";
            }
            result[result.Length-1] += "╝";
            Console.SetCursorPosition(xstart, ystart);
            Console.Write(result[0]);

            Console.SetCursorPosition(xstart, ystart + 1);
            Console.Write(result[1][0]);
            Console.ForegroundColor = titleColor;
            for (int j = 1; j < result[1].Length - 1; j++)
            {
                Console.Write(result[1][j]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(result[1][result[1].Length - 1]);
            for (int i = 2; i < result.Length; i++)
            {
                Console.SetCursorPosition(xstart, ystart + i);
                Console.Write(result[i]);
            }



        }
        public void DrawCentrally()
        {
            string[] result = new string[height + 2];
            result[0] = "╔";
            string temp = "";
            for (int i = 0; i < length; i++)
            {
                result[0] += "═";
            }
            result[0] += "╗";
            for (int i = 1; i < height + 1; i++)
            {
                temp = " ";
                result[i] += "║";

                if(i-1 == 0)
                {
                    temp += text[i - 1];
                    for (int j = temp.Length; j < length; j++)
                    {
                        temp += " ";
                    }
                    result[i] += temp;
                    result[i] += "║";
                }
                else
                {
                    temp = "";
                    int tempLength = text[i - 1].Length;
                    double div2 = (length - tempLength) / 2;

                    for (int j = 0; j < Math.Floor(div2); j++)
                    {
                        temp += " ";
                    }
                    result[i] += temp;
                    temp = "";
                    result[i] += text[i - 1];
                    for (int j = result[i].Length; j < length +1; j++)
                    {
                        temp += " ";
                    }
                    result[i] += temp;
                    result[i] += "║";
                }

            }
            result[result.Length - 1] += "╚";
            for (int i = 0; i < length; i++)
            {
                result[result.Length - 1] += "═";
            }
            result[result.Length - 1] += "╝";
            Console.SetCursorPosition(xstart, ystart);
            Console.Write(result[0]);

            Console.SetCursorPosition(xstart, ystart + 1);
            Console.Write(result[1][0]);
            Console.ForegroundColor = titleColor;
            for (int j = 1; j < result[1].Length - 1; j++)
            {
                Console.Write(result[1][j]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(result[1][result[1].Length - 1]);
            for (int i = 2; i < result.Length; i++)
            {
                Console.SetCursorPosition(xstart, ystart + i);
                Console.Write(result[i]);
            }
        }
        public void drawNoText()
        {
            string[] result = new string[height + 2];
            result[0] = "╔";
            string temp = "";
            for (int i = 0; i < length; i++)
            {
                result[0] += "═";
            }
            result[0] += "╗";
            for (int i = 1; i < height + 1; i++)
            {
                temp = "";
                result[i] += "║";
                for (int j = temp.Length; j < length; j++)
                {
                    temp += " ";
                }
                result[i] += temp;
                result[i] += "║";
            }
            result[result.Length - 1] += "╚";
            for (int i = 0; i < length; i++)
            {
                result[result.Length - 1] += "═";
            }
            result[result.Length - 1] += "╝";
            Console.SetCursorPosition(xstart, ystart);
            Console.Write(result[0]);

            Console.SetCursorPosition(xstart, ystart + 1);
            Console.Write(result[1][0]);
            Console.ForegroundColor = titleColor;
            for (int j = 1; j < result[1].Length - 1; j++)
            {
                Console.Write(result[1][j]);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(result[1][result[1].Length - 1]);
            for (int i = 2; i < result.Length; i++)
            {
                Console.SetCursorPosition(xstart, ystart + i);
                Console.Write(result[i]);
            }

        }



    }
    }

