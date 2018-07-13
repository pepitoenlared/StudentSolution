using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using BLL;
using System.Data;

namespace StudentSolution.Student
{
    public partial class index : System.Web.UI.Page
    {
        public List<StudentBO> entities;
        public List<TypeBO> types;
        private TypeBLL typeBLL = new TypeBLL();
        private StudentBLL studentBLL = new StudentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                entities = new List<StudentBO>();
                entities = studentBLL.getList();

                types = new List<TypeBO>();
                types = typeBLL.getListSearch();

                searchTypeList.DataSource = types;
                searchTypeList.DataTextField = "Name";
                searchTypeList.DataValueField = "Id";
                searchTypeList.DataBind();

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                                    new DataColumn("Id", typeof(int)),
                                    new DataColumn("Type", typeof(TypeBO)),
                                    new DataColumn("Name",typeof(string)),
                                    new DataColumn("Gender",typeof(string)),
                                    new DataColumn("Time",typeof(string)) });

                foreach (var item in entities)
                {
                    dt.Rows.Add(item.Id, item.Type, item.Name, item.Gender, item.Time);
                }

                dataGridView.DataSource = entities;
                dataGridView.DataBind();
            }
        }

        public void searchData(object sender, EventArgs e)
        {
            int typeId = int.Parse(searchTypeList.SelectedItem.Value.ToString());
            char gender = char.Parse(searchGender.SelectedItem.Value);
            string name = searchName.Text;

            List<StudentBO> list = studentBLL.searchList(typeId, gender, name);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {
                                    new DataColumn("Id", typeof(int)),
                                    new DataColumn("Type", typeof(TypeBO)),
                                    new DataColumn("Name",typeof(string)),
                                    new DataColumn("Gender",typeof(string)),
                                    new DataColumn("Time",typeof(string)) });

            foreach (var item in list)
            {
                dt.Rows.Add(item.Id, item.Type, item.Name, item.Gender, item.Time);
            }

            dataGridView.DataSource = list;
            dataGridView.DataBind();
        }
    }
}