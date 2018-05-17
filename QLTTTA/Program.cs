using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using QLTTTA.GUI;


namespace QLTTTA
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

         //BonusSkins.Register();
         SkinManager.EnableFormSkins();
         Application.Run(new frmLogin());
         
         

        }
   }
}
