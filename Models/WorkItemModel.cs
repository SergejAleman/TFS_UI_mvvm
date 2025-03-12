
namespace TFS_UI_mvvm.Models;

public class WorkItemModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public WorkItemModel(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}