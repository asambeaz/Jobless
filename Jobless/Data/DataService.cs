using Jobless.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Jobless.Data
{
    public class DataService
    {
        public static List<Company> GetCopmpanies()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Company> companies = new List<Company>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM companies"; ;
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Company company = new Company();
                    company.Id = reader.GetInt32(0);
                    company.Name = reader.GetString(1);
                    company.Password = reader.GetString(2);
                    company.NumberOfActivePostings = reader.GetInt32(3);

                    companies.Add(company);
                }
            }
            return companies;
        }

        public static void AddCompany(string name, string password, int numberOfActivePostings)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO companies(name, password, number_of_active_postings)" +
                                "VALUES (@name, @password, @number_of_active_postings)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@number_of_active_postings", numberOfActivePostings);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteCompany(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM companies " +
                                "Where id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public static List<JobPosting> GetJobPostings()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<JobPosting> jobPostings = new List<JobPosting>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM job_postings";
                MySqlCommand command1 = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    JobPosting jobPosting = new JobPosting();
                    jobPosting.Id = reader.GetInt32(0);
                    jobPosting.CompanyId = reader.GetInt32(1);
                    jobPosting.Description = reader.GetString(2);
                    jobPosting.Proffesion = reader.GetString(3);

                    jobPostings.Add(jobPosting);
                }
            }
            return jobPostings;
        }
        public static void AddJobPosting(int companyId, string proffesion, string description)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO job_postings(company_id, proffesion, description)" +
                                "VALUES (@company_id, @proffesion, @description)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@cmopany_id", companyId);
                command.Parameters.AddWithValue("@proffesion", proffesion);
                command.Parameters.AddWithValue("@description", description);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteJobPosting(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM job_postings " +
                                "WHERE id = @id";
                MySqlCommand command1 = new MySqlCommand(sql, mySqlConnection);
                command1.Parameters.AddWithValue("@id", id);
                command1.ExecuteNonQuery();
            }
        }

        public static List<Application> GetApplications()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Application> applications = new List<Application>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM applications";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Application application = new Application();
                    application.Id = reader.GetInt32(0);
                    application.Name = reader.GetString(1);
                    application.JobPostingId = reader.GetInt32(2);

                    applications.Add(application);
                }
            }

            return applications;
        }
        public static void AddApplication(string name, int jobPostingId)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO applications(name, job_posting_id) " +
                                "VALUES (@name, @job_posting_id)";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@job_posting_id", jobPostingId);
                command.ExecuteNonQuery();
            }
        }
    }
}
