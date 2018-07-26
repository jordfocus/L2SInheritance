using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace L2SInheritance.DAL
{
    public class BaseContext : DataContext
    {
        public BaseContext(string connectionString, MappingSource mappingSource)
            : base(connectionString, mappingSource)
        {

        }

        public BaseContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {

        }

        public override void SubmitChanges(ConflictMode failureMode)
        {
            // get the changed entities before submitting the changes
            var changedEntities = GetChangeSet();
            base.SubmitChanges(failureMode);

            var allChanged = changedEntities.Inserts.Union(changedEntities.Updates);
            foreach (var entity in allChanged.Where(e => ((BaseEntity)e).Messages.Any()))
            {
                var baseEntity = ((BaseEntity)entity);
                foreach (var message in baseEntity.Messages)
                {
                    Logger.Instance.WriteLog(message);
                }
            }
        }
    }
}
