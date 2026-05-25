export interface Auction {
  id: number;
  userId: number;
  createdBy: string;
  title: string;
  description: string;
  price: number;
  startdate: string;
  enddate: string;
  imageUrl: string;
  isOpen: boolean;
  isActive: boolean;
}
