using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using Sample.BusinessLogicLayer;

namespace Sample.Website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        [Inject]
        public Student StudentBLL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateGradeGrids();
        }

        private void PopulateGradeGrids()
        {
            gvGrades.DataSource = StudentBLL.GetGrades("1234xyz", "mcs123");
            gvGrades.DataBind();

            gvGradesLongerCache.DataSource = StudentBLL.GetGradesWithHigherCacheTimeout("1234xyz", "mcs123");
            gvGradesLongerCache.DataBind();
        }
    }
}