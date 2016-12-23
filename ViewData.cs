using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace CmdViewSheet
{
    class ViewData
    {
     
        

        public ViewData() { }

        public string sheetNum(Document doc, UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Selection sel = uidoc.Selection;
            Reference hasPickOne = sel.PickObject(ObjectType.Element, "Select Object");
            Element e = uidoc.Document.GetElement(hasPickOne);
            string y = e.get_Parameter(BuiltInParameter.VIEWER_SHEET_NUMBER).AsString();


            if (y.Contains("-"))
            {
                //TaskDialog.Show("Selection", "This Section is no on a sheet");
                return null;
            }

            else
            {
                
            }

            return y;

        }
    }
}
