using System;
using System.Configuration;

namespace Global
{
    public class Configurator
    {
        public string databaseConnectionString;
        public bool isTestEnvironment = false;
        public bool isSimulated = false;

        public Configurator()
        {
            //Read the deployment mode setting from the config file
            string deploymentMode = ConfigurationManager.AppSettings["DeploymentMode"];
            databaseConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

            try
            {
                //Examine the deployment mode
                switch(deploymentMode.ToUpper())
                {
                    case "TEST_SIMULATED":
                        {
                            // Set flags accordingly.
                            isTestEnvironment = true;
                            isSimulated = true;
                            break;
                        }

                    case "TEST_DATABASE":
                        {
                            // Set flags accordingly.
                            isTestEnvironment = true;
                            isSimulated = false;

                            // Set the connection strings.
                            databaseConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
                            break;
                        }

                    case "PRODUCTION":
                        {
                            // Set flags accordingly.
                            isTestEnvironment = false;
                            isSimulated = false;

                            // Set the connection strings.
                            databaseConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionProduction"].ToString();

                            // Make sure that the Entity Framework connect string is consistent.
                            if (databaseConnectionString.Contains("TEST"))
                            {
                                throw new Exception("The database connection string references the TEST database, even though the deployment mode setting is for PRODUCTION. These must be consistent.");
                            }
                            break;
                        }
                    default:
                        {
                            throw new Exception("The Deployment Mode was not set or is invalid.");
                        }
                }
            }
            catch (Exception innerException)
            {
                throw new Exception("The Configuration settings are not set or invalid. Note that for database connections, the mode must correspond to connection string names. For example, if the mode is TEST_DATABASE then you MUST have a connection string named Pwadc_Sql_TEST.", innerException);
            }

        }
    }
}
