﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BO;

namespace StudentSolution.Student
{
    public partial class edit : System.Web.UI.Page
    {
        public StudentBO entity;
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

                string value = Request.QueryString["id"];
                int id = int.Parse(value);

                entity = studentBLL.findById(id);

                typeDropDownList.SelectedValue = entity.Type.Id.ToString();
                this.name.Text = entity.Name;
                this.id.Value = entity.Id.ToString();
                gender.SelectedValue = entity.Gender.ToString();
            }
        }

        public void saveData(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //TypeBO aux = (TypeBO)typeDropDownList.SelectedItem;
                studentBLL.Edit(int.Parse(id.Value), int.Parse(typeDropDownList.SelectedItem.Value.ToString()), name.Text, char.Parse(gender.SelectedValue));
                Response.Redirect("index.aspx");
            }
        }
    }
}