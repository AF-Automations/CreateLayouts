// (C) Copyright 2021 by  
//
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.Runtime;
using System;

// This line is not mandatory, but improves loading performances
[assembly: ExtensionApplication(typeof(CreateLayouts.MyPlugin))]

namespace CreateLayouts
{
    // This class is instantiated by AutoCAD once and kept alive for the 
    // duration of the session. If you don't do any one time initialization 
    // then you should remove this class.
    public class MyPlugin : IExtensionApplication
    {

        public void Initialize()
        {
            Utils.AcadUi.PrintToCmdLine("\nLoading CreateLayouts...");
        }

        public void Terminate()
        {
            // Do plug-in application clean up here
        }

    }

}
