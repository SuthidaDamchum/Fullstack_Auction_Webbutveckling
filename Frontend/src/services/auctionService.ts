import axios from "axios";
import type { Auction } from "../types/Auction";

const API = "https://localhost:7140/api/Auction";

export const getAllAuctions = async (search?: string): Promise<Auction[]> => {
  const response = await axios.get(`${API}/GetAllAuctions`, {
    params: { search },
  });
  return response.data;
};
