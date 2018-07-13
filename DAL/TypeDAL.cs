using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;

namespace DAL
{
    public static class TypeDAL
    {
        private static List<TypeBO> types = new List<TypeBO>();

        public static bool Insert(TypeBO type)
        {
            bool result = false;

            try
            {
                TypeDAL.types.Add(type);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static bool Edit(TypeBO type)
        {
            bool result = false;
            try
            {
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static bool Delete(TypeBO type)
        {
            bool result = false;
            try
            {

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static TypeBO findById(int id)
        {
            TypeBO type = TypeDAL.types.FirstOrDefault(o => o.Id == id);

            return type;
        }

        public static TypeBO findByName(string name)
        {
            TypeBO type = TypeDAL.types.FirstOrDefault(o => o.Name == name);

            return type;
        }

        public static List<TypeBO> getList()
        {
            return TypeDAL.types;
        }

        public static List<TypeBO> getListSearch()
        {
            List<TypeBO> list = new List<TypeBO>();
            TypeBO new_type = new TypeBO();
            new_type.Id = 0;
            new_type.Name = "Select an Item (Type)";
            list.Add(new_type);

            foreach (var item in TypeDAL.types)
            {
                list.Add(item);
            }

            return list;
        }

        public static void LoadData()
        {
            TypeBO type = new TypeBO();
            type.Id = 1;
            type.Name = "Kindergardens";
            TypeDAL.types.Add(type);

            TypeBO type2 = new TypeBO();
            type2.Id = 2;
            type2.Name = "Elementary Schools";
            TypeDAL.types.Add(type2);

            TypeBO type3 = new TypeBO();
            type3.Id = 3;
            type3.Name = "High Schools";
            TypeDAL.types.Add(type3);

            TypeBO type4 = new TypeBO();
            type4.Id = 4;
            type4.Name = "University";
            TypeDAL.types.Add(type4);
        }
    }
}
