using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2009M1HelloUWP.Entities;
using T2009M1HelloUWP.Utils;

namespace T2009M1HelloUWP.Models
{
    public class StudentModel : IStudentModel
    {
        private static string InsertCommand =
            "insert into students" +
            "(roll_number, fullname, avatar, email, birthday, phone, address, gender, created_at, updated_at, status)" +
            "values" +
            "(@roll_number, @fullname, @avatar, @email, @birthday, @phone, @address, @gender, @created_at, @updated_at, @status)";
        private static string SelectCommand = "select * from students";


        public bool Save(Student student)
        {
            using (var connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                var mysqlCommand = new MySqlCommand(InsertCommand, connection);
                mysqlCommand.Parameters.AddWithValue("@rollNumber", student.Rollnumber);
                mysqlCommand.Parameters.AddWithValue("@fullName", student.Fullname);
                mysqlCommand.Parameters.AddWithValue("@avatar", student.Avatar);
                mysqlCommand.Parameters.AddWithValue("@email", student.Email);
                mysqlCommand.Parameters.AddWithValue("@birthday", student.Birthday.ToString("yyyy-MM-dd"));
                mysqlCommand.Parameters.AddWithValue("@phone", student.Phone);
                mysqlCommand.Parameters.AddWithValue("@address", student.Address);
                mysqlCommand.Parameters.AddWithValue("@gender", student.Gender);
                mysqlCommand.Parameters.AddWithValue("@createdAt", student.CreatedAt.ToString("yyyy-MM-dd"));
                mysqlCommand.Parameters.AddWithValue("@updatedAt", student.UpdatedAt.ToString("yyyy-MM-dd"));
                mysqlCommand.Parameters.AddWithValue("@status", student.Status);

                // thực thi
                mysqlCommand.ExecuteNonQuery();
                // try with resource \ using
                Console.WriteLine("Lưu sinh viên thành công.");
                return true;
            }
            return false;
        }

        public List<Student> FindAll()
        {
            List<Student> result = new List<Student>();
            using (var connection = ConnectionHelper.GetConnection())
            {
                connection.Open();
                var mysqlCommand = new MySqlCommand(SelectCommand, connection);
                var reader = mysqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var rollNumber = reader.GetString("roll_number");
                    var fullNamer = reader.GetString("full_name");
                    var avatar = reader.GetString("avatar");
                    var email = reader.GetString("email");
                    var birthday = reader.GetDateTime("birthday");
                    var phone = reader.GetString("phone");
                    var address = reader.GetString("address");
                    var gender = reader.GetString("gender");
                    var createdAt = reader.GetDateTime("created_at");
                    var updatedAt = reader.GetDateTime("updated_at");
                    var status = reader.GetInt32("status");
                    var student = new Student
                    {
                        Rollnumber = rollNumber,
                        Fullname = fullNamer,
                        Avatar = avatar,
                        Email = email,
                        Birthday = birthday,
                        Phone = phone,
                        Address = address,
                        Gender = gender,
                        CreatedAt = createdAt,
                        UpdatedAt = updatedAt,
                        Status = status
                    };
                    result.Add(student);
                }
            }
            return result;
        }
    }
}
