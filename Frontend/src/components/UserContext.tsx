import { createContext, Dispatch, SetStateAction } from 'react';

export type User = {
  // Define the properties of the user object here
  userName: string;
  userRole: string;
  // ...
};

type UserContextType = {
  user: User | null;
  setUser: Dispatch<SetStateAction<User | null>>;
};

// Initialize the context with undefined
export const UserContext = createContext<UserContextType | undefined>(undefined);
