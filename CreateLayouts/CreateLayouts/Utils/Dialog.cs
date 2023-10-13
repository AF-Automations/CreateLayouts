using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CreateLayouts.Utils
{
    public class Dialog
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defExtension"> .ext </param>
        /// <param name="title">title of the dialog</param>
        /// <param name="filterString"> Ext files (*.ext)|*.ext </param>
        /// <returns></returns>
        public static string OpenFileDialog(string defExtension, string title, string filterString)
        {
            string fileName = string.Empty;
            System.Windows.Forms.OpenFileDialog dbox = new System.Windows.Forms.OpenFileDialog();
            dbox.AddExtension = true;
            dbox.DefaultExt = defExtension;
            dbox.Filter = filterString;
            dbox.Title = title;
            dbox.CheckFileExists = true;
            dbox.Multiselect = false;
            if (dbox.ShowDialog() == DialogResult.OK)
            {
                fileName = dbox.FileName;
            }
            return fileName;
        }

    }
}
