﻿using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ZUMOAPPNAME
{
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public class TodoItemManager
	{
		// Azure
		IMobileServiceTable<TodoItem> todoTable;
		MobileServiceClient client;

		public TodoItemManager()
		{
			client = new MobileServiceClient(
				Constants.ApplicationURL,
				Constants.ApplicationKey);

			this.todoTable = client.GetTable<TodoItem>();

		}
//		public ToDoItem GetTaskFromList(string id)
//		{
//			return todoTable.FirstOrDefault(o => o.ID == id);   
//		}
		public async Task<TodoItem> GetTaskAsync(string id)
		{
			try
			{
				return await todoTable.LookupAsync(id);
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}
		public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync()
		{
			try
			{
				return new ObservableCollection<TodoItem>(await todoTable.ReadAsync());
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
			return null;
		}
		public async Task SaveTaskAsync(TodoItem item)
		{
			if (item.ID == null)
			{
				await todoTable.InsertAsync(item);
				//TodoViewModel.TodoItems.Add(item);
			}
			else
				await todoTable.UpdateAsync(item);
		}
		public async Task DeleteTaskAsync(TodoItem item)
		{
			try
			{
				//TodoViewModel.TodoItems.Remove(item);
				await todoTable.DeleteAsync(item);
			}
			catch (MobileServiceInvalidOperationException msioe)
			{
				Debug.WriteLine(@"INVALID {0}", msioe.Message);
			}
			catch (Exception e)
			{
				Debug.WriteLine(@"ERROR {0}", e.Message);
			}
		}
	}
}

