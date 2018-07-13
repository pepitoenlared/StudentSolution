using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BLL;

namespace StudentSolution.Student
{
    public partial class delete : System.Web.UI.Page
    {
        private StudentBO studentBO = new StudentBO();
        private StudentBLL studentBLL = new StudentBLL();
        public StudentBO entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            string value = Request.QueryString["id"];
            int id = int.Parse(value);
            entity = studentBLL.findById(id);
        }

        public void deleteItem(object sender, EventArgs e)
        {
            studentBLL.Delete(entity.Id);
            Response.Redirect("index.aspx");
        }
    }
}