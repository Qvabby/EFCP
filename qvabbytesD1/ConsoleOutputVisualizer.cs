﻿namespace qvabbytesD1
{
    public class ConsoleOutputVisualizer
    {
        /// <summary>
        /// Print Message (default green color)
        /// </summary>
        /// <param name="msg">Text you want to output on console.</param>
        public void Qprint(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        /// <summary>
        /// Print message (custom color)
        /// </summary>
        /// <param name="msg">Text you want to output on console.</param>
        /// <param name="TextColor">Color of Text</param>
        public void Qprint(string msg, string TextColor)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), TextColor);
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        /// <summary>
        /// Print message (custom colors)
        /// </summary>
        /// <param name="msg">Text you want to output on console.</param>
        /// <param name="TextColor">Color of Text</param>
        /// <param name="BackgroundColor">Background color</param>
        public void Qprint(string msg, string TextColor, string BackgroundColor)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), TextColor);
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), BackgroundColor);
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        /// <summary>
        /// Print message (red color)
        /// </summary>
        /// <param name="msg">Danger Text</param>
        public void Qdanger(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        /// <summary>
        /// Print message (yellow color)
        /// </summary>
        /// <param name="msg">Warning Text</param>
        public void Qwarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        /// <summary>
        /// Print message (green color)
        /// </summary>
        /// <param name="msg">Success text</param>
        public void Qsuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
