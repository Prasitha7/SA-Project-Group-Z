using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA_Group_Z__21._1_
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call the API to get the list of supported shapes
                using (var client = new WebClient())
                {
                    var json = client.DownloadString("http://localhost:8080/api/shapes");
                    var shapes = JsonConvert.DeserializeObject<List<Shape>>(json);

                    // Add the shapes to the dropdown list
                    foreach (var shape in shapes)
                    {
                        DropDownList1.Items.Add(new ListItem(shape.Type, shape.Type));
                    }
                }
            }
        }
    }
}