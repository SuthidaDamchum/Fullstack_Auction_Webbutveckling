export interface Auction {
  id: number;
  userId: number;
  createdBy: string;
  title: string;
  description: string;
  price: number;
  startDate: string;
  endDate: string;
  imageUrl: string;
  isOpen: boolean;
  isActive: boolean;
}
