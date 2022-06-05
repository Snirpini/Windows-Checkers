﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameBoardForm gameBoardForm = new GameBoardForm();
            gameBoardForm.ShowDialog();
        }
    }
}
