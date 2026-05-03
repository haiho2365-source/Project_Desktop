using Project_OOP;
using System.Collections.Generic;

public class PublicationManager
{
    private List<Publication> _postList;

    public PublicationManager()
    {
        _postList = new List<Publication>();
    }

    public void AddPost(Publication post)
    {
        _postList.Add(post);
        Logger.Log("Đã thêm: " + post.Title);
    }

    public void RemovePost(string id)
    {
        Publication postToRemove = null;

        foreach (Publication p in _postList)
        {
            if (p.Id == id) 
            {
                postToRemove = p;
                break;
            }
        }

        if (postToRemove != null)
        {
            _postList.Remove(postToRemove);
        }
    }

    public void ShowAllPosts()
    {
        foreach (Publication p in _postList)
        {
            p.DisplayContent();
        }
    }

    public List<Publication> GetPostList()
    {
        return _postList;
    }

    public void SetPostList(List<Publication> loadedList)
    {
        _postList = loadedList;
    }
}