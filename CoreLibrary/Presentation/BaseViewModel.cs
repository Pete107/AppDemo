namespace CoreLibrary;

public abstract class BaseViewModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreateDate { get; set; } = DateTime.Today;
    public bool Edited => EditDate > DateTime.MinValue;
    public DateTime EditDate { get; set; } = DateTime.MinValue;
    public bool Deleted => DeleteDate > DateTime.MinValue;
    public DateTime DeleteDate { get; set; } = DateTime.MinValue;

    protected BaseViewModel()
    {
        
    }

    protected BaseViewModel(BaseModel model)
    {
        Id = model.Id;
        CreateDate = model.CreateDate;
        EditDate = model.EditDate ?? DateTime.MinValue;
        DeleteDate = model.DeleteDate ?? DateTime.MinValue;
    }
}