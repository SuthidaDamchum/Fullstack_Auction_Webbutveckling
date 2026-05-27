import axios from "axios";
import type { Bid } from "../types/Bid";

const API = "https://localhost:7140/api/Bid";

export const getBidsByAuctionId = async (auctionId: number): Promise<Bid[]> => {
  const response = await axios.get(
    `${API}/${auctionId}/getBidsByAuctionId`,
    {},
  );
  return response.data;
};

export const getHighestBid = async (auctionId: number): Promise<Bid> => {
  const response = await axios.get(`${API}/${auctionId}/Highestbid`);
  return response.data;
};

export const addBid = async (
  auctionId: number,
  userId: number,
  amount: number,
): Promise<Bid> => {
  const token = localStorage.getItem("token");
  const response = await axios.post(
    `${API}/AddBid`,
    { auctionId, userId, amount },
    { headers: { Authorization: `Bearer ${token}` } },
  );
  return response.data;
};

export const deleteBid = async (bidId: number): Promise<Bid[]> => {
  const token = localStorage.getItem("token");
  const response = await axios.delete(`${API}/${bidId}`, {
    headers: { Authorization: `Bearer ${token}` },
  });
  return response.data;
};
