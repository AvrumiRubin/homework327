using System.Data.SqlClient;

namespace homework_3___27.data
{
    public class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class PeopleDB
    {
        private string _connectionString;

        public PeopleDB(string connectionString)
        {
            _connectionString = connectionString; 
        }

        public void Add(People person)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "Insert into people (FirstName, LastName, Age) Values (@first, @last, @age)";
            cmd.Parameters.AddWithValue("@first", person.FirstName);
            cmd.Parameters.AddWithValue("@last", person.LastName);
            cmd.Parameters.AddWithValue("@age", person.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void AddMany(List<People> peoples)
        {
            foreach(People p in peoples)
            {
                Add(p);
            }
        }

        public List<People> GetPeoples()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "Select * from People";
            connection.Open();
            var list = new List<People>();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new People
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return list;
        }
    }
}