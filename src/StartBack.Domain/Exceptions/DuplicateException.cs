using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartBack.Domain.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string resourceType, string resourceIdentifier, string additionalInfo)
    : base($"{resourceType} with identifier '{resourceIdentifier}' already exists. {additionalInfo}")
        {
            ResourceType = resourceType;
            ResourceIdentifier = resourceIdentifier;
            AdditionalInfo = additionalInfo;
        }

        public string ResourceType { get; }
        public string ResourceIdentifier { get; }
        public string AdditionalInfo { get; }
    }
}
