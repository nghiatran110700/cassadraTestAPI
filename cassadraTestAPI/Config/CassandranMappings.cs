using cassadraTestAPI.Model;
using Cassandra.Mapping;

namespace cassadraTestAPI.Config
{
    public class CassandranMappings : Cassandra.Mapping.Mappings
    {
        public CassandranMappings()
        {
            For<Post>().TableName("posts").PartitionKey(x => x.post_id)
                .Column(x => x.post_id)
                .Column(x => x.title)
                .Column(x => x.body)
                .Column(x => x.lastupdated);
        }
    }
}
