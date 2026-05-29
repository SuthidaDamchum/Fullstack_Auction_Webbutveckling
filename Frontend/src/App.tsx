import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import AuctionListPage from "./pages/AuctionListPage/AuctionListPage";
import LoginPage from "./pages/LoginPage/LoginPage";
import Navbar from "./components/Navbar/Navbar";
import RegisterPage from "./pages/RegisterPage/RegisterPage";
import AuctionDetailPage from "./pages/AuctionDetailPage/AuctionDetailPage";
import ClosedAuctionsPage from "./pages/ClosedAuctionsPage/ClosedAuctionsPage";
import CreateAuctionPage from "./pages/CreateAuctionPage/CreateAuctionPage";
import ProfilePage from "./pages/ProfilePage/ProfilePage";

const App = () => {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path="/" element={<Navigate to="/auctions" />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/auctions" element={<AuctionListPage />} />
          <Route path="/auctions/:id" element={<AuctionDetailPage />} />
          <Route path="/closed" element={<ClosedAuctionsPage />} />
          <Route path="/create" element={<CreateAuctionPage />} />
          <Route path="/profile" element={<ProfilePage />} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
};

export default App;
