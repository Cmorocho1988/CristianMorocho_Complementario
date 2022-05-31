using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CristianMorocho.Models;
using System.IO;

namespace CristianMorocho.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection conn;

        public SQLiteHelper(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);

            conn.CreateTableAsync<Students>().Wait();
            conn.CreateTableAsync<StudentsLogin>().Wait();
        }

        public Task<List<StudentsLogin>> GetStudentsLoginAsync(int id)
        {
            return conn.Table<StudentsLogin>().Where(i => i.User == id).ToListAsync();
        }

        public Task<int> SaveStudentsLoginAsync(StudentsLogin studentsLogin)
        {
            return conn.InsertAsync(studentsLogin);
        }

        public Task<int> GetLoginStudent(StudentsLogin studentsLogin)
        {
            return conn.Table<StudentsLogin>().Where(i => i.User == studentsLogin.User && i.Password == studentsLogin.Password).CountAsync();
        }

        public Task<int> SaveStudentAsync(Students students)
        {
            return conn.InsertAsync(students);
        }

        public Task<List<Students>> GetStudentsAsync()
        {
            return conn.Table<Students>().ToListAsync();
        }

        public Task<int> UpdateStudentAsync(Students students)
        {
            return conn.UpdateAsync(students);
        }

        public Task<int> DeleteStudentAsync(int id)
        {
            return conn.DeleteAsync<Students>(id);
        }

        public Task<Students> GetStudent(int id)
        {
            return conn.Table<Students>().Where(i => i.cod_estudiante == id).FirstOrDefaultAsync();
        }
    }   
}
