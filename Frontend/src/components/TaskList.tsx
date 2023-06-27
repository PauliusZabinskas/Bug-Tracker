import React from 'react';

interface ITask {
  id: string;
  taskName: string;
  discription: string;
  currentState: 0 | 1 | 2;
}

interface TaskListProps {
  tasks: ITask[];
  handleUpdate: (task: ITask) => void;
  handleDelete: (id: string) => void;
  handleStateChange: (id: string, newState: ITask['currentState']) => void;
}

const TaskList: React.FC<TaskListProps> = ({ tasks, handleUpdate, handleDelete, handleStateChange }) => (
  <ul className="flex flex-wrap" >
    {tasks.map((task, index) => (
      <li key={index} className='p-8  hover:text-lg hover:shadow-2xl'>
        <h3><p className='font-bold'>Name:</p> {task.taskName}</h3>
        <h3><p className='font-bold'>Discription:</p> {task.discription}</h3>
        <div className='flex flex-wrap mt-2'>
          <li className='p-2 hover:font-bold hover:text-lg border border-blue-500 border border-yellow-500 rounded-full mx-2'>
            <button onClick={() => handleUpdate(task)}>Edit</button>
          </li>
          <li className='p-2 hover:font-bold hover:text-lg border border-yellow-500 rounded-full'>
            <button onClick={() => handleDelete(task.id)}>Delete</button>
          </li>
          <li className='p-2 hover:font-bold hover:text-lg border border-yellow-500 rounded-full'>
            <select className='bg-transparent' value={task.currentState} onChange={(e) =>
              handleStateChange(task.id, Number(e.target.value) as ITask['currentState'])}>
              <option value="0">Open</option>
              <option value="1">In Process</option>
              <option value="2">Closed</option>
            </select>
          </li>
        </div>
      </li>
    ))}
  </ul>
);

export default TaskList;
