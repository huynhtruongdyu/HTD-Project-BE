using Mapster;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Enums.TodoApp;
using Portal.Domain.Models.TodoApp;
using Portal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskTable = Portal.Domain.Aggregates.TodoApp.Task;

namespace Portal.API.Controllers
{
    public class TasksController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _unitOfWork.TaskRepository.GetAll();
            var dataResp = data.Adapt<List<TaskModel>>();
            return SuccessResult(dataResp);
        }

        [HttpPost]
        public IActionResult Create(TaskCreateReqModel model)
        {
            List<string> errorMessages = new();
            if (string.IsNullOrEmpty(model.Name))
                errorMessages.Add("task.name.is.required");

            if (model.Priority == null)
                errorMessages.Add("task.priority.is.required");
            if (model.Priority.HasValue && !Enum.IsDefined(typeof(Priority), model.Priority))
                errorMessages.Add("task.priority.is.not.valid");

            if (model.Status == null)
                errorMessages.Add("task.status.is.required");
            if (model.Status.HasValue && !Enum.IsDefined(typeof(Status), model.Status))
                errorMessages.Add("task.status.is.not.valid");

            if (errorMessages.Any())
                return ErrorResult(errorMessages);
            try
            {
                TaskTable newTask = model.Adapt<TaskTable>();
                _unitOfWork.TaskRepository.Create(newTask);
                _unitOfWork.SaveChanges();
                return SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TaskUpdateReqModel model)
        {
            List<string> errorMessages = new();
            var existTask = _unitOfWork.TaskRepository.GetById(id);
            if (existTask == null) return ErrorResult("task.not.found");
            if (string.IsNullOrEmpty(model.Name))
                errorMessages.Add("task.name.is.required");

            if (model.Priority == null)
                errorMessages.Add("task.priority.is.required");
            if (model.Priority.HasValue && !Enum.IsDefined(typeof(Priority), model.Priority))
                errorMessages.Add("task.priority.is.not.valid");

            if (model.Status == null)
                errorMessages.Add("task.status.is.required");
            if (model.Status.HasValue && !Enum.IsDefined(typeof(Status), model.Status))
                errorMessages.Add("task.status.is.not.valid");

            if (errorMessages.Any())
                return ErrorResult(errorMessages);
            try
            {
                existTask.Name = model.Name;
                existTask.Description = model.Description;
                existTask.Priority = model.Priority.Value;
                existTask.Status = model.Status.Value;
                existTask.UpdatedDate = DateTime.Now;
                _unitOfWork.TaskRepository.Update(existTask);
                _unitOfWork.SaveChanges();
                return SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ErrorResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var existTask = _unitOfWork.TaskRepository.GetById(id);
            if (existTask == null)
                return ErrorResult("task.id.not.found");
            try
            {
                _unitOfWork.TaskRepository.Delete(existTask);
                _unitOfWork.SaveChanges();
                return SuccessResult(existTask);
            }catch(Exception ex)
            {
                return ErrorResult(ex);
            }
        }
    }
}