﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADL_Client_Demo
{
    class Program
    {
        private static void Main(string[] args)
        {
            var auth_session = new AzureDataLake.Authentication.AuthenticatedSession();
            auth_session.Authenticate();

            string store_account = "datainsightsadhoc";
            string analytics_account = "datainsightsadhoc";
            string subid = "045c28ea-c686-462f-9081-33c34e871ba3";
            var sub = new AzureDataLake.Subscription(subid);

            var StoreClient = new AzureDataLake.Store.StoreFileSystemClient(store_account, auth_session);
            var AnalyticsClient = new AzureDataLake.Analytics.AnalyticsClient(analytics_account, auth_session);
            var StoreAccountClient = new AzureDataLake.Store.StoreAccountClient(sub, auth_session);
            var AnalyticsAccountClient = new AzureDataLake.Analytics.AnalyticsAccountClient(sub, auth_session);

            var directory = AzureDataLake.Authentication.Directory.Resolve("microsoft.com");

            var adls_accounts = StoreAccountClient.ListStores(subid);
            foreach (var a in adls_accounts)
            {
                System.Console.WriteLine("Store {0} ", a.Name);
            }

            var adla_accounts = AnalyticsAccountClient.ListStores(subid);
            foreach (var a in adla_accounts)
            {
                System.Console.WriteLine("Analytics {0} ", a.Name);
            }


            int x = 1;

            /*
            var getjobs_options = new AzureDataLake.Analytics.GetJobListPagedOptions();
            getjobs_options.Top = 30;
            getjobs_options.OrderByField = "submitTime";
            getjobs_options.OrderByDirection = "desc";


            var sjo = new AzureDataLake.Analytics.SubmitJobOptions();
            sjo.ScriptText = "FOOBAR";
            var ji = AnalyticsClient.SubmitJob(sjo);

            System.Console.WriteLine("{0} {1} {2}", ji.Name, ji.JobId, ji.SubmitTime);

            */
            /*
            var jobs = AnalyticsClient.GetJobList(getjobs_options).ToArray();


            foreach (var job in jobs)
            {
                var job2 = AnalyticsClient.GetJob(job.JobId.Value);
                System.Console.WriteLine("{0} {1}", job.Name, job.JobId);
            }
            
            var pages = StoreClient.ListPaged("/",200);
            foreach (var page in pages)
            {
                foreach (var file in page)
                {
                    System.Console.WriteLine(file.PathSuffix);
                    //var acl = store_client.GetPermissions("/test/" + file.PathSuffix);
                }
            }
            */

            /*
            var pages = store_client.ListPagedRecursive("/",4);
            foreach (var page in pages)
            {
                foreach (var child in page.Children)
                {
                    System.Console.WriteLine(page.Path +"/"+ child.PathSuffix);
                }
            }*/

            //store_client.CreateDirectory("/testsaveen");
            //store_client.Delete("/testsaveen");

            //store_client.CreateFile("/saveenr/testdata.txt", "Hello World", true);
            /// store_client.ModifyACLs(bname, "other::r-x");




        }

    }
}
