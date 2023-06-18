export default interface Task {
    id: number;
    name: string;
    description: string;
    status: 'open' | 'in progress' | 'closed';
  }