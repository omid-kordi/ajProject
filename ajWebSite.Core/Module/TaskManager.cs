using System;
using System.Collections.Generic;
using System.Linq;

namespace ajWebSite.Core.Module
{
    public class TaskManager
    {
        public int currentUserId { get; private set; }

        private static object _syncRoot = new object();
        private static List<UserTask> UserTasks { get; set; }

        public TaskManager(int userId)
        {
            currentUserId = userId;
            if (UserTasks == null)
            {
                UserTasks = new List<UserTask>();
            }
        }

        public List<UserTask> GetUserTasks(int userId)
        {
            lock (_syncRoot)
            {
                var userTask = UserTasks.Where(x => x.UserID == userId && x.LastChange.AddMinutes(2) > DateTime.Now).ToList();
                return userTask;
            }

        }

        public Guid UpdateProgress(int progress, Guid taskId, int userId, string title)
        {

            lock (_syncRoot)
            {

                var userTask = UserTasks.FirstOrDefault(x => x.TaskId == taskId);
                if (userTask == null)
                {
                    UserTasks.Add(new UserTask
                    {
                        StartTime = DateTime.Now,
                        LastChange = DateTime.Now,
                        TaskId = taskId,
                        UserID = userId,
                        Title = title,
                        Progress = 0,
                    });
                }
                else
                {
                    userTask.Progress = progress;
                    userTask.LastChange = DateTime.Now;
                }
                return taskId;
            }

        }

        public void RemoveTask(Guid taskId)
        {
            lock (_syncRoot)
            {
                var userTask = UserTasks.FirstOrDefault(x => x.TaskId == taskId);
                if (userTask != null)
                    UserTasks.Remove(userTask);

            }
        }

        delegate Guid ProcessTask(int count, Guid taskId, int userId, string title);
        public void LongRunningProcess(int current, int total, Guid taskId, string title)
        {
            if (current >= total - 1)
            {
                RemoveTask(taskId);
                return;
            }

            ProcessTask processTask = new ProcessTask(UpdateProgress);
            var progress = (int)Math.Ceiling(((double) current / total) * 100);
            processTask.BeginInvoke(progress, taskId, currentUserId, title, new AsyncCallback(CheckFinishProcess), processTask);
        }
        public void CheckFinishProcess(IAsyncResult result)
        {
            ProcessTask processTask = (ProcessTask)result.AsyncState;
            var taskId = processTask.EndInvoke(result);
        }

    }
    public class UserTask
    {
        public DateTime StartTime { get; set; }
        public DateTime LastChange { get; set; }
        public int UserID { get; set; }
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public int Progress { get; set; }
    }
}
