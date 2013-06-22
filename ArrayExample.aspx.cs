using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using InfoSoftGlobal;

public partial class _ArrayExample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[,] arrData = { 
                                { "Sales of Food Products", "892500", "2009" }, 
                                { "Sales of Non-Food Products", "595000", "2009" },

                                { "Sales of Food Products", "1407400", "2010" },
                                { "Sales of Non-Food Products", "693200", "2010" },

                                { "Sales of Food Products", "1565000", "2011" },
                                { "Sales of Non-Food Products", "880400", "2011" },
        };

        StringBuilder xmlStr = new StringBuilder();

        xmlStr.Append("<chart caption='Break-up of sales for last 3 years' numberPrefix='$'>");

        xmlStr.Append("<categories>");
        for (int i = 0; i < 6; i++)
        {
            xmlStr.AppendFormat("<category label = '{0}' />", arrData[i, 2]);
            i++;
        }
        xmlStr.Append("</categories>");

        xmlStr.Append("<dataset seriesName = 'Sales of Food Products'>");
        for (int i = 0; i < 3; i++)
        {
            xmlStr.AppendFormat("<set value = '{0}' />", arrData[i, 1]);
        }
        xmlStr.Append("</dataset>");

        xmlStr.Append("<dataset seriesName = 'Sales of Non-Food Products'>");
        for (int i = 3; i < 6; i++)
        {
            xmlStr.AppendFormat("<set value = '{0}' />", arrData[i, 1]);
        }
        xmlStr.Append("</dataset>");

        xmlStr.Append("</chart>");

        Literal1.Text = FusionCharts.RenderChart("Charts/StackedBar2D.swf", "", xmlStr.ToString(), "productSales", "600", "300", false, true);


    }
}