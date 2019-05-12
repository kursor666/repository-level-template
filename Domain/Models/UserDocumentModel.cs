using System;

namespace Domain.Models
{
    public class UserDocumentModel : IModel
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public Guid DocumentId { get; set; }

        public UserModel User { get; set; }
        public DocumentModel Document { get; set; }
    }
}
