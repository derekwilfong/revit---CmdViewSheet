#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace CmdViewSheet
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
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

            // Access current selection

            try
            {
                ViewData m = new ViewData();
                string q = m.sheetNum(doc, uiapp).ToString();

                TaskDialog.Show("Sheet Number", q);

                //if (string.IsNullOrEmpty(q))

                //    {
                //    TaskDialog.Show("Selection","This view is not located on a sheet");
                //}
                //else
                //{
                //    TaskDialog.Show("Sheet Number", q/*m.sheetNum(doc, uiapp).ToString()*/);
                //}

            }

            catch(Exception)
            {
                TaskDialog.Show("Selection", "This section is not on a sheet");
                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
}
