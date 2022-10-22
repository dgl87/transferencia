using Google.Cloud.BigQuery.V2;
using System;

namespace CrudBQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            programa01();
        }
        static void programa01()
        {
            string projectId = "journey-event-process-dev";
            var client = BigQueryClient.Create(projectId);
            string query = "UPDATE `journey-event-process-dev.luis.journey_event_v2` SET properties = array(select struct('aaa', 'bbb')) WHERE shootingId = '6266a7fe620ece9416d2ae1b'";
            var result = client.ExecuteQuery(query, null);
            foreach (var item in result)
            {
                Console.WriteLine(item["shootingId"] + " " + item["eventType"]);
            }
        }
    }
}
