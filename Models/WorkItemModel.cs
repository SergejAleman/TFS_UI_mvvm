
namespace TFS_UI_mvvm.Models;

public class WorkItemModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string State { get; set; }

    public WorkItemModel(int id, string title, string state)
    {
        Id = id;
        Title = title;
        State = state;
    }
}
