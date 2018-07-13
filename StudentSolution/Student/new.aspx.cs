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
    public partial class _new : System.Web.UI.Page
    {
        public List<TypeBO> entities;
        private TypeBLL typeBLL = new TypeBLL();
        private StudentBLL studentBLL = new StudentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                entities = new List<TypeBO>();
                entities = typeBLL.getList();

                typeDropDownList.DataSource = entities;
                typeDropDownList.DataTextField = "Name";
                typeDropDownList.DataValueField = "Id";
                typeDropDownList.DataBind();
            }
        }

        public void saveData(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //TypeBO aux = (TypeBO)typeDropDownList.SelectedItem;
                studentBLL.Create(int.Parse(typeDropDownList.SelectedItem.Value.ToString()), name.Text, char.Parse(gender.SelectedValue));
                Response.Redirect("index.aspx");
            }
        }
    }
}