using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAL;

namespace BLL
{
    public class TypeBLL
    {
        public bool Insert(TypeBO type)
        {
            return TypeDAL.Insert(type);
        }

        public bool Edit(TypeBO type)
        {
            return TypeDAL.Edit(type);
        }

        public bool Delete(TypeBO type)
        {
            return TypeDAL.Delete(type);
        }

        public List<TypeBO> getList()
        {
            if (TypeDAL.getList().Count == 0)
                TypeDAL.LoadData();

            return TypeDAL.getList();
        }

        public List<TypeBO> getListSearch()
        {
            if (TypeDAL.getList().Count == 0)
                TypeDAL.LoadData();

            return TypeDAL.getListSearch();
        }
    }
}
