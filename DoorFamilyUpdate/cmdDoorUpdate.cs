#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace DoorFamilyUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class cmdDoorUpdate : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // populate the data grid with all doors in project
                // fist column to display room name where door is located
                // second column to display current door size (i.e. 30"x80")
                // third column to be combo box showing types for Flush Single w_Hardware

            // put any code needed for the form here

            List<FamilyInstance> doorList = new List<FamilyInstance>();

            FilteredElementCollector colDoors = new FilteredElementCollector(doc);
            colDoors.OfCategory(BuiltInCategory.OST_Doors);
            colDoors.WhereElementIsNotElementType();

            doorList = colDoors.Cast<FamilyInstance>().ToList();

            // open form
            frmDoorUpdate curForm = new frmDoorUpdate(doorList)
            {
                Width = 500,
                Height = 400,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            // get form data and do something

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
