using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAL;

namespace BLL
{
    public class StudentBLL
    {
        public bool Create (int typeId, string name, char gender)
        {
            return StudentDAL.Create(typeId, name, gender);
        }

        public bool Edit (int id, int typeId, string name, char gender)
        {
            return StudentDAL.Edit(id, typeId, name, gender);
        }

        public bool Delete (int id)
        {
            return StudentDAL.Delete(id);
        }

        public StudentBO findById (int id)
        {
            return StudentDAL.findById(id);
        }

        public List<StudentBO> getList()
        {
            if (StudentDAL.getList().Count == 0)
                StudentDAL.LoadData();
            return StudentDAL.getList();
        }

        public List<StudentBO> searchListByType(int typeId)
        {
            return StudentDAL.searchListByType(typeId);
        }

        public List<StudentBO> searchList(int typeId, char gender, string name)
        {
            return StudentDAL.searchList(typeId, gender, name.ToLower());
        }
    }
}
