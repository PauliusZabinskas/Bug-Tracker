import { useState } from 'react';
import TaskManager from './components/TaskManager';
import ITask from './components/interface/ITask'


const App = () => {
  const [userTasks, setUserTasks] = useState<ITask[]>([]);

  const handleAddTask = (name: string, description: string) => {
    const newTask: ITask = {
      id: Math.floor(Math.random() * 100000), // Generate random ID
      name,
      description,
      status: 'open',
    };
    setUserTasks([...userTasks, newTask]);
  };

  return (
    <div className="App">
      <TaskManager ITasks={userTasks} addITask={handleAddTask} />
    </div>
  );
};

export default App;
