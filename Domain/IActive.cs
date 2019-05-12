namespace Domain
{
    public interface IActive : IModel
    {
        bool IsActive { get; set; }
    }
}