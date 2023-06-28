import { useState, useEffect } from 'react';
import './style.css'
import TaskList from './TaskList';
import ITask from './interface/ITask';

const TaskManager = () => {
  const [ITaskName, setITaskName] = useState<string>('');
  const [ITaskDescription, setITaskDescription] = useState<string>('');
  const [tasks, setTasks] = useState<ITask[]>([]);
  const [editingTask, setEditingTask] = useState<ITask | null>(null);
  const [isModalOpen, setIsModalOpen] = useState(false);


  const fetchTasks = async () => {
    try {
      const response = await fetch('http://localhost:5047/tasks');
      if (response.ok) {
        const tasks = await response.json();
        setTasks(tasks);
      } else {
        console.error('Failed to fetch tasks');
      }
    } catch (error) {
      console.error('Failed to fetch tasks:', error);
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (ITaskName.trim() !== '' && ITaskDescription.trim() !== '') {
      const newITask = {
        taskName: ITaskName,
        discription: ITaskDescription,
      };
      try {
        const response = await fetch('http://localhost:5047/tasks', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(newITask),
        });

        if (response.ok) {
          setITaskName('');
          setITaskDescription('');
          fetchTasks(); // Fetch tasks again after a task is added
        } else {
          console.error('Failed to add task');
        }
      } catch (error) {
        console.error('Failed to add task:', error);
      }
    }
  };

  const handleUpdate = (task: ITask) => {
    setEditingTask(task);
    setITaskName(task.taskName);
    setITaskDescription(task.discription);
    setIsModalOpen(true);
  };

  const handleModalClose = () => {
    setIsModalOpen(false);
  };

  const handleUpdateSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (editingTask && ITaskName.trim() !== '' && ITaskDescription.trim() !== '') {
      const updatedTask = {
        ...editingTask,
        taskName: ITaskName,
        discription: ITaskDescription,
        currentState: editingTask.currentState,
      };
      
      try {
        const response = await fetch(`http://localhost:5047/tasks/${editingTask.id}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(updatedTask),
        });

        if (response.ok) {
          setEditingTask(null);
          setITaskName('');
          setITaskDescription('');
          fetchTasks(); // Fetch tasks again after a task is updated
        } else {
          console.error('Failed to update task');
        }
      } catch (error) {
        console.error('Failed to update task:', error);
      }
    }
    setIsModalOpen(false);
  };

  const handleDelete = async (id: string) => {
    try {
      const response = await fetch(`http://localhost:5047/tasks/${id}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        fetchTasks(); // Fetch tasks again after a task is deleted
      } else {
        console.error('Failed to delete task');
      }
    } catch (error) {
      console.error('Failed to delete task:', error);
    }
  };

  const handleStateChange = async (id: string, newState: ITask['currentState']) => {
    const taskToUpdate = tasks.find(task => task.id === id);
    if (!taskToUpdate) {
      console.error(`Failed to find task with ID ${id}`);
      return;
    }
    const updatedTask = { ...taskToUpdate, currentState: Number(newState) };
    
    try {
      const response = await fetch(`http://localhost:5047/tasks/${id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedTask),
      });

      if (response.ok) {
        fetchTasks(); // Fetch tasks again after a task is updated
      } else {
        throw new Error(`HTTP error! status: ${response.status}`); // Added error handling
      }
    } catch (error) {
      console.error('Failed to update task state:', error);
    }
  };

  return (
    <>
      <form onSubmit={handleSubmit} className='p-2'>
        <input
          type="text"
          value={ITaskName}
          onChange={(e) => setITaskName(e.target.value)}
          placeholder="Task Name"
          required
          className='border-2 border-rose-500 p-1 p-2 rounded-full mx-2'
        />
        <input
          type="text"
          value={ITaskDescription}
          onChange={(e) => setITaskDescription(e.target.value)}
          placeholder="Task Description"
          required
          className='border-2 border-rose-500 p-1 p-2 rounded-full mx-2'
        />
        <button type="submit"
          className='p-1 rounded md:rounded-lg border-indigo-500/100 hover:text-lg font-bold shadow-xl border border-yellow-500'>Add Task</button>
      </form>

      

      {isModalOpen && editingTask && (
        <div className="modal">
          <div className="modal-content bg-blue-500 rounded-full">
            <span className="close-button" onClick={handleModalClose}>&times;</span>
            <form onSubmit={handleUpdateSubmit}>
              <input
                type="text"
                value={ITaskName}
                onChange={(e) => setITaskName(e.target.value)}
                required
                className='p-2 rounded-full mx-2'
              />
              <input
                type="text"
                value={ITaskDescription}
                onChange={(e) => setITaskDescription(e.target.value)}
                required
                className='p-2 rounded-full mx-2'
              />
              <button type="submit" className='p-2 bg-gray-400 hover:text-lg font-bold rounded-full mx-2 border border-yellow-500'>Submit Edited Task</button>
            </form>
          </div>
        </div>
      )}
      
      <div className="">
        <h1 className="title">Task State: Open</h1>
        <TaskList tasks={tasks.filter(task => task.currentState === 0)} handleUpdate={handleUpdate} handleDelete={handleDelete} handleStateChange={handleStateChange} />
      </div>

      <div className="">
        <h1 className="title">Task State: In-Progress</h1>
        <TaskList tasks={tasks.filter(task => task.currentState === 1)} handleUpdate={handleUpdate} handleDelete={handleDelete} handleStateChange={handleStateChange} />
      </div>

      <div className="">
        <h1 className="title">Task State: Closed</h1>
        <TaskList tasks={tasks.filter(task => task.currentState === 2)} handleUpdate={handleUpdate} handleDelete={handleDelete} handleStateChange={handleStateChange} />
      </div>

    </>
  );
};


export default TaskManager;
