import type { UserDTO } from "../types/User";
import axios from "axios";

const API = "https://localhost:7140/api/User";

export const getAllUsers = async (): Promise<UserDTO[]> => {
  const token = localStorage.getItem("token");
  const response = await axios.get(`${API}/GetAllUsers`, {
    headers: { Authorization: `Bearer ${token}` },
  });
  return response.data;
};

export const deactivateUser = async (id: number): Promise<void> => {
  const token = localStorage.getItem("token");
  await axios.put(
    `${API}/${id}/DeactivateUser`,
    {},
    {
      headers: { Authorization: `Bearer ${token}` },
    },
  );
};
