export default interface Task {
  id: string;
  taskName: string;
  discription: string;
  currentState: 0 | 1 | 2;
  }