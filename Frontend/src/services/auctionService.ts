import axios from "axios";
import type { Auction } from "../types/Auction";
import type { CreateAuction } from "../types/Auction";

const API = "https://localhost:7140/api/Auction";

export const getAllAuctions = async (search?: string): Promise<Auction[]> => {
  const response = await axios.get(`${API}/GetAllAuctions`, {
    params: { search },
  });
  return response.data;
};

export const getAuctionById = async (auctionId: number): Promise<Auction> => {
  const response = await axios.get(`${API}/${auctionId}/GetAuctionById`);
  return response.data;
};

export const getClosedAuctions = async (
  search?: string,
): Promise<Auction[]> => {
  const response = await axios.get(`${API}/SearchClosedAuctions`, {
    params: { search },
  });
  return response.data;
};
export const createAuction = async (
  auction: CreateAuction,
): Promise<Auction> => {
  const token = localStorage.getItem("token");
  const response = await axios.post(`${API}/AddAuction`, auction, {
    headers: { Authorization: `Bearer ${token}` },
  });
  return response.data;
};
