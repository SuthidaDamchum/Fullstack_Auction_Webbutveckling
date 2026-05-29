import axios from "axios";
import type { User } from "../types/User";

const API_URL = "https://localhost:7140/api/Authentication";

//Login
export const login = async (email: string, password: string): Promise<User> => {
  const response = await axios.post(`${API_URL}/Login`, { email, password });
  return response.data;
};

//Register
export const register = async (
  name: string,
  email: string,
  password: string,
): Promise<User> => {
  const response = await axios.post(`${API_URL}/Register`, {
    name,
    email,
    password,
  });
  return response.data;
};

export const updatePassword = async (
  id: number,
  oldPassword: string,
  newPassword: string,
): Promise<void> => {
  const token = localStorage.getItem("token");
  await axios.put(
    `${API_URL}/${id}/UpdatePassword`,
    { currentPassword: oldPassword, newPassword },
    { headers: { Authorization: `Bearer ${token}` } },
  );
};
