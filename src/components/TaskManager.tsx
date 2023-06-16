import { useState } from 'react';
import ITask from './interface/ITask'


interface TaskManagerProps {
  ITasks: ITask[];
  addITask: (name: string, description: string) => void;
}


const ITaskItem: React.FC<{ ITask: ITask; moveCallback: (ITask: ITask) => void }> = ({ ITask, moveCallback }) => {
  return (
    <div style={{ display: 'flex', flexDirection: 'column', border: '1px solid white' }}>
      <h4><b style={{color:"orange"}}>{"Task Name: "}</b>{ITask.name}</h4>
      <p> <b style={{color: 'orange'}}>{"Description: "}</b> { ITask.description}</p>
      <button style={{ width: '50%', alignSelf: 'center' }} onClick={() => moveCallback(ITask)}>
        Move
      </button>
    </div>
  );
};

const App2 = ({ ITasks, addITask }: TaskManagerProps) => {
  const [openITasks, setOpenITasks] = useState<ITask[]>(ITasks);
  const [inProgressITasks, setInProgressITasks] = useState<ITask[]>([]);
  const [closedITasks, setClosedITasks] = useState<ITask[]>([]);
  const [ITaskName, setITaskName] = useState('');
  const [ITaskDescription, setITaskDescription] = useState('');

  const handleITaskMoved = (ITask: ITask) => {
    if (ITask.status === 'open') {
      setOpenITasks(openITasks.filter((current) => current !== ITask));
      setInProgressITasks([...inProgressITasks, { ...ITask, status: 'in progress' }]);
    } else if (ITask.status === 'in progress') {
      setInProgressITasks(inProgressITasks.filter((current) => current !== ITask));
      setClosedITasks([...closedITasks, { ...ITask, status: 'closed' }]);
    } else {
      setClosedITasks(closedITasks.filter((current) => current !== ITask));
      setOpenITasks([...openITasks, { ...ITask, status: 'open' }]);
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (ITaskName.trim() !== '' && ITaskDescription.trim() !== '') {
      const newITask: ITask = {
        id: Math.floor(Math.random() * 100000),
        name: ITaskName,
        description: ITaskDescription,
        status: 'open',
      };
      addITask(newITask.name, newITask.description);
      setOpenITasks([...openITasks, newITask]);
      setITaskName('');
      setITaskDescription('');
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
        />
        <input
          type="text"
          value={ITaskDescription}
          onChange={(e) => setITaskDescription(e.target.value)}
          placeholder="ITask Description"
        />
        <button type="submit">Add Task</button>
      </form>

      <div style={{ display: 'flex', flexDirection: 'row', width: '100vw' }}>
        {/* open ITasks column */}
        <div style={{ display: 'flex', flex: 1, flexDirection: 'column', width: '100%' }}>
          <h2>Open Tasks</h2>
          {openITasks.map((ITask) => (
            <ITaskItem key={ITask.id} ITask={ITask} moveCallback={handleITaskMoved} />
          ))}
        </div>

        {/* in progress ITasks column */}
        <div style={{ display: 'flex', flex: 1, flexDirection: 'column', width: '100%' }}>
          <h2>In Progress</h2>
          {inProgressITasks.map((ITask) => (
            <ITaskItem key={ITask.id} ITask={ITask} moveCallback={handleITaskMoved} />
          ))}
        </div>

        {/* closed ITasks column */}
        <div style={{ display: 'flex', flex: 1, flexDirection: 'column', width: '100%' }}>
          <h2>Closed</h2>
          {closedITasks.map((ITask) => (
            <ITaskItem key={ITask.id} ITask={ITask} moveCallback={handleITaskMoved} />
          ))}
        </div>
      </div>
    </>
  );
};

export default App2;
