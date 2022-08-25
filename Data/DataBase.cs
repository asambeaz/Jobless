using MySql.Data.MySqlClient;

namespace Jobless.Data
{
    public static class DataBase
    {
        private const string ConnectionString = "Server=localhost;Database=Jobless;Uid=root;Pwd=Mindil12345;";
        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            if(connection == null)
            {
                connection = new MySqlConnection(ConnectionString);
            }
            return connection;
        }

        static DataBase()
        {
            MySqlConnection connection = GetConnection();
            connection.Open();

            using (connection)
            {
                string sqlCompany = "CREATE TABLE IF NOT EXISTS companies( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "password VARCHAR(50) NOT NULL, " +
                                    "number_of_active_postings INT " +
                                    ")";

                MySqlCommand commandCompany = new MySqlCommand(sqlCompany, connection);
                commandCompany.ExecuteNonQuery();

                string sqlJobPosting = "CREATE TABLE IF NOT EXISTS job_postings( " +
                                        "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                        "company_id INT, " +
                                        "proffesion VARCHAR(50) NOT NULL, " +
                                        "description VARCHAR(50) NOT NULL, " +
                                        "is_active BOOLEAN, " +
                                        "CONSTRAINT fk_job_postings_companies " +
                                        "FOREIGN KEY(company_id) REFERENCES companies(id) ON DELETE CASCADE " +
                                        ")";

                MySqlCommand commandJobPosting = new MySqlCommand(sqlJobPosting, connection);
                commandJobPosting.ExecuteNonQuery();

                string sqlApplication = "CREATE TABLE IF NOT EXISTS applications( " +
                                        "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                        "name VARCHAR(50) NOT NULL, " +
                                        "job_posting_id INT, " +
                                        "CONSTRAINT fk_applications_job_postings " +
                                        "FOREIGN KEY(job_posting_id) REFERENCES job_postings(id) ON DELETE CASCADE " +
                                        ")";

                MySqlCommand comanndApplication = new MySqlCommand(sqlJobPosting, connection);
                comanndApplication.ExecuteNonQuery();

            }
            connection.Close();
        }
    }
}
