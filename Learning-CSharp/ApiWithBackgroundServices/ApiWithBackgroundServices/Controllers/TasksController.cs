using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithBackgroundServices.BackgroundServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiWithBackgroundServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _Logger;

        public TasksController(IBackgroundTaskQueue queue, ILogger<TasksController> logger)
        {
            Queue = queue;
            _Logger = logger;
        }

        public IBackgroundTaskQueue Queue { get; }

        [HttpPost]
        public string AddTaskAsync()
        {
            AddTaskToBackgroundService(GetTask);

            return "Background task added";

            Task GetTask(int taskID)
            {
                return new Task(() => _Logger.LogInformation($"{taskID} Background task queued."));
            }
        }

        private void AddTaskToBackgroundService(Func<int, Task> taskFunc)
        {
            Queue.QueueBackgroundWorkItem(async token =>
            {
                var guid = Guid.NewGuid().ToString();

                for (int delayLoop = 1; delayLoop < 4; delayLoop++)
                {
                    try
                    {
                        _Logger.LogInformation($"Task {delayLoop}/3");
                        taskFunc(delayLoop).Start();
                    }
                    catch (Exception ex)
                    {
                        _Logger.LogError(ex,
                            "An error occurred writing to the " +
                            $"database. Error: {ex.Message}");
                    }

                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                }

                _Logger.LogInformation(
                    $"Queued Background Task {guid} is complete. 3/3");
            });
        }
    }
}