using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace MovieRank
{
    public static class AwsServiceConfiguration
    {
        public static void ConfigureAwsServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>();

            services.AddSingleton<IAmazonDynamoDB>(provider =>
            {
                var awsOptions = configuration.GetAWSOptions();
                var region = configuration.GetValue<string>("DynamoDB:Region");
                if (string.IsNullOrEmpty(region))
                {
                    throw new Exception("DynamoDB region not configured");
                }

                var accessKey = configuration.GetValue<string>("AWS:Credentials:AccessKey");
                var secretKey = configuration.GetValue<string>("AWS:Credentials:SecretKey");
                if (string.IsNullOrEmpty(accessKey))
                {
                    throw new Exception("AWS access key not configured");
                }
                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new Exception("AWS secret key not configured");
                }

                var credentials = new BasicAWSCredentials(accessKey, secretKey);

                var dynamoConfig = new AmazonDynamoDBConfig
                {
                    RegionEndpoint = RegionEndpoint.GetBySystemName(region)
                };

                var client = new AmazonDynamoDBClient(credentials, dynamoConfig);
                var tableName = configuration.GetValue<string>("DynamoDB:MoviesTableName");
                try
                {
                    var response = client.DescribeTableAsync(new DescribeTableRequest
                    {
                        TableName = tableName
                    }).GetAwaiter().GetResult();
                }
                catch (ResourceNotFoundException ex)
                {
                    throw new Exception($"Table {tableName} not found in region {region}", ex);
                }

                return client;
            });
        }
    }
}