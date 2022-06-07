using LabTwo.Models;
using Microsoft.Data.SqlClient;

namespace LabTwo
{
    public class DataAccessLayer
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonInfo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Person> people = new List<Person>();

        public List<Person> GetPersonInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlText = "Select * from Person";
            SqlCommand command = new SqlCommand(sqlText, connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Person person = new Person();
                person.Id = (int)dr[0];
                person.Name = (string)dr[1];
                person.Address = (string)dr[2];
                person.Qualification = (string)dr[3];
                person.MaritialStatus = (bool)dr[4];
                people.Add(person);
            }
            return people;
        }
        public bool SavePerson(Person person)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string sqlText = "insert into Person (Name, Address, Qualification, MaritialStatus) values ( @Name, @Address, @Qualification, @MaritialStatus)";
                SqlCommand command = new SqlCommand(sqlText, connection);
                command.Parameters.Add(new SqlParameter("@Name", person.Name));
                command.Parameters.Add(new SqlParameter("@Address", person.Address));
                command.Parameters.Add(new SqlParameter("@Qualification", person.Qualification));
                command.Parameters.Add(new SqlParameter("@MaritialStatus", person.MaritialStatus));
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection.State != null)
                {
                    connection.Close();
                }
            }
        }

        public bool EditPersonInfo(Person p)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlText = "Select * from Person";
            SqlCommand command = new SqlCommand(sqlText, connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Person person = new Person();
                person.Id = (int)dr[0];
                person.Name = (string)dr[1];
                person.Address = (string)dr[2];
                person.Qualification = (string)dr[3];
                person.MaritialStatus = (bool)dr[4];
                people.Add(person);
            }
            connection.Close();
            try
            {
                Person per = people.Where(x => x.Id == p.Id).FirstOrDefault();
                per.Name = p.Name;
                per.Address = p.Address;
                per.Qualification = p.Qualification;
                per.MaritialStatus = p.MaritialStatus;
                string sqlTextUpdate = $"update Person set Name = @Name, Address=@Address, Qualification=@Qualification, MaritialStatus = @MaritialStatus WHERE Id = {p.Id} ";
                SqlCommand commandUpdate = new SqlCommand(sqlTextUpdate, connection);
                commandUpdate.Parameters.Add(new SqlParameter("@Name", per.Name));
                commandUpdate.Parameters.Add(new SqlParameter("@Address", per.Address));
                commandUpdate.Parameters.Add(new SqlParameter("@Qualification", per.Qualification));
                commandUpdate.Parameters.Add(new SqlParameter("@MaritialStatus", per.MaritialStatus));
                connection.Open();
                commandUpdate.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection.State != null)
                {
                    connection.Close();
                }
            }

        }
        public void DeleteInfo(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlText = $"delete from Person where Id = {id}";
            SqlCommand command = new SqlCommand(sqlText, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Person Details(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlText = "Select * from Person";
            SqlCommand command = new SqlCommand(sqlText, connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Person person = new Person();
                person.Id = (int)dr[0];
                person.Name = (string)dr[1];
                person.Address = (string)dr[2];
                person.Qualification = (string)dr[3];
                person.MaritialStatus = (bool)dr[4];
                people.Add(person);
            }
            Person per = people.Where(x => x.Id == id).FirstOrDefault();
            return per;
        }
    }
}
