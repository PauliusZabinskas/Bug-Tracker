export default interface Task {
    taskName: string;
    discription: string;
    status: 'open' | 'in progress' | 'closed';
  }