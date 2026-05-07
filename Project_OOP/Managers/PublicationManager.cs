using Project_OOP;
using System.Collections.Generic;

public class PublicationManager
{
    private List<Publication> _postList;

    public PublicationManager()
    {
        this._postList = new List<Publication>();
    }

    public void AddPost(Publication post)
    {
        this._postList.Add(post);
       
    }

    public bool UnapprovePost(string id)
    {
        for (int i = 0; i < this._postList.Count; i = i + 1)
        {
            if (this._postList[i].Id == id)
            {
                this._postList[i].IsApproved = false; 
                return true;
            }
        }
        return false;
    }

    public bool ApprovePost(string id)
    {
        for (int i = 0; i < this._postList.Count; i = i + 1)
        {
            if (this._postList[i].Id == id)
            {
                this._postList[i].IsApproved = true; 
                return true;
            }
        }
        return false; 
    }

    public bool RemovePost(string id)
    {
        for (int i = 0; i < this._postList.Count; i = i + 1)
        {
            if (this._postList[i].Id == id)
            {
                this._postList.RemoveAt(i);
                return true; 
            }
        }
        return false;
    }

    public void ShowAllPosts()
    {
        for (int i = 0; i < this._postList.Count; i = i + 1)
        {
            this._postList[i].DisplayContent();
        }
    }

    public List<Publication> GetPostList()
    {
        return this._postList;
    }

    public void SetPostList(List<Publication> loadedList)
    {
        this._postList = loadedList;
    }

    public bool UpdatePost(string id, string newTitle, string extraData)
    {
        for (int i = 0; i < this._postList.Count; i = i + 1)
        {
            if (this._postList[i].Id == id)
            {
                this._postList[i].Title = newTitle;

                Publication p = this._postList[i];

                if (p is BreakingNews)
                {
                    BreakingNews breaking = (BreakingNews)p;
                    int newTrend;
                    if (int.TryParse(extraData, out newTrend) == true)
                    {
                        breaking.TrendLevel = newTrend;
                    }
                }
                else if (p is DailyNews)
                {
                    DailyNews daily = (DailyNews)p;
                    int newTrend;
                    if (int.TryParse(extraData, out newTrend) == true)
                    {
                        daily.TrendLevel = newTrend;
                    }
                }
                else if (p is VideoReport)
                {
                    VideoReport video = (VideoReport)p;
                    video.Resolution = extraData;
                }
                else if (p is WeeklyMagazine)
                {
                    WeeklyMagazine magazine = (WeeklyMagazine)p;
                    magazine.Author = extraData;
                }

                return true;
            }
        }
        return false;
    }
}