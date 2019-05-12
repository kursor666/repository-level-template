using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class DocumentModel : IActive
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        public IList<UserDocumentModel> Users { get; set; }
    }
}
