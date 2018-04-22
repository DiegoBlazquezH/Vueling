using Redis.Common.Models;
using Redis.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisBusiness
{
    public class StudentBL
    {
        private StudentDao studentDao;

        public StudentBL()
        {
            this.studentDao = new StudentDao();
        }

        public Student Read(string key)
        {
            return studentDao.Read(key);
        }

        public bool Save(string key, Student student)
        {
            return studentDao.Save(key, student);
        }
    }
}
