namespace CoreLibrary.Data;
public abstract class BaseModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreateDate { get; set; } = DateTime.Today;
    public DateTime? EditDate { get; set; }
    public DateTime? DeleteDate { get; set; }

    protected BaseModel()
    {
    }

    protected BaseModel(BaseViewModel viewModel)
    {
        Id = viewModel.Id;
        CreateDate = viewModel.CreateDate;
    }

    public virtual void Update(BaseModel model)
    {
        EditDate = DateTime.Today;
    }

    public void Delete()
    {
        EditDate = DateTime.Today;
        DeleteDate = DateTime.Today;
    }

    public void Recover()
    {
        EditDate = DateTime.Today;
        DeleteDate = null;
    }
}