using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ItiWfcSelfHosted
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            //run CMD as Administrator and add this line for permission "netsh http add urlacl url=http://+:8081/ItIWfc user=<local_username>"
            Uri baseAddress = new Uri("http://localhost:8081/ItIWfc");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(Service1), baseAddress))
            {

                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connectionString"];
                string connectionString = settings.ConnectionString;

                Service1.sqlConnect(connectionString);
                // Enable metadata publishing.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
