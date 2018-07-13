using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using System.IO;

namespace DAL
{
    public static class StudentDAL
    {
        private static List<StudentBO> students = new List<StudentBO>();

        public static bool Create(int typeId, string name, char gender)
        {
            bool result = false;

            try
            {
                TypeBO type = TypeDAL.findById(typeId);
                StudentBO student_new = new StudentBO();
                student_new.Type = type;
                student_new.Id = StudentDAL.getList().OrderByDescending(o => o.Id).First().Id + 1;
                student_new.Name = name;
                student_new.Gender = gender;
                student_new.SetTime();

                StudentDAL.students.Add(student_new);
                result = true;
            }
            catch (Exception)
            {
                result = false;
                throw;
            }

            return result;
        }

        public static bool Edit(int id, int typeId, string name, char gender)
        {
            bool result = false;
            try
            {
                foreach (var item in StudentDAL.students)
                {
                    if (item.Id == id)
                    {
                        TypeBO type = TypeDAL.findById(typeId);
                        item.Type = type;
                        item.Name = name;
                        item.Gender = gender;
                        item.SetTime();
                    }
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static bool Delete(int id)
        {
            bool result = false;
            try
            {
                List<StudentBO> list = new List<StudentBO>();
                foreach (var item in StudentDAL.students)
                {
                    if (item.Id != id)
                        list.Add(item);
                }

                StudentDAL.students = list;
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static StudentBO findById(int id)
        {
            StudentBO student = StudentDAL.students.FirstOrDefault(o => o.Id == id);

            return student;
        }

        public static List<StudentBO> getList()
        {
            return StudentDAL.students.OrderBy(o => o.Time).ToList();
        }

        public static List<StudentBO> searchListByType(int typeId)
        {
            List<StudentBO> list = new List<StudentBO>();

            foreach (var item in StudentDAL.students)
            {
                if (item.Type.Id == typeId)
                    list.Add(item);
            }

            return list;
        }

        public static List<StudentBO> searchList(int typeId, char gender, string name)
        {
            List<StudentBO> list = new List<StudentBO>();
            //list = StudentDAL.students.FindAll(o => o.Type.Id == typeId || o.Gender == gender || o.Name.ToLower().Contains(name));
            if (typeId != 0 || gender != '0')
            {
                if (typeId != 0 && gender != '0')
                {
                    if (name != "")
                        list = StudentDAL.students.FindAll(o => (o.Type.Id == typeId && o.Gender == gender) && o.Name.ToLower().Contains(name)).OrderBy(o => o.Time).ToList();
                    else
                        list = StudentDAL.students.FindAll(o => (o.Type.Id == typeId && o.Gender == gender)).OrderBy(o => o.Time).ToList();
                } else
                {
                    if (typeId != 0 && gender == '0')
                    {
                        if (name != "")
                            list = StudentDAL.students.FindAll(o => o.Type.Id == typeId && o.Name.ToLower().Contains(name)).OrderBy(o => o.Time).ToList();
                        else
                            list = StudentDAL.students.FindAll(o => o.Type.Id == typeId).OrderBy(o => o.Time).ToList();
                    }

                    if (typeId == 0 && gender != '0')
                    {
                        if (name != "")
                            list = StudentDAL.students.FindAll(o => o.Gender == gender && o.Name.ToLower().Contains(name)).OrderBy(o => o.Time).ToList();
                        else
                            list = StudentDAL.students.FindAll(o => o.Gender == gender).OrderBy(o => o.Time).ToList();
                    }
                }
            }
            else if (name != "")
            {
                list = StudentDAL.students.FindAll(o => o.Name.ToLower().Contains(name)).OrderBy(o => o.Name).ToList();
            } else
            {
                list = StudentDAL.students.OrderBy(o => o.Time).ToList();
            }
            return list;
        }

        public static void LoadData()
        {
            if (TypeDAL.getList().Count == 0)
                TypeDAL.LoadData();

            //string fileName = @"input.csv";
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\DAL\source\input.csv";
            //string fileName = "c:/Users/brayan-pc/documents/visual studio 2017/Projects/Students/DAL/source/input.csv";

            try
            {
                int contador = 0;
                foreach (var line in File.ReadLines(fileName).Skip(1))
                {
                    contador++;
                    var data = line.Split(';');
                    TypeBO type = TypeDAL.findByName(data[0]);
                    StudentBO student_new = new StudentBO();
                    student_new.Type = type;
                    student_new.Id = contador;
                    student_new.Name = data[1];
                    student_new.Gender = char.Parse(data[2]);
                    student_new.SetTime(data[3]);
                    StudentDAL.students.Add(student_new);
                }
            }
            catch (Exception)
            {

                throw;
            }
            //return myList;
        }

        public static void LoadData2()
        {
            TypeBO type = new TypeBO();
            if (TypeDAL.getList().Count == 0)
                TypeDAL.LoadData();

            type = TypeDAL.findById(2);

            StudentBO student = new StudentBO();
            student.Id = 1;
            student.Name = "Jose";
            student.Gender = 'M';
            student.Type = type;
            student.Time = DateTime.Now.ToString();

            StudentDAL.students.Add(student);

            StudentBO student_2 = new StudentBO();
            student_2.Id = 2;
            student_2.Name = "Maria";
            student_2.Gender = 'F';
            student_2.Type = type;
            student_2.Time = DateTime.Now.ToString();

            StudentDAL.students.Add(student_2);

            StudentBO student_3 = new StudentBO();
            student_3.Id = 3;
            student_3.Name = "Jorge";
            student_3.Gender = 'M';
            student_3.Type = type;
            student_3.Time = DateTime.Now.ToString();

            StudentDAL.students.Add(student_3);
            //return myList;
        }
    }
}
