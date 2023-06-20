
import { useState, useEffect } from 'react';

interface ITask {
  taskName: string;
  discription: string;
}

const TaskManager: React.FC = () => {
  const [ITaskName, setITaskName] = useState('');
  const [ITaskDescription, setITaskDescription] = useState('');
  const [tasks, setTasks] = useState<ITask[]>([]);

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

  return (
    <>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={ITaskName}
          onChange={(e) => setITaskName(e.target.value)}
          placeholder="Task Name"
          required
        />
        <input
          type="text"
          value={ITaskDescription}
          onChange={(e) => setITaskDescription(e.target.value)}
          placeholder="Task Description"
          required
        />
        <button type="submit">Add Task</button>
      </form>
      <div className="">
        <ul  className="" >
            {tasks.map((task, index) => (
              <li key={index} className=''>
                <p ><p className=''>Task Name:</p>{task.taskName}</p>
                <p>{task.discription}</p>
              </li>
            ))}
        </ul>
      </div>
        
      
      
    </>
  );
};

export default TaskManager;
