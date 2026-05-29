export interface User {
  id: number;
  name: string;
  email: string;
  role: string;
  token: string;
}

export interface UserDTO {
  id: number;
  name: string;
  email: string;
  role: string;
  isActive: boolean;
}
