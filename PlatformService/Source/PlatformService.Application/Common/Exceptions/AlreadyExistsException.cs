using System;

namespace PlatformService.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string entityType, string field, object value)
            : base($"Entity \"{entityType}\" with {field} equals to \"{value}\" already exists.")
        {

        }

        public AlreadyExistsException(string entityType, string[] fields, object[] values)
            : base($"Entity \"{entityType}\" with ({string.Join(", ", fields)}) equals to \"{string.Join(", ", values)}\" already exists.")
        {

        }
    }
}
