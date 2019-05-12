using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class UserModel : IActive
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsTestBoolProperty { get; set; }

        public IList<UserDocumentModel> Documents { get; set; }
    }

    public interface ITest : IModel
    {
        
    }

    public class ExtendedUserModel : UserModel, ITest
    {
        
    }
}
